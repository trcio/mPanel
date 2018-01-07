using System.Drawing;
using mPanel.Matrix;

namespace mPanel.Actions.Pong
{
    public class Paddle
    {
        private readonly Frame Frame;

        public Color Fill { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int DeltaX { get; set; }

        public Paddle(Frame frame, Color fill, int x, int y, int width)
        {
            Frame = frame;
            Fill = fill;
            X = x;
            Y = y;
            Width = width;

            FixCoordinates();
        }

        public void Move()
        {
            X += DeltaX;

            FixCoordinates();
        }

        public void FixCoordinates()
        {
            if (X > MatrixPanel.Width - Width)
                X = MatrixPanel.Width - Width;
            else if (X < 0)
                X = 0;
        }

        public void Draw()
        {
            using (var fill = new SolidBrush(Fill))
            {
                Frame.Graphics.FillRectangle(fill, X, Y, Width, 1);
            }
        }
    }
}
