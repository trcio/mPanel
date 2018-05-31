using mPanel.Controls;
using mPanel.Matrix;

namespace mPanel.Actions
{
    partial class PreviewForm
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
            this.panel = new mPanel.Controls.PanelPreview();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.BackColor = System.Drawing.SystemColors.Control;
            this.panel.GapSize = 1;
            this.panel.Location = new System.Drawing.Point(14, 15);
            this.panel.MinimumSize = new System.Drawing.Size(239, 239);
            this.panel.Name = "panel";
            this.panel.PixelSize = 15;
            this.panel.Size = new System.Drawing.Size(239, 239);
            this.panel.TabIndex = 0;
            // 
            // PreviewForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(268, 267);
            this.ControlBox = false;
            this.Controls.Add(this.panel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(279, 302);
            this.Name = "PreviewForm";
            this.Text = "Preview";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PreviewForm_FormClosing);
            this.Load += new System.EventHandler(this.PreviewForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private PanelPreview panel;
    }
}