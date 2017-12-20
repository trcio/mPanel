namespace Control_Panel
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.serialPorts = new System.Windows.Forms.ComboBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.colorButton = new System.Windows.Forms.Button();
            this.brightnessBar = new System.Windows.Forms.TrackBar();
            this.brightnessButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.hardwareBox = new System.Windows.Forms.GroupBox();
            this.actionBox = new System.Windows.Forms.GroupBox();
            this.rainbowButton = new System.Windows.Forms.Button();
            this.rainbowUpDown = new System.Windows.Forms.NumericUpDown();
            this.rainbowTimer = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.panelPreview1 = new Control_Panel.Matrix.PanelPreview();
            this.colorComboBox = new Control_Panel.ColorComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.brightnessBar)).BeginInit();
            this.hardwareBox.SuspendLayout();
            this.actionBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rainbowUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // serialPorts
            // 
            this.serialPorts.FormattingEnabled = true;
            this.serialPorts.Location = new System.Drawing.Point(11, 20);
            this.serialPorts.Margin = new System.Windows.Forms.Padding(2);
            this.serialPorts.Name = "serialPorts";
            this.serialPorts.Size = new System.Drawing.Size(98, 21);
            this.serialPorts.TabIndex = 1;
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(10, 45);
            this.connectButton.Margin = new System.Windows.Forms.Padding(2);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(100, 23);
            this.connectButton.TabIndex = 2;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // colorButton
            // 
            this.colorButton.Location = new System.Drawing.Point(10, 47);
            this.colorButton.Margin = new System.Windows.Forms.Padding(2);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(130, 23);
            this.colorButton.TabIndex = 3;
            this.colorButton.Text = "Set Color";
            this.colorButton.UseVisualStyleBackColor = true;
            this.colorButton.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // brightnessBar
            // 
            this.brightnessBar.Location = new System.Drawing.Point(143, 20);
            this.brightnessBar.Margin = new System.Windows.Forms.Padding(2);
            this.brightnessBar.Maximum = 255;
            this.brightnessBar.Name = "brightnessBar";
            this.brightnessBar.Size = new System.Drawing.Size(210, 45);
            this.brightnessBar.TabIndex = 6;
            this.brightnessBar.TickFrequency = 64;
            this.brightnessBar.Value = 64;
            this.brightnessBar.Scroll += new System.EventHandler(this.brightnessBar_Scroll);
            // 
            // brightnessButton
            // 
            this.brightnessButton.Location = new System.Drawing.Point(144, 74);
            this.brightnessButton.Margin = new System.Windows.Forms.Padding(2);
            this.brightnessButton.Name = "brightnessButton";
            this.brightnessButton.Size = new System.Drawing.Size(209, 23);
            this.brightnessButton.TabIndex = 7;
            this.brightnessButton.Text = "Set Brightness - 64";
            this.brightnessButton.UseVisualStyleBackColor = true;
            this.brightnessButton.Click += new System.EventHandler(this.brightnessButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(10, 74);
            this.clearButton.Margin = new System.Windows.Forms.Padding(2);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(130, 23);
            this.clearButton.TabIndex = 8;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // hardwareBox
            // 
            this.hardwareBox.Controls.Add(this.serialPorts);
            this.hardwareBox.Controls.Add(this.connectButton);
            this.hardwareBox.Location = new System.Drawing.Point(12, 12);
            this.hardwareBox.Name = "hardwareBox";
            this.hardwareBox.Size = new System.Drawing.Size(121, 78);
            this.hardwareBox.TabIndex = 9;
            this.hardwareBox.TabStop = false;
            this.hardwareBox.Text = " Hardware";
            // 
            // actionBox
            // 
            this.actionBox.Controls.Add(this.rainbowButton);
            this.actionBox.Controls.Add(this.colorComboBox);
            this.actionBox.Controls.Add(this.rainbowUpDown);
            this.actionBox.Controls.Add(this.colorButton);
            this.actionBox.Controls.Add(this.brightnessButton);
            this.actionBox.Controls.Add(this.clearButton);
            this.actionBox.Controls.Add(this.brightnessBar);
            this.actionBox.Location = new System.Drawing.Point(139, 12);
            this.actionBox.Name = "actionBox";
            this.actionBox.Size = new System.Drawing.Size(363, 138);
            this.actionBox.TabIndex = 10;
            this.actionBox.TabStop = false;
            this.actionBox.Text = "Actions";
            // 
            // rainbowButton
            // 
            this.rainbowButton.Location = new System.Drawing.Point(144, 102);
            this.rainbowButton.Name = "rainbowButton";
            this.rainbowButton.Size = new System.Drawing.Size(150, 23);
            this.rainbowButton.TabIndex = 13;
            this.rainbowButton.Text = "Rainbow Fade";
            this.rainbowButton.UseVisualStyleBackColor = true;
            this.rainbowButton.Click += new System.EventHandler(this.rainbowButton_Click);
            // 
            // rainbowUpDown
            // 
            this.rainbowUpDown.Location = new System.Drawing.Point(300, 102);
            this.rainbowUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.rainbowUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.rainbowUpDown.Name = "rainbowUpDown";
            this.rainbowUpDown.Size = new System.Drawing.Size(53, 22);
            this.rainbowUpDown.TabIndex = 12;
            this.rainbowUpDown.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.rainbowUpDown.ValueChanged += new System.EventHandler(this.rainbowUpDown_ValueChanged);
            // 
            // rainbowTimer
            // 
            this.rainbowTimer.Interval = 40;
            this.rainbowTimer.Tick += new System.EventHandler(this.rainbowTimer_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 127);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panelPreview1
            // 
            this.panelPreview1.FrameBuffer = null;
            this.panelPreview1.GapSize = 1;
            this.panelPreview1.Location = new System.Drawing.Point(23, 156);
            this.panelPreview1.Name = "panelPreview1";
            this.panelPreview1.PanelHeight = 15;
            this.panelPreview1.PanelWidth = 15;
            this.panelPreview1.PixelSize = 5;
            this.panelPreview1.Size = new System.Drawing.Size(129, 117);
            this.panelPreview1.TabIndex = 12;
            // 
            // colorComboBox
            // 
            this.colorComboBox.Colors = ((System.Collections.Generic.List<System.Drawing.Color>)(resources.GetObject("colorComboBox.Colors")));
            this.colorComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.colorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colorComboBox.FormattingEnabled = true;
            this.colorComboBox.Items.AddRange(new object[] {
            "Transparent",
            "AliceBlue",
            "AntiqueWhite",
            "Aqua",
            "Aquamarine",
            "Azure",
            "Beige",
            "Bisque",
            "Black",
            "BlanchedAlmond",
            "Blue",
            "BlueViolet",
            "Brown",
            "BurlyWood",
            "CadetBlue",
            "Chartreuse",
            "Chocolate",
            "Coral",
            "CornflowerBlue",
            "Cornsilk",
            "Crimson",
            "Cyan",
            "DarkBlue",
            "DarkCyan",
            "DarkGoldenrod",
            "DarkGray",
            "DarkGreen",
            "DarkKhaki",
            "DarkMagenta",
            "DarkOliveGreen",
            "DarkOrange",
            "DarkOrchid",
            "DarkRed",
            "DarkSalmon",
            "DarkSeaGreen",
            "DarkSlateBlue",
            "DarkSlateGray",
            "DarkTurquoise",
            "DarkViolet",
            "DeepPink",
            "DeepSkyBlue",
            "DimGray",
            "DodgerBlue",
            "Firebrick",
            "FloralWhite",
            "ForestGreen",
            "Fuchsia",
            "Gainsboro",
            "GhostWhite",
            "Gold",
            "Goldenrod",
            "Gray",
            "Green",
            "GreenYellow",
            "Honeydew",
            "HotPink",
            "IndianRed",
            "Indigo",
            "Ivory",
            "Khaki",
            "Lavender",
            "LavenderBlush",
            "LawnGreen",
            "LemonChiffon",
            "LightBlue",
            "LightCoral",
            "LightCyan",
            "LightGoldenrodYellow",
            "LightGreen",
            "LightGray",
            "LightPink",
            "LightSalmon",
            "LightSeaGreen",
            "LightSkyBlue",
            "LightSlateGray",
            "LightSteelBlue",
            "LightYellow",
            "Lime",
            "LimeGreen",
            "Linen",
            "Magenta",
            "Maroon",
            "MediumAquamarine",
            "MediumBlue",
            "MediumOrchid",
            "MediumPurple",
            "MediumSeaGreen",
            "MediumSlateBlue",
            "MediumSpringGreen",
            "MediumTurquoise",
            "MediumVioletRed",
            "MidnightBlue",
            "MintCream",
            "MistyRose",
            "Moccasin",
            "NavajoWhite",
            "Navy",
            "OldLace",
            "Olive",
            "OliveDrab",
            "Orange",
            "OrangeRed",
            "Orchid",
            "PaleGoldenrod",
            "PaleGreen",
            "PaleTurquoise",
            "PaleVioletRed",
            "PapayaWhip",
            "PeachPuff",
            "Peru",
            "Pink",
            "Plum",
            "PowderBlue",
            "Purple",
            "Red",
            "RosyBrown",
            "RoyalBlue",
            "SaddleBrown",
            "Salmon",
            "SandyBrown",
            "SeaGreen",
            "SeaShell",
            "Sienna",
            "Silver",
            "SkyBlue",
            "SlateBlue",
            "SlateGray",
            "Snow",
            "SpringGreen",
            "SteelBlue",
            "Tan",
            "Teal",
            "Thistle",
            "Tomato",
            "Turquoise",
            "Violet",
            "Wheat",
            "White",
            "WhiteSmoke",
            "Yellow",
            "YellowGreen"});
            this.colorComboBox.Location = new System.Drawing.Point(11, 20);
            this.colorComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.colorComboBox.Name = "colorComboBox";
            this.colorComboBox.ShowAllColors = true;
            this.colorComboBox.Size = new System.Drawing.Size(128, 23);
            this.colorComboBox.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(514, 276);
            this.Controls.Add(this.panelPreview1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.actionBox);
            this.Controls.Add(this.hardwareBox);
            this.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(530, 200);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = " MatrixPanel Control MatrixPanel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.brightnessBar)).EndInit();
            this.hardwareBox.ResumeLayout(false);
            this.actionBox.ResumeLayout(false);
            this.actionBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rainbowUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox serialPorts;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button colorButton;
        private ColorComboBox colorComboBox;
        private System.Windows.Forms.TrackBar brightnessBar;
        private System.Windows.Forms.Button brightnessButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.GroupBox hardwareBox;
        private System.Windows.Forms.GroupBox actionBox;
        private System.Windows.Forms.NumericUpDown rainbowUpDown;
        private System.Windows.Forms.Button rainbowButton;
        private System.Windows.Forms.Timer rainbowTimer;
        private System.Windows.Forms.Button button1;
        private Matrix.PanelPreview panelPreview1;
    }
}

