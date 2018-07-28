using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using mPanel.Matrix;
using Brushes = System.Drawing.Brushes;


namespace mPanel.Actions.Tetris
{
    public class TetrisGame
    {
        private static readonly Random Random;

        private long FrameCount;

        private readonly HashSet<Keys> ActiveKeys;
        private readonly Queue<TetrisBlock> BlockBag;
        private readonly Color[][] ColorGrid;
        private TetrisBlock ActiveBlock, NextBlock;
        
        public bool GameOver { get; private set; }

        static TetrisGame()
        {
            Random = new Random();
        }

        public TetrisGame()
        {
            FrameCount = 0;
            ActiveKeys = new HashSet<Keys>();
            BlockBag = new Queue<TetrisBlock>();
            
            FillBlockBag();
            NextBlock = BlockBag.Dequeue();
            AssignNextActiveBlock();

            ColorGrid = new Color[15][];

            for (var i = 0; i < ColorGrid.Length; i++)
                ColorGrid[i] = new Color[10];
        }

        public void KeyDown(Keys key)
        {
            ActiveKeys.Add(key);
        }

        public void KeyUp(Keys key)
        {
            ActiveKeys.Remove(key);
        }

        public void Loop(Frame frame)
        {
            FrameCount++;

            RemoveFirstCompleteRow();

            for (var y = 0; y < ColorGrid.Length; y++)
                for (var x = 0; x < ColorGrid[y].Length; x++)
                    frame.SetPixel(x, y, ColorGrid[y][x]);

            ActiveBlock.Draw(frame.Graphics);
            NextBlock.Draw(frame.Graphics);

            DrawBorders(frame.Graphics);

            HandleInput();

            if (FrameCount % 8 == 0)
                MoveActiveBlock();

            if (IsActiveBlockColliding())
            {
                SolidifyActiveBlock();
                AssignNextActiveBlock();
            }

            // Game over
            if (!CheckOverflow())
                return;

            GameOver = true;
            frame.Graphics.FillRectangle(Brushes.Red, 11, 10, 4, 5);
        }

        private void DrawBorders(Graphics g)
        {
            g.FillRectangle(Brushes.White, 10, 0, 1, 15);
            g.FillRectangle(Brushes.White, 10, 4, 5, 1);
            g.FillRectangle(Brushes.White, 10, 9, 5, 1);
        }

        private void HandleInput()
        {
            Keys[] keys = new Keys[ActiveKeys.Count];
            ActiveKeys.CopyTo(keys);

            foreach (var e in keys)
            {
                switch (e)
                {
                    case Keys.W:
                        RotateActiveBlock();
                        KeyUp(Keys.W);
                        break;
                    case Keys.S:
                        ActiveBlock.Origin.Y++;

                        if (IsActiveBlockColliding())
                            ActiveBlock.Origin.Y--;
                        break;
                    case Keys.A:
                        ActiveBlock.Origin.X--;

                        if (IsActiveBlockColliding())
                            ActiveBlock.Origin.X++;
                        break;
                    case Keys.D:
                        ActiveBlock.Origin.X++;

                        if (IsActiveBlockColliding())
                            ActiveBlock.Origin.X--;
                        break;
                    case Keys.N:
                        ActiveBlock = TetrisBlock.StandardSet[new Random().Next(TetrisBlock.StandardSet.Count)];
                        break;
                }
            }
        }

        private void RotateActiveBlock()
        {
            ActiveBlock.Orientation++;

            // cycle through values
            if ((int) ActiveBlock.Orientation > 3)
                ActiveBlock.Orientation = Orientation.Up;

            // continue if all is good
            if (!IsActiveBlockColliding())
                return;

            var max = 0;

            // find max block offset and compensate (wall kick)
            foreach (var p in ActiveBlock.ObjectivePoints)
            {
                if (p.X < 0 && 0 - p.X > max)
                    max = 0 - p.X;
                else if (p.X > 9 && 9 - p.X < max)
                    max = 9 - p.X;
            }

            ActiveBlock.Origin.X += max;

            // continue if all is good
            if (!IsActiveBlockColliding())
                return;

            // undo modifications if rotation is not possible here
            ActiveBlock.Origin.X -= max;

            if (ActiveBlock.Orientation == Orientation.Up)
                ActiveBlock.Orientation = Orientation.Right;
            else
                ActiveBlock.Orientation--;
        }

        private void MoveActiveBlock()
        {
            ActiveBlock.Origin.Y++;
        }

        private bool IsActiveBlockColliding()
        {
            return ActiveBlock.ObjectivePoints.Any(p => p.X < 0 || p.X > 9 || p.Y > 14 || ColorGrid[p.Y][p.X] != Color.Empty);
        }

