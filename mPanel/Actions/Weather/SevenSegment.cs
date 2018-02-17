using System.Drawing;

namespace mPanel.Actions.Weather
{
    public class SevenSegment
    {
        public Size SegmentSize { get; set; }
        public Brush Color { get; set; } = Brushes.White;
        public Point Location { get; set; }

        private readonly int[][] DigitSegments;
        private int Digit;

        public SevenSegment()
        {
            DigitSegments = new []
            {
                new [] { 1, 1, 1, 0, 1, 1, 1 },
                new [] { 0, 0, 0, 0, 0, 1, 1 },
                new [] { 1, 0, 1, 1, 1, 1, 0 },
                new [] { 1, 0, 0, 1, 1, 1, 1 },
                new [] { 0, 1, 0, 1, 0, 1, 1 },
                new [] { 1, 1, 0, 1, 1, 0, 1 },
                new [] { 1, 1, 1, 1, 1, 0, 1 },
                new [] { 1, 0, 0, 0, 0, 1, 1 },
                new [] { 1, 1, 1, 1, 1, 1, 1 },
                new [] { 1, 1, 0, 1, 1, 1, 1 }
            };

            SegmentSize = new Size(3, 1);
        }

        public void SetDigit(int digit)
        {
            if (digit < 0 || digit > 9)
                return;

            Digit = digit;
        }

        public void Draw(Graphics g)
        {
            var segments = DigitSegments[Digit];

            g.FillRectangle(segments[0] > 0 ? Color : Brushes.Black, X(SegmentSize.Height), Y(0), SegmentSize.Width, SegmentSize.Height);

            g.FillRectangle(segments[1] > 0 ? Color : Brushes.Black, X(0), Y(SegmentSize.Height), SegmentSize.Height, SegmentSize.Width);

            g.FillRectangle(segments[2] > 0 ? Color : Brushes.Black, X(0), Y(2 * SegmentSize.Height + SegmentSize.Width), SegmentSize.Height, SegmentSize.Width);

            g.FillRectangle(segments[3] > 0 ? Color : Brushes.Black, X(SegmentSize.Height), Y(SegmentSize.Height + SegmentSize.Width), SegmentSize.Width, SegmentSize.Height);

            g.FillRectangle(segments[4] > 0 ? Color : Brushes.Black, X(SegmentSize.Height), Y(2 * SegmentSize.Height + 2 * SegmentSize.Width), SegmentSize.Width, SegmentSize.Height);

            g.FillRectangle(segments[5] > 0 ? Color : Brushes.Black, X(SegmentSize.Height + SegmentSize.Width), Y(SegmentSize.Height), SegmentSize.Height, SegmentSize.Width);

            g.FillRectangle(segments[6] > 0 ? Color : Brushes.Black, X(SegmentSize.Height + SegmentSize.Width), Y(2 * SegmentSize.Height + SegmentSize.Width), SegmentSize.Height, SegmentSize.Width);
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
