using System;
using System.Windows.Forms;
using Control_Panel.Matrix;

namespace Control_Panel.Actions
{
    public partial class PreviewForm : Form
    {
        private MatrixPanel Matrix => ((ContainerForm) MdiParent)?.Matrix;

        public PreviewForm()
        {
            InitializeComponent();
        }

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
    }
}
