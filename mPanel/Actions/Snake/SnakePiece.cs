using System;
using System.Drawing;
using mPanel.Matrix;
using mPanel.Misc;

namespace mPanel.Actions.Snake
{
    public class SnakePiece
    {
        private readonly Frame Frame;

        public Color Fill { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public SnakePiece(Frame frame, Color fill, int x, int y)
        {
            Frame = frame;
            Fill = fill;
            X = x;
            Y = y;

            FixCoordinates();
        }

        private void FixCoordinates()
        {
            if (X > MatrixPanel.Width - 1)
                X = 0;
            else if (X < 0)
                X = MatrixPanel.Width - 1;

            if (Y > MatrixPanel.Height - 1)
                Y = 0;
            else if (Y < 0)
                Y = MatrixPanel.Height - 1;
        }

        public void CopyCoordinates(SnakePiece piece)
        {
            X = piece.X;
            Y = piece.Y;

            FixCoordinates();
        }

        public void Move(Direction direction)
        {
            X += direction.DeltaX;
            Y += direction.DeltaY;

            FixCoordinates();
        }

        public double DistanceFrom(SnakePiece piece)
        {
            return Math.Sqrt(Math.Pow(piece.X - X, 2) + Math.Pow(piece.Y - Y, 2));
        }

        public double DistanceFrom(FoodPiece piece)
        {
            return Math.Sqrt(Math.Pow(piece.X - X, 2) + Math.Pow(piece.Y - Y, 2));
        }

        public void Draw()
        {
            using (var fill = new SolidBrush(Fill))
            {
                Frame.Graphics.FillRectangle(fill, X, Y, 1, 1);
            }
        }
    }
}
