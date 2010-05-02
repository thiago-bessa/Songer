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

        public static MusicalNoteDictionary MusicalNoteDictionary { get; private set; }
        public static ChordDictionary ChordDictionary { get; private set; }

        public MusicalAnalyzer()
        {
            MusicalAnalyzer.MusicalNoteDictionary = new MusicalNoteDictionary();
            MusicalAnalyzer.ChordDictionary = new ChordDictionary(MusicalAnalyzer.MusicalNoteDictionary);
        }

        public void AnalyzeAudio()
        {
            this.AnalyzeAudio(new LineInCapture());
        }

        public void AnalyzeAudio(string filename)
        {
            this.AnalyzeAudio(new WaveFileCapture(filename));
        }

        internal void AnalyzeAudio(SoundSource soundSource)
        {
            if (this.isStillProcessing)
                throw new InvalidOperationException("AnalyzeAudio is still processing");

            this.isStillProcessing = true;

            this.soundSource = soundSource;
            this.soundSource.SoundDetected += new EventHandler<SoundDetectedEventArgs>(OnSoundDetected);

            this.soundSource.Start();
        }

        public void AbortAnalysis()
        {
            this.soundSource.Stop();
        }

        private void OnSoundDetected(object sender, SoundDetectedEventArgs e)
        {
            Dictionary<MusicalNote, double> notesBeingPlayed = this.GetNotesBeingPlayed(e.SoundData);
            if (notesBeingPlayed.Count > 0)
            {
                this.OnNotesDetected(notesBeingPlayed);
            }
            
            List<Chord> chordsBeingPlayed = this.GetChordsBeingPlayed(notesBeingPlayed);
            if (chordsBeingPlayed != null)
            {
                this.OnChordDetected(chordsBeingPlayed);
            }
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

        public List<Chord> GetChordsBeingPlayed(Dictionary<MusicalNote, double> notesBeingPlayed)
        {
            if (notesBeingPlayed.Count > 0)
            {
                List<Chord> possibleChords = new List<Chord>();
                List<MusicalNote> filteredNotes = notesBeingPlayed
                    //.OrderBy(n => n.Value)
                    //.Take(12)
                    .Select(pair => pair.Key).ToList();

                foreach (Chord chord in MusicalAnalyzer.ChordDictionary)
                {
                    if (chord.Matches(filteredNotes))
                    {
                        possibleChords.Add(chord);
                    }
                }

                //possibleChords = possibleChords.OrderBy(c => c.ToString()).ToList();

                return possibleChords;
            }

            return null;
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

        private void OnChordDetected(List<Chord> chord)
        {
            if (this.ChordDetected != null)
            {
                this.ChordDetected(this, new ChordDetectedEventArgs(chord));
            }
        }

        private void OnProcessingFinished(string chords)
        {
            if (this.ProcessingFinished != null)
            {
                this.ProcessingFinished(this, new AudioProcessingFinishedEventArgs(chords));
            }
        }
    }
}
