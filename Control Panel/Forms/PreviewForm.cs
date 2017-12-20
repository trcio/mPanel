using System.Windows.Forms;

namespace Control_Panel.Forms
{
    public partial class PreviewForm : Form
    {
        public PreviewForm()
        {
            InitializeComponent();
        }

        public void Matrix_FrameHook(object sender, byte[] e)
        {
            panel.UpdatePreview(e);
        }
    }
}
