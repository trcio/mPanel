using System.Drawing;
using System.Timers;
using System.Windows.Forms;
using Control_Panel.Matrix;
using Timer = System.Timers.Timer;

namespace Control_Panel.Actions.Pong
{
    public partial class PongForm : Form
    {
        private const int FramesPerSecond = 30;

        private MatrixPanel Matrix => ((ContainerForm) MdiParent)?.Matrix;

        private readonly Timer GameTimer;
        private readonly Frame Frame;
        private Ball Ball;
        private Paddle TopPaddle, BottomPaddle;

        private long FrameCount;
        private bool GameOver;

        public PongForm()
        {
            InitializeComponent();

            GameTimer = new Timer(1000.0 / FramesPerSecond);
            GameTimer.Elapsed += GameTimerOnElapsed;

            Frame = new Frame();

            NewGame();
        }

        private void GameTimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            Frame.Graphics.Clear(Color.Black);

            if (GameOver)
            {
                TopPaddle.Draw();
                BottomPaddle.Draw();
                Ball.Draw();
            }
            else
            {
                TopPaddle.Move();
                BottomPaddle.Move();

                TopPaddle.Draw();
                BottomPaddle.Draw();

                if (FrameCount % 3 == 0)
                {
                    Bounce();
                    Ball.Move();

                    if (Ball.Y < 1 || Ball.Y > MatrixPanel.Height - 2)
                        NewGame();
                }

                Ball.Draw();
            }

            // push frame to matrix
            Matrix.SendFrame(Frame);

            FrameCount++;
        }

        private void NewGame()
        {
            Ball = new Ball(Frame, MatrixPanel.Width / 2, MatrixPanel.Height / 2);
            TopPaddle = new Paddle(Frame, Color.White, 5, 0, 5);
            BottomPaddle = new Paddle(Frame, Color.White, 5, 14, 5);

            GameOver = true;
        }

        private void Bounce()
        {
            if (Ball.X < 1)
                Ball.Direction.DeltaX = 1;
            else if (Ball.X > MatrixPanel.Width - 2)
                Ball.Direction.DeltaX = -1;

            // bounce down
            if (Ball.Y == TopPaddle.Y + 1 && PaddleCollision(TopPaddle, Ball))
            {
                Ball.Direction.DeltaY = 1;

                if (TopPaddle.DeltaX != 0 && TopPaddle.DeltaX != Ball.Direction.DeltaX)
                    Ball.Direction.DeltaX = TopPaddle.DeltaX;

                Ball.Randomize();
            }
            else if (Ball.Y == BottomPaddle.Y - 1 && PaddleCollision(BottomPaddle, Ball))
            {
                Ball.Direction.DeltaY = -1;

                if (BottomPaddle.DeltaX != 0 && BottomPaddle.DeltaX != Ball.Direction.DeltaX)
                    Ball.Direction.DeltaX = BottomPaddle.DeltaX;

                Ball.Randomize();
            }
        }

        private static bool PaddleCollision(Paddle paddle, Ball ball)
        {
            for (var i = 0; i < paddle.Width; i++)
            {
                if (paddle.X + i == ball.X)
                    return true;
            }

            return false;
        }

        private void PongForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            GameTimer.Stop();
            Matrix.Clear();
        }

        private void PongForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D:
                    TopPaddle.DeltaX = -1;
                    break;
                case Keys.F:
                    TopPaddle.DeltaX = 1;
                    break;
                case Keys.J:
                    BottomPaddle.DeltaX = -1;
                    break;
                case Keys.K:
                    BottomPaddle.DeltaX = 1;
                    break;
                case Keys.S:
                    GameOver = false;
                    break;
            }
        }

        private void PongForm_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D:
                case Keys.F:
                    TopPaddle.DeltaX = 0;
                    break;
                case Keys.J:
                case Keys.K:
                    BottomPaddle.DeltaX = 0;
                    break;
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            GameOver = false;
        }

        private void enableButton_Click(object sender, System.EventArgs e)
        {
            if (GameTimer.Enabled)
            {
                GameTimer.Stop();
                enableButton.Text = "Enable";
            }
            else
            {
                FrameCount = 0;
                GameTimer.Start();
                enableButton.Text = "Disable";
            }
        }
    }
}
