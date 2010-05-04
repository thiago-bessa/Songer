using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Songer.Database
{
    public class Song : IEquatable<Song>
    {
        public string Name { get; set; }
        public string Artist { get; set; }
        public string ChordSequence { get; set; }

        public Song(string name, string artist, string chordSequence)
        {
            this.Name = name;
            this.Artist = artist;
            this.ChordSequence = chordSequence;
        }

        public bool Matches(string chordSequence)
        {
            return this.ChordSequence.Contains(chordSequence);
        }

        public override string ToString()
        {
            return String.Format("{0} - {1}: {2}",
                this.Name, this.Artist, this.ChordSequence);
        }

        #region IEquatable<Music> Members

        public bool Equals(Song other)
        {
            return this.ChordSequence.Equals(other.ChordSequence);
        }

        #endregion
    }
}
