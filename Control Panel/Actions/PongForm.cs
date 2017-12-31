using System.Drawing;
using System.Timers;
using System.Windows.Forms;
using Control_Panel.Matrix;
using Timer = System.Timers.Timer;

namespace Control_Panel.Actions
{
    public partial class PongForm : Form
    {
        private const int FramesPerSecond = 30;

        private MatrixPanel Matrix => ((ContainerForm) MdiParent)?.Matrix;

        private readonly Timer GameTimer;
        private readonly Frame Frame;

        public PongForm()
        {
            InitializeComponent();

            GameTimer = new Timer(1000.0 / FramesPerSecond);
            GameTimer.Elapsed += GameTimerOnElapsed;

            Frame = new Frame();
        }

        private void GameTimerOnElapsed(object sender, ElapsedEventArgs e)
        {

            // push frame to matrix
            Matrix.SendFrame(Frame);
        }
    }

    public class Paddle
    {
        private readonly Frame Frame;

        public Color Fill { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }

        public Paddle(Frame frame, Color fill, int x, int y, int width)
        {
            Frame = frame;
            Fill = fill;
            X = x;
            Y = y;
            Width = width;
        }

        public void Draw()
        {
            using (var fill = new SolidBrush(Fill))
            {
                Frame.Graphics.FillRectangle(fill, X, Y, Width, 1);
            }
        }
    }
}
