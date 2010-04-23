using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using SlimDX.DirectSound;
using SlimDX.Multimedia;

namespace Songer.SoundInput
{
    public class WaveFileCapture : SoundSource, IDisposable
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
        
        public override void Start()
        {
            this.processingThread = new Thread(new ThreadStart(this.CaptureLoop));
            this.processingThread.Name = String.Format("Processing WaveFile: {0}", this.filename);
            this.processingThread.Start();
        }

        protected override void CaptureLoop()
        {

        getHere:

            int bufferSize = this.Format.AverageBytesPerSecond;
            byte[] waveData = new byte[bufferSize];
            int position = 0;
            
            while (position < this.waveStream.Length)
            {
                position += this.waveStream.Read(waveData, 0, bufferSize);

                //Convert byte[] data to short[]
                short[] soundData = new short[bufferSize / 2];
                Buffer.BlockCopy(waveData, 0, soundData, 0, bufferSize);

                this.OnSoundDetected(soundData);
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
                this.waveStream.Close();
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            this.Stop();
            this.waveStream.Dispose();
        }

        #endregion
    }
}