        private bool CheckOverflow()
        {
            // return ActiveBlock.ObjectivePoints.Any(p => p.Y < 0) || ColorGrid[0].Any(c => c != Color.Empty);
            return ColorGrid[0].Any(c => c != Color.Empty);
        }

        private void SolidifyActiveBlock()
        {
            if (ActiveBlock.Origin.Y > 0)
                ActiveBlock.Origin.Y--;

            foreach (var p in ActiveBlock.ObjectivePoints)
                ColorGrid[p.Y][p.X] = ActiveBlock.Fill.Color;
        }

        private void FillBlockBag()
        {
            foreach (var block in TetrisBlock.StandardSet.OrderBy(x => Random.Next()))
                BlockBag.Enqueue(block);
        }

        private void AssignNextActiveBlock()
        {
            // assign new tetromino
            if (BlockBag.Count < 1)
                FillBlockBag();

            ActiveBlock = NextBlock;
            NextBlock = BlockBag.Dequeue();

            // set random location
            ActiveBlock.Origin.Y = 0;
            ActiveBlock.Origin.X = Random.Next(6);

            NextBlock.Origin.Y = 0;
            NextBlock.Origin.X = 11;
        }

        private bool RemoveFirstCompleteRow()
        {
            for (var row = 0; row < ColorGrid.Length; row++)
            {
                if (ColorGrid[row].Any(b => b == Color.Empty))
                    continue;

                for (var i = row; i > 0; i--)
                    ColorGrid[i] = ColorGrid[i - 1];
                
                ColorGrid[0] = new Color[ColorGrid[row].Length];

                return true;
            }

            return false;
        }
    }

    public enum Orientation
    {
        Up,
        Right,
        Down,
        Left
    }

    public class TetrisBlock
    {
        public static List<TetrisBlock> StandardSet => new List<TetrisBlock>
        {
            new TetrisBlockI(),
            new TetrisBlockJ(),
            new TetrisBlockL(),
            new TetrisBlockO(),
            new TetrisBlockS(),
            new TetrisBlockT(),
            new TetrisBlockZ()
            // new Tetromino { Fill = Brushes.Blue, RelativePoints = new [] { new Point(0, 0), new Point(0, 1), new Point(1, 1), new Point(2, 1) } },
            // new Tetromino { Fill = Brushes.Orange, RelativePoints = new [] { new Point(0, 1), new Point(1, 1), new Point(2, 1), new Point(2, 0) } },
            // new Tetromino { Fill = Brushes.Yellow, RelativePoints = new [] { new Point(0, 0), new Point(0, 1), new Point(1, 0), new Point(1, 1) } },
            // new Tetromino { Fill = Brushes.Green, RelativePoints = new [] { new Point(0, 1), new Point(1, 1), new Point(1, 0), new Point(2, 0) } },
            // new Tetromino { Fill = Brushes.Purple, RelativePoints = new[] { new Point(0, 1), new Point(1, 1), new Point(1, 0), new Point(2, 1) } },
            // new Tetromino { Fill = Brushes.Red, RelativePoints = new [] { new Point(0,0), new Point(1, 0), new Point(1, 1), new Point(2, 1) } }
        };

        public Point Origin;
        public Dictionary<Orientation, Point[]> RelativePoints { get; set; }
        public SolidBrush Fill { get; set; }
        public Orientation Orientation { get; set; }
        public IEnumerable<Point> ObjectivePoints => RelativePoints[Orientation].Select(p => new Point(Origin.X + p.X, Origin.Y + p.Y));

        public void Draw(Graphics g)
        {
            foreach (var p in ObjectivePoints)
                g.FillRectangle(Fill, p.X, p.Y, 1, 1);

            
        }
    }

    public class TetrisBlockI : TetrisBlock
    {
        public TetrisBlockI()
        {
            Fill = new SolidBrush(Color.Cyan);
            RelativePoints = new Dictionary<Orientation, Point[]>
            {
                { Orientation.Up, new[] { new Point(0, 1), new Point(1, 1), new Point(2, 1), new Point(3, 1) } },
                { Orientation.Right, new[] { new Point(2, 0), new Point(2, 1), new Point(2, 2), new Point(2, 3) } },
                { Orientation.Down, new[] { new Point(0, 2), new Point(1, 2), new Point(2, 2), new Point(3, 2) } },
                { Orientation.Left, new[] { new Point(1, 0), new Point(1, 1), new Point(1, 2), new Point(1, 3) } }
            };
        }
    }

