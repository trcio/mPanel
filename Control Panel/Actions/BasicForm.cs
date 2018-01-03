using System;
using System.Windows.Forms;
using Control_Panel.Matrix;

namespace Control_Panel.Actions
{
    public partial class BasicForm : Form
    {
        private MatrixPanel Matrix => ((ContainerForm) MdiParent)?.Matrix;

        private readonly Frame Frame;

        public BasicForm()
        {
            InitializeComponent();

            Frame = new Frame();
        }

        private void BasicForm_Load(object sender, EventArgs e)
        {
            Matrix.Clear();

            colorComboBox.SelectedIndex = 3;
        }

        private void BasicForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Matrix.Standby();
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
            Frame.Clear(colorComboBox.SelectedColor);

            Matrix.SendFrame(Frame);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            Matrix.Clear();
        }

        private void standbyButton_Click(object sender, EventArgs e)
        {
            Matrix.Standby();
        }
    }
}
