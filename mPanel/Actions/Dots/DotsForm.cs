using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using mPanel.Extra;
using Timer = System.Timers.Timer;
using mPanel.Matrix;

namespace mPanel.Actions.Dots
{
    public partial class DotsForm : Form
    {
        private const int FramesPerSecond = 10;

        private MatrixPanel Matrix => ((ContainerForm) MdiParent)?.Matrix;

        private readonly Frame Frame;
        private readonly Timer FrameTimer;
        private List<Dot> Dots;

        public DotsForm()
        {
            InitializeComponent();

            Frame = new Frame();

            FrameTimer = new Timer(1000.0 / FramesPerSecond);
            FrameTimer.Elapsed += FrameTimer_Elapsed;
        }

        private void FrameTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Frame.Clear(Color.Black);

            Dots.ForEach((d) =>
            {
                d.Draw();
            });

            Matrix.SendFrame(Frame);
        }

        private void ResetDots()
        {
            Dots = new List<Dot>();

            for (var i = 0; i < 8; i++)
            {
                Dots.Add(new ChaseDot(Frame, ColorHelper.HsvToColor((byte) (i * 20 % 255))));
//                Dots.Add(new Dot(Frame, ColorHelper.HsvToColor((byte) (i * 30 % 255))));
            }
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
                ResetDots();
                FrameTimer.Start();
                enableButton.Text = "Disable";
            }
        }
    }
}
