using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Songer.MusicalInterpreter;

namespace Songer.UnitTests
{
    [TestFixture]
    public class MusicalAnalyzerTests
    {
        private MusicalAnalyzer musicalAnalyzer;

        [SetUp]
        public void SetUpTest()
        {
            this.musicalAnalyzer = new MusicalAnalyzer();
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
