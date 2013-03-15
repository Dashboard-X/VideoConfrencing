using System;
using System.Windows.Forms;

namespace CentralServerDemo
{
    public partial class FormPending : Form
    {
        private iConfServer.NET.iConfServerDotNet ics;
        public FormPending(iConfServer.NET.iConfServerDotNet ics)
        {
            InitializeComponent();
            this.ics = ics;
        }

        private void btnAcceptRequest_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstPending.SelectedItems.Count; i++)
			{
			    ics.AcceptContactRequest(lstPending.SelectedItems[i].ToString());
			}

            ics.GetContactList();
            ics.GetPendingContactRequests();
            
        }
    }
}
