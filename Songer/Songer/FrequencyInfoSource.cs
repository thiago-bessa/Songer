using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Songer
{
    public abstract class FrequencyInfoSource
    {
        public abstract void Listen();
        public abstract void Stop();
        public abstract int SampleRate { get; }

        public event EventHandler<FrequencyDetectedEventArgs> FrequencyDetected;

        protected void OnFrequencyDetected(FrequencyDetectedEventArgs e)
        {
            if (FrequencyDetected != null)
            {
                FrequencyDetected(this, e);
            }
        }
    }

    public class FrequencyDetectedEventArgs : EventArgs
    {
        public double Frequency { get; private set; }
        public double[] Spectrogram { get; private set; }
        public int MaxSpectrogram { get; private set; }

        public FrequencyDetectedEventArgs(double frequency, double[] spectrogram, int indexMaxSpectrogram)
        {
            this.Frequency = frequency;
            this.Spectrogram = spectrogram;
            this.MaxSpectrogram = indexMaxSpectrogram;
        }
    }
}
