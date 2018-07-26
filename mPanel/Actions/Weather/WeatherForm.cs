using System;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;
using mPanel.Matrix;
using mPanel.Extra;
using mPanel.Extra.Color;
using mPanel.Extra.Yahoo;
using Timer = System.Timers.Timer;

namespace mPanel.Actions.Weather
{
    public partial class WeatherForm : Form
    {
        private const int FramesPerSecond = 30;

        private MatrixPanel Matrix => ((ContainerForm) MdiParent)?.Matrix;

        private readonly Frame Frame;
        private readonly Timer FrameTimer;
        private readonly TemperatureDisplay TemperatureDisplay;
        private readonly YahooProvider Yahoo;

        public WeatherForm()
        {
            InitializeComponent();

            Frame = new Frame();

            FrameTimer = new Timer(1000.0 / FramesPerSecond);
            FrameTimer.Elapsed += FrameTimer_Elapsed;

            TemperatureDisplay = new TemperatureDisplay(Frame);            
            Yahoo = new YahooProvider();
        }

        #region Methods

        private void FrameTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // Noise.FillNoise();
            //
            // Frame.Clear(Color.Black);
            //
            // for (var x = 0; x < MatrixPanel.Width; x++)
            // for (var y = 0; y < MatrixPanel.Height; y++)
            // {
            //     Frame.SetPixel(x, y, Noise.GetColorFromPalette(ColorPalette.StandbyRainbow, x, y));
            // }
            //
            // Noise.ColorOffset++;
            //
            // Matrix.SendFrame(Frame);
        }

        private async void UpdateWeather()
        {
            try
            {
                var data = await Yahoo.GetWeather(locationTextBox.Text);

                if (!UpdateUi(data))
                    return;

                Frame.Clear(Color.Black);

                TemperatureDisplay.SetTemperature(int.Parse(data.Query.Results.Channel.Item.Condition.Temp));
                TemperatureDisplay.Draw();

                Matrix.SendFrame(Frame);
            }
            catch (Exception)
            {
                UpdateUi(null);
                Matrix.Clear();
            }
        }

        private bool UpdateUi(WeatherResponse data)
        {
            if (data == null || data.Query?.Count < 1)
            {
                locationLabel.Text = countryLabel.Text = conditionLabel.Text = dateLabel.Text = "not found";
                conditionPictureBox.ImageLocation = string.Empty;
                return false;
            }

            locationLabel.Text = $"{data.Query?.Results.Channel.Location.City}, {data.Query?.Results.Channel.Location.Region}";
            countryLabel.Text = data.Query?.Results.Channel.Location.Country;
            conditionLabel.Text = $"{data.Query?.Results.Channel.Item.Condition.Temp} °F, {data.Query?.Results.Channel.Item.Condition.Text}";
            dateLabel.Text = data.Query?.Results.Channel.Item.Condition.Date.Substring(5);

            conditionPictureBox.ImageLocation = data.Query?.Results.Channel.Item.Description.InBetween("<img src=\"", "\"/>");

            return true;
        }

        #endregion

        #region Form Events

        private void WeatherForm_Load(object sender, EventArgs e)
        {
            locationTextBox.SetCue("zipcode or place");
        }

        private void locationTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            e.SuppressKeyPress = true;
            findButton_Click(sender, e);
        }

        private void locationTextBox_Click(object sender, EventArgs e)
        {
            locationTextBox.SelectAll();
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            UpdateWeather();

            if (FrameTimer.Enabled)
            {
                FrameTimer.Stop();
                findButton.Text = "Display Weather";
            }
            else
            {
                FrameTimer.Start();
                findButton.Text = "Stop";
            }
        }

        #endregion
    }
}
