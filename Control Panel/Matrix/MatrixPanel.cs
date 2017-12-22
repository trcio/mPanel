using System;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Threading.Tasks;

namespace Control_Panel.Matrix
{
    public class MatrixPanel : IDisposable
    {
        private const int PixelDataLength = 3;
        private const int BaudRate = 1000000;
        private const byte StandbyHeader = 0xC0;
        private const byte ClearHeader = 0xC1;
        private const byte FrameHeader = 0xC2;
        private const byte BrightnessHeader = 0xC3;

        private static readonly byte[] PacketHeader = { 0xDE, 0xAD, 0xBE, 0xEF };

        private SerialPort Arduino;

        public bool Connected => Arduino?.IsOpen ?? false;
        public static int Width, Height;
        public event EventHandler<byte[]> FrameHook;

        public MatrixPanel(int width, int height)
        {
            Width = width;
            Height = height;
        }

        protected virtual void OnFrameHook(byte[] e)
        {
            FrameHook?.Invoke(this, e);
        }

        private void Arduino_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Console.Write(Arduino.ReadExisting());
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
            if (!Connected)
                return;

            Standby();
            Arduino.Close();
        }

        public void Standby()
        {
            if (!Connected)
                return;

            Arduino.Write(PacketHeader, 0, PacketHeader.Length);
            Arduino.Write(new [] { StandbyHeader }, 0, 1);
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

        public void SetBrightness(byte value)
        {
            if (!Connected)
                return;

            var data = new [] { BrightnessHeader, value };

            Arduino.Write(PacketHeader, 0, PacketHeader.Length);
            Arduino.Write(data, 0, data.Length);
        }

        public void Dispose()
        {
            Arduino?.Dispose();
        }
    }
}
