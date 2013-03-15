using System.Windows.Forms;

namespace VideoPhoneDemo
{
    public partial class frmPopOut : Form
    {
        public frmMain _mainform;
        public iConfClient.NET.iConfClientDotNet _icc;

        public frmPopOut(frmMain mainform, iConfClient.NET.iConfClientDotNet icc)
        {
            InitializeComponent();
            _mainform = mainform;
            _icc = icc;
        }

        private void frmPopOut_FormClosing(object sender, FormClosingEventArgs e)
        {
            _icc.Parent = _mainform.pnlicc;
            _icc.Dock = DockStyle.Fill;
            e.Cancel = false;
        }
    }
}
