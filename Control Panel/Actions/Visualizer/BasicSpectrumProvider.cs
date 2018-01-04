using System.Collections.Generic;
using CSCore.DSP;

// BasicSpectrumProvider repurposed from CSCore sample project

namespace Control_Panel.Actions.Visualizer
{
    public class BasicSpectrumProvider : FftProvider
    {
        private readonly int SampleRate;
        private readonly List<object> Contexts;

        public BasicSpectrumProvider(int channels, int sampleRate, FftSize fftSize) : base(channels, fftSize)
        {
            SampleRate = sampleRate;
            Contexts = new List<object>();
        }

        public int GetFftBandIndex(float frequency)
        {
            var fftSize = (int) FftSize;
            var f = SampleRate / 2.0;

            return (int) (frequency / f * (fftSize / 2.0));
        }

        public bool GetFftData(float[] buffer, object context)
        {
            if (Contexts.Contains(context))
                return false;

            Contexts.Add(context);
            GetFftData(buffer);

            return true;
        }

        public override void Add(float left, float right)
        {
            base.Add(left, right);
            Contexts.Clear();
        }

        public override void Add(float[] samples, int count)
        {
            base.Add(samples, count);
            if (count > 0)
                Contexts.Clear();
        }
    }
}