    public class TetrisBlockJ : TetrisBlock
    {
        public TetrisBlockJ()
        {
            Fill = new SolidBrush(Color.Blue);
            RelativePoints = new Dictionary<Orientation, Point[]>
            {
                { Orientation.Up, new[] { new Point(0, 0), new Point(0, 1), new Point(1, 1), new Point(2, 1) } },
                { Orientation.Right, new[] { new Point(1, 0), new Point(2, 0), new Point(1, 1), new Point(1, 2) } },
                { Orientation.Down, new[] { new Point(0, 1), new Point(1, 1), new Point(2, 1), new Point(2, 2) } },
                { Orientation.Left, new[] { new Point(0, 2), new Point(1, 2), new Point(1, 1), new Point(1, 0) } }
            };
        }
    }

    public class TetrisBlockL : TetrisBlock
    {
        public TetrisBlockL()
        {
            Fill = new SolidBrush(Color.Orange);
            RelativePoints = new Dictionary<Orientation, Point[]>
            {
                { Orientation.Up, new[] { new Point(0, 1), new Point(1, 1), new Point(2, 1), new Point(2, 0) } },
                { Orientation.Right, new[] { new Point(1, 0), new Point(1, 1), new Point(1, 2), new Point(2, 2) } },
                { Orientation.Down, new[] { new Point(0, 1), new Point(1, 1), new Point(2, 1), new Point(0, 2) } },
                { Orientation.Left, new[] { new Point(0, 0), new Point(1, 0), new Point(1, 1), new Point(1, 2) } }
            };
        }
    }

    public class TetrisBlockO : TetrisBlock
    {
        public TetrisBlockO()
        {
            Fill = new SolidBrush(Color.Yellow);
            RelativePoints = new Dictionary<Orientation, Point[]>
            {
                { Orientation.Up, new[] { new Point(0, 0), new Point(1, 0), new Point(0, 1), new Point(1, 1) } },
                { Orientation.Right, new[] { new Point(0, 0), new Point(1, 0), new Point(0, 1), new Point(1, 1) } },
                { Orientation.Down, new[] { new Point(0, 0), new Point(1, 0), new Point(0, 1), new Point(1, 1) } },
                { Orientation.Left, new[] { new Point(0, 0), new Point(1, 0), new Point(0, 1), new Point(1, 1) } }
            };
        }
    }

    public class TetrisBlockS : TetrisBlock
    {
        public TetrisBlockS()
        {
            Fill = new SolidBrush(Color.Green);
            RelativePoints = new Dictionary<Orientation, Point[]>
            {
                { Orientation.Up, new[] { new Point(0, 1), new Point(1, 1), new Point(1, 0), new Point(2, 0) } },
                { Orientation.Right, new[] { new Point(1, 0), new Point(1, 1), new Point(2, 1), new Point(2, 2) } },
                { Orientation.Down, new[] { new Point(0, 2), new Point(1, 2), new Point(1, 1), new Point(2, 1) } },
                { Orientation.Left, new[] { new Point(0, 0), new Point(0, 1), new Point(1, 1), new Point(1, 2) } }
            };
        }
    }

    public class TetrisBlockT : TetrisBlock
    {
        public TetrisBlockT()
        {
            Fill = new SolidBrush(Color.Purple);
            RelativePoints = new Dictionary<Orientation, Point[]>
            {
                { Orientation.Up, new[] { new Point(1, 0), new Point(0, 1), new Point(1, 1), new Point(2, 1) } },
                { Orientation.Right, new[] { new Point(1, 0), new Point(1, 1), new Point(2, 1), new Point(1, 2) } },
                { Orientation.Down, new[] { new Point(0, 1), new Point(1, 1), new Point(1, 2), new Point(2, 1) } },
                { Orientation.Left, new[] { new Point(0, 1), new Point(1, 0), new Point(1, 1), new Point(1, 2) } }
            };
        }
    }

    public class TetrisBlockZ : TetrisBlock
    {
        public TetrisBlockZ()
        {
            Fill = new SolidBrush(Color.Red);
            RelativePoints = new Dictionary<Orientation, Point[]>
            {
                { Orientation.Up, new[] { new Point(0, 0), new Point(1, 0), new Point(1, 1), new Point(2, 1) } },
                { Orientation.Right, new[] { new Point(1, 2), new Point(1, 1), new Point(2, 1), new Point(2, 0) } },
                { Orientation.Down, new[] { new Point(0, 1), new Point(1, 1), new Point(1, 2), new Point(2, 2) } },
                { Orientation.Left, new[] { new Point(0, 2), new Point(0, 1), new Point(1, 1), new Point(1, 0) } }
            };
        }
    }
}
