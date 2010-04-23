using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Songer.SoundInput
{
    public class SoundDetectedEventArgs : EventArgs
    {
        public short[] SoundData { get; private set; }

        public SoundDetectedEventArgs(short[] soundData)
        {
            this.SoundData = soundData;
        }
    }
}
