using System;
using System.Drawing;
using System.Linq.Expressions;
using System.Net.Configuration;
using Control_Panel.Matrix;
using Control_Panel.Misc;
using CSCore.DSP;

// LineSpectrum repurposed from CSCore sample project

namespace Control_Panel.Actions.Visualizer
{
    public sealed class LineSpectrum : Spectrum
    {
        private readonly Frame Frame;

        public LineSpectrum(Frame frame, FftSize size, BasicSpectrumProvider provider)
        {
            Frame = frame;
            FftSize = (int) size;
            MaxFftIndex = FftSize / 2 - 1;

            SpectrumProvider = provider;

            SpectrumResolution = MatrixPanel.Width;

            UpdateFrequencyMapping();
        }

        public void Draw()
        {
            var fftBuffer = new float[FftSize];

            if (!SpectrumProvider.GetFftData(fftBuffer, this))
                return;

            var spectrumPoints = CalculateSpectrumPoints(MatrixPanel.Height, fftBuffer);

            byte hue = 0;

            for (var x = 0; x < spectrumPoints.Count; x++)
            {
                using (var brush = new SolidBrush(ColorHelper.HsvToColor(hue / 255.0, 1.0, 1.0)))
                {
                    var height = (int) Math.Round(spectrumPoints[x].Value);
                    Frame.Graphics.FillRectangle(brush, x, MatrixPanel.Height - height, 1, height);
                }

                hue += 255 / 15;
            }
            
        }
    }
}
