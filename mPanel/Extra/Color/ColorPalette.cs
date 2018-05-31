using System.Drawing;
using System.Drawing.Drawing2D;
using SystemColor = System.Drawing.Color;

namespace mPanel.Extra.Color
{
    public class ColorPalette
    {
        public static readonly ColorPalette StandbyRainbow = new ColorPalette
        (
            new [] { 0, 32, 64, 96, 128, 160, 192, 224, 255 },
            new []
            {
                SystemColor.Red, SystemColor.DarkOrange, SystemColor.Yellow, SystemColor.FromArgb(0, 255, 0), SystemColor.Aqua,
                SystemColor.Blue, SystemColor.FromArgb(85, 0, 171), SystemColor.FromArgb(171, 0, 85), SystemColor.Red
            }
        );

        private const int Resolution = 256;
        private readonly SystemColor[] Colors;

        public Bitmap Bitmap { get; }
        public SystemColor this[byte index, byte alpha] => SystemColor.FromArgb(alpha, Colors[index]);

        public ColorPalette(int[] positions, SystemColor[] colors)
        {
            Colors = new SystemColor[Resolution];
            Bitmap = new Bitmap(Resolution, 1);

            var blend = new ColorBlend
            {
                Colors = colors,
                Positions = new float[positions.Length]
            };

            for (var i = 0; i < positions.Length; i++)
            {
                blend.Positions[i] = positions[i] / 255f;
            }

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
