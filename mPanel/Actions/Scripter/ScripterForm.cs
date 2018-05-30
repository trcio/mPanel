using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Text;
using System.Windows.Forms;
using System.Timers;
using Timer = System.Timers.Timer;
using mPanel.Matrix;
using mPanel.Extra;
using mPanel.Properties;

namespace mPanel.Actions.Scripter
{
    public partial class ScripterForm : Form
    {
        private MatrixPanel Matrix => ((ContainerForm) MdiParent)?.Matrix;

        private readonly Timer FrameTimer;
        private Script Script;

        private int FrameCount;
        private bool FreshFile;

        public ScripterForm()
        {
            InitializeComponent();

            FrameTimer = new Timer();
            FrameTimer.Elapsed += FrameTimer_Elapsed;

            FreshFile = true;
        }

        #region Methods

        private void FrameTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                Script.ExecuteDraw();
                Matrix?.SendFrame(Script.Frame);
                FrameCount++;
            }
            catch (Exception ex)
            {
                this.ExInvoke(f =>
                {
                    NotifyException(ex);
                });
            }
        }

        private void OpenLuaFile(string file)
        {
            scriptTextBox.Text = File.ReadAllText(file);
            ChangeFileTitle(Path.GetFileName(file));
        }

        private void SaveLuaFile(string file)
        {
            File.WriteAllText(file, scriptTextBox.Text, Encoding.UTF8);
            ChangeFileTitle(Path.GetFileName(file));
        }

        private void RunScript()
        {
            ToggleControls(false);

            try
            {
                Script = new Script();
                Script.LoadString(scriptTextBox.Text);

                FrameCount = 0;

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

            ToggleControls(true);
        }

        private void NotifyException(Exception ex)
        {
            StopScript();

            SystemSounds.Exclamation.Play();

            statusLabel.Text = $"Exception: {ex.Message}";
        }

        private void ChangeFileTitle(string title)
        {
            FreshFile = true;
            Text = $"Scripter - {title}";
        }

        private void ToggleControls(bool state)
        {
            openToolStripMenuItem.Enabled = state;
            saveToolStripMenuItem.Enabled = state;
            scriptTextBox.Enabled = state;
            runToolStripMenuItem.Text = state ? "Run" : "Stop";
            statusLabel.Text = state ? "Idle" : "Running";
            frameLabel.Text = state ? $"{FrameCount} frames sent" : string.Empty;
        }

        private void ShowReference()
        {
            Show();
            scriptTextBox.Text = Resources.ScriptReference;
            scriptTextBox.ReadOnly = true;
            fileToolStripMenuItem.Enabled = false;
            openToolStripMenuItem.Enabled = false;
            saveToolStripMenuItem.Enabled = false;
            runToolStripMenuItem.Enabled = false;
            referenceToolStripMenuItem.Enabled = false;
            statusLabel.Text = "Reference";
            Text = "Scripter Reference";
        }

        #endregion

        #region Form Events

        private void ScripterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrameTimer.Stop();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var fd = new OpenFileDialog())
            {
                fd.CheckFileExists = true;
                fd.Filter = "Lua script file (*.lua)|*.lua";
                fd.Title = "Open script file";

                if (fd.ShowDialog() != DialogResult.OK)
                    return;

                OpenLuaFile(fd.FileName);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var fd = new SaveFileDialog())
            {
                fd.OverwritePrompt = true;
                fd.Filter = "Lua script file (*.lua)|*.lua";
                fd.Title = "Save script file";

                if (fd.ShowDialog() != DialogResult.OK)
                    return;

                SaveLuaFile(fd.FileName);
            }
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FrameTimer.Enabled)
                StopScript();
            else
                RunScript();
        }

        private void scriptTextBox_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            if (!FreshFile)
                return;

            Text += "*";
            FreshFile = false;
        }

        private void increaseFontSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (scriptTextBox.Font.Size.CompareTo(20) >= 0)
                return;

            scriptTextBox.Font = new Font(scriptTextBox.Font.FontFamily, scriptTextBox.Font.Size + 0.5f);
        }

        private void decreaseFontSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (scriptTextBox.Font.Size.CompareTo(5) <= 0)
                return;

            scriptTextBox.Font = new Font(scriptTextBox.Font.FontFamily, Math.Max(5, scriptTextBox.Font.Size - 0.5f));
        }

        private void referenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ScripterForm { MdiParent = MdiParent };
            form.ShowReference();
        }

        #endregion
    }
}
