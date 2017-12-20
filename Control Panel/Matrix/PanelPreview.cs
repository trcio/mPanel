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

            Width = PanelWidth * PixelSize + 14 * GapSize;
            Height = PanelHeight * PixelSize + 14 * GapSize;
        }

        public void SetPreview(byte[] data)
        {
            if (data?.Length != PanelWidth * PanelHeight * 3)
                return;

            FrameBuffer = data;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;

            var x = 0;
            var y = 0;

            if (FrameBuffer == null)
                return;

            for (var i = 0; i < FrameBuffer.Length; i += PixelDataLength)
            {
                // draw pixel
                var brush = new SolidBrush(Color.FromArgb(FrameBuffer[i], FrameBuffer[i + 1], FrameBuffer[i + 2]));
                g.FillRectangle(brush, x, y, PixelSize, PixelSize);

                x += PixelSize + GapSize;

                if (i % PanelWidth * PixelDataLength != 0)
                    continue;

                y += PixelSize + GapSize;
                x = 0;
            }
        }
    }
}
