using System.Drawing;
using System.Timers;
using System.Windows.Forms;
using mPanel.Matrix;
using Timer = System.Timers.Timer;

namespace mPanel.Actions.Pong
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
        private bool AwaitingStart;

        public PongForm()
        {
            InitializeComponent();

            GameTimer = new Timer(1000.0 / FramesPerSecond);
            GameTimer.Elapsed += GameTimer_Elapsed;

            Frame = new Frame();

            NewGame();
        }

        private void GameTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Frame.Clear(Color.Black);

            if (AwaitingStart)
            {
                // draw objects in default position
                Ball.Draw();
                TopPaddle.Draw();
                BottomPaddle.Draw();
            }
            else
            {
                // move the paddles
                TopPaddle.Move();
                BottomPaddle.Move();

                // perform ball collision
                BounceBall();

                // move ball periodically
                if (FrameCount % 2 == 0)
                    Ball.Move();

                // check if ball was scored
                if (Ball.Y < 0 || Ball.Y > MatrixPanel.Height - 1)
                    NewGame();

                // draw objects
                Ball.Draw();
                TopPaddle.Draw();
                BottomPaddle.Draw();
            }

            // push frame to matrix
            Matrix.SendFrame(Frame);

            FrameCount++;
        }

        private void NewGame()
        {
            Ball = new Ball(Frame, MatrixPanel.Width / 2, MatrixPanel.Height / 2);
            TopPaddle = new Paddle(Frame, Color.White, 6, 0, 3);
            BottomPaddle = new Paddle(Frame, Color.White, 6, 14, 3);

            AwaitingStart = true;
        }

        private void BounceBall()
        {
            if (Ball.X < 1)
                Ball.Direction.DeltaX = 1;
            else if (Ball.X > MatrixPanel.Width - 2)
                Ball.Direction.DeltaX = -1;

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
            for (var i = paddle.X; i < paddle.X + paddle.Width; i++)
            {
                if (i == ball.X)
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
                case Keys.NumPad1:
                    BottomPaddle.DeltaX = -1;
                    break;
                case Keys.NumPad3:
                    BottomPaddle.DeltaX = 1;
                    break;
                case Keys.Space:
                    AwaitingStart = false;
                    break;
            }
        }

        private void PongForm_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D:
                    if (TopPaddle.DeltaX < 0)
                        TopPaddle.DeltaX = 0;
                    break;
                case Keys.F:
                    if (TopPaddle.DeltaX > 0)
                        TopPaddle.DeltaX = 0;
                    break;
                case Keys.NumPad1:
                    if (BottomPaddle.DeltaX < 0)
                        BottomPaddle.DeltaX = 0;
                    break;
                case Keys.NumPad3:
                    if (BottomPaddle.DeltaX > 0)
                        BottomPaddle.DeltaX = 0;
                    break;
            }
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
                label1.Focus();
            }
        }
    }
}
