using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Songer.MusicalInterpreter
{
    public class MusicalNote : IEquatable<MusicalNote>
    {
        public string Name { get; private set; }
        public double Frequency { get; private set; }
        public List<double> Harmonics { get; private set; }

        private MusicalNote()
        {
            this.Harmonics = new List<double>();
        }

        public static MusicalNote FromString(string noteInformation)
        {
            MusicalNote musicalNote = new MusicalNote();
            string[] information = noteInformation.Split(',');

            musicalNote.Name = information[0];
            musicalNote.Frequency = Convert.ToDouble(information[1], CultureInfo.InvariantCulture);

            for (int i = 2; i < information.Length - 2; i++)
            {
                musicalNote.Harmonics.Add(Convert.ToDouble(information[i], CultureInfo.InvariantCulture));
            }

            return musicalNote;
        }

        public override string ToString()
        {
            return this.Name;
        }

        #region IEquatable<MusicalNote> Members

        public bool Equals(MusicalNote other)
        {
            return this.Name.Equals(other.Name, StringComparison.InvariantCulture);
        }

        #endregion
    }
}