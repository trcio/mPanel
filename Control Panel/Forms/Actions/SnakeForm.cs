using System;
using System.Collections.Generic;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;
using Control_Panel.Matrix;
using Timer = System.Timers.Timer;

namespace Control_Panel.Forms.Actions
{
    public partial class SnakeForm : Form
    {
        private const int FramesPerSecond = 15;

        private MatrixPanel Matrix => ((ContainerForm) MdiParent)?.Matrix;

        private readonly Timer GameTimer;
        private readonly Frame Frame;
        private readonly FoodPiece FoodPiece;
        private readonly List<SnakePiece> SnakePieces;
        private Direction Direction;

        public SnakeForm()
        {
            InitializeComponent();

            GameTimer = new Timer(1000.0 / FramesPerSecond);
            GameTimer.Elapsed += GameTimerOnElapsed;

            Frame = new Frame();

            Direction = Direction.Left;

            FoodPiece = new FoodPiece(Frame);
            SnakePieces = new List<SnakePiece>
            {
                new SnakePiece(7, 7, Color.White, Frame)
            };
        }

        private void GameTimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            Frame.Graphics.Clear(Color.Black);

            FoodPiece.Draw();

            for (var i = SnakePieces.Count - 1; i > 0; i--)
                SnakePieces[i].CopyCoordinates(SnakePieces[i - 1]);

            SnakePieces[0].Move(Direction);

            for (var i = 1; i < SnakePieces.Count; i++)
                if (SnakePieces[0].DistanceFrom(SnakePieces[i]) < 1)
                    ResetSnake();

            foreach (var piece in SnakePieces)
                piece.Draw();

            if (SnakePieces[0].DistanceFrom(FoodPiece) < 1)
                AddPiece();

            // push frame to matrix
            Matrix.SendFrame(Frame);
        }

        private void AddPiece()
        {
            var last = SnakePieces[SnakePieces.Count - 1];

            SnakePieces.Add(new SnakePiece(last.X, last.Y, FoodPiece.Fill, Frame));

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
            Direction = Direction.Up;
        }

        private void downButton_Click(object sender, EventArgs e)
        {
            Direction = Direction.Down;
        }

        private void leftButton_Click(object sender, EventArgs e)
        {
            Direction = Direction.Left;
        }

        private void rightButton_Click(object sender, EventArgs e)
        {
            Direction = Direction.Right;
        }

        private void SnakeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            GameTimer.Stop();
            Matrix.Clear();
        }
    }

    class SnakePiece
    {
        private readonly Frame Frame;

        public int X { get; set; }
        public int Y { get; set; }
        public Color Fill { get; set; }

        public SnakePiece(int x, int y, Color fill, Frame frame)
        {
            X = x;
            Y = y;
            Fill = fill;
            Frame = frame;

            FixCoordinates();
        }

        private void FixCoordinates()
        {
            if (X > MatrixPanel.Width - 1)
                X = 0;
            else if (X < 0)
                X = MatrixPanel.Width - 1;

            if (Y > MatrixPanel.Height - 1)
                Y = 0;
            else if (Y < 0)
                Y = MatrixPanel.Height - 1;
        }

        public void CopyCoordinates(SnakePiece piece)
        {
            X = piece.X;
            Y = piece.Y;

            FixCoordinates();
        }

        public void Move(Direction direction)
        {
            X += direction.X;
            Y += direction.Y;

            FixCoordinates();
        }

        public double DistanceFrom(SnakePiece piece)
        {
            return Math.Sqrt(Math.Pow(piece.X - X, 2) + Math.Pow(piece.Y - Y, 2));
        }

        public double DistanceFrom(FoodPiece piece)
        {
            return Math.Sqrt(Math.Pow(piece.X - X, 2) + Math.Pow(piece.Y - Y, 2));
        }

        public void Draw()
        {
            using (var fill = new SolidBrush(Fill))
            {
                Frame.Graphics.FillRectangle(fill, X, Y, 1, 1);
            }
        }
    }

    class FoodPiece
    {
        private static readonly Random Random = new Random();
        private readonly Frame Frame;

        public int X { get; set; }
        public int Y { get; set; }
        public Color Fill { get; set; }

        public FoodPiece(Frame frame)
        {
            Frame = frame;
            Randomize();
        }

        public void Randomize()
        {
            X = Random.Next(0, MatrixPanel.Width);
            Y = Random.Next(0, MatrixPanel.Height);
            Fill = ColorUtils.HsvToColor(Random.NextDouble(), 1.0, 1.0);
        }

        public void Draw()
        {
            using (var fill = new SolidBrush(Fill))
            {
                Frame.Graphics.FillRectangle(fill, X, Y, 1, 1);
            }
        }
    }

    class Direction
    {
        public static Direction Up = new Direction(0, -1);
        public static Direction Down = new Direction(0, 1);
        public static Direction Left = new Direction(-1, 0);
        public static Direction Right = new Direction(1, 0);

        public int X { get; set; }
        public int Y { get; set; }

        public Direction(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
