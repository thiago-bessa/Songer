using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Songer.MusicalInterpreter;

namespace Songer.UnitTests
{
    [TestFixture]
    public class NotesAndChordsTests
    {
        [Test(Description = "Assert that information is loaded from Notes.txt")]
        public void LoadMusicalNoteDictionary()
        {
            MusicalNoteDictionary notes = new MusicalNoteDictionary();

            Assert.That(notes[440].Name, Is.EqualTo("A4"));
            Assert.That(notes[220].Frequency, Is.EqualTo(220));
            Assert.That(notes[987.77].Harmonics[1], Is.EqualTo(2963.3));

        }

        [Test(Description="Assert that information is loaded from Chords.txt")]
        public void LoadChordDictionary()
        {
            MusicalNoteDictionary notes = new MusicalNoteDictionary();
            ChordDictionary chords = new ChordDictionary(notes);
            
            Chord chordA = chords[0];
            Assert.That(chordA.Name, Is.EqualTo("A"));
            string[] notesChordA = new string[] { "E2", "A2", "E3", "A3", "C4#", "E4" };
            for (int i = 0; i < chordA.MusicalNotes.Count; i++)
            {
                Assert.That(chordA.MusicalNotes[i].Name, Is.EqualTo(notesChordA[i]));
            }

            Chord chordEm7 = chords.Find(chord => chord.Name.Equals("Em7"));
            Assert.That(chordEm7.Name, Is.EqualTo("Em7"));
            string[] noteschordEm7 = new string[] { "E2", "D3", "G3", "B3" };
            for (int i = 0; i < chordEm7.MusicalNotes.Count; i++)
            {
                Assert.That(chordEm7.MusicalNotes[i].Name, Is.EqualTo(noteschordEm7[i]));
            }
        }
    }
}
