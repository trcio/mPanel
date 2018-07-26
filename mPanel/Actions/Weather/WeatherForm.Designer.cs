namespace mPanel.Actions.Weather
{
    partial class WeatherForm
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
            this.locationTextBox = new System.Windows.Forms.TextBox();
            this.findButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.divider1 = new System.Windows.Forms.Label();
            this.locationLabel = new System.Windows.Forms.Label();
            this.countryLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.conditionLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.conditionPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.conditionPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // locationTextBox
            // 
            this.locationTextBox.Location = new System.Drawing.Point(12, 12);
            this.locationTextBox.Name = "locationTextBox";
            this.locationTextBox.Size = new System.Drawing.Size(150, 22);
            this.locationTextBox.TabIndex = 3;
            this.locationTextBox.Text = "richardson, tx";
            this.locationTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.locationTextBox.Click += new System.EventHandler(this.locationTextBox_Click);
            this.locationTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.locationTextBox_KeyDown);
            // 
            // findButton
            // 
            this.findButton.Location = new System.Drawing.Point(12, 40);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(150, 30);
            this.findButton.TabIndex = 4;
            this.findButton.Text = "Display Weather";
            this.findButton.UseVisualStyleBackColor = true;
            this.findButton.Click += new System.EventHandler(this.findButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Location";
            // 
            // divider1
            // 
            this.divider1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.divider1.Location = new System.Drawing.Point(12, 81);
            this.divider1.Name = "divider1";
            this.divider1.Size = new System.Drawing.Size(151, 2);
            this.divider1.TabIndex = 8;
            // 
            // locationLabel
            // 
            this.locationLabel.AutoSize = true;
            this.locationLabel.Location = new System.Drawing.Point(10, 104);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(60, 13);
            this.locationLabel.TabIndex = 9;
            this.locationLabel.Text = "not found";
            // 
            // countryLabel
            // 
            this.countryLabel.AutoSize = true;
            this.countryLabel.Location = new System.Drawing.Point(10, 134);
            this.countryLabel.Name = "countryLabel";
            this.countryLabel.Size = new System.Drawing.Size(60, 13);
            this.countryLabel.TabIndex = 11;
            this.countryLabel.Text = "not found";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Country";
            // 
            // conditionLabel
            // 
            this.conditionLabel.AutoSize = true;
            this.conditionLabel.Location = new System.Drawing.Point(10, 164);
            this.conditionLabel.Name = "conditionLabel";
            this.conditionLabel.Size = new System.Drawing.Size(60, 13);
            this.conditionLabel.TabIndex = 13;
            this.conditionLabel.Text = "not found";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(10, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Condition";
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(10, 194);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(60, 13);
            this.dateLabel.TabIndex = 15;
            this.dateLabel.Text = "not found";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(10, 179);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Date";
            // 
            // conditionPictureBox
            // 
            this.conditionPictureBox.InitialImage = null;
            this.conditionPictureBox.Location = new System.Drawing.Point(130, 130);
            this.conditionPictureBox.Name = "conditionPictureBox";
            this.conditionPictureBox.Size = new System.Drawing.Size(32, 32);
            this.conditionPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.conditionPictureBox.TabIndex = 16;
            this.conditionPictureBox.TabStop = false;
            // 
            // WeatherForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(174, 255);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.conditionLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.countryLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.locationLabel);
            this.Controls.Add(this.divider1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.findButton);
            this.Controls.Add(this.locationTextBox);
            this.Controls.Add(this.conditionPictureBox);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WeatherForm";
            this.ShowIcon = false;
            this.Text = "Weather";
            this.Load += new System.EventHandler(this.WeatherForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.conditionPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox locationTextBox;
        private System.Windows.Forms.Button findButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label divider1;
        private System.Windows.Forms.Label locationLabel;
        private System.Windows.Forms.Label countryLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label conditionLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox conditionPictureBox;
    }
}