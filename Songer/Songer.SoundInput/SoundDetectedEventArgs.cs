using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Songer.SoundInput
{
    public class SoundDetectedEventArgs : EventArgs
    {
        public double Frequency { get; private set; }
        public double[] Spectrogram { get; private set; }
        public int MaxSpectrogram { get; private set; }

        public SoundDetectedEventArgs(double frequency, double[] spectrogram, int indexMaxSpectrogram)
        {
            this.Frequency = frequency;
            this.Spectrogram = spectrogram;
            this.MaxSpectrogram = indexMaxSpectrogram;
        }
    }
}
