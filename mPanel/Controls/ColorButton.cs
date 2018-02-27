using System;
using System.Drawing;
using System.Windows.Forms;

namespace mPanel.Controls
{
    public class ColorButton : Button
    {
        private readonly ColorDialog Dialog;

        public Color SelectedColor
        {
            get => Dialog.Color;
            set
            {
                Dialog.Color = value;
                BackColor = value;
                ForeColor = value == Color.Black ? Color.White : Color.Black;
            }
        }

        public ColorButton()
        {
            Dialog = new ColorDialog
            {
                AllowFullOpen = true,
                SolidColorOnly = true
            };
        }

        protected override void OnClick(EventArgs e)
        {
            if (Dialog.ShowDialog() == DialogResult.OK)
            {
                SelectedColor = Dialog.Color;
            }
            
            base.OnClick(e);
        }
    }
}
