using System;
using System.Collections.Generic;
using CSCore;

// Spectrum repurposed from a CSCore sample project

namespace mPanel.Actions.Visualizer
{
    public enum ScalingStrategy
    {
        Decibel,
        Linear,
        Sqrt
    }

    public abstract class Spectrum
    {
        private const int ScaleFactorLinear = 9;
        private const int ScaleFactorSqrt = 2;
        private const double MinDbValue = -90;
        private const double MaxDbValue = 0;
        private const double DbScale = (MaxDbValue - MinDbValue);

        private int MaximumFrequencyIndex;
        private int MinimumFrequencyIndex;
        private int[] SpectrumIndexMax;
        private int[] SpectrumLogScaleIndexMax;

        protected int SpectrumResolution { get; set; }
        protected int MaxFftIndex { get; set; }

        public int FftSize { get; set; }
        public int MaximumFrequency { get; set; }
        public int MinimumFrequency { get; set; }
        public bool IsXLogScale { get; set; }
        public bool UseAverage { get; set; }
        public ScalingStrategy ScalingStrategy { get; set; }
        public BasicSpectrumProvider SpectrumProvider { get; set; }

        protected void UpdateFrequencyMapping()
        {
            MaximumFrequencyIndex = Math.Min(SpectrumProvider.GetFftBandIndex(MaximumFrequency) + 1, MaxFftIndex);
            MinimumFrequencyIndex = Math.Min(SpectrumProvider.GetFftBandIndex(MinimumFrequency), MaxFftIndex);

            var indexCount = MaximumFrequencyIndex - MinimumFrequencyIndex;
            var linearIndexBucketSize = Math.Round(indexCount / (double) SpectrumResolution, 3);

            SpectrumIndexMax = SpectrumIndexMax.CheckBuffer(SpectrumResolution, true);
            SpectrumLogScaleIndexMax = SpectrumLogScaleIndexMax.CheckBuffer(SpectrumResolution, true);

            var maxLog = Math.Log(SpectrumResolution, SpectrumResolution);

            for (var i = 1; i < SpectrumResolution; i++)
            {
                var logIndex = (int) ((maxLog - Math.Log(SpectrumResolution + 1 - i, SpectrumResolution + 1)) * indexCount) +
                    MinimumFrequencyIndex;

                SpectrumIndexMax[i - 1] = MinimumFrequencyIndex + (int) (i * linearIndexBucketSize);
                SpectrumLogScaleIndexMax[i - 1] = logIndex;
            }

            if (SpectrumResolution <= 0)
                return;

            SpectrumIndexMax[SpectrumIndexMax.Length - 1] = MaximumFrequencyIndex;
            SpectrumLogScaleIndexMax[SpectrumLogScaleIndexMax.Length - 1] = MaximumFrequencyIndex;
        }

        protected List<SpectrumPointData> CalculateSpectrumPoints(double maxValue, float[] fftBuffer)
        {
            var dataPoints = new List<SpectrumPointData>();

            double value0 = 0, value = 0, lastValue = 0;
            var actualMaxValue = maxValue;
            var spectrumPointIndex = 0;

            for (var i = MinimumFrequencyIndex; i <= MaximumFrequencyIndex; i++)
            {
                switch (ScalingStrategy)
                {
                    case ScalingStrategy.Decibel:
                        value0 = (20 * Math.Log10(fftBuffer[i]) - MinDbValue) / DbScale * actualMaxValue;
                        break;
                    case ScalingStrategy.Linear:
                        value0 = fftBuffer[i] * ScaleFactorLinear * actualMaxValue;
                        break;
                    case ScalingStrategy.Sqrt:
                        value0 = Math.Sqrt(fftBuffer[i]) * ScaleFactorSqrt * actualMaxValue;
                        break;
                }

                var recalc = true;

                value = Math.Max(0, Math.Max(value0, value));

                while (spectrumPointIndex <= SpectrumIndexMax.Length - 1 &&
                       i == (IsXLogScale ? SpectrumLogScaleIndexMax[spectrumPointIndex] : SpectrumIndexMax[spectrumPointIndex]))
                {
                    if (!recalc)
                        value = lastValue;

                    if (value > maxValue)
                        value = maxValue;

                    if (UseAverage && spectrumPointIndex > 0)
                        value = (lastValue + value) / 2.0;

                    dataPoints.Add(new SpectrumPointData { SpectrumPointIndex = spectrumPointIndex, Value = value });

                    lastValue = value;
                    value = 0.0;
                    spectrumPointIndex++;
                    recalc = false;
                }
            }

            return dataPoints;
        }

        protected struct SpectrumPointData
        {
            public int SpectrumPointIndex;
            public double Value;
        }
    }
}
