namespace Control_Panel.Actions
{
    partial class PongForm
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
            this.SuspendLayout();
            // 
            // enableButton
            // 
            this.enableButton.Location = new System.Drawing.Point(12, 83);
            this.enableButton.Name = "enableButton";
            this.enableButton.Size = new System.Drawing.Size(150, 30);
            this.enableButton.TabIndex = 9;
            this.enableButton.Text = "Enable";
            this.enableButton.UseVisualStyleBackColor = true;
            // 
            // PongForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(174, 127);
            this.Controls.Add(this.enableButton);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PongForm";
            this.ShowIcon = false;
            this.Text = "Pong";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button enableButton;
    }
}