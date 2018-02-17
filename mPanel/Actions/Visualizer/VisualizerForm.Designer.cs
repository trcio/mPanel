namespace mPanel.Actions.Visualizer
{
    partial class VisualizerForm
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
            this.enableButton = new System.Windows.Forms.Button();
            this.averageCheckBox = new System.Windows.Forms.CheckBox();
            this.minimumUpDown = new System.Windows.Forms.NumericUpDown();
            this.maximumUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.amplifierUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.minimumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.amplifierUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // enableButton
            // 
            this.enableButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.enableButton.Location = new System.Drawing.Point(12, 192);
            this.enableButton.Name = "enableButton";
            this.enableButton.Size = new System.Drawing.Size(150, 30);
            this.enableButton.TabIndex = 0;
            this.enableButton.Text = "Enable";
            this.enableButton.UseVisualStyleBackColor = true;
            this.enableButton.Click += new System.EventHandler(this.enableButton_Click);
            // 
            // averageCheckBox
            // 
            this.averageCheckBox.AutoSize = true;
            this.averageCheckBox.Location = new System.Drawing.Point(12, 12);
            this.averageCheckBox.Name = "averageCheckBox";
            this.averageCheckBox.Size = new System.Drawing.Size(88, 17);
            this.averageCheckBox.TabIndex = 1;
            this.averageCheckBox.Text = "Use average";
            this.averageCheckBox.UseVisualStyleBackColor = true;
            this.averageCheckBox.CheckedChanged += new System.EventHandler(this.averageCheckBox_CheckedChanged);
            // 
            // minimumUpDown
            // 
            this.minimumUpDown.Location = new System.Drawing.Point(12, 54);
            this.minimumUpDown.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.minimumUpDown.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.minimumUpDown.Name = "minimumUpDown";
            this.minimumUpDown.Size = new System.Drawing.Size(54, 22);
            this.minimumUpDown.TabIndex = 2;
            this.minimumUpDown.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.minimumUpDown.ValueChanged += new System.EventHandler(this.minimumUpDown_ValueChanged);
            // 
            // maximumUpDown
            // 
            this.maximumUpDown.Location = new System.Drawing.Point(12, 103);
            this.maximumUpDown.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.maximumUpDown.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.maximumUpDown.Name = "maximumUpDown";
            this.maximumUpDown.Size = new System.Drawing.Size(54, 22);
            this.maximumUpDown.TabIndex = 3;
            this.maximumUpDown.Value = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.maximumUpDown.ValueChanged += new System.EventHandler(this.maximumUpDown_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Minimum frequency";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Maximum frequency";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // amplifierUpDown
            // 
            this.amplifierUpDown.DecimalPlaces = 2;
            this.amplifierUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.amplifierUpDown.Location = new System.Drawing.Point(12, 152);
            this.amplifierUpDown.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.amplifierUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.amplifierUpDown.Name = "amplifierUpDown";
            this.amplifierUpDown.Size = new System.Drawing.Size(54, 22);
            this.amplifierUpDown.TabIndex = 6;
            this.amplifierUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.amplifierUpDown.ValueChanged += new System.EventHandler(this.amplifierUpDown_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Amplifier value";
            // 
            // VisualizerForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(174, 234);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.amplifierUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.maximumUpDown);
            this.Controls.Add(this.minimumUpDown);
            this.Controls.Add(this.averageCheckBox);
            this.Controls.Add(this.enableButton);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(190, 273);
            this.Name = "VisualizerForm";
            this.ShowIcon = false;
            this.Text = "Visualizer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VisualizerForm_FormClosing);
            this.Load += new System.EventHandler(this.VisualizerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.minimumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.amplifierUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button enableButton;
        private System.Windows.Forms.CheckBox averageCheckBox;
        private System.Windows.Forms.NumericUpDown minimumUpDown;
        private System.Windows.Forms.NumericUpDown maximumUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown amplifierUpDown;
        private System.Windows.Forms.Label label3;
    }
}