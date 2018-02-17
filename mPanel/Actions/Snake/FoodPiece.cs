using System;
using System.Drawing;
using mPanel.Matrix;
using mPanel.Extra;

namespace mPanel.Actions.Snake
{
    public class FoodPiece
    {
        public static readonly Random Random = new Random();

        private readonly Frame Frame;
        private byte Hue;

        public Color Fill { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public FoodPiece(Frame frame)
        {
            Frame = frame;

            Randomize();
        }

        public void Randomize()
        {
            Hue += 255 / 14;
            Fill = ColorHelper.HsvToColor(Hue);
            X = Random.Next(0, MatrixPanel.Width);
            Y = Random.Next(0, MatrixPanel.Height);
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
