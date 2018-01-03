using System;
using System.Collections.Generic;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;
using Control_Panel.Matrix;
using Control_Panel.Misc;
using Timer = System.Timers.Timer;

namespace Control_Panel.Actions.Snake
{
    public partial class SnakeForm : Form
    {
        private const int FramesPerSecond = 15;

        private MatrixPanel Matrix => ((ContainerForm) MdiParent)?.Matrix;

        private readonly Timer GameTimer;
        private readonly Frame Frame;
        private readonly FoodPiece FoodPiece;
        private readonly List<SnakePiece> SnakePieces;
        private Direction Direction, PreviousDirection;

        public SnakeForm()
        {
            InitializeComponent();

            GameTimer = new Timer(1000.0 / FramesPerSecond);
            GameTimer.Elapsed += GameTimerOnElapsed;

            Frame = new Frame();

            Direction = Direction.Left;
            PreviousDirection = Direction.None;

            FoodPiece = new FoodPiece(Frame);
            SnakePieces = new List<SnakePiece>
            {
                new SnakePiece(Frame, Color.White, 7, 7)
            };
        }

        private void GameTimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            Frame.Clear(Color.Black);

            // draw food
            FoodPiece.Draw();

            // cascade tail pieces
            for (var i = SnakePieces.Count - 1; i > 0; i--)
                SnakePieces[i].CopyCoordinates(SnakePieces[i - 1]);

            // move snake head
            SnakePieces[0].Move(Direction);

            // check reverse direction
            if (SnakePieces.Count > 1 && Direction.IsOpposite(PreviousDirection))
                ResetSnake();

            // check tail collision
            for (var i = 1; i < SnakePieces.Count; i++)
                if (SnakePieces[0].DistanceFrom(SnakePieces[i]) < 1)
                    ResetSnake();

            // draw snake pieces
            foreach (var piece in SnakePieces)
                piece.Draw();

            // add food piece if collision
            if (SnakePieces[0].DistanceFrom(FoodPiece) < 1)
                AddPiece();

            // push frame to matrix
            Matrix.SendFrame(Frame);
        }

        private void AddPiece()
        {
            var last = SnakePieces[SnakePieces.Count - 1];

            SnakePieces.Add(new SnakePiece(Frame, FoodPiece.Fill, last.X, last.Y));

            FoodPiece.Randomize();

            Invoke(new Action(() =>
            {
                Text = $"Snake - {SnakePieces.Count - 1}";
            }));
        }

        private void ResetSnake()
        {
            var head = SnakePieces[0];

            SnakePieces.Clear();
            SnakePieces.Add(head);

            Invoke(new Action(() =>
            {
                Text = "Snake";
            }));
        }

        private void SnakeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            GameTimer.Stop();
            Matrix.Clear();
        }

        private void SnakeForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    upButton_Click(sender, e);
                    break;
                case Keys.S:
                    downButton_Click(sender, e);
                    break;
                case Keys.A:
                    leftButton_Click(sender, e);
                    break;
                case Keys.D:
                    rightButton_Click(sender, e);
                    break;
            }
        }

        private void enableButton_Click(object sender, EventArgs e)
        {
            if (GameTimer.Enabled)
            {
                GameTimer.Stop();
                enableButton.Text = "Enable";
            }
            else
            {
                GameTimer.Start();
                enableButton.Text = "Disable";
            }
        }

        private void upButton_Click(object sender, EventArgs e)
        {
            PreviousDirection = Direction;
            Direction = Direction.Up;
        }

        private void downButton_Click(object sender, EventArgs e)
        {
            PreviousDirection = Direction;
            Direction = Direction.Down;
        }

        private void leftButton_Click(object sender, EventArgs e)
        {
            PreviousDirection = Direction;
            Direction = Direction.Left;
        }

        private void rightButton_Click(object sender, EventArgs e)
        {
            PreviousDirection = Direction;
            Direction = Direction.Right;
        }
    }
}
