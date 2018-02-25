using System;
using System.Drawing;
using System.Windows.Forms;
using mPanel.Matrix;

namespace mPanel.Controls
{
    public sealed class FrameEditor : Control
    {
        private static int PixelDataLength => MatrixPanel.PixelDataLength;

        private byte[] FrameBuffer;
        private int SelectedIndex;

        public int PanelWidth => MatrixPanel.Width;
        public int PanelHeight => MatrixPanel.Height;
        public int PixelSize { get; set; }
        public int GapSize { get; set; }
        public Frame CurrentFrame { get; set; }

        public event EventHandler<ChangeArgs> PixelChanged;

        public FrameEditor()
        {
            DoubleBuffered = true;

            FrameBuffer = new byte[PanelWidth * PanelHeight * PixelDataLength];
        }

        private void OnPixelChanged(ChangeArgs e)
        {
            if (CurrentFrame == null)
                return;

            PixelChanged?.Invoke(this, e);
            FrameBuffer = CurrentFrame.GetBytes();
            Invalidate();
        }

        public void SetFrame(Frame frame)
        {
            CurrentFrame = frame;
            FrameBuffer = frame.GetBytes();
            Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.X < 0 || e.Y < 0 || e.X >= Width || e.Y >= Height)
            {
                SelectedIndex = -1;
                return;
            }

            var x = e.X / (Width / PanelWidth);
            var y = e.Y / (Height / PanelHeight);
            var index = x + PanelWidth * y;

            SelectedIndex = index;

            OnPixelChanged(new ChangeArgs(e.Button, new Point(x, y)));
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            OnMouseMove(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            SelectedIndex = -1;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(BackColor);

            var index = 0;
            var x = 0;
            var y = 0;

            for (var i = 0; i < FrameBuffer.Length; i += PixelDataLength)
            {
                var color = Color.FromArgb(FrameBuffer[i], FrameBuffer[i + 1], FrameBuffer[i + 2]);
                
                using (var brush = new SolidBrush(color))
                {
                    if (SelectedIndex == index)
                    {
                        g.FillRectangle(Brushes.White, x, y, PixelSize, PixelSize);
                        g.FillRectangle(brush, x + PixelSize / 4, y + PixelSize / 4, PixelSize - PixelSize / 2, PixelSize - PixelSize / 2);
                    }
                    else
                        g.FillRectangle(brush, x, y, PixelSize, PixelSize);
                }

                g.DrawRectangle(Pens.Black, x, y, PixelSize - 1, PixelSize - 1);

                x += PixelSize + GapSize;
                index++;

                if (index % PanelWidth != 0)
                    continue;

                x = 0;
                y += PixelSize + GapSize;
            }
        }

        public class ChangeArgs : EventArgs
        {
            public MouseButtons Button { get; }
            public Point Pixel { get; }

            public ChangeArgs(MouseButtons button, Point pixel)
            {
                Button = button;
                Pixel = pixel;
            }
        }
    }
}
