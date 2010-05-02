using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Songer.MusicalInterpreter
{
    public class NotesDetectedEventArgs : EventArgs
    {
        public Dictionary<MusicalNote, double> MusicalNotes { get; private set; }

        public NotesDetectedEventArgs(Dictionary<MusicalNote, double> musicalNotes)
        {
            this.MusicalNotes = musicalNotes;
        }
    }

    public class ChordDetectedEventArgs : EventArgs
    {
        public List<Chord> Chords { get; private set; }

        public ChordDetectedEventArgs(List<Chord> chord)
        {
            this.Chords = chord;
        }
    }

    public class AudioProcessingFinishedEventArgs : EventArgs
    {
        public string Chords { get; private set; }

        public AudioProcessingFinishedEventArgs(string chords)
        {
            this.Chords = chords;
        }
    }
}
