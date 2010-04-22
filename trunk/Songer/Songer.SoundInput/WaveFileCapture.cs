using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using SlimDX.DirectSound;
using SlimDX.Multimedia;

namespace Songer.SoundInput
{
    public class WaveFileCapture : SoundSource
    {
        private WaveStream waveStream;
        private Thread processingThread;
        private string filename;

        public WaveFileCapture(string filename)
        {
            this.filename = filename;
            this.waveStream = new WaveStream(filename);
            this.Format = this.waveStream.Format;
        }
        
        public override void Listen()
        {
            this.processingThread = new Thread(new ThreadStart(this.ProcessWaveFile));
            this.processingThread.Name = String.Format("Processing WaveFile: {0}", this.filename);
            this.processingThread.Start();
        }

        public void ProcessWaveFile()
        {

        getHere:

            int bufferSize = this.Format.AverageBytesPerSecond;
            byte[] data = new byte[bufferSize];
            int position = 0;


            while (position < this.waveStream.Length)
            {
                position += this.waveStream.Read(data, 0, bufferSize);

                //Convert byte[] data to short[]
                short[] x = new short[bufferSize / 2];
                Buffer.BlockCopy(data, 0, x, 0, bufferSize);

                this.ProcessData(x);
            }

            this.waveStream.Position = 0;
            goto getHere;

            this.waveStream.Close();
        }

        public override void Stop()
        {
            if (this.processingThread.IsAlive)
            {
                this.processingThread.Abort();
            }
        }
    }
}
