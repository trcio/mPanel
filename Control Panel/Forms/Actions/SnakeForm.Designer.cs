namespace Control_Panel.Forms.Actions
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
            this.SuspendLayout();
            // 
            // enableButton
            // 
            this.enableButton.Location = new System.Drawing.Point(12, 83);
            this.enableButton.Name = "enableButton";
            this.enableButton.Size = new System.Drawing.Size(150, 30);
            this.enableButton.TabIndex = 0;
            this.enableButton.Text = "Enable";
            this.enableButton.UseVisualStyleBackColor = true;
            // 
            // upButton
            // 
            this.upButton.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upButton.Location = new System.Drawing.Point(63, 13);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(48, 20);
            this.upButton.TabIndex = 1;
            this.upButton.Text = "UP";
            this.upButton.UseVisualStyleBackColor = true;
            // 
            // downButton
            // 
            this.downButton.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downButton.Location = new System.Drawing.Point(63, 39);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(48, 20);
            this.downButton.TabIndex = 2;
            this.downButton.Text = "DOWN";
            this.downButton.UseVisualStyleBackColor = true;
            // 
            // leftButton
            // 
            this.leftButton.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leftButton.Location = new System.Drawing.Point(12, 39);
            this.leftButton.Name = "leftButton";
            this.leftButton.Size = new System.Drawing.Size(45, 20);
            this.leftButton.TabIndex = 3;
            this.leftButton.Text = "LEFT";
            this.leftButton.UseVisualStyleBackColor = true;
            // 
            // rightButton
            // 
            this.rightButton.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rightButton.Location = new System.Drawing.Point(117, 39);
            this.rightButton.Name = "rightButton";
            this.rightButton.Size = new System.Drawing.Size(45, 20);
            this.rightButton.TabIndex = 4;
            this.rightButton.Text = "RIGHT";
            this.rightButton.UseVisualStyleBackColor = true;
            // 
            // divider1
            // 
            this.divider1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.divider1.Location = new System.Drawing.Point(12, 70);
            this.divider1.Name = "divider1";
            this.divider1.Size = new System.Drawing.Size(151, 2);
            this.divider1.TabIndex = 8;
            // 
            // SnakeForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(174, 271);
            this.Controls.Add(this.divider1);
            this.Controls.Add(this.rightButton);
            this.Controls.Add(this.leftButton);
            this.Controls.Add(this.downButton);
            this.Controls.Add(this.upButton);
            this.Controls.Add(this.enableButton);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SnakeForm";
            this.ShowIcon = false;
            this.Text = "Snake";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button enableButton;
        private System.Windows.Forms.Button upButton;
        private System.Windows.Forms.Button downButton;
        private System.Windows.Forms.Button leftButton;
        private System.Windows.Forms.Button rightButton;
        private System.Windows.Forms.Label divider1;
    }
}