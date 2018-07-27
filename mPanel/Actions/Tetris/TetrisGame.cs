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
        private readonly List<Keys> ActiveKeys;

        public List<TetrisBlock> Blocks;
        public TetrisBlock Falling;

        public bool[][] Grid;

        public TetrisGame()
        {
            ActiveKeys = new List<Keys>();
            Blocks = new List<TetrisBlock>();
            Falling = new TetrisBlockI();
        }

        public void KeyDown(KeyEventArgs e)
        {
            ActiveKeys.Add(e.KeyCode);
        }

        public void KeyUp(KeyEventArgs e)
        {
            ActiveKeys.RemoveAll(k => k == e.KeyCode);
        }

        public void Loop(Frame frame)
        {
            foreach (var t in Blocks)
            {
                t.Draw(frame.Graphics);
            }

            Falling.Draw(frame.Graphics);

            HandleInput();
            // MoveFalling();
            // CollideFalling();
            
        }

        private void HandleInput()
        {
            foreach (var e in ActiveKeys)
            {
                switch (e)
                {
                    case Keys.W:
                        Falling.Orientation++;

                        if ((int) Falling.Orientation > 3)
                            Falling.Orientation = Orientation.Up;

                        break;
                    case Keys.S:
                        Falling.Origin.Y++;
                        break;
                    case Keys.A:
                        Falling.Origin.X--;
                        break;
                    case Keys.D:
                        Falling.Origin.X++;
                        break;
                    case Keys.N:
                        Falling = TetrisBlock.StandardSet[new Random().Next(TetrisBlock.StandardSet.Count)];

                        break;
                }
            }
        }

        private void MoveFalling()
        {
            Falling.Origin.Y++;
        }

        private void CollideFalling()
        {
            CreateGrid();

            foreach (var p in Falling.ObjectivePoints)
            {
                if (p.X < 0 || p.Y < 0 || p.Y > 14 || p.X > 9 || Grid[p.X][p.Y])
                {
                    Falling.Origin.Y--;

                    Blocks.Add(Falling);

                    // assign new tetromino
                    Falling = TetrisBlock.StandardSet[new Random().Next(TetrisBlock.StandardSet.Count)];
                    Falling.Origin.X -= 2;

                    break;
                }
            }
        }

        private void CreateGrid()
        {
            Grid = new bool[10][];

            for (var i = 0; i < Grid.Length; i++)
                Grid[i] = new bool[15];


            foreach (var p in Blocks.SelectMany(t => t.ObjectivePoints))
            {
                Grid[p.X][p.Y] = true;
            }
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
        public static List<TetrisBlock> StandardSet = new List<TetrisBlock>
        {
            new TetrisBlockI { Orientation = Orientation.Up },
            new TetrisBlockJ { Orientation = Orientation.Up },
            new TetrisBlockL { Orientation = Orientation.Up },
            new TetrisBlockO() { Orientation = Orientation.Up },
            new TetrisBlockS() { Orientation = Orientation.Up },
            new TetrisBlockT() { Orientation = Orientation.Up },
            new TetrisBlockZ() { Orientation = Orientation.Up }
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
