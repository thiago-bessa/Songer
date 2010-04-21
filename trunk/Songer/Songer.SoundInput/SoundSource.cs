using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Songer.SoundInput
{
    public abstract class SoundSource
    {
        public abstract void Listen();
        public abstract void Stop();

        public event EventHandler<SoundDetectedEventArgs> SoundDetected;

        protected void OnSoundDetected(SoundDetectedEventArgs e)
        {
            if (this.SoundDetected != null)
            {
                this.SoundDetected(this, e);
            }
        }
    }
}
