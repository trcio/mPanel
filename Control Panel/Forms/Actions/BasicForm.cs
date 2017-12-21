using System;
using System.Windows.Forms;
using Control_Panel.Matrix;

namespace Control_Panel.Forms.Actions
{
    public partial class BasicForm : Form
    {
        private MatrixPanel Matrix => ((ContainerForm)MdiParent)?.Matrix;

        public BasicForm()
        {
            InitializeComponent();
        }

        private void brightnessBar_Scroll(object sender, EventArgs e)
        {
            brightnessButton.Text = $"Set Brightness - {brightnessBar.Value}";
        }

        private void brightnessButton_Click(object sender, EventArgs e)
        {
            Matrix.SetBrightness((byte) brightnessBar.Value);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            Matrix.Clear();
        }

    }
}
