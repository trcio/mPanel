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
        private KeyEventArgs KeyArgs;

        public int PanelWidth => MatrixPanel.Width;
        public int PanelHeight => MatrixPanel.Height;
        public int PixelSize { get; set; }
        public int GapSize { get; set; }
        public Frame SelectedFrame { get; set; }

        public event EventHandler<ActionEventArgs> Action;

        public FrameEditor()
        {
            DoubleBuffered = true;

            FrameBuffer = new byte[PanelWidth * PanelHeight * PixelDataLength];
            KeyArgs = new KeyEventArgs(Keys.None);
        }

        private void OnPixelChanged(ActionEventArgs e)
        {
            if (SelectedFrame == null)
                return;

            Action?.Invoke(this, e);
            FrameBuffer = SelectedFrame.GetBytes();
            Invalidate();
        }

        public void SetFrame(Frame frame)
        {
            SelectedFrame = frame;
            FrameBuffer = frame.GetBytes();
            Invalidate();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            KeyArgs = e;
            base.OnKeyDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            KeyArgs = e;
            base.OnKeyUp(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            Focus();

            if (e.X < 0 || e.Y < 0 || e.X >= Width || e.Y >= Height)
            {
                SelectedIndex = -1;
                return;
            }

            var x = e.X / (Width / PanelWidth);
            var y = e.Y / (Height / PanelHeight);
            var index = x + PanelWidth * y;

            SelectedIndex = index;

            OnPixelChanged(new ActionEventArgs(e, KeyArgs, new Point(x, y)));
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

        public class ActionEventArgs : EventArgs
        {
            public MouseEventArgs Mouse { get; }
            public KeyEventArgs Keys { get; }
            public Point Pixel { get; }

            public ActionEventArgs(MouseEventArgs mouse, KeyEventArgs keys, Point pixel)
            {
                Mouse = mouse;
                Keys = keys;
                Pixel = pixel;
            }
        }
    }
}
