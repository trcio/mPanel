using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace mPanel.Controls
{
    public sealed class ColorComboBox : ComboBox
    {
        private readonly SolidBrush HighlightBrush;
        private readonly SolidBrush BackColorBrush;

        [Browsable(false)]
        public Color SelectedColor => Color.FromName(Text);

        public ColorComboBox()
        {
            DropDownStyle = ComboBoxStyle.DropDownList;
            DrawMode = DrawMode.OwnerDrawFixed;
            DoubleBuffered = true;

            HighlightBrush = new SolidBrush(SystemColors.Highlight);
            BackColorBrush = new SolidBrush(BackColor);

            AddSystemColors();
        }

        private void AddSystemColors()
        {
            var colors = typeof(Color).GetProperties(BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.Public);

            foreach (var color in colors)
            {
                Items.Add(color.Name);
            }
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;

            var g = e.Graphics;
            var text = GetItemText(Items[e.Index]);

            var b = e.Bounds;
            var colorBounds = new Rectangle(b.X + 2, b.Y + 3, b.Width - (b.Width - 10), b.Height - (b.Height - 10));

            var selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;

            using (var color = new SolidBrush(Color.FromName(text)))
            {
                g.FillRectangle(selected ? HighlightBrush : BackColorBrush, b);
                g.FillRectangle(color, colorBounds);
                g.DrawRectangle(Pens.Black, colorBounds);
                g.DrawString(text, e.Font, Brushes.Black, b.X + 16, b.Y + 0.5f);
            }
        }
    }
}
