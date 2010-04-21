using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using SlimDX.DirectSound;
using SlimDX.Multimedia;
using Microsoft.Win32.SafeHandles;
using Songer.SoundAnalysis;

namespace Songer.SoundInput
{
    public class LineInCapture : SoundSource, IDisposable
    {
        const int BufferSeconds = 3;
        const int NotifyPointsInSecond = 2;
        bool isCapturing = false;
        bool disposed = false;

        //Values based on possible guitar notes
        const double MinFreq = 60;
        const double MaxFreq = 1300;
        
        DirectSoundCapture capture;
        CaptureBuffer buffer;
        int bufferLength;
        AutoResetEvent positionEvent;
        ManualResetEvent terminated;
        Thread thread;

        public LineInCapture()
        {
            positionEvent = new AutoResetEvent(false);
            terminated = new ManualResetEvent(true);
        }

        private void EnsureIdle()
        {
            if (this.isCapturing)
            {
                throw new LineCaptureException("Capture is in process");
            }
        }

        /// <summary>
        /// Starts capture process.
        /// </summary>
        public override void Listen()
        {
            EnsureIdle();

            isCapturing = true;

            WaveFormat format = new WaveFormat();
            format.Channels = 1;
            format.BitsPerSample = 16;
            format.SamplesPerSecond = 44100;
            format.FormatTag = WaveFormatTag.Pcm;
            format.BlockAlignment = (short)((format.Channels * format.BitsPerSample + 7) / 8);
            format.AverageBytesPerSecond = format.BlockAlignment * format.SamplesPerSecond;

            bufferLength = format.AverageBytesPerSecond * BufferSeconds;
            CaptureBufferDescription desciption = new CaptureBufferDescription();
            desciption.Format = format;
            desciption.BufferBytes = bufferLength;

            capture = new DirectSoundCapture();
            buffer = new CaptureBuffer(capture, desciption);

            int waitHandleCount = BufferSeconds * NotifyPointsInSecond;
            NotificationPosition[] positions = new NotificationPosition[waitHandleCount];
            for (int i = 0; i < waitHandleCount; i++)
            {
                NotificationPosition position = new NotificationPosition();
                position.Offset = (i + 1) * bufferLength / positions.Length - 1;
                position.Event = positionEvent;
                positions[i] = position;
            }

            buffer.SetNotificationPositions(positions);

            terminated.Reset();
            thread = new Thread(new ThreadStart(ThreadLoop));
            thread.Name = "Sound capture";
            thread.Start();
        }

        private void ThreadLoop()
        {
            buffer.Start(true);
            try
            {
                int nextCapturePosition = 0;
                WaitHandle[] handles = new WaitHandle[] { terminated, positionEvent };
                while (WaitHandle.WaitAny(handles) > 0)
                {
                    int capturePosition = buffer.CurrentCapturePosition;
                    int readPosition = buffer.CurrentReadPosition;

                    int lockSize = readPosition - nextCapturePosition;
                    if (lockSize < 0) lockSize += bufferLength;
                    if((lockSize & 1) != 0) lockSize--;

                    int itemsCount = lockSize >> 1;

                    short[] data = new short[itemsCount];
                    buffer.Read<short>(data, nextCapturePosition, false);//, itemsCount, 0);
                    this.ProcessData(data);
                    nextCapturePosition = (nextCapturePosition + lockSize) % bufferLength;
                }
            }
            finally
            {
                buffer.Stop();
            }
        }

        /// <summary>
        /// Processes the captured data.
        /// </summary>
        /// <param name="data">Captured data</param>
        protected void ProcessData(short[] data)
        {
            double[] spectrogram = CooleyTukeyFFT.CalculateSpectrogram(data);
            int index = 0;
            double max = spectrogram[0];
            int usefullMaxSpectr = Math.Min(spectrogram.Length, (int)(MaxFreq * spectrogram.Length / 44100) + 1);

            for (int i = 1; i < usefullMaxSpectr; i++)
            {
                if (max < spectrogram[i])
                {
                    max = spectrogram[i];
                    index = i;
                }
            }
            //index = 46;
            double freq = (double)44100 * index / spectrogram.Length;
            if (freq < MinFreq) freq = 0;

            this.OnSoundDetected(new SoundDetectedEventArgs(freq, spectrogram, usefullMaxSpectr));
        }

        /// <summary>
        /// Stops capture process.
        /// </summary>
        public override void Stop()
        {
            if (isCapturing)
            {
                isCapturing = false;

                terminated.Set();
                thread.Join();

                //notify.Dispose();
                buffer.Dispose();
                capture.Dispose();
            }
        }

        public void Dispose()
        {
            if (!this.disposed)
            {
                this.disposed = true;
                GC.SuppressFinalize(this);

                if (this.isCapturing)
                {
                    this.Stop();
                }

                this.positionEvent.Close();
                this.terminated.Close();
            }
        }

        public class LineCaptureException : Exception
        {
            public LineCaptureException(string message)
                : base(message)
            {
            }
        }
    }
}
