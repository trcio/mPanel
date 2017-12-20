using System;
using System.Drawing;
using System.Windows.Forms;

namespace Control_Panel.Matrix
{
    public class PanelPreview : Panel
    {
        private const int PixelDataLength = 3;

        public int PanelWidth { get; set; }
        public int PanelHeight { get; set; }
        public int PixelSize { get; set; }
        public int GapSize { get; set; }
        public byte[] FrameBuffer { get; set; }

        
        public PanelPreview()
        {
            PanelWidth = 15;
            PanelHeight = 15;
            PixelSize = 3;
            GapSize = 1;

            FrameBuffer = new byte[PanelWidth * PanelHeight];
        }

        public void UpdatePreview(byte[] data)
        {
            if (data?.Length != PanelWidth * PanelHeight * 3)
                return;

            Buffer.BlockCopy(data, 0, FrameBuffer, 0, data.Length);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Width = PanelWidth * PixelSize + 14 * GapSize;
            Height = PanelHeight * PixelSize + 14 * GapSize;

            if (FrameBuffer == null)
                return;

            var g = e.Graphics;

            var count = 0;
            var x = 0;
            var y = 0;

            for (var i = 0; i < FrameBuffer.Length; i += PixelDataLength)
            {
                count++;

                var brush = new SolidBrush(Color.FromArgb(FrameBuffer[i], FrameBuffer[i + 1], FrameBuffer[i + 2]));
                g.FillRectangle(brush, x, y, PixelSize, PixelSize);

                x += PixelSize + GapSize;

                if (count < 15)
                    continue;

                count = 0;
                x = 0;
                y += PixelSize + GapSize;
            }
        }
    }
}
