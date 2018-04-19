using System.Drawing;
using mPanel.Extra;

namespace mPanel.Actions.Scripter
{
    public static class LuaFunctions
    {
        public static Color Rgb(byte r, byte g, byte b)
        {
            return Color.FromArgb(r, g, b);
        }

        public static Color Hsv(byte hue)
        {
            return ColorHelper.HsvToColor(hue);
        }

        public static Color Alpha(byte a, Color c)
        {
            return Color.FromArgb(a, c);
        }

        public static Point Point(int x, int y)
        {
            return new Point(x, y);
        }

        public static Pen Pen(Color c)
        {
            return new Pen(c);
        }

        public static Brush Brush(Color c)
        {
            return new SolidBrush(c);
        }
    }
}
