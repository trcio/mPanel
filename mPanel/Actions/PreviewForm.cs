using System;
using System.Windows.Forms;
using mPanel.Matrix;

namespace mPanel.Actions
{
    public partial class PreviewForm : Form
    {
        private MatrixPanel Matrix => ((ContainerForm) MdiParent)?.Matrix;

        public PreviewForm()
        {
            InitializeComponent();
        }

        #region Form Events

        private void PreviewForm_Load(object sender, EventArgs e)
        {
            Matrix.FrameHook += Matrix_FrameHook;
        }

        private void PreviewForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Matrix.FrameHook -= Matrix_FrameHook;
        }

        public void Matrix_FrameHook(object sender, byte[] e)
        {
            panel.UpdatePreview(e);
        }

        #endregion
    }
}
