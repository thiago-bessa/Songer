using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace Songer.MusicalInterpreter
{
    public class MusicalNoteDictionary : Dictionary<double, MusicalNote>
    {
        public int[] StringNotes { get; private set; }

        internal MusicalNoteDictionary()
        {
            this.StringNotes = new int[6];

            Stream file = Assembly
                .GetExecutingAssembly()
                .GetManifestResourceStream("Songer.MusicalInterpreter.Docs.Notes.txt");

            StreamReader reader = new StreamReader(file);

            while (!reader.EndOfStream)
            {
                MusicalNote musicalNote = MusicalNote.FromString(reader.ReadLine());
                this.Add(musicalNote.Frequency, musicalNote);

                switch (musicalNote.Name)
                {
                    case "E2": //6th String
                        this.StringNotes[0] = this.Count - 1;
                        break;
                    case "A2": //5th String
                        this.StringNotes[1] = this.Count - 1;
                        break;
                    case "D3": //4th String
                        this.StringNotes[2] = this.Count - 1;
                        break;
                    case "G3": //3rd String
                        this.StringNotes[3] = this.Count - 1;
                        break;
                    case "B3": //2nd String
                        this.StringNotes[4] = this.Count - 1;
                        break;
                    case "E4": //1st String
                        this.StringNotes[5] = this.Count - 1;
                        break;
                }
            }

            reader.Close();
        }

        public MusicalNote FindClosestNote(double frequency)
        {
            double[] frequencies = this.Keys.ToArray<double>();
            int possibleIndex = Array.BinarySearch<double>(frequencies, frequency);
            int finalIndex;

            //Make it positive
            if (possibleIndex < 0)
            {
                possibleIndex = Math.Abs(possibleIndex) - 1;
            }

            if ((frequencies[possibleIndex] - frequency) < (frequency - frequencies[possibleIndex - 1]))
            {
                finalIndex = possibleIndex;
            }
            else
            {
                finalIndex = possibleIndex - 1;
            }

            return this[frequencies[finalIndex]];
        }
    }
}
