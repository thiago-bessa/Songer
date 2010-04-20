using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SoundCapture;
using Songer.Analysis;

namespace Songer
{
    class SoundFrequencyInfoSource : FrequencyInfoSource
    {
        SoundCaptureDevice device;
        Adapter adapter;

        internal SoundFrequencyInfoSource(SoundCaptureDevice device)
        {
            this.device = device;
        }

        public override void Listen()
        {
            adapter = new Adapter(this, device);
            adapter.Start();
        }

        public override void Stop()
        {
            adapter.Stop();
        }

        public override int SampleRate
        {
            get
            {
                return adapter.SampleRate;
            }
        }

        class Adapter : SoundCaptureBase
        {
            SoundFrequencyInfoSource owner;

            //Values based on guitar notes
            const double MinFreq = 60;
            const double MaxFreq = 1300;

            internal Adapter(SoundFrequencyInfoSource owner, SoundCaptureDevice device)
                : base(device)
            {
                this.owner = owner;
            }

            protected override void ProcessData(short[] data)
            {               
                double[] x = new double[data.Length];
                for (int i = 0; i < x.Length; i++)
                {
                    x[i] = data[i];
                }

                double[] spectr = FftAlgorithm.Calculate(x);
                int index = 0;
                double max = spectr[0];
                int usefullMaxSpectr = Math.Min(spectr.Length, (int)(MaxFreq * spectr.Length / SampleRate) + 1);

                for (int i = 1; i < usefullMaxSpectr; i++)
                {
                    if (max < spectr[i])
                    {
                        max = spectr[i]; index = i;
                    }
                }
                //index = 46;
                double freq = (double)SampleRate * index / spectr.Length;
                if (freq < MinFreq) freq = 0;

                owner.OnFrequencyDetected(new FrequencyDetectedEventArgs(freq, spectr, usefullMaxSpectr));
            }
        }
    }
}
