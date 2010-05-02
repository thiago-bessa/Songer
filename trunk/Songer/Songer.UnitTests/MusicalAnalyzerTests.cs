using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Songer.MusicalInterpreter;
using Songer.SoundInput;
using System.Threading;

namespace Songer.UnitTests
{
    [TestFixture]
    public class MusicalAnalyzerTests
    {
        private MusicalAnalyzer musicalAnalyzer;
        private Dictionary<MusicalNote, double> notesBeingPlayed;
        private List<Chord> chord;
        private string chordSequence;

        [SetUp]
        public void SetUpTestEnvironment()
        {
            this.musicalAnalyzer = new MusicalAnalyzer();
            this.musicalAnalyzer.NotesDetected += new EventHandler<NotesDetectedEventArgs>(onNotesDetected);
            this.musicalAnalyzer.ChordDetected += new EventHandler<ChordDetectedEventArgs>(onChordDetected);
            this.musicalAnalyzer.ProcessingFinished += new EventHandler<AudioProcessingFinishedEventArgs>(onProcessingFinished);

            this.notesBeingPlayed = new Dictionary<MusicalNote,double>();
            this.chord = null;
            this.chordSequence = string.Empty;
        }

        private void onNotesDetected(object sender, NotesDetectedEventArgs e)
        {
            this.notesBeingPlayed = e.MusicalNotes;
        }

        private void onChordDetected(object sender, ChordDetectedEventArgs e)
        {
            this.chord = e.Chords;
        }

        private void onProcessingFinished(object sender, AudioProcessingFinishedEventArgs e)
        {
            this.chordSequence = e.Chords;
        }

        [TearDown]
        public void TearDownTestEnvironment()
        {
        }

        [Test]
        public void ExtractNotesFromSoundData()
        {
            string[] chordNotes = new string[] { "G2", "B2", "D3", "G3", "B3", "G4" };

            this.musicalAnalyzer.AnalyzeAudio(@"..\Sounds\G.wav");

            while (this.notesBeingPlayed.Count == 0)
            {
                Thread.Sleep(100);
            }

            foreach (string note in chordNotes)
            {
                Assert.That(
                    this.notesBeingPlayed.Count(m => m.Key.Name.Equals(note)),
                    Is.GreaterThan(0));
            }
        }

        [Test]
        public void ExtractChordFromNotes()
        {
            this.musicalAnalyzer.AnalyzeAudio(@"..\Sounds\G.wav");

            while (this.chord == null)
            {
                Thread.Sleep(100);
            }
            
            Assert.That(
                chord.Count(c => c.Name.Equals("G", StringComparison.InvariantCulture)),
                Is.GreaterThanOrEqualTo(1));
        }

        [Test]
        public void ExtractChordCollectionFromMusic()
        {
            this.musicalAnalyzer.AnalyzeAudio(@"..\Sounds\Seq2Var.wav");

            while (this.chordSequence == string.Empty)
            {
                Thread.Sleep(100);
            }

            Assert.That(this.chordSequence, Is.EqualTo("G D Em C"));
        }
    }
}
