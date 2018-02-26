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
            this.label1 = new System.Windows.Forms.Label();
            this.delayUpDown = new System.Windows.Forms.NumericUpDown();
            this.timerButton = new System.Windows.Forms.Button();
            this.removeFrameButton = new System.Windows.Forms.Button();
            this.upFrameButton = new System.Windows.Forms.Button();
            this.downFrameButton = new System.Windows.Forms.Button();
            this.loadAnimationButton = new System.Windows.Forms.Button();
            this.saveAnimationButton = new System.Windows.Forms.Button();
            this.clearAllButton = new System.Windows.Forms.Button();
            this.importButton = new System.Windows.Forms.Button();
            this.editor = new mPanel.Controls.FrameEditor();
            ((System.ComponentModel.ISupportInitialize)(this.delayUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // addFrameButton
            // 
            this.addFrameButton.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addFrameButton.Location = new System.Drawing.Point(12, 309);
            this.addFrameButton.Name = "addFrameButton";
            this.addFrameButton.Size = new System.Drawing.Size(47, 27);
            this.addFrameButton.TabIndex = 2;
            this.addFrameButton.Text = "Add";
            this.addFrameButton.UseVisualStyleBackColor = true;
            this.addFrameButton.Click += new System.EventHandler(this.addFrameButton_Click);
            // 
            // treeView
            // 
            this.treeView.HideSelection = false;
            this.treeView.Indent = 5;
            this.treeView.ItemHeight = 20;
            this.treeView.Location = new System.Drawing.Point(12, 12);
            this.treeView.Name = "treeView";
            this.treeView.ShowPlusMinus = false;
            this.treeView.Size = new System.Drawing.Size(100, 290);
            this.treeView.TabIndex = 3;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(523, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Delay (ms)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // delayUpDown
            // 
            this.delayUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.delayUpDown.Location = new System.Drawing.Point(526, 28);
            this.delayUpDown.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.delayUpDown.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.delayUpDown.Name = "delayUpDown";
            this.delayUpDown.Size = new System.Drawing.Size(100, 22);
            this.delayUpDown.TabIndex = 5;
            this.delayUpDown.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // timerButton
            // 
            this.timerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timerButton.Location = new System.Drawing.Point(526, 56);
            this.timerButton.Name = "timerButton";
            this.timerButton.Size = new System.Drawing.Size(100, 30);
            this.timerButton.TabIndex = 7;
            this.timerButton.Text = "Enable";
            this.timerButton.UseVisualStyleBackColor = true;
            this.timerButton.Click += new System.EventHandler(this.timerButton_Click);
            // 
            // removeFrameButton
            // 
            this.removeFrameButton.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeFrameButton.Location = new System.Drawing.Point(12, 342);
            this.removeFrameButton.Name = "removeFrameButton";
            this.removeFrameButton.Size = new System.Drawing.Size(47, 27);
            this.removeFrameButton.TabIndex = 8;
            this.removeFrameButton.Text = "Remove";
            this.removeFrameButton.UseVisualStyleBackColor = true;
            this.removeFrameButton.Click += new System.EventHandler(this.removeFrameButton_Click);
            // 
            // upFrameButton
            // 
            this.upFrameButton.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upFrameButton.Location = new System.Drawing.Point(65, 309);
            this.upFrameButton.Name = "upFrameButton";
            this.upFrameButton.Size = new System.Drawing.Size(47, 27);
            this.upFrameButton.TabIndex = 9;
            this.upFrameButton.Text = "Up";
            this.upFrameButton.UseVisualStyleBackColor = true;
            this.upFrameButton.Click += new System.EventHandler(this.upFrameButton_Click);
            // 
            // downFrameButton
            // 
            this.downFrameButton.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downFrameButton.Location = new System.Drawing.Point(65, 342);
            this.downFrameButton.Name = "downFrameButton";
            this.downFrameButton.Size = new System.Drawing.Size(47, 27);
            this.downFrameButton.TabIndex = 10;
            this.downFrameButton.Text = "Down";
            this.downFrameButton.UseVisualStyleBackColor = true;
            this.downFrameButton.Click += new System.EventHandler(this.downFrameButton_Click);
            // 
            // loadAnimationButton
            // 
            this.loadAnimationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.loadAnimationButton.Location = new System.Drawing.Point(526, 372);
            this.loadAnimationButton.Name = "loadAnimationButton";
            this.loadAnimationButton.Size = new System.Drawing.Size(100, 30);
            this.loadAnimationButton.TabIndex = 11;
            this.loadAnimationButton.Text = "Load .ma";
            this.loadAnimationButton.UseVisualStyleBackColor = true;
            this.loadAnimationButton.Click += new System.EventHandler(this.loadAnimationButton_Click);
            // 
            // saveAnimationButton
            // 
            this.saveAnimationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveAnimationButton.Location = new System.Drawing.Point(526, 336);
            this.saveAnimationButton.Name = "saveAnimationButton";
            this.saveAnimationButton.Size = new System.Drawing.Size(100, 30);
            this.saveAnimationButton.TabIndex = 12;
            this.saveAnimationButton.Text = "Save .ma";
            this.saveAnimationButton.UseVisualStyleBackColor = true;
            this.saveAnimationButton.Click += new System.EventHandler(this.saveAnimationButton_Click);
            // 
            // clearAllButton
            // 
            this.clearAllButton.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearAllButton.Location = new System.Drawing.Point(12, 375);
            this.clearAllButton.Name = "clearAllButton";
            this.clearAllButton.Size = new System.Drawing.Size(100, 27);
            this.clearAllButton.TabIndex = 13;
            this.clearAllButton.Text = "Clear All";
            this.clearAllButton.UseVisualStyleBackColor = true;
            this.clearAllButton.Click += new System.EventHandler(this.clearAllButton_Click);
            // 
            // importButton
            // 
            this.importButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.importButton.Location = new System.Drawing.Point(526, 300);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(100, 30);
            this.importButton.TabIndex = 14;
            this.importButton.Text = "Import Image";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // editor
            // 
            this.editor.BackColor = System.Drawing.Color.White;
            this.editor.GapSize = 1;
            this.editor.Location = new System.Drawing.Point(124, 12);
            this.editor.MaximumSize = new System.Drawing.Size(390, 390);
            this.editor.MinimumSize = new System.Drawing.Size(315, 315);
            this.editor.Name = "editor";
            this.editor.PixelSize = 25;
            this.editor.SelectedFrame = null;
            this.editor.Size = new System.Drawing.Size(390, 390);
            this.editor.TabIndex = 1;
            this.editor.Text = "ss";
            // 
            // AnimatorForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(638, 414);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.clearAllButton);
            this.Controls.Add(this.saveAnimationButton);
            this.Controls.Add(this.loadAnimationButton);
            this.Controls.Add(this.downFrameButton);
            this.Controls.Add(this.upFrameButton);
            this.Controls.Add(this.removeFrameButton);
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
            this.MinimumSize = new System.Drawing.Size(654, 453);
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
        private System.Windows.Forms.Button removeFrameButton;
        private System.Windows.Forms.Button upFrameButton;
        private System.Windows.Forms.Button downFrameButton;
        private System.Windows.Forms.Button loadAnimationButton;
        private System.Windows.Forms.Button saveAnimationButton;
        private System.Windows.Forms.Button clearAllButton;
        private System.Windows.Forms.Button importButton;
    }
}