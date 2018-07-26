using System;
using System.Drawing;
using mPanel.Matrix;

namespace mPanel.Actions.Weather
{
    public class TemperatureDisplay
    {
        private readonly Frame Frame;
        private readonly NumberSegment Digit1, Digit2;

        public int Temperature { get; private set; }

        public TemperatureDisplay(Frame frame)
        {
            Frame = frame;

            Digit1 = new NumberSegment { Location = new Point(4, 5) };
            Digit2 = new NumberSegment { Location = new Point(8, 5) };
        }

        public void Draw()
        {
            if (Temperature < 0)
                Frame.Graphics.DrawLine(Pens.White, 2, 7, 3, 7);
            else if (Temperature > 99)
                Frame.Graphics.DrawLine(Pens.White, 3, 5, 3, 9);

            var offset = Temperature >= 0 && Temperature <= 99 ? 0 : 1;

            Digit1.Draw(Frame.Graphics, offset);
            Digit2.Draw(Frame.Graphics, offset);
        }

        public void SetTemperature(int temperature)
        {
            if (temperature <= 99)
            {
                Digit1.SetDigit(temperature / 10);
                Digit2.SetDigit(temperature % 10);
            }
            else if (temperature > 99)
            {
                Digit1.SetDigit(temperature / 10 % 10);
                Digit2.SetDigit(temperature % 10);
            }

            Temperature = temperature;
        }
    }

    public class NumberSegment
    {
        private readonly Size Size;
        private readonly string[] Numbers;
        private int Digit;

        public Brush Fill { get; set; }
        public Point Location { get; set; }

        public NumberSegment()
        {
            Fill = Brushes.White;
            Size = new Size(3, 5);
            Numbers = new[]
            {
                "111101101101111",
                "010010010010010",
                "111001111100111",
                "111001111001111",
                "101101111001001",
                "111100111001111",
                "111100111101111",
                "111001001001001",
                "111101111101111",
                "111101111001001"
            };
        }

        public void SetDigit(int digit)
        {
            digit = Math.Abs(digit);

            if (digit < 0 || digit > 9)
                return;

            Digit = digit;
        }

        public void Draw(Graphics g, int offsetX)
        {
            for (var row = 0; row < Size.Height; row++)
                for (var col = 0; col < Size.Width; col++)
                    g.FillRectangle(Numbers[Digit][col + row * Size.Width] == '0' ? Brushes.Black : Fill, col + offsetX + Location.X, row + Location.Y, 1, 1);
        }
    }
}
