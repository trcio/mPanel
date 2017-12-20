using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

/***LEAVE THIS HERE***
 * http://patpositron.com
 * Made by PatPositron on HF
 * Date: 6/26/13
 * Reuse as needed
***LEAVE THIS HERE***/

namespace Control_Panel
{
    class ColorComboBox : ComboBox
    {
        private Rectangle RB, BRDR, BRF;
        private SolidBrush HL, CLR, BK;
        private bool _showAll = true;
        private List<Color> _colors = new List<Color>() { Color.Red, Color.Green, Color.Blue };

        [Browsable(false)]
        public Color SelectedColor
        {
            get
            {
                if (base.Text.Any(char.IsDigit))
                    return _colors[base.SelectedIndex];
                else
                    return Color.FromName(base.Text);
            }
        }
        [Browsable(false)]
        public string SelectedColorString
        {
            get { return base.Text; }
        }

        public bool ShowAllColors
        {
            get { return _showAll; }
            set { _showAll = value; CCInvalidate(); }
        }

        public List<Color> Colors
        {
            get { return _colors; }
            set { _colors = value; CCInvalidate(); }
        }

        private string between(string source, string startX, string endX)
        {
            int startIndex = source.IndexOf(startX) + startX.Count();
            try { return source.Substring(startIndex, source.IndexOf(endX, startIndex) - startIndex).Trim(); }
            catch { return String.Empty; }
        }

        private void CCInvalidate()
        {
            base.Items.Clear();

            if (_showAll)
            {
                Type colorType = typeof(System.Drawing.Color);
                PropertyInfo[] propInfos = colorType.GetProperties(BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.Public);
                foreach (PropertyInfo propInfo in propInfos)
                {
                    base.Items.Add(propInfo.Name);
                }
            }
            else
            {
                foreach (Color clr in _colors)
                {
                    if (between(clr.ToString(), "Color [", "]").Any(char.IsDigit))
                    {
                        base.Items.Add(clr.ToArgb().ToString());
                    }
                    else
                        base.Items.Add(between(clr.ToString(), "Color [", "]"));
                }
            }
        }

        public void AddColor(Color c)
        {
            _colors.Add(c);
            CCInvalidate();
        }

        public void AddColorRange(Color[] c)
        {
            _colors.AddRange(c);
            CCInvalidate();
        }

        public ColorComboBox()
        {
            SetStyle(ControlStyles.Selectable, false);
            DropDownStyle = ComboBoxStyle.DropDownList;
            DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            Size = new Size(120, 21);

            HL = new SolidBrush(SystemColors.Highlight);
            BK = new SolidBrush(BackColor);
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                string name;
                RB = e.Bounds;
                BRDR = new Rectangle(RB.X + 2, RB.Y + 2, RB.Width - (RB.Width - 10), RB.Height - (RB.Height - 10));
                BRF = new Rectangle(RB.X + 2, RB.Y + 2, RB.Width - (RB.Width - 10), RB.Height - (RB.Height - 10));
                CLR = new SolidBrush(ColorTranslator.FromHtml(GetItemText(Items[e.Index])));

                if (GetItemText(Items[e.Index]).Any(char.IsDigit))
                    name = "Custom";
                else
                    name = GetItemText(Items[e.Index]);

                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    e.Graphics.FillRectangle(HL, RB);
                    e.Graphics.FillRectangle(CLR, BRF);
                    e.Graphics.DrawString(name, e.Font, Brushes.Black, RB.X + 14, RB.Y + 1);
                    e.Graphics.DrawRectangle(Pens.Black, BRDR);
                }
                else
                {
                    e.Graphics.FillRectangle(BK, RB);
                    e.Graphics.DrawString(name, e.Font, Brushes.Black, RB.X + 14, RB.Y + 1);
                    e.Graphics.FillRectangle(CLR, BRF);
                    e.Graphics.DrawRectangle(Pens.Black, BRDR);
                }
            }
        }
    }
}