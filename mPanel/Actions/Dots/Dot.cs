using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using mPanel.Matrix;
using mPanel.Extra.Color;

namespace mPanel.Actions.Dots
{
    public class Dot
    {
        protected static readonly Random Random = new Random();
        protected readonly Frame Frame;

        public byte Alpha { get; set; }
        public int Step { get; set; }
        public Color Color { get; set; }
        public Point Location { get; set; }
        
        public Dot(Frame frame, Color color)
        {
            Frame = frame;
            Color = color;
            Alpha = (byte) Random.Next(byte.MaxValue);
            Step = 20;

            Randomize();
        }

        public void Randomize()
        {
            Location = new Point(Random.Next(Frame.Width), Random.Next(Frame.Height));
        }

        public virtual void Draw()
        {
            Alpha += (byte) Step;

            using (var b = new SolidBrush(Color.FromArgb(Alpha, Color)))
            {
                Frame.Graphics.FillRectangle(b, Location.X, Location.Y, 1, 1);
            }

            if (Step + Alpha > byte.MaxValue)
                Randomize();
        }
    }

    public class ChaseDot : Dot
    {
        private bool Chase;
        private bool GoingDown;

        public int Length { get; set; }
        
        public ChaseDot(Frame frame, Color color) : base(frame, color)
        {
            Step = 1;
            Length = 1;
            Chase = false;
            Randomize();
        }

        public new void Randomize()
        {
            GoingDown = Random.NextDouble() > 0.5;
            Location = new Point(Random.Next(Frame.Width), Random.Next(GoingDown ? 0 : Frame.Height / 3 * 2, GoingDown ? Frame.Height / 3 : Frame.Height));
            Color = ColorHelper.HsvToColor((byte) Random.Next(byte.MaxValue));
        }

        public override void Draw()
        {
            if (GoingDown)
                DrawDown();
            else
                DrawUp();
        }

        private void DrawUp()
        {
            using (var b = new LinearGradientBrush(new Rectangle(Location.X, Location.Y - 1, 1, Length + 1), Color, Color.Black, LinearGradientMode.Vertical))
            {
                if (Chase)
                {
                    Frame.Graphics.FillRectangle(b, Location.X, Location.Y, 1, Length);
                    Length -= Step;
                }
                else
                {
                    Frame.Graphics.FillRectangle(b, Location.X, Location.Y, 1, Length);
                    Location = new Point(Location.X, Location.Y - Step);
                    Length += Step;
                }
            }

            if (Length < 1)
            {
                Randomize();
                Length = 1;
                Chase = false;
            }
            else if (Location.Y < 0)
                Chase = true;
        }

        private void DrawDown()
        {
            using (var b = new LinearGradientBrush(new Rectangle(Location.X, Location.Y - 1, 1, Length + 1), Color.Black, Color, LinearGradientMode.Vertical))
            {
                if (Chase)
                {
                    Frame.Graphics.FillRectangle(b, Location.X, Location.Y, 1, Length);
                    Location = new Point(Location.X, Location.Y + Step);
                }
                else
                {
                    Frame.Graphics.FillRectangle(b, Location.X, Location.Y, 1, Length);
                    Length += Step;
                }
            }

            if (Location.Y > Frame.Height)
            {
                Randomize();
                Length = 1;
                Chase = false;
            }
            else if (Location.Y + Length > Frame.Height)
                Chase = true;
        }
    }
}
