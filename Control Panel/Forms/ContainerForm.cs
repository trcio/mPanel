using System;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;
using Control_Panel.Matrix;

namespace Control_Panel.Forms
{
    public partial class ContainerForm : Form
    {
        private readonly MatrixPanel Matrix;      

        public ContainerForm()
        {
            InitializeComponent();

            Matrix = new MatrixPanel(15, 15);
        }

        #region Form Events

        private void ContainerForm_Load(object sender, EventArgs e)
        {
            portComboBox.Items.AddRange((object[]) SerialPort.GetPortNames().AsEnumerable());

            if (portComboBox.Items.Count > 0)
                portComboBox.SelectedIndex = 0;
        }

        private void ContainerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Matrix.Disconnect();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            if (Matrix.Connected)
            {
                CloseChildrenForms();
                Matrix.Disconnect();
                connectButton.Text = "Connect";
            }
            else
            {
                if (string.IsNullOrWhiteSpace(portComboBox.Text) || !Matrix.Connect(portComboBox.Text))
                    return;

                AddInitialForms();
                Matrix.Clear();
                connectButton.Text = "Disconnect";
            }
        }

        #endregion

        #region Methods

        private void CloseChildrenForms()
        {
            foreach (var form in MdiChildren)
                form.Close();
        }

        private void AddInitialForms()
        {
            var preview = new PreviewForm { MdiParent = this };
            Matrix.FrameHook += preview.Matrix_FrameHook;
            preview.Show();
        }

        #endregion
    }
}
