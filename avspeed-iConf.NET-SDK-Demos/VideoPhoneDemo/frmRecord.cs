using System;
using System.Windows.Forms;
using iConfServer.NET;

namespace VideoPhoneDemo
{
    public partial class frmRecord : Form
    {
        private iConfServerDotNet ics;

        public frmRecord( iConfServer.NET.iConfServerDotNet ics)
        {
            InitializeComponent();
            this.ics = ics;

            LoadVideoCompressors(cbVideoCompressors);
            LoadAudioCompressors(cbAudioCompressors);
        }

        private void LoadVideoCompressors(ComboBox cb)
        {
            cb.DataSource = ics.GetVideoCompressorsForRecording();
        }

        private void LoadAudioCompressors(ComboBox cb)
        {
            cb.DataSource = ics.GetAudioCompressorsForRecording();
        }

        private void frmRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

 

    }
}
