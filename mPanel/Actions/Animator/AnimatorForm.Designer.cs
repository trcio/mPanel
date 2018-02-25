namespace mPanel.Actions.Animator
{
    partial class AnimatorForm
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
            this.addFrameButton = new System.Windows.Forms.Button();
            this.treeView = new System.Windows.Forms.TreeView();
            this.editor = new mPanel.Controls.FrameEditor();
            this.label1 = new System.Windows.Forms.Label();
            this.delayUpDown = new System.Windows.Forms.NumericUpDown();
            this.timerButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.delayUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // addFrameButton
            // 
            this.addFrameButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addFrameButton.Location = new System.Drawing.Point(112, 341);
            this.addFrameButton.Name = "addFrameButton";
            this.addFrameButton.Size = new System.Drawing.Size(100, 30);
            this.addFrameButton.TabIndex = 2;
            this.addFrameButton.Text = "Add Frame";
            this.addFrameButton.UseVisualStyleBackColor = true;
            this.addFrameButton.Click += new System.EventHandler(this.addFrameButton_Click);
            // 
            // treeView
            // 
            this.treeView.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView.HideSelection = false;
            this.treeView.Indent = 5;
            this.treeView.ItemHeight = 20;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Name = "treeView";
            this.treeView.ShowPlusMinus = false;
            this.treeView.Size = new System.Drawing.Size(100, 383);
            this.treeView.TabIndex = 3;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            // 
            // editor
            // 
            this.editor.BackColor = System.Drawing.Color.White;
            this.editor.CurrentFrame = null;
            this.editor.GapSize = 1;
            this.editor.Location = new System.Drawing.Point(112, 12);
            this.editor.MaximumSize = new System.Drawing.Size(315, 315);
            this.editor.MinimumSize = new System.Drawing.Size(315, 315);
            this.editor.Name = "editor";
            this.editor.PixelSize = 20;
            this.editor.Size = new System.Drawing.Size(315, 315);
            this.editor.TabIndex = 1;
            this.editor.Text = "ss";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(436, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Delay (ms)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // delayUpDown
            // 
            this.delayUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.delayUpDown.Location = new System.Drawing.Point(439, 28);
            this.delayUpDown.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.delayUpDown.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.delayUpDown.Name = "delayUpDown";
            this.delayUpDown.Size = new System.Drawing.Size(100, 22);
            this.delayUpDown.TabIndex = 5;
            this.delayUpDown.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // timerButton
            // 
            this.timerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timerButton.Location = new System.Drawing.Point(439, 56);
            this.timerButton.Name = "timerButton";
            this.timerButton.Size = new System.Drawing.Size(100, 30);
            this.timerButton.TabIndex = 7;
            this.timerButton.Text = "Enable";
            this.timerButton.UseVisualStyleBackColor = true;
            this.timerButton.Click += new System.EventHandler(this.timerButton_Click);
            // 
            // AnimatorForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(551, 383);
            this.Controls.Add(this.timerButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.delayUpDown);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.addFrameButton);
            this.Controls.Add(this.editor);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AnimatorForm";
            this.ShowIcon = false;
            this.Text = "Animator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AnimatorForm_FormClosing);
            this.Load += new System.EventHandler(this.AnimatorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.delayUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Controls.FrameEditor editor;
        private System.Windows.Forms.Button addFrameButton;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown delayUpDown;
        private System.Windows.Forms.Button timerButton;
    }
}