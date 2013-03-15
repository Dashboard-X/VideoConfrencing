using System;
using System.Collections;
using System.Windows.Forms;
using iConfServer.NET.HelperClasses;


namespace IP2IPSimpleScreenSharing
{
    ///IP2IP demo with screen sharing
    /// Demo created using the iConf.NET Video Conferencing SDK
    /// http://www.avspeed.com
    public partial class Form1 : Form
    {
        private Viewer scf;

        private VideoDevice vd;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                ics.InitializeAudioSystem(iConfServer.NET.iConfServerDotNet.audioType.DirectSound, -1, -1, 16000, 10);


                vd = new VideoDevice();
                vd.cbVideoDevices.DataSource = ics.GetVideoDevices();

                ics.SelectVideoDevice(0);

                //start previewing video using the default video size 
                ics.StartPreview(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error initializing {0}", ex.Message));
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //stop listening
            ics.Listen(false, ics.GetLocalIp()[0].ToString(), 9990, 17860, 17861);

            //stop the video preview
            ics.StopPreview();

            e.Cancel = false;
        }

        private void btnCall_Click(object sender, EventArgs e)
        {
            string myIp = ics.GetLocalIp()[0].ToString();
            string ipToCall = txtIP.Text;

            const int videoPort = 9990;
            const int audioTcpPort = 17860;
            const int audioUdpPort = 17861;

            //place a call to an iConf Server
            //note when using the Call function we have the ability to supply callback parameters 
            //which will help the peer connection call us back

            icc.Call(ipToCall, videoPort, 0, 0, "test", ics.CallBackId, myIp, videoPort, audioTcpPort, audioUdpPort, "");
        }


        private void ics_IncomingCall(object sender, string authenticationData, int socketHandle, string callbackid, string callbackipaddress, int callbackvideoport, int callbackaudiotcpport, int callbackaudiudpport)
        {
            Invoke(new MethodInvoker(delegate
            {
                //accept the incoming call
                ics.AcceptCall("n/a", socketHandle);

                //call back to have a 1 on one video conference
                icc.Call(callbackipaddress, callbackvideoport, 0, 0, "n/a", callbackid,
                         ics.GetLocalIp()[0].ToString(), 0, 0, 0, "");
            }));

        }

        private void ics_ClientDisconnected(object sender, string ipAddress, int port)
        {
            Invoke(new MethodInvoker(delegate
            {
                //peer has disconnected
                //disconnect our client as well
                icc.Disconnect();
            }));
        }

        private void ics_CannotRunGraph()
        {
            MessageBox.Show("Video Capture device might be in use");
        }


        private void btnHangUp_Click(object sender, EventArgs e)
        {
            icc.Disconnect();
            icc.ClearImage();
        }



        private void ics_VideoPreviewStarted(int videoWidth, int videoHeight, string deviceName)
        {
            // this is where we are going to initialize the video encoder -

            Invoke(new MethodInvoker(delegate
            {
                this.Text = string.Format("IP 2 IP Demo w/ Screen Sharing - {0}x{1}", videoWidth, videoHeight);
                lblDevice.Text = deviceName;

                ics.VideoRateControl = iConfServer.NET.iConfServerDotNet.RateControl.ConstantQuality;
                //Initialize Codec
                ics.SetEncoderProperties(VideoCodecs.MPEG4, 20, 8000, 0, 0, 0);

                if (!ics.IsListening)
                    //listen for incoming connections
                    ics.Listen(true, ics.GetLocalIp()[0].ToString(), 9990, 17860, 17861);
            }));
        }

        private void btnStartScreenSharing_Click(object sender, EventArgs e)
        {
            ics.StartScreenSharing( iConfServer.NET.iConfServerDotNet.DesktopSharingType.Full);

            string invitationMessage = "N/A";
            if (Helper.InputBox("Invitation Message", "Enter Invitation message below", ref invitationMessage) == System.Windows.Forms.DialogResult.OK)
            {

            }
            else invitationMessage = "N/A";

            ics.InviteClientToViewScreen(-1, invitationMessage);
        }

        private void btnStopScreenSharing_Click(object sender, EventArgs e)
        {
            ics.StopScreenSharing();
        }

        private void icc_ScreenSharingStopped(int sessionid)
        {
           //take action when screen sharing is stopped ...
        }

        private void icc_RequestToShareScreen(string fromIp, string keytoConnect, string invitationMessage)
        {
            Invoke(new MethodInvoker(delegate
            {
                if (MessageBox.Show("Would you like to accept this invitation : " + invitationMessage, "Invitation - Screen Sharing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    icc.AcceptScreenSharingSession(keytoConnect);

                    scf = new Viewer(icc);
                    scf.Tag = Convert.ToInt32(keytoConnect);
                    scf.Text = "Screen";
                    scf.Show();
                    scf.timer1.Enabled = true;

                }
                else
                {
                    icc.RejectScreenSharingSession("");
                }
            }));
        }

        private void btnChangeVideoDevice_Click(object sender, EventArgs e)
        {

            if (vd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ics.SelectVideoDevice(vd.cbVideoDevices.SelectedIndex);
                ics.StartPreview(0);
            }

        }
    }
}
