using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Songer.SoundAnalysis;

namespace Songer.MusicalInterpreter
{
    public class MusicalAnalyzer
    {
        public MusicalNoteDictionary MusicalNoteDictionary { get; private set; }
        public ChordDictionary ChordDictionary { get; private set; }

        public MusicalAnalyzer()
        {
            this.MusicalNoteDictionary = new MusicalNoteDictionary(@"Docs\Notes.txt");
            this.ChordDictionary = new ChordDictionary(@"Docs\Chords.txt", this.MusicalNoteDictionary);
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

                    if (freq < minFreq)
                        continue;

                    amplitude /= 1000000000000;

                    MusicalNote musicalNote = this.MusicalNoteDictionary.FindClosestNote(freq);

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

        public Chord GetChordBeingPlayed(Dictionary<MusicalNote, double> notesBeingPlayed, ChordDictionary chords)
        {
            foreach (Chord chord in this.ChordDictionary)
            {
                chord.Matches(notesBeingPlayed);
            }

            return null;
        }
    }
}
