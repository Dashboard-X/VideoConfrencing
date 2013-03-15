using System;
using System.Windows.Forms;

namespace CentralServerDemo
{
    public partial class AudioDevsForm : Form
    {
        public AudioDevsForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
