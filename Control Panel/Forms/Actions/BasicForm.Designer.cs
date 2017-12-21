namespace Control_Panel.Forms.Actions
{
    partial class BasicForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BasicForm));
            this.clearButton = new System.Windows.Forms.Button();
            this.brightnessButton = new System.Windows.Forms.Button();
            this.brightnessBar = new System.Windows.Forms.TrackBar();
            this.colorComboBox1 = new Control_Panel.ColorComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.brightnessBar)).BeginInit();
            this.SuspendLayout();
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(12, 189);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(150, 30);
            this.clearButton.TabIndex = 5;
            this.clearButton.Text = "Clear Panel";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // brightnessButton
            // 
            this.brightnessButton.Location = new System.Drawing.Point(12, 51);
            this.brightnessButton.Name = "brightnessButton";
            this.brightnessButton.Size = new System.Drawing.Size(150, 30);
            this.brightnessButton.TabIndex = 2;
            this.brightnessButton.Text = "Set Brightness - 64";
            this.brightnessButton.UseVisualStyleBackColor = true;
            this.brightnessButton.Click += new System.EventHandler(this.brightnessButton_Click);
            // 
            // brightnessBar
            // 
            this.brightnessBar.Location = new System.Drawing.Point(12, 12);
            this.brightnessBar.Maximum = 255;
            this.brightnessBar.Name = "brightnessBar";
            this.brightnessBar.Size = new System.Drawing.Size(150, 45);
            this.brightnessBar.TabIndex = 1;
            this.brightnessBar.TickFrequency = 64;
            this.brightnessBar.Value = 64;
            this.brightnessBar.Scroll += new System.EventHandler(this.brightnessBar_Scroll);
            // 
            // colorComboBox1
            // 
            this.colorComboBox1.Colors = ((System.Collections.Generic.List<System.Drawing.Color>)(resources.GetObject("colorComboBox1.Colors")));
            this.colorComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.colorComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colorComboBox1.FormattingEnabled = true;
            this.colorComboBox1.Items.AddRange(new object[] {
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
            this.colorComboBox1.Location = new System.Drawing.Point(13, 141);
            this.colorComboBox1.Name = "colorComboBox1";
            this.colorComboBox1.ShowAllColors = true;
            this.colorComboBox1.Size = new System.Drawing.Size(148, 23);
            this.colorComboBox1.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 105);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 30);
            this.button1.TabIndex = 3;
            this.button1.Text = "Set Color";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(12, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 2);
            this.label2.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(12, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 2);
            this.label1.TabIndex = 8;
            // 
            // BasicForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(174, 231);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.colorComboBox1);
            this.Controls.Add(this.brightnessButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.brightnessBar);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BasicForm";
            this.ShowIcon = false;
            this.Text = "Basic Actions";
            ((System.ComponentModel.ISupportInitialize)(this.brightnessBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button brightnessButton;
        private System.Windows.Forms.TrackBar brightnessBar;
        private ColorComboBox colorComboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}