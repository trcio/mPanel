using System;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;
using mPanel.Extra;
using mPanel.Matrix;
using Timer = System.Timers.Timer;

namespace mPanel.Actions.Tetris
{
    public partial class TetrisForm : Form
    {
        private const int FramesPerSecond = 15;

        private MatrixPanel Matrix => ((ContainerForm) MdiParent)?.Matrix;

        private readonly Frame Frame;
        private readonly Timer GameTimer;

        private TetrisGame Game;
        

        public TetrisForm()
        {
            InitializeComponent();

            Frame = new Frame();

            GameTimer = new Timer(1000.0 / FramesPerSecond);
            GameTimer.Elapsed += GameTimer_Elapsed;
        }

        #region Methods

        private void GameTimer_Elapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            Frame.Clear(Color.Black);

            Game.Loop(Frame);

            // push frame to matrix
            Matrix.SendFrame(Frame);

            if (Game.GameOver)
                startButton.ExInvoke(b => b.PerformClick());
        }

        #endregion

        #region Form Events

        private void TetrisForm_KeyDown(object sender, KeyEventArgs e)
        {
            Game?.KeyDown(e.KeyCode);
        }

        private void TetrisForm_KeyUp(object sender, KeyEventArgs e)
        {
            Game?.KeyUp(e.KeyCode);
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (GameTimer.Enabled)
            {
                GameTimer.Stop();
                startButton.Text = "Start New Game";
            }
            else
            {
                Game = new TetrisGame();
                GameTimer.Start();
                startButton.Text = "Stop Game";
            }
        }

        #endregion
    }
}
