using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Control_Panel.Matrix;

namespace Control_Panel.Actions
{
    public partial class BasicForm : Form
    {
        private MatrixPanel Matrix => ((ContainerForm) MdiParent)?.Matrix;

        public BasicForm()
        {
            InitializeComponent();
        }

        private void BasicForm_Load(object sender, EventArgs e)
        {
            colorComboBox.SelectedIndex = 3;
        }

        private void brightnessBar_Scroll(object sender, EventArgs e)
        {
            brightnessButton.Text = $"Set Brightness - {brightnessBar.Value}";
        }

        private void brightnessButton_Click(object sender, EventArgs e)
        {
            Matrix.SetBrightness((byte) brightnessBar.Value);
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            using (var frame = new Frame())
            {
                frame.Clear(colorComboBox.SelectedColor);

                Matrix.SendFrame(frame);
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            Matrix.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var frame = new Frame())
            using (var gradient = new LinearGradientBrush(frame.Rectangle, Color.Purple, Color.Yellow, LinearGradientMode.Horizontal))
            {
                frame.Graphics.FillRectangle(gradient, frame.Rectangle);

                Matrix.SendFrame(frame);
            }

        }
    }
}
