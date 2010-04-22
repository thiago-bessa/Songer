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
        private const int bufferSeconds = 1;
        private const int notifyPointsInSecond = 2;
        private bool isCapturing = false;
        private bool disposed = false;
        private int bufferLength;

        private DirectSoundCapture captureDevice;
        private CaptureBuffer captureBuffer;
        private AutoResetEvent positionEvent;
        private ManualResetEvent terminatedEvent;
        private Thread captureThread;

        public LineInCapture()
        {
            this.positionEvent = new AutoResetEvent(false);
            this.terminatedEvent = new ManualResetEvent(true);
        }
        
        public override void Listen()
        {
            if (this.isCapturing)
            {
                throw new InvalidOperationException("Capture is in process");
            }

            this.isCapturing = true;
            this.bufferLength = this.Format.AverageBytesPerSecond * bufferSeconds;

            CaptureBufferDescription desciption = new CaptureBufferDescription();
            desciption.Format = this.Format;
            desciption.BufferBytes = bufferLength;

            this.captureDevice = new DirectSoundCapture();
            this.captureBuffer = new CaptureBuffer(captureDevice, desciption);

            int waitHandleCount = bufferSeconds * notifyPointsInSecond;
            NotificationPosition[] notificationPositions = new NotificationPosition[waitHandleCount];

            for (int i = 0; i < waitHandleCount; i++)
            {
                NotificationPosition position = new NotificationPosition();
                position.Offset = (i + 1) * bufferLength / notificationPositions.Length - 1;
                position.Event = positionEvent;

                notificationPositions[i] = position;
            }

            this.captureBuffer.SetNotificationPositions(notificationPositions);

            this.terminatedEvent.Reset();
            this.captureThread = new Thread(new ThreadStart(this.CaptureLoop));
            this.captureThread.Name = "Sound capture";
            this.captureThread.Start();
        }

        private void CaptureLoop()
        {
            this.captureBuffer.Start(true);

            try
            {
                int nextCapturePosition = 0;
                WaitHandle[] handles = new WaitHandle[] { this.terminatedEvent, this.positionEvent };

                while (WaitHandle.WaitAny(handles) > 0)
                {
                    int readPosition = this.captureBuffer.CurrentReadPosition;
                    int lockSize = readPosition - nextCapturePosition;

                    if (lockSize < 0)
                    {
                        lockSize += this.bufferLength;
                    }

                    if ((lockSize & 1) != 0)
                    {
                        lockSize--;
                    }

                    int itemsCount = lockSize >> 1;

                    short[] data = new short[itemsCount];
                    this.captureBuffer.Read<short>(data, nextCapturePosition, false);
                    this.ProcessData(data);
                    nextCapturePosition = (nextCapturePosition + lockSize) % bufferLength;
                }
            }
            finally
            {
                this.captureBuffer.Stop();
            }
        }


        public override void Stop()
        {
            if (this.isCapturing)
            {
                this.isCapturing = false;

                this.terminatedEvent.Set();
                this.captureThread.Join();

                this.captureBuffer.Dispose();
                this.captureDevice.Dispose();
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
                this.terminatedEvent.Close();
            }
        }
    }
}
