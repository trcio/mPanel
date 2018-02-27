using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Media;
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
        private int FrameIndex, FrameCounter;

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

        private void AddFrame(Frame frame)
        {
            FrameCounter++;

            var node = new TreeNode($"Frame {FrameCounter}")
            {
                Tag = frame
            };
            
            treeView.Nodes.Add(node);
            treeView.SelectedNode = node;

            editor.SetFrame(frame);
        }

        private void AddFrame(Image image)
        {
            var b = new Bitmap(MatrixPanel.Width, MatrixPanel.Height, PixelFormat.Format24bppRgb);
            b.ScaleCopy(image);
            AddFrame(new Frame(b));
        }

        private void SaveAnimation(string file)
        {
            var bitmaps = new List<Bitmap>();

            foreach (var node in treeView.Nodes)
                bitmaps.Add(((Frame) ((TreeNode) node).Tag).Bitmap);
            
            var animation = new AnimationFile
            {
                Delay = (int) delayUpDown.Value,
                Bitmaps = bitmaps
            };

            if (!AnimationFile.SaveAnimation(animation, file))
                SystemSounds.Exclamation.Play();
        }

        private void LoadAnimation(AnimationFile file)
        {
            if (file == null || file.Bitmaps.Count < 1)
            {
                SystemSounds.Hand.Play();
                return;
            }

            delayUpDown.Value = file.Delay;

            ClearFrames();

            foreach (var bitmap in file.Bitmaps)
                AddFrame(new Frame(bitmap));
        }

        private Frame GetSelectedFrame()
        {
            return (Frame) treeView.SelectedNode.Tag;
        }

        private void ClearFrames()
        {
            treeView.Nodes.Clear();
            FrameCounter = 0;
        }

        private void ToggleControls(bool state)
        {
            treeView.Enabled = state;
            delayUpDown.Enabled = state;
            importButton.Enabled = state;
            saveAnimationButton.Enabled = state;
            loadAnimationButton.Enabled = state;
            addFrameButton.Enabled = state;
            removeFrameButton.Enabled = state;
            upFrameButton.Enabled = state;
            downFrameButton.Enabled = state;
            clearAllButton.Enabled = state;
        }

        #endregion

        #region Form Events

        private void AnimatorForm_Load(object sender, EventArgs e)
        {
            editor.Action += editor_Action;

            AddFrame(new Frame());
        }

        private void AnimatorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrameTimer.Stop();
            Matrix.Clear();
        }

        private void editor_Action(object sender, FrameEditor.ActionEventArgs e)
        {
            var frame = GetSelectedFrame();

            var left = e.Mouse.Button.HasFlag(MouseButtons.Left);
            var right = e.Mouse.Button.HasFlag(MouseButtons.Right);
            var ctrl = e.Keys.Modifiers.HasFlag(Keys.Control);
            var alt = e.Keys.Modifiers.HasFlag(Keys.Alt);
            var shift = e.Keys.Modifiers.HasFlag(Keys.Shift);

            if (left && ctrl)
                frame.SetPixel(e.Pixel, Color.Black);
            else if (right && ctrl)
                frame.Clear(Color.Black);
            else if (left && alt)
            {
                if (shift)
                    frame.Clear(leftAltColorButton.SelectedColor);
                else
                    frame.SetPixel(e.Pixel, leftAltColorButton.SelectedColor);
            }
            else if (right && alt)
            {
                if (shift)
                    frame.Clear(rightAltColorButton.SelectedColor);
                else
                    frame.SetPixel(e.Pixel, rightAltColorButton.SelectedColor);
            }
            else if (left)
            {
                if (shift)
                    frame.Clear(leftColorButton.SelectedColor);
                else
                    frame.SetPixel(e.Pixel, leftColorButton.SelectedColor);
            }
            else if (right)
            {
                if (shift)
                    frame.Clear(rightColorButton.SelectedColor);
                else
                    frame.SetPixel(e.Pixel, rightColorButton.SelectedColor);
            }

            Matrix.SendFrame(frame);
        }

        private void editor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control)
                AddFrame(editor.SelectedFrame.Bitmap);
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var frame = GetSelectedFrame();

            editor.SetFrame(frame);
            Matrix.SendFrame(frame);
        }

        private void addFrameButton_Click(object sender, EventArgs e)
        {
            AddFrame(new Frame());
        }

        private void removeFrameButton_Click(object sender, EventArgs e)
        {
            if (treeView.Nodes.Count > 1)
                treeView.Nodes.Remove(treeView.SelectedNode);
        }

        private void upFrameButton_Click(object sender, EventArgs e)
        {
            if (treeView.Nodes.Count < 2 || treeView.Nodes.IndexOf(treeView.SelectedNode) == 0)
                return;

            var node = treeView.SelectedNode;
            var index = treeView.Nodes.IndexOf(node);
            var other = treeView.Nodes[index - 1];

            treeView.Nodes.Remove(other);
            treeView.Nodes.Insert(index, other);
            treeView.SelectedNode = node;
        }

        private void downFrameButton_Click(object sender, EventArgs e)
        {
            if (treeView.Nodes.Count < 2 || treeView.Nodes.IndexOf(treeView.SelectedNode) == treeView.Nodes.Count - 1)
                return;

            var node = treeView.SelectedNode;
            var index = treeView.Nodes.IndexOf(node);
            var other = treeView.Nodes[index + 1];

            treeView.Nodes.Remove(other);
            treeView.Nodes.Insert(index, other);
            treeView.SelectedNode = node;
        }

        private void clearAllButton_Click(object sender, EventArgs e)
        {
            ClearFrames();
            AddFrame(new Frame());
        }

        private void delayUpDown_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            e.Handled = true;
            enableButton.PerformClick();
        }

        private void enableButton_Click(object sender, EventArgs e)
        {
            if (FrameTimer.Enabled)
            {
                FrameTimer.Stop();
                ToggleControls(true);
                enableButton.Text = "Enable";
            }
            else
            {
                FrameIndex = 0;
                FrameTimer.Interval = (double) delayUpDown.Value;
                FrameTimer.Start();
                ToggleControls(false);
                enableButton.Text = "Disable";
            }
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            using (var fd = new OpenFileDialog())
            {
                fd.CheckFileExists = true;
                fd.Filter = "Image files (*.gif, *.png, *.jpg, *.jpeg)|*.gif;*.png;*.jpg;*.jpeg";
                fd.Title = "Import image into animation";

                if (fd.ShowDialog() != DialogResult.OK)
                    return;

                var image = Image.FromFile(fd.FileName);
                var dim = new FrameDimension(image.FrameDimensionsList[0]);
                var frames = image.GetFrameCount(dim);

                for (var i = 1; i <= frames; i++)
                {
                    AddFrame(image);

                    if (i < frames)
                        image.SelectActiveFrame(dim, i);
                }
            }
        }

        private void saveAnimationButton_Click(object sender, EventArgs e)
        {
            using (var fd = new SaveFileDialog())
            {
                fd.OverwritePrompt = true;
                fd.Filter = "Animation file (*.ma)|*.ma";
                fd.Title = "Save animation file";

                if (fd.ShowDialog() != DialogResult.OK)
                    return;

                SaveAnimation(fd.FileName);
            }
        }

        private void loadAnimationButton_Click(object sender, EventArgs e)
        {
            using (var fd = new OpenFileDialog())
            {
                fd.CheckFileExists = true;
                fd.Filter = "Animation file (*.ma)|*.ma";
                fd.Title = "Load animation file";

                if (fd.ShowDialog() != DialogResult.OK)
                    return;

                LoadAnimation(AnimationFile.ReadAnimation(fd.FileName));
            }
        }

        #endregion
    }
}
