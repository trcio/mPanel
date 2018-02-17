using System.Drawing;

namespace mPanel.Actions.Weather
{
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
            if (digit < 0 || digit > 9)
                return;

            Digit = digit;
        }

        public void Draw(Graphics g)
        {
            for (var row = 0; row < Size.Height; row++)
                for (var col = 0; col < Size.Width; col++)
                    g.FillRectangle(Numbers[Digit][col + row * Size.Width] == '0' ? Brushes.Black : Fill, X(col), Y(row), 1, 1);
        }

        private int X(int x)
        {
            return Location.X + x;
        }

        private int Y(int y)
        {
            return Location.Y + y;
        }
    }
}
