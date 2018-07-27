namespace mPanel.Actions.Snake
{
    partial class SnakeForm
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
            this.upButton = new System.Windows.Forms.Button();
            this.downButton = new System.Windows.Forms.Button();
            this.leftButton = new System.Windows.Forms.Button();
            this.rightButton = new System.Windows.Forms.Button();
            this.divider1 = new System.Windows.Forms.Label();
            this.endlessCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // enableButton
            // 
            this.enableButton.Location = new System.Drawing.Point(12, 97);
            this.enableButton.Name = "enableButton";
            this.enableButton.Size = new System.Drawing.Size(150, 30);
            this.enableButton.TabIndex = 0;
            this.enableButton.Text = "Enable";
            this.enableButton.UseVisualStyleBackColor = true;
            this.enableButton.Click += new System.EventHandler(this.enableButton_Click);
            // 
            // upButton
            // 
            this.upButton.Font = new System.Drawing.Font("Consolas", 8F);
            this.upButton.Location = new System.Drawing.Point(63, 11);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(45, 30);
            this.upButton.TabIndex = 1;
            this.upButton.Text = "W";
            this.upButton.UseVisualStyleBackColor = true;
            this.upButton.Click += new System.EventHandler(this.upButton_Click);
            // 
            // downButton
            // 
            this.downButton.Font = new System.Drawing.Font("Consolas", 8F);
            this.downButton.Location = new System.Drawing.Point(63, 47);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(45, 30);
            this.downButton.TabIndex = 2;
            this.downButton.Text = "S";
            this.downButton.UseVisualStyleBackColor = true;
            this.downButton.Click += new System.EventHandler(this.downButton_Click);
            // 
            // leftButton
            // 
            this.leftButton.Font = new System.Drawing.Font("Consolas", 8F);
            this.leftButton.Location = new System.Drawing.Point(12, 47);
            this.leftButton.Name = "leftButton";
            this.leftButton.Size = new System.Drawing.Size(45, 30);
            this.leftButton.TabIndex = 3;
            this.leftButton.Text = "A";
            this.leftButton.UseVisualStyleBackColor = true;
            this.leftButton.Click += new System.EventHandler(this.leftButton_Click);
            // 
            // rightButton
            // 
            this.rightButton.Font = new System.Drawing.Font("Consolas", 8F);
            this.rightButton.Location = new System.Drawing.Point(117, 47);
            this.rightButton.Name = "rightButton";
            this.rightButton.Size = new System.Drawing.Size(45, 30);
            this.rightButton.TabIndex = 4;
            this.rightButton.Text = "D";
            this.rightButton.UseVisualStyleBackColor = true;
            this.rightButton.Click += new System.EventHandler(this.rightButton_Click);
            // 
            // divider1
            // 
            this.divider1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.divider1.Location = new System.Drawing.Point(12, 86);
            this.divider1.Name = "divider1";
            this.divider1.Size = new System.Drawing.Size(151, 2);
            this.divider1.TabIndex = 8;
            // 
            // endlessCheckBox
            // 
            this.endlessCheckBox.AutoSize = true;
            this.endlessCheckBox.Location = new System.Drawing.Point(13, 136);
            this.endlessCheckBox.Name = "endlessCheckBox";
            this.endlessCheckBox.Size = new System.Drawing.Size(97, 17);
            this.endlessCheckBox.TabIndex = 9;
            this.endlessCheckBox.Text = "Endless mode";
            this.endlessCheckBox.UseVisualStyleBackColor = true;
            // 
            // SnakeForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(174, 164);
            this.Controls.Add(this.endlessCheckBox);
            this.Controls.Add(this.divider1);
            this.Controls.Add(this.rightButton);
            this.Controls.Add(this.leftButton);
            this.Controls.Add(this.downButton);
            this.Controls.Add(this.upButton);
            this.Controls.Add(this.enableButton);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SnakeForm";
            this.ShowIcon = false;
            this.Text = "Snake";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SnakeForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SnakeForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button enableButton;
        private System.Windows.Forms.Button upButton;
        private System.Windows.Forms.Button downButton;
        private System.Windows.Forms.Button leftButton;
        private System.Windows.Forms.Button rightButton;
        private System.Windows.Forms.Label divider1;
        private System.Windows.Forms.CheckBox endlessCheckBox;
    }
}