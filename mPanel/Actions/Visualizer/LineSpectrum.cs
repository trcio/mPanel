using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using CSCore.DSP;
using mPanel.Matrix;

// LineSpectrum repurposed from a CSCore sample project

namespace mPanel.Actions.Visualizer
{
    public sealed class LineSpectrum : Spectrum
    {
        private readonly Frame Frame;

        public double Amplifier { get; set; }

        public LineSpectrum(Frame frame, FftSize size, BasicSpectrumProvider provider)
        {
            Frame = frame;
            FftSize = (int) size;
            MaxFftIndex = FftSize / 2 - 1;

            SpectrumProvider = provider;

            Amplifier = 1;

            MinimumFrequency = 20;
            MaximumFrequency = 20000;

            SpectrumResolution = MatrixPanel.Width;

            UpdateFrequencyMapping();
        }

        public void SetMinimumFrequency(int min)
        {
            MinimumFrequency = min;
            UpdateFrequencyMapping();
        }

        public void SetMaximumFrequency(int max)
        {
            MaximumFrequency = max;
            UpdateFrequencyMapping();
        }

        public void Draw()
        {
            var fftBuffer = new float[FftSize];

            if (!SpectrumProvider.GetFftData(fftBuffer, this))
                return;

            var spectrumPoints = CalculateSpectrumPoints(MatrixPanel.Height, fftBuffer);

            for (var x = 0; x < spectrumPoints.Count; x++)
            {
                var height = (int) Math.Round(spectrumPoints[x].Value * Amplifier);

                using (var brush = new LinearGradientBrush(new Rectangle(x, 0, 1, MatrixPanel.Height), Color.Red, Color.Green, LinearGradientMode.Vertical))
                {
                    Frame.Graphics.FillRectangle(brush, x, MatrixPanel.Height - height, 1, height);
                }
            }
        }
    }
}
