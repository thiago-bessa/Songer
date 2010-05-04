using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Db4objects.Db4o;

namespace Songer.Database
{
    public class SongStore
    {
        private IObjectContainer database;

        public SongStore()
        {
            this.database = Db4oEmbedded.OpenFile("SongStore.yap");
        }

        public void Add(Song song)
        {
            this.database.Store(song);
            this.database.Commit();
        }

        public void Delete(Song song)
        {
            this.database.Delete(song);
            this.database.Commit();
        }

        public IList<Song> Search(string chordSequence)
        {
            return this.database.Query<Song>(s => s.Matches(chordSequence));
        }
    }
}
