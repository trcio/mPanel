using System;
using System.Media;
using System.Windows.Forms;
using System.Timers;
using Timer = System.Timers.Timer;
using mPanel.Matrix;
using mPanel.Extra;

namespace mPanel.Actions.Scripter
{
    public partial class ScripterForm : Form
    {
        private MatrixPanel Matrix => ((ContainerForm) MdiParent)?.Matrix;

        private readonly Frame Frame;
        private readonly Timer FrameTimer;
        private MatrixScript Script;

        public ScripterForm()
        {
            InitializeComponent();

            Frame = new Frame();

            FrameTimer = new Timer();
            FrameTimer.Elapsed += FrameTimer_Elapsed;
        }

        private void FrameTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                Script.ExecuteDraw();
                Matrix?.SendFrame(Script.Frame);
            }
            catch (Exception ex)
            {
                this.ExInvoke(f =>
                {
                    NotifyException(ex);
                });
            }
        }

        private void RunScript()
        {
            scriptTextBox.Enabled = false;
            runToolStripMenuItem.Text = "Stop";
            statusLabel.Text = "Running";

            try
            {
                Script = new MatrixScript();
                Script.LoadString(scriptTextBox.Text);

                FrameTimer.Interval = Script.FrameInterval;
                FrameTimer.Start();
            }
            catch (Exception ex)
            {
                NotifyException(ex);
            }
        }

        private void StopScript()
        {
            FrameTimer.Stop();

            scriptTextBox.Enabled = true;
            runToolStripMenuItem.Text = "Run";
            statusLabel.Text = "Idle";
        }

        private void NotifyException(Exception ex)
        {
            StopScript();

            SystemSounds.Exclamation.Play();

            statusLabel.Text = $"Exception: {ex.Message}";
        }

        private void runToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (FrameTimer.Enabled)
                StopScript();
            else
                RunScript();
        }
    }
}
