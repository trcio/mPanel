using System;

namespace mPanel.Matrix
{
    public abstract class MatrixPanel : IDisposable
    {
        public const int PixelDataLength = 3;

        public static int Width { get; protected set; }
        public static int Height { get; protected set; }
        public abstract bool Connected { get; }

        public event EventHandler<byte[]> FrameHook;

        protected MatrixPanel(int width, int height)
        {
            Width = width;
            Height = height;
        }

        protected void OnFrameHook(byte[] e)
        {
            FrameHook?.Invoke(this, e);
        }

        public abstract bool Connect();
        public abstract void Disconnect();
        public abstract void Standby(byte brightness);
        public abstract void Clear();
        public abstract void SendFrame(byte[] buffer);
        public abstract void SendFrame(Frame frame);
        public abstract void SetBrightness(byte brightness);
        public abstract override string ToString();
        public abstract void Dispose();
    }
}
