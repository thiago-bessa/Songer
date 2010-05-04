using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Songer.SoundAnalysis;
using Songer.SoundInput;

namespace Songer.MusicalInterpreter
{
    public class MusicalAnalyzer
    {
        private SoundSource soundSource;
        private bool isStillProcessing;
        private List<Chord> chordSequence;

        public static MusicalNoteDictionary MusicalNoteDictionary { get; private set; }
        public static ChordDictionary ChordDictionary { get; private set; }

        public MusicalAnalyzer()
        {
            MusicalAnalyzer.MusicalNoteDictionary = new MusicalNoteDictionary();
            MusicalAnalyzer.ChordDictionary = new ChordDictionary();

            this.chordSequence = new List<Chord>();
        }

        public void AnalyzeAudio()
        {
            this.AnalyzeAudio(new LineInCapture());
        }

        public void AnalyzeAudio(string filename)
        {
            this.AnalyzeAudio(new WaveFileCapture(filename));
        }

        private void AnalyzeAudio(SoundSource soundSource)
        {
            if (this.isStillProcessing)
            {
                throw new InvalidOperationException("AnalyzeAudio is still processing");
            }
            
            this.isStillProcessing = true;
            this.chordSequence.Clear();

            this.soundSource = soundSource;
            this.soundSource.SoundDetected += new EventHandler<SoundDetectedEventArgs>(OnSoundDetected);
            this.soundSource.CaptureFinished += new EventHandler(OnCaptureFinished);

            this.soundSource.Start();
        }

        public void AbortAnalysis()
        {
            this.soundSource.Stop();
            this.OnProcessingFinished();
        }

        private string ProcessCapturedChordsSequence()
        {
            List<Chord> finalChordSequence = new List<Chord>();
            StringBuilder s = new StringBuilder();

            //Eliminate repeating continuous chords
            foreach (Chord chord in this.chordSequence)
            {
                if (!finalChordSequence.Contains(chord))
                {
                    finalChordSequence.Add(chord);
                }
            }

            foreach (Chord chord in finalChordSequence)
            {
                s.AppendFormat("{0} ", chord.Name);
            }

            //Removes final space before returning
            return s.Remove(s.Length - 1, 1).ToString(); 
        }

        private void OnSoundDetected(object sender, SoundDetectedEventArgs e)
        {
            Dictionary<MusicalNote, double> notesBeingPlayed = this.GetNotesBeingPlayed(e.SoundData);
            if (notesBeingPlayed.Count > 0)
            {
                this.OnNotesDetected(notesBeingPlayed);
            }
            
            Chord chordBeingPlayed = this.GetChordsBeingPlayed(notesBeingPlayed);
            if (chordBeingPlayed != null)
            {
                this.OnChordDetected(chordBeingPlayed);
                this.chordSequence.Add(chordBeingPlayed);
            }
        }

        private void OnCaptureFinished(object sender, EventArgs e)
        {
            this.OnProcessingFinished();
        }

        public Dictionary<MusicalNote, double> GetNotesBeingPlayed(short[] soundData)
        {
            Dictionary<MusicalNote, double> notesBeingPlayed = new Dictionary<MusicalNote, double>();

            double minFreq = 70; //Value based on possible guitar notes
            double maxFreq = 1300; //Value based on possible guitar notes
            double[] spectrogram = CooleyTukeyFFT.CalculateSpectrogram(soundData);

            int index = 0;
            double max = spectrogram[0];
            int usefullMaxSpectr = Math.Min(spectrogram.Length, (int)(maxFreq * spectrogram.Length / 44100) + 1);

            for (int i = 1; i < usefullMaxSpectr; i++)
            {
                if (max < spectrogram[i])
                {
                    max = spectrogram[i];
                    index = i;
                }
            }

            if (((double)44100 * index / spectrogram.Length) > minFreq)
            {
                for (int i = 1; i < usefullMaxSpectr; i++)
                {
                    double freq = (double)44100 * i / spectrogram.Length;
                    double amplitude = spectrogram[i];

                    if (freq < minFreq || amplitude < 80000000000000)
                        continue;

                    amplitude /= 1000000000000;

                    MusicalNote musicalNote = MusicalAnalyzer.MusicalNoteDictionary.FindClosestNote(freq);

                    if (notesBeingPlayed.ContainsKey(musicalNote))
                    {
                        if (notesBeingPlayed[musicalNote] < amplitude)
                            notesBeingPlayed[musicalNote] = amplitude;
                    }
                    else
                    {
                        notesBeingPlayed.Add(musicalNote, amplitude);
                    }
                }
            }

            return notesBeingPlayed;
        }

        public Chord GetChordsBeingPlayed(Dictionary<MusicalNote, double> notesBeingPlayed)
        {
            List<Chord> possibleChords = new List<Chord>();

            if (notesBeingPlayed.Count > 0)
            {
                List<MusicalNote> filteredNotes = notesBeingPlayed
                    .OrderBy(n => n.Value)
                    .Take(12)
                    .Select(pair => pair.Key).ToList();

                foreach (Chord chord in MusicalAnalyzer.ChordDictionary)
                {
                    if (chord.Matches(filteredNotes) && !possibleChords.Contains(chord))
                    {
                        possibleChords.Add(chord);
                    }
                }
            }

            switch (possibleChords.Count)
            {
                case 0: //No chord found
                    return null;
             
                case 1: //Only one chord found
                    return possibleChords[0];

                default: //More than one chord found, try to get one with higher probability

                    return Chord.FromString("error me");
                    
            }
        }
        
        public event EventHandler<NotesDetectedEventArgs> NotesDetected;
        public event EventHandler<ChordDetectedEventArgs> ChordDetected;
        public event EventHandler<AudioProcessingFinishedEventArgs> ProcessingFinished;

        private void OnNotesDetected(Dictionary<MusicalNote, double> musicalNotes)
        {
            if (this.NotesDetected != null)
            {
                this.NotesDetected(this, new NotesDetectedEventArgs(musicalNotes));
            }
        }

        private void OnChordDetected(Chord chord)
        {
            if (this.ChordDetected != null)
            {
                this.ChordDetected(this, new ChordDetectedEventArgs(chord));
            }
        }

        private void OnProcessingFinished()
        {
            this.isStillProcessing = false;

            if (this.ProcessingFinished != null)
            {
                this.ProcessingFinished(this, new AudioProcessingFinishedEventArgs(this.ProcessCapturedChordsSequence()));
            }
        }
    }
}
