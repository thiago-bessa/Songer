using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Songer.MusicalInterpreter;
using Songer.SoundInput;

namespace Songer.UnitTests
{
    [TestFixture]
    public class MusicalAnalyzerTests
    {
        private MusicalAnalyzer musicalAnalyzer;
        WaveFileCapture wave;

        [SetUp]
        public void SetUp()
        {
            this.musicalAnalyzer = new MusicalAnalyzer();
            this.wave = new WaveFileCapture(@"..\Sounds\G.wav");
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void ExtractNotesFromSoundData()
        {
        }

        [Test]
        public void ExtractChordFromNotes()
        {
        }

        [Test]
        public void ExtractChordCollectionFromMusic()
        {
        }
    }
}
