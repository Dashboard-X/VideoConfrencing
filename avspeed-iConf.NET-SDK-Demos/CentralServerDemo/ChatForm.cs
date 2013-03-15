using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CentralServerDemo
{
    public partial class frmChat : Form
    {
        public ExRichTextBox rtBox;
        private iConfServer.NET.iConfServerDotNet ics;

        public frmChat( iConfServer.NET.iConfServerDotNet ics)
        {
            InitializeComponent();
            rtBox = new ExRichTextBox();
            rtBox.Parent = pnlFill;
            rtBox.Dock = DockStyle.Fill;
            rtBox.ReadOnly = true;
            this.ics = ics;
        }

        private void frmChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void txtSendMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                ics.SendMessageToConference(txtSendMessage.Text);
                txtSendMessage.Clear();
            }
        }
    }
}