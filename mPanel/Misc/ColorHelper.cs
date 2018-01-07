using System;
using System.Drawing;

namespace mPanel.Misc
{
    public class ColorHelper
    {
        //        public static List<Color> GetRainbowColors(int colorCount)
        //        {
        //            List<Color> ret = new List<Color>(colorCount);
        //
        //            double p = 360.0 / (double)colorCount;
        //
        //            for (int n = 0; n < colorCount; n++)
        //            {
        //                ret.Add(HsvToRgb(n * p, 1.0, 1.0));
        //            }
        //
        //            return ret;
        //        }

        public static Color HsvToColor(double hue, double saturation, double val)
        {
            if (hue == 1.0)
                hue = 0.0;

            const double step = 1.0 / 6.0;
            var vh = hue / step;

            var i = (int)Math.Floor(vh);

            var f = vh - i;
            var p = val * (1.0 - saturation);
            var q = val * (1.0 - saturation * f);
            var t = val * (1.0 - saturation * (1.0 - f));

            double r, g, b;

            switch (i)
            {
                case 0:
                    r = val;
                    g = t;
                    b = p;
                    break;
                case 1:
                    r = q;
                    g = val;
                    b = p;
                    break;
                case 2:
                    r = p;
                    g = val;
                    b = t;
                    break;
                case 3:
                    r = p;
                    g = q;
                    b = val;
                    break;
                case 4:
                    r = t;
                    g = p;
                    b = val;
                    break;
                case 5:
                    r = val;
                    g = p;
                    b = q;
                    break;
                default:
                    r = 0;
                    g = 0;
                    b = 0;
                    break;
            }

            return Color.FromArgb((int)(r * 255), (int)(g * 255), (int)(b * 255));
        }
    }
}
