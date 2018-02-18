using System;
using System.Drawing;
using System.Windows.Forms;
using mPanel.Matrix;
using mPanel.Extra;
using mPanel.Extra.Yahoo;

namespace mPanel.Actions.Weather
{
    public partial class WeatherForm : Form
    {
        private MatrixPanel Matrix => ((ContainerForm) MdiParent)?.Matrix;

        private readonly Frame Frame;
        private readonly NumberSegment Digit1, Digit2;
        private readonly YahooProvider Yahoo;

        public WeatherForm()
        {
            InitializeComponent();

            Frame = new Frame();

            Digit1 = new NumberSegment { Location = new Point(4, 5) };
            Digit2 = new NumberSegment { Location = new Point(8, 5) };
            
            Yahoo = new YahooProvider();
        }

        #region Methods

        private async void UpdateWeather()
        {
            try
            {
                var data = await Yahoo.GetWeather(locationTextBox.Text);

                if (!UpdateUi(data))
                    return;

                var temp = int.Parse(data.Query.Results.Channel.Item.Condition.Temp);

                Digit1.SetDigit(temp / 10);
                Digit2.SetDigit(temp % 10);

                Digit1.Draw(Frame.Graphics);
                Digit2.Draw(Frame.Graphics);

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
            locationTextBox.SelectAll();

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

        private void locationTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            e.SuppressKeyPress = true;
            UpdateWeather();
        }

        private void locationTextBox_Click(object sender, EventArgs e)
        {
            locationTextBox.SelectAll();
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            UpdateWeather();
        }

        #endregion
    }
}
