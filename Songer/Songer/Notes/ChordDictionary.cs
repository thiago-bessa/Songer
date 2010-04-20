using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Songer
{
    public class ChordDictionary : List<Chord>
    {
        public ChordDictionary(string filename, MusicalNoteDictionary notes)
        {
            StreamReader reader = new StreamReader(filename);

            while (!reader.EndOfStream)
            {
                Chord chord = Chord.FromString(reader.ReadLine(), notes);
                this.Add(chord);
            }
        }
    }
}
