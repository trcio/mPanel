﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;
using mPanel.Matrix;
using mPanel.Actions;
using mPanel.Actions.Snake;
using mPanel.Actions.Pong;
using mPanel.Actions.Visualizer;
using mPanel.Actions.Weather;

namespace mPanel
{
    public partial class ContainerForm : Form
    {
        private readonly Dictionary<string, Type> ActionForms;

        public MatrixPanel Matrix { get; }

        public ContainerForm()
        {
            InitializeComponent();

            Matrix = new MatrixPanel(15, 15);

            ActionForms = new Dictionary<string, Type>
            {
                { "Snake", typeof(SnakeForm) },
                { "Pong", typeof(PongForm) },
                { "Visualizer", typeof(VisualizerForm) },
                { "Weather", typeof(WeatherForm) }
            };
        }

        #region Methods

        private void ClearActions()
        {
            foreach (var form in MdiChildren)
                form.Close();

            actionsToolStripMenuItem.Visible = false;
        }

        private void InitializeActions()
        {
            var preview = new PreviewForm { MdiParent = this };
            preview.Show();
            preview.Location = new Point(0, 0);

            var basic = new BasicForm { MdiParent = this };
            basic.Show();
            basic.Location = new Point(preview.Right, 0);

            actionsToolStripMenuItem.Visible = true;
        }

        #endregion

        #region Form Events

        private void ContainerForm_Load(object sender, EventArgs e)
        {
            portComboBox.Items.AddRange(SerialPort.GetPortNames());

            if (portComboBox.Items.Count > 0)
                portComboBox.SelectedIndex = 0;

            foreach (var action in ActionForms)
            {
                var item = actionsToolStripMenuItem.DropDownItems.Add(action.Key);
                item.Tag = action.Value;
                item.Click += ActionItem_Click;
            }
        }

        private void ActionItem_Click(object sender, EventArgs eventArgs)
        {
            var item = (ToolStripMenuItem) sender;
            var instance = (Form) Activator.CreateInstance((Type) item.Tag);

            instance.MdiParent = this;
            instance.Show();
        }

        private void ContainerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Matrix.Disconnect();
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Matrix.Connected)
            {
                ClearActions();
                Matrix.Disconnect();

                portComboBox.Enabled = true;
                connectToolStripMenuItem.Text = "Connect to";
            }
            else
            {
                if (string.IsNullOrWhiteSpace(portComboBox.Text) || !Matrix.Connect(portComboBox.Text))
                    return;

                InitializeActions();

                portComboBox.Enabled = false;
                connectToolStripMenuItem.Text = "Disconnect from";
            }
        }

        private void portComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                connectToolStripMenuItem_Click(sender, e);
        }

        #endregion
    }
}
