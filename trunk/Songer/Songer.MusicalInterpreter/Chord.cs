using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Songer.MusicalInterpreter
{
    public class Chord
    {
        public string Name { get; private set; }
        public List<MusicalNote> MusicalNotes { get; private set; }

        private Chord()
        {
            this.MusicalNotes = new List<MusicalNote>();
        }

        internal static Chord FromString(string chordInformation, MusicalNoteDictionary notes)
        {
            Chord chord = new Chord();

            if (chordInformation.Length == 27)
                chordInformation += " ";

            chord.Name = chordInformation.Substring(0, 15).Trim();

            for (int i = 0; i < 6; i++)
            {
                string note = chordInformation.Substring(16 + (i * 2), 2).Trim();

                //if the is marked "x", then there is no note played in that string
                if (note.Equals("x"))
                    continue;

                //Convert the finger position on guitar string to musical note
                chord.MusicalNotes.Add(notes.ElementAt(notes.StringNotes[i] + Convert.ToInt32(note)).Value);
            }

            return chord;
        }

        public override string ToString()
        {
            string result = string.Empty;

            foreach (MusicalNote note in this.MusicalNotes)
            {
                result += note.Name + " ";
            }

            return result;
        }

        internal bool Matches(List<MusicalNote> notesBeingPlayed)
        {
            foreach(MusicalNote note in this.MusicalNotes)
            {
                if (!notesBeingPlayed.Contains(note))
                    return false;
            }

            return true;
        }
    }
}
