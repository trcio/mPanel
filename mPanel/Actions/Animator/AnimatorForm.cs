using System;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;
using Timer = System.Timers.Timer;
using mPanel.Controls;
using mPanel.Extra;
using mPanel.Matrix;

namespace mPanel.Actions.Animator
{
    public partial class AnimatorForm : Form
    {
        private MatrixPanel Matrix => ((ContainerForm) MdiParent)?.Matrix;

        private readonly Timer FrameTimer;
        private int FrameIndex;

        public AnimatorForm()
        {
            InitializeComponent();

            FrameTimer = new Timer();
            FrameTimer.Elapsed += FrameTimer_Elapsed;
        }

        #region Methods

        private void FrameTimer_Elapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            if (FrameIndex >= treeView.Nodes.Count)
                FrameIndex = 0;

            treeView.ExInvoke(t => t.SelectedNode = t.Nodes[FrameIndex]);

            FrameIndex++;
        }

        private void AddFrame()
        {
            var node = new TreeNode($"Frame {treeView.Nodes.Count + 1}")
            {
                Tag = new Frame()
            };
            
            treeView.Nodes.Add(node);
            treeView.SelectedNode = node;

            editor.SetFrame((Frame) node.Tag);
        }

        private Frame GetSelectedFrame()
        {
            return (Frame) treeView.SelectedNode.Tag;
        }

        #endregion

        #region Form Events

        private void editor_PixelChanged(object sender, FrameEditor.ChangeArgs e)
        {
            var frame = GetSelectedFrame();
            
            if (e.Button == MouseButtons.Left)
                frame.SetPixel(e.Pixel, Color.Orange);
            else if (e.Button == MouseButtons.Right)
                frame.SetPixel(e.Pixel, Color.Black);

            if (e.Button == MouseButtons.None)
                return;

            Matrix.SendFrame(frame);
        }

        private void AnimatorForm_Load(object sender, EventArgs e)
        {
            editor.PixelChanged += editor_PixelChanged;

            AddFrame();
        }

        private void AnimatorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrameTimer.Stop();
            Matrix.Clear();
        }

        private void addFrameButton_Click(object sender, EventArgs e)
        {
            AddFrame();
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var frame = GetSelectedFrame();

            editor.SetFrame(frame);
            Matrix.SendFrame(frame);
        }

        private void timerButton_Click(object sender, EventArgs e)
        {
            if (FrameTimer.Enabled)
            {
                FrameTimer.Stop();
                delayUpDown.Enabled = true;
                timerButton.Text = "Enable";
            }
            else
            {
                FrameIndex = 0;
                FrameTimer.Interval = (double) delayUpDown.Value;
                FrameTimer.Start();
                delayUpDown.Enabled = false;
                timerButton.Text = "Disable";
            }
        }

        #endregion
    }
}
