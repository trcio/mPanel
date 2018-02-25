using System;
using System.IO.Ports;

namespace mPanel.Matrix
{
    public class SerialPanel : MatrixPanel
    {
        private const int BaudRate = 1000000;
        private const byte StandbyHeader = 0xC0;
        private const byte ClearHeader = 0xC1;
        private const byte FrameHeader = 0xC2;
        private const byte BrightnessHeader = 0xC3;

        private static readonly byte[] PacketHeader = { 0xDE, 0xAD, 0xBE, 0xEF };

        private SerialPort Arduino;

        public override bool Connected => Arduino?.IsOpen ?? false;

        public string Port { get; set; }

        public SerialPanel(int width, int height) : base(width, height) { }

        private void Arduino_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Console.Write(Arduino.ReadExisting());
        }

        public override bool Connect()
        {
            if (Connected)
                return true;

            try
            {
                Arduino = new SerialPort(Port, BaudRate);
                Arduino.DataReceived += Arduino_DataReceived;
                Arduino.Open();
            }
            catch
            {
                Console.WriteLine($"Could not open connection on port {Port}");
            }

            return Connected;
        }

        public override void Disconnect()
        {
            if (!Connected)
                return;

            Arduino.Close();
        }

        public override void Standby(byte brightness)
        {
            if (!Connected)
                return;

            var data = new [] { StandbyHeader, brightness };

            Arduino.Write(PacketHeader, 0, PacketHeader.Length);
            Arduino.Write(data, 0, data.Length);

            OnFrameHook(new byte[Width * Height * PixelDataLength]);
        }

        public override void Clear()
        {
            if (!Connected)
                return;

            var data = new [] { ClearHeader, (byte) 0, (byte) 0, (byte) 0 };

            Arduino.Write(PacketHeader, 0, PacketHeader.Length);
            Arduino.Write(data, 0, data.Length);

            OnFrameHook(new byte[Width * Height * PixelDataLength]);
        }

        public override void SendFrame(byte[] buffer)
        {
            if (!Connected || buffer == null)
                return;

            var data = new [] { FrameHeader };

            Arduino.Write(PacketHeader, 0, PacketHeader.Length);
            Arduino.Write(data, 0, data.Length);
            Arduino.Write(buffer, 0, buffer.Length);

            OnFrameHook(buffer);
        }

        public override void SendFrame(Frame frame)
        {
            SendFrame(frame.GetBytes());
        }

        public override void SetBrightness(byte brightness)
        {
            if (!Connected)
                return;

            var data = new [] { BrightnessHeader, brightness };

            Arduino.Write(PacketHeader, 0, PacketHeader.Length);
            Arduino.Write(data, 0, data.Length);
        }

        public override string ToString()
        {
            return Port;
        }

        public override void Dispose()
        {
            Arduino?.Dispose();
        }
    }
}
