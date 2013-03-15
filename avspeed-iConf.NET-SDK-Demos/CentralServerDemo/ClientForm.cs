//INSTANT C# NOTE: Formerly VB project-level imports:
using System.Windows.Forms;

namespace CentralServerDemo
{
	public partial class ClientForm
	{

		internal ClientForm()
		{
			InitializeComponent();
		}

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            icc.Disconnect();
            System.Threading.Thread.Sleep(1000);
        }

        private void icc_NewVideoFrameBytesAvailable(byte[] bitmapbytes)
        {

        }
	}
} //end of root namespace