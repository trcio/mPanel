using System;
using System.Drawing;
using System.IO.Ports;
using System.Linq;

namespace Control_Panel.Matrix
{
    public class MatrixPanel : IDisposable
    {
        private const int PixelDataLength = 3;
        private const int BaudRate = 1000000;

        private static readonly byte[] PacketHeader = { 0xDE, 0xAD, 0xBE, 0xEF };
        private static readonly byte[] FrameHeader = { 0xDE, 0xAD, 0xBE, 0xEF, 0xC1 };
        private static readonly byte[] BrightnessHeader = { 0xDE, 0xAD, 0xBE, 0xEF, 0xC3 };

        private SerialPort Arduino;
        private byte[] FrameBuffer;

        public static int Width, Height;

        public bool Connected => Arduino.IsOpen;

        public MatrixPanel(int width, int height)
        {
            Arduino = new SerialPort();

            Width = width;
            Height = height;

            Clear();
        }

        public bool Connect(string port)
        {
            if (Connected)
                return true;

            try
            {
                Arduino = new SerialPort(port, BaudRate);
                Arduino.DataReceived += Arduino_DataReceived;
                Arduino.Open();
            }
            catch
            {
                Console.WriteLine("Could not open port");
            }

            return Connected;
        }

        public void Disconnect()
        {
            if (Connected)
                Arduino.Close();
        }

        private void Arduino_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Console.Write(Arduino.ReadExisting());
        }

        public void SetFrame(byte[] buffer)
        {
            if (buffer == null)
                return;

            Buffer.BlockCopy(buffer, 0, FrameBuffer, 0, buffer.Length);
        }

        public void SetFrame(Frame frame)
        {
            SetFrame(frame.GetBytes());
        }

        public void SetFrame(Color color)
        {
            for (var i = 0; i < FrameBuffer.Length; i += PixelDataLength)
            {
                Buffer.SetByte(FrameBuffer, i, color.R);
                Buffer.SetByte(FrameBuffer, i + 1, color.G);
                Buffer.SetByte(FrameBuffer, i + 2, color.B);
            }
        }

        public void SetBrightness(byte value)
        {
            if (!Connected)
                return;

            var data = new[] { value };

            Arduino.Write(BrightnessHeader, 0, BrightnessHeader.Length);
            Arduino.Write(data, 0, data.Length);
        }

        public void PushFrame()
        {
            if (!Connected)
                return;

            Arduino.Write(FrameHeader, 0, FrameHeader.Length);
            Arduino.Write(FrameBuffer, 0, FrameBuffer.Length);
        }

        public void Clear()
        {
            Clear(Color.Black);
        }

        public void Clear(Color background)
        {
            FrameBuffer = new byte[Width * Height * PixelDataLength];

            SetFrame(background);

            if (!Connected)
                return;

            var data = new byte[] { 0xC2, background.R, background.G, background.B };

            Arduino.Write(PacketHeader, 0, PacketHeader.Length);
            Arduino.Write(data, 0, data.Length);
        }

        public void Dispose()
        {
            Arduino?.Dispose();
        }
    }
}
