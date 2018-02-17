using System.Drawing;
using System.Windows.Forms;
using mPanel.Matrix;

namespace mPanel.Actions.Weather
{
    public partial class WeatherForm : Form
    {
        private MatrixPanel Matrix => ((ContainerForm) MdiParent)?.Matrix;

        private readonly Frame Frame;

        public WeatherForm()
        {
            InitializeComponent();

            Frame = new Frame();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            var digit = new NumberGrid {Location = new Point(4, 5)};
            var digit2 = new NumberGrid {Location = new Point(8, 5)};

            digit.SetDigit((int) numericUpDown1.Value);
            digit2.SetDigit((int) numericUpDown1.Value);

            digit.Draw(Frame.Graphics);
            digit2.Draw(Frame.Graphics);

            Matrix.SendFrame(Frame);
        }
    }
}
