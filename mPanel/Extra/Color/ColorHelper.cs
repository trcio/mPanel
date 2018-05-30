using System;
using SystemColor = System.Drawing.Color;

namespace mPanel.Extra.Color
{
    public class ColorHelper
    {
        public static SystemColor HsvToColor(byte hue)
        {
            return HsvToColor(hue / 255.0, 1.0, 1.0);
        }

        public static SystemColor HsvToColor(double hue, double saturation, double value)
        {
            if (hue > 0.999)
                hue = 0.0;

            const double step = 1.0 / 6.0;
            var vh = hue / step;

            var i = (int) Math.Floor(vh);

            var f = vh - i;
            var p = value * (1.0 - saturation);
            var q = value * (1.0 - saturation * f);
            var t = value * (1.0 - saturation * (1.0 - f));

            double r, g, b;

            switch (i)
            {
                case 0:
                    r = value;
                    g = t;
                    b = p;
                    break;
                case 1:
                    r = q;
                    g = value;
                    b = p;
                    break;
                case 2:
                    r = p;
                    g = value;
                    b = t;
                    break;
                case 3:
                    r = p;
                    g = q;
                    b = value;
                    break;
                case 4:
                    r = t;
                    g = p;
                    b = value;
                    break;
                case 5:
                    r = value;
                    g = p;
                    b = q;
                    break;
                default:
                    r = 0;
                    g = 0;
                    b = 0;
                    break;
            }

            return SystemColor.FromArgb((int) (r * 255), (int) (g * 255), (int) (b * 255));
        }
    }
}
