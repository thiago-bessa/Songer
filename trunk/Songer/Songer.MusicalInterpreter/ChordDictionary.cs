using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace Songer.MusicalInterpreter
{
    public class ChordDictionary : List<Chord>
    {
        public ChordDictionary(MusicalNoteDictionary notes)
        {
            Stream file = Assembly
                .GetExecutingAssembly()
                .GetManifestResourceStream("Songer.MusicalInterpreter.Docs.Chords.txt");

            StreamReader reader = new StreamReader(file);

            while (!reader.EndOfStream)
            {
                Chord chord = Chord.FromString(reader.ReadLine(), notes);
                this.Add(chord);
            }

            reader.Close();
        }
    }
}
