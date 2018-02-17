using System;
using System.IO.Ports;

namespace mPanel.Matrix
{
    public class MatrixPanel : IDisposable
    {
        public const int PixelDataLength = 3;

        private const int BaudRate = 1000000;
        private const byte StandbyHeader = 0xC0;
        private const byte ClearHeader = 0xC1;
        private const byte FrameHeader = 0xC2;
        private const byte BrightnessHeader = 0xC3;

        private static readonly byte[] PacketHeader = { 0xDE, 0xAD, 0xBE, 0xEF };

        private SerialPort Arduino;

        public static int Width { get; private set; }
        public static int Height { get; private set; }
        public bool Connected => Arduino?.IsOpen ?? false;

        public event EventHandler<byte[]> FrameHook;

        public MatrixPanel(int width, int height)
        {
            Width = width;
            Height = height;
        }

        private void Arduino_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Console.Write(Arduino.ReadExisting());
        }

        protected virtual void OnFrameHook(byte[] e)
        {
            FrameHook?.Invoke(this, e);
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
                Console.WriteLine($"Could not open connection on port {port}");
            }

            return Connected;
        }

        public void Disconnect()
        {
            if (!Connected)
                return;

            Arduino.Close();
        }

        public void Standby(byte brightness)
        {
            if (!Connected)
                return;

            var data = new [] { StandbyHeader, brightness };

            Arduino.Write(PacketHeader, 0, PacketHeader.Length);
            Arduino.Write(data, 0, data.Length);

            OnFrameHook(new byte[Width * Height * PixelDataLength]);
        }

        public void Clear()
        {
            if (!Connected)
                return;

            var data = new [] { ClearHeader, (byte) 0, (byte) 0, (byte) 0 };

            Arduino.Write(PacketHeader, 0, PacketHeader.Length);
            Arduino.Write(data, 0, data.Length);

            OnFrameHook(new byte[Width * Height * PixelDataLength]);
        }

        public void SendFrame(byte[] buffer)
        {
            if (!Connected || buffer == null)
                return;

            var data = new [] { FrameHeader };

            Arduino.Write(PacketHeader, 0, PacketHeader.Length);
            Arduino.Write(data, 0, data.Length);
            Arduino.Write(buffer, 0, buffer.Length);

            OnFrameHook(buffer);
        }

        public void SendFrame(Frame frame)
        {
            SendFrame(frame.GetBytes());
        }

        public void SetBrightness(byte brightness)
        {
            if (!Connected)
                return;

            var data = new [] { BrightnessHeader, brightness };

            Arduino.Write(PacketHeader, 0, PacketHeader.Length);
            Arduino.Write(data, 0, data.Length);
        }

        public void Dispose()
        {
            Arduino?.Dispose();
        }
    }
}
