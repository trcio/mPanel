using System;
using mPanel.Matrix;
using SystemColor = System.Drawing.Color;
using ColorPalette = mPanel.Extra.Color.ColorPalette;

// PaletteNoise is repurposed from the FastLED/Examples/NoisePlusPalette C++ implementation

namespace mPanel.Extra.Noise
{
    public class PaletteNoise
    {
        private static readonly Random Random;
        private readonly byte[,] NoiseBytes;
        private ushort NoiseX, NoiseY, NoiseZ;

        public byte ColorOffset { get; set; }
        public ushort Speed { get; set; } = 2;
        public ushort Scale { get; set; } = 10;
        public double XFactor { get; set; } = 8.0;
        public double YFactor { get; set; } = -16.0;
        public double ZFactor { get; set; } = 2.0;

        static PaletteNoise()
        {
            Random = new Random();
        }

        public PaletteNoise()
        {
            NoiseBytes = new byte[MatrixPanel.Width, MatrixPanel.Height];

            NoiseX = (ushort) Random.Next(ushort.MaxValue + 1);
            NoiseY = (ushort) Random.Next(ushort.MaxValue + 1);
            NoiseZ = (ushort) Random.Next(ushort.MaxValue + 1);
        }

        public void FillNoise()
        {
            byte dataSmoothing = 0;

            if (Speed < 50)
                dataSmoothing = (byte) (200 - Speed * 4);

            for (var x = 0; x < NoiseBytes.GetLength(0); x++)
            for (var y = 0; y < NoiseBytes.GetLength(1); y++)
            {
                var data = SimplexNoise.Noise((ushort) (NoiseX + x * Scale), (ushort) (NoiseY + y * Scale), NoiseZ);

                data = QSub(data, 16);
                data = QAdd(data, QScale(data, 39));

                if (dataSmoothing > 0)
                {
                    var a = QScale(NoiseBytes[x, y], dataSmoothing);
                    var b = QScale(data, (byte) (256 - dataSmoothing));
                    data = (byte) (a + b);
                }

                NoiseBytes[x, y] = data;
            }

            NoiseX += (ushort) (Speed / XFactor);
            NoiseY += (ushort) (Speed / YFactor);
            NoiseZ += (ushort) (Speed / ZFactor);
        }

        public SystemColor GetColorFromPalette(ColorPalette palette, int x, int y)
        {
            var index = (byte) (NoiseBytes[y, x] + ColorOffset);
            var alpha = NoiseBytes[x, y];

            // alpha = alpha > 127 ? (byte) 255 : QDim((byte) (alpha * 2));

            return palette[index, alpha];
        }

        private static byte QAdd(byte a, byte b)
        {
            return (byte) Math.Min(byte.MaxValue, a + b);
        }

        private static byte QSub(byte a, byte b)
        {
            return (byte) Math.Max(byte.MinValue, a - b);
        }

        private static byte QScale(byte a, byte scale)
        {
            return (byte) (a * (scale / 256.0));
        }

        private static byte QDim(byte a)
        {
            return QScale(a, a);
        }
    }
}
