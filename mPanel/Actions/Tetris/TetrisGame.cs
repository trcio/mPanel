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
        private readonly HashSet<Keys> ActiveKeys;

        private long FrameCount;

        public List<TetrisBlock> Blocks;
        public TetrisBlock ActiveBlock;

        public bool[][] Grid;
        public bool GameOver { get; private set; }

        public TetrisGame()
        {
            FrameCount = 0;
            ActiveKeys = new HashSet<Keys>();
            Blocks = new List<TetrisBlock>();
            ActiveBlock = new TetrisBlockI();
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

            ReloadGrid();
            RemoveCompleteRows();              

            ActiveBlock.Draw(frame.Graphics);

            foreach (var t in Blocks)
                t.Draw(frame.Graphics);

            DrawBorders(frame.Graphics);

            HandleInput();

            if (FrameCount % 10 == 0)
                MoveFalling();

            if (CheckOverflow())
            {
                GameOver = true;
                return;
            }

            if (IsActiveBlockColliding())
                ChangeActiveBlock();
        }

        private void DrawBorders(Graphics g)
        {
            g.FillRectangle(Brushes.White, 10, 0, 1, 15);
            g.FillRectangle(Brushes.White, 10, 4, 5, 1);
            g.FillRectangle(Brushes.White, 10, 9, 5, 1);
        }

        private void ReloadGrid()
        {
            Grid = new bool[15][];

            for (var i = 0; i < Grid.Length; i++)
                Grid[i] = new bool[10];
            
            foreach (var p in Blocks.SelectMany(t => t.ObjectivePoints))
            {
                Grid[p.Y][p.X] = true;
            }
        }

        private void HandleInput()
        {
            foreach (var e in ActiveKeys)
            {
                switch (e)
                {
                    case Keys.W:
                        RotateActiveBlock();
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

        private void MoveFalling()
        {
            ActiveBlock.Origin.Y++;
        }

        private bool IsActiveBlockColliding()
        {
            return ActiveBlock.ObjectivePoints.Any(p => p.X < 0 || p.X > 9 || p.Y > 14 || Grid[p.Y][p.X]);
        }

        private void ChangeActiveBlock()
        {
            ActiveBlock.Origin.Y--;

            Blocks.Add(ActiveBlock);

            // assign new tetromino
            ActiveBlock = TetrisBlock.StandardSet[new Random().Next(TetrisBlock.StandardSet.Count)];
        }

        private void RemoveCompleteRows()
        {
            for (var row = 0; row < Grid.Length; row++)
            {
                if (Grid[row].All(b => b))
                {
                    foreach (var block in Blocks)
                    {
                        for (var i = 0; i < block.RelativePoints[block.Orientation].Length; i++)
                        {
                            if (block.RelativePoints[block.Orientation][i].Y + block.Origin.Y == row)
                            {
                                block.RelativePoints[block.Orientation][i] = Point.Empty;
                            }
                        }
                    }
                }
            }
        }

        private bool CheckOverflow()
        {
            return Blocks.SelectMany(b => b.ObjectivePoints).Any(p => p.Y <= 0);
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
            // new TetrisBlockJ(),
            // new TetrisBlockL(),
            // new TetrisBlockO(),
            // new TetrisBlockS(),
            // new TetrisBlockT(),
            // new TetrisBlockZ()
            // new Tetromino { Fill = Brushes.Blue, RelativePoints = new [] { new Point(0, 0), new Point(0, 1), new Point(1, 1), new Point(2, 1) } },
            // new Tetromino { Fill = Brushes.Orange, RelativePoints = new [] { new Point(0, 1), new Point(1, 1), new Point(2, 1), new Point(2, 0) } },
            // new Tetromino { Fill = Brushes.Yellow, RelativePoints = new [] { new Point(0, 0), new Point(0, 1), new Point(1, 0), new Point(1, 1) } },
            // new Tetromino { Fill = Brushes.Green, RelativePoints = new [] { new Point(0, 1), new Point(1, 1), new Point(1, 0), new Point(2, 0) } },
            // new Tetromino { Fill = Brushes.Purple, RelativePoints = new[] { new Point(0, 1), new Point(1, 1), new Point(1, 0), new Point(2, 1) } },
            // new Tetromino { Fill = Brushes.Red, RelativePoints = new [] { new Point(0,0), new Point(1, 0), new Point(1, 1), new Point(2, 1) } }
        };

        public Point Origin;
        public Dictionary<Orientation, Point[]> RelativePoints { get; set; }
        public Brush Fill { get; set; }
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
            Fill = Brushes.Cyan;
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
            Fill = Brushes.Blue;
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
            Fill = Brushes.Orange;
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
            Fill = Brushes.Yellow;
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
            Fill = Brushes.Green;
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
            Fill = Brushes.Purple;
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
            Fill = Brushes.Red;
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
