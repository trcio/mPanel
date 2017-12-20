using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Control_Panel.Matrix
{
    public class Frame : IDisposable
    {
        private const int PixelDataLength = 3;

        public Graphics G { get; }
        public Bitmap Bitmap { get; }
        public static int Width => MatrixPanel.Width;
        public static int Height => MatrixPanel.Height;
        public Rectangle Rectangle => new Rectangle(0, 0, Width, Height);

        public Frame()
        {
            Bitmap = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);
            G = Graphics.FromImage(Bitmap);
        }

        public byte[] GetBytes()
        {
            var rect = new Rectangle(0, 0, Bitmap.Width, Bitmap.Height);
            var data = Bitmap.LockBits(rect, ImageLockMode.ReadOnly, Bitmap.PixelFormat);

            byte[] bytes;

            try
            {
                bytes = new byte[data.Width * data.Height * PixelDataLength];

                for (var y = 0; y < data.Height; y++)
                {
                    var ptr = (IntPtr) ((long) data.Scan0 + y * data.Stride);

                    var row0 = y * data.Width * PixelDataLength;

                    for (var x = row0; x < row0 + data.Width * PixelDataLength; x += PixelDataLength)
                    {
                        Marshal.Copy(ptr, bytes, x + 2, 1);
                        Marshal.Copy(IntPtr.Add(ptr, 1), bytes, x + 1, 1);
                        Marshal.Copy(IntPtr.Add(ptr, 2), bytes, x, 1);

                        ptr = IntPtr.Add(ptr, PixelDataLength);
                    }
                }
            }
            finally
            {
                Bitmap.UnlockBits(data);
            }

            return bytes;
        }

        public void Dispose()
        {
            G?.Dispose();
            Bitmap?.Dispose();
        }
    }
}
