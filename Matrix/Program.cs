using System;
using System.IO.Ports;

namespace Matrix
{
    class Program
    {
        private static byte[] White = new byte[]
        {
            255, 25, 255, 255, 255, 255,
            255, 255, 255, 255, 255, 255,
            255, 255, 255, 255, 255, 255,
            255, 255, 255, 255, 255, 255,
            255, 255, 255, 255, 255, 255
        };

        private static byte[] Black = new byte[]
        {
            0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0
        };

        static void Main(string[] args)
        {
            var random = new Random();

            var command = new char[] {'f'};

            using (var arduino = new SerialPort("COM6", 115200))
            {
                arduino.Open();

                while (true)
                {
                    var bytes = new byte[225 * 3];

                    random.NextBytes(bytes);

                    arduino.Write(command, 0, 1);
                    arduino.Write(bytes, 0, bytes.Length);

                    if (Console.ReadLine() != "stop")
                        continue;

                    arduino.Write("c");
                    break;
                }
            }
        }
    }
}
