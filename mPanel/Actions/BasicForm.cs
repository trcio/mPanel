using System;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;
using mPanel.Extra.Color;
using mPanel.Extra.Noise;
using Timer = System.Timers.Timer;
using mPanel.Matrix;

namespace mPanel.Actions
{
    public partial class BasicForm : Form
    {
        private const int FramesPerSecond = 30;

        private MatrixPanel Matrix => ((ContainerForm) MdiParent)?.Matrix;

        private readonly Frame Frame;
        private readonly Timer StandbyTimer;
        private readonly PaletteNoise Noise;

        public BasicForm()
        {
            InitializeComponent();

            Frame = new Frame();

            StandbyTimer = new Timer(1000.0 / FramesPerSecond);
            StandbyTimer.Elapsed += StandbyTimer_Elapsed;

            Noise = new PaletteNoise();
        }

        private void StandbyTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Noise.FillNoise();

            Frame.Clear(Color.Black);

            for (var x = 0; x < MatrixPanel.Width; x++)
            for (var y = 0; y < MatrixPanel.Height; y++)
            {
                Frame.SetPixel(x, y, Noise.GetColorFromPalette(ColorPalette.StandbyRainbow, x, y));
            }

            Noise.ColorOffset++;

            Matrix.SendFrame(Frame);
        }

        #region Form Events

        private void BasicForm_Load(object sender, EventArgs e)
        {
            Matrix.Clear();

            colorComboBox.SelectedIndex = 3;
        }

        private void BasicForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Matrix.Standby(32);
        }

        private void brightnessBar_Scroll(object sender, EventArgs e)
        {
            brightnessButton.Text = $"Set Brightness - {brightnessTrackBar.Value}";
        }

        private void brightnessButton_Click(object sender, EventArgs e)
        {
            Matrix.SetBrightness((byte) brightnessTrackBar.Value);
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
            if (StandbyTimer.Enabled)
            {
                StandbyTimer.Stop();
                standbyButton.Text = "Enable Standby";
            }
            else
            {
                StandbyTimer.Start();
                standbyButton.Text = "Disable Standby";
            }
        }

        #endregion
    }
}
