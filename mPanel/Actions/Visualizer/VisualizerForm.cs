using System;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;
using CSCore;
using CSCore.DSP;
using CSCore.SoundIn;
using CSCore.Streams;
using mPanel.Matrix;
using Timer = System.Timers.Timer;

namespace mPanel.Actions.Visualizer
{
    public partial class VisualizerForm : Form
    {
        private const int FramesPerSecond = 30;

        private MatrixPanel Matrix => ((ContainerForm) MdiParent)?.Matrix;

        private readonly Timer FrameTimer;
        private readonly Frame Frame;

        private WasapiCapture SoundIn;
        private IWaveSource Source;
        private LineSpectrum Spectrum;

        public VisualizerForm()
        {
            InitializeComponent();

            FrameTimer = new Timer(1000.0 / FramesPerSecond);
            FrameTimer.Elapsed += FrameTimer_Elapsed;

            Frame = new Frame();
        }

        private void FrameTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Frame.Clear(Color.Black);

            Spectrum.Draw();

            Matrix.SendFrame(Frame);
        }

        private void VisualizerForm_Load(object sender, EventArgs e)
        {
            SoundIn = new WasapiLoopbackCapture();
            SoundIn.Initialize();

            var soundInSource = new SoundInSource(SoundIn);

            SetupSource(soundInSource.ToSampleSource());

            var buffer = new byte[Source.WaveFormat.BytesPerSecond / 2];
            soundInSource.DataAvailable += (o, args) =>
            {
                while (Source.Read(buffer, 0, buffer.Length) > 0) { }
            };

            SoundIn.Start();
        }

        private void SetupSource(ISampleSource source)
        {
            var spectrumProvider = new BasicSpectrumProvider(source.WaveFormat.Channels, source.WaveFormat.SampleRate, FftSize.Fft4096);

            Spectrum = new LineSpectrum(Frame, FftSize.Fft4096, spectrumProvider)
            {
                UseAverage = true,
                IsXLogScale = true,
                ScalingStrategy = ScalingStrategy.Decibel
            };

            var notificationSource = new SingleBlockNotificationStream(source);
            notificationSource.SingleBlockRead += (sender, args) => spectrumProvider.Add(args.Left, args.Right);

            Source = notificationSource.ToWaveSource(16);
        }

        private void enableButton_Click(object sender, EventArgs e)
        {
            if (FrameTimer.Enabled)
            {
                FrameTimer.Stop();
                enableButton.Text = "Enable";
            }
            else
            {
                FrameTimer.Start();
                enableButton.Text = "Disable";
            }
        }

        private void VisualizerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrameTimer.Stop();
            Matrix.Clear();

            SoundIn?.Stop();
            SoundIn?.Dispose();
            Source?.Dispose();
        }

        private void averageCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Spectrum.UseAverage = averageCheckBox.Checked;
        }

        private void minimumUpDown_ValueChanged(object sender, EventArgs e)
        {
            Spectrum.SetMinimumFrequency((int) minimumUpDown.Value);
        }

        private void maximumUpDown_ValueChanged(object sender, EventArgs e)
        {
            Spectrum.SetMaximumFrequency((int) maximumUpDown.Value);
        }

        private void amplifierUpDown_ValueChanged(object sender, EventArgs e)
        {
            Spectrum.Amplifier = (double) amplifierUpDown.Value;
        }
    }
}
