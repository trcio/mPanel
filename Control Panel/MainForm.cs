using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;
using Control_Panel.Matrix;

namespace Control_Panel
{
    public partial class MainForm : Form
    {
        private readonly MatrixPanel Matrix;

        private byte RainbowHue;

        public MainForm()
        {
            InitializeComponent();
            Matrix = new MatrixPanel(15, 15);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            serialPorts.Items.AddRange((object[]) SerialPort.GetPortNames().AsEnumerable());

            if (serialPorts.Items.Count > 0)
                serialPorts.SelectedIndex = 0;

            colorComboBox.SelectedIndex = 3;

            ToggleActions(false);
        }

        private void ToggleActions(bool state)
        {
            foreach (Control control in actionBox.Controls)
                control.Enabled = state;
        }


        private void connectButton_Click(object sender, EventArgs e)
        {
            if (Matrix.Connected)
            {
                Matrix.Disconnect();
                ToggleActions(false);
                connectButton.Text = "Connect";
            }
            else
            {
                if (!Matrix.Connect(serialPorts.Text))
                    return;

                Matrix.Clear();
                ToggleActions(true);
                connectButton.Text = "Disconnect";
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Matrix.Clear();
            Matrix.Disconnect();
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            Matrix.SetFrame(colorComboBox.SelectedColor);
            Matrix.PushFrame();
//            MatrixPanel.Clear(colorComboBox.SelectedColor);
        }

        private void brightnessButton_Click(object sender, EventArgs e)
        {
            Matrix.SetBrightness((byte) brightnessBar.Value);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            Matrix.Clear();
        }

        private void brightnessBar_Scroll(object sender, EventArgs e)
        {
            brightnessButton.Text = $"Set Brightness - {brightnessBar.Value}";
        }

        private void rainbowButton_Click(object sender, EventArgs e)
        {
            rainbowTimer.Enabled = !rainbowTimer.Enabled;
        }

        private void rainbowTimer_Tick(object sender, EventArgs e)
        {
//            var c = new Spectrum.Color.HSV(RainbowHue,1.0, 1.0).ToRGB();
//
//            MatrixPanel.SetFrame(Color.FromArgb(c.R, c.G, c.B));

            Matrix.SetFrame(ColorUtils.HsvToColor(RainbowHue/255.0, 1.0, 1.0));
            Matrix.PushFrame();

            RainbowHue++;
        }

        private void rainbowUpDown_ValueChanged(object sender, EventArgs e)
        {
            rainbowTimer.Interval = (int) rainbowUpDown.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frame = new Frame();
            var g = frame.G;

//            g.FillRectangle(new LinearGradientBrush(frame.Rectangle, Color.Green, Color.Red, LinearGradientMode.Vertical), frame.Rectangle);
            g.FillRectangle(Brushes.Blue, frame.Rectangle);

            g.DrawRectangle(Pens.Green, frame.Rectangle);

            Matrix.SetFrame(frame);
            Matrix.PushFrame();
        }
    }
}
