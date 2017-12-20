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
            Matrix.FrameHook += Matrix_FrameHook;
        }

        private void Matrix_FrameHook(object sender, byte[] e)
        {
            panelPreview.UpdatePreview(e);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            serialPorts.Items.AddRange((object[]) SerialPort.GetPortNames().AsEnumerable());

            if (serialPorts.Items.Count > 0)
                serialPorts.SelectedIndex = 0;

            colorComboBox.SelectedIndex = 3;

            ToggleActions(false);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Matrix.Disconnect();
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
                if (string.IsNullOrWhiteSpace(serialPorts.Text) || !Matrix.Connect(serialPorts.Text))
                    return;

                Matrix.Clear();
                ToggleActions(true);
                connectButton.Text = "Disconnect";
            }
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

        private void brightnessBar_Scroll(object sender, EventArgs e)
        {
            brightnessButton.Text = $"Set Brightness - {brightnessBar.Value}";
        }

        private void brightnessButton_Click(object sender, EventArgs e)
        {
            Matrix.SetBrightness((byte) brightnessBar.Value);
        }

        private void rainbowButton_Click(object sender, EventArgs e)
        {
            rainbowTimer.Enabled = !rainbowTimer.Enabled;

            rainbowButton.Text = rainbowTimer.Enabled ? "Rainbow Cycle - Off" : "Rainbow Cycle - On";
        }

        private void rainbowTimer_Tick(object sender, EventArgs e)
        {
            using (var frame = new Frame())
            {
                frame.Clear(ColorUtils.HsvToColor(RainbowHue / 255.0, 1.0, 1.0));
                Matrix.SendFrame(frame);
            }

            RainbowHue++;
        }

        private void rainbowUpDown_ValueChanged(object sender, EventArgs e)
        {
            rainbowTimer.Interval = (int) rainbowUpDown.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var frame = new Frame())
            {
                var g = frame.Graphics;

                g.FillRectangle(new LinearGradientBrush(Frame.Rectangle, Color.Red, Color.Green, LinearGradientMode.Vertical), Frame.Rectangle);

                g.DrawRectangle(Pens.Blue, 0, 0, Frame.Width - 1, Frame.Height - 1);

                Matrix.SendFrame(frame);
            }
        }
    }
}
