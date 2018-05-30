using System.Drawing;
using System.Drawing.Drawing2D;
using SystemColor = System.Drawing.Color;

namespace mPanel.Extra.Color
{
    public class ColorPalette
    {
        public static readonly ColorPalette StandbyRainbow = new ColorPalette(new ColorBlend
        {
            Positions = new[] { 0, 8 / 32f, 12 / 32f, 16 / 32f, 22 / 32f, 28 / 32f, 1 },
            Colors = new[]
            {
                SystemColor.Red, SystemColor.Orange, SystemColor.Yellow, SystemColor.Green,
                SystemColor.Blue, SystemColor.Indigo, SystemColor.Red
            }
        });

        private const int Resolution = 256;
        private readonly SystemColor[] Colors;

        public Bitmap Bitmap { get; }
        public SystemColor this[byte index, byte alpha] => SystemColor.FromArgb(alpha, Colors[index]);

        public ColorPalette(ColorBlend blend)
        {
            Colors = new SystemColor[Resolution];
            Bitmap = new Bitmap(Resolution, 1);

            MapColors(blend);
        }

        private void MapColors(ColorBlend blend)
        {
            using (var g = Graphics.FromImage(Bitmap))
            using (var b = new LinearGradientBrush(new Rectangle(0, 0, Resolution, 1), SystemColor.Black, SystemColor.Black, 0, false))
            {
                b.InterpolationColors = blend;
                g.FillRectangle(b, 0, 0, Resolution, 1);

                for (var i = 0; i < Resolution; i++)
                    Colors[i] = Bitmap.GetPixel(i, 0);
            }
        }
    }
}
