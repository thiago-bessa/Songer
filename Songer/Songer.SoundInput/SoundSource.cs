using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SlimDX.Multimedia;
using Songer.SoundAnalysis;

namespace Songer.SoundInput
{
    public abstract class SoundSource
    {
        private const double minFreq = 60; //Value based on possible guitar notes
        private const double maxFreq = 1300; //Value based on possible guitar notes

        public abstract void Listen();
        public abstract void Stop();

        private WaveFormat format = SoundSource.GenerateWaveFormat();

        public event EventHandler<SoundDetectedEventArgs> SoundDetected;

        protected WaveFormat Format
        {
            get { return format; }
            set { format = value; }
        }
        
        protected void OnSoundDetected(SoundDetectedEventArgs e)
        {
            if (this.SoundDetected != null)
            {
                this.SoundDetected(this, e);
            }
        }

        protected void ProcessData(short[] data)
        {
            double[] spectrogram = CooleyTukeyFFT.CalculateSpectrogram(data);

            int index = 0;
            double max = spectrogram[0];
            int usefullMaxSpectr = Math.Min(spectrogram.Length, (int)(maxFreq * spectrogram.Length / 44100) + 1);

            for (int i = 1; i < usefullMaxSpectr; i++)
            {
                if (max < spectrogram[i])
                {
                    max = spectrogram[i];
                    index = i;
                }
            }

            double freq = (double)44100 * index / spectrogram.Length;
            if (freq < minFreq)
            {
                freq = 0;
            }

            this.OnSoundDetected(new SoundDetectedEventArgs(freq, spectrogram, usefullMaxSpectr));
        }
        
        private static WaveFormat GenerateWaveFormat()
        {
            WaveFormat format = new WaveFormat();
            format.FormatTag = WaveFormatTag.Pcm;
            format.Channels = 1;
            format.BitsPerSample = 16;
            format.SamplesPerSecond = 44100;
            format.BlockAlignment = (short)(format.Channels * (format.BitsPerSample / 8));
            format.AverageBytesPerSecond = format.BlockAlignment * format.SamplesPerSecond;

            return format;
        }
    }
}
