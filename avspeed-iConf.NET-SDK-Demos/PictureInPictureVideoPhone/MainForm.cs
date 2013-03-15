using System;
using System.Drawing; 
using System.Windows.Forms;
using iConfServer.NET;
using iConfServer.NET.HelperClasses;

namespace PictureInPictureVideoPhone
{
    /// <summary>
    /// This sample application was created using the iConf.NET SDK
    /// For more information visit http://www.avspeed.com
    /// Copyright 2012 AVSPEED, Inc. all rights reserved. 
    /// This is a simple Picture in Picture 2 way conferencing demo
    /// </summary>
    public partial class MainForm : Form
    {
        private iConfServer.NET.iConfServerDotNet ics;
        private iConfClient.NET.iConfClientDotNet icc;

       // private ScreenSharingForm ssf ;
        private string displayName = "";

        public MainForm()
        {
            try
            {
                InitializeComponent();

                pnlMessage.Dock = DockStyle.Top;

                CreateControls();
                GetLocalIp();
                InitializeAudio();
                ListVideoDevices();
                StartVideoPreview(0);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "/" + ex.StackTrace + " " + ex.InnerException.Message);
            }
        }

        private void InitializeAudio()
        {
            ics.InitializeAudioSystem(iConfServerDotNet.audioType.DirectSound, -1, -1, 16000, 10);
        }

        /// <summary>
        /// gets the ip of the local machine
        /// </summary>
        private void GetLocalIp()
        {
            if (ics != null)
                lblMyIp.Text = ics.GetLocalIp()[0].ToString();
        }

        /// <summary>
        /// enumerate the video devices installed on the system
        /// </summary>
        private void ListVideoDevices()
        {
            cbCam.DataSource = ics.GetVideoDevices();
        }

        private int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        
        /// <summary>
        /// Instantiates the the iConf components
        /// </summary>
        private void CreateControls()
        {
            ics = new iConfServer.NET.iConfServerDotNet();
            ics.Parent = pnlMain;
            ics.Dock = DockStyle.Fill;
            ics.Visible = true;


            //events
            ics.IncomingCall += new iConfServer.NET.iConfServerDotNet.IncomingCallDelegate(ics_IncomingCall);
            ics.ClientConnectionLost += new iConfServerDotNet.ClientConnectionLostDelegate(ics_ClientConnectionLost);
            ics.ScreenControlRequest   += new iConfServerDotNet.ScreenControlRequestDelegate(ics_ScreenControlRequest);
            ics.VideoPreviewStarted += new iConfServerDotNet.VideoPreviewStartedDelegate(ics_VideoPreviewStarted);

            icc = new iConfClient.NET.iConfClientDotNet();
            icc.Parent = pnlOtherVideo;
            icc.Dock = DockStyle.Fill;
            icc.Visible = true;

            //events
            icc.CallAccepted += new iConfClient.NET.iConfClientDotNet.CallAcceptedDelegate(icc_CallAccepted);
            icc.CallRejected += new iConfClient.NET.iConfClientDotNet.CallRejectedDelegate(icc_CallRejected);
        }

        void ics_VideoPreviewStarted(int videoWidth, int videoHeight, string deviceName)
        {
            Invoke(new MethodInvoker(delegate
            {
                ics.SetEncoderProperties(VideoCodecs.MPEG4, 20, 8000, 0, 0, 0);

                if (!ics.IsListening)
                //listen for incoming connections
                ics.Listen(true, ics.GetLocalIp()[0].ToString(), 9990, 17860, 17861);
            }));
            
        }

        private void ics_ScreenControlRequest(string fromuser)
        {
            Invoke(new MethodInvoker(delegate
            {
                if (MessageBox.Show("Accept screen control request from handle " + fromuser, "Screen control Request", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    ics.GrantScreenControl(Convert.ToInt32(fromuser));
                }
                else ics.DenyScreenControl(Convert.ToInt32(fromuser));
            }));
        }

        private void icc_CallRejected(string rejectionmessage)
        {
            Invoke(new MethodInvoker(delegate
            {
                DisplayMessage("Call rejected ..");
                icc.SetImage(null);
                icc.Parent = pnlOtherVideo;
                ics.Parent = pnlMain;
                pnlOtherVideo.Visible = false;
                pbHangup.Visible = false;
                pbCall.Visible = true;
            }));
        }

        private delegate void ProcessClientConnectionLostDelegate( int socketHandle );

        private void CloseScreenSharingForm()
        {
            
        }

        private void ics_ClientConnectionLost(int sockethandle)
        {
            Invoke(new MethodInvoker(delegate
            {
                HideOptionsPanel();
                DisplayMessage("Call ended");
                CloseScreenSharingForm();
                icc.SetImage(null);
                icc.Parent = pnlOtherVideo;
                ics.Parent = pnlMain;
                pnlOtherVideo.Visible = false;
                pbHangup.Visible = false;
                pbCall.Visible = true;
            }));

        }

        private void icc_CallAccepted(string acceptmessage)
        {
            Invoke(new MethodInvoker(delegate
            {
                icc.Size = new Size(icc.CurrentVideoWidth, icc.CurrentVideoHeight);
                this.Size = icc.Size;
            }));
        }

        private void StartVideoPreview( int cameraIndex )
        {
            if (ics.VideoDeviceCount == 0)
                MessageBox.Show("You do not a have a video input device on your system");

            ics.SelectVideoDevice(cameraIndex);
            ics.StartPreview(0);
        }

        private void ics_IncomingCall(object sender, string authenticationData, int socketHandle, string callbackid, string callbackipaddress, int callbackvideoport, int callbackaudiotcpport, int callbackaudiudpport)
        {
            Invoke(new MethodInvoker(delegate
            {
                var args = new[] { socketHandle.ToString(), callbackvideoport.ToString(), callbackipaddress, callbackid, authenticationData };

                ShowIncomingCall(args);
            }));
        }

        private void pbCall_Click(object sender, EventArgs e)
        {

            if (txtIP.Text == string.Empty)
            {
                MessageBox.Show("Please enter an ip to call.", "Missing ip", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string myIp = ics.GetLocalIp()[0].ToString();
            string ipToCall = txtIP.Text;
            int videoPort = 9990;
            int audioTcpPort = 17860;
            int audioUdpPort = 17861;

            //place a call to an iConf Server
            //note when using the Call function we have the ability to supply callback parameters 
            //which will help the peer connection call us back

            if (displayName == "")
            {
                displayName = "User" + RandomNumber(1, 1000);
                InputBoxSample.InputBoxResult res = InputBoxSample.InputBox.Show("You do not have a display name. Please enter your Display Name",
                                                                                 "Display Name", displayName, null);
                if ( (res != null) && (res.Text != ""))
                {
                    displayName = res.Text;
                }

            }

            pnlOtherVideo.Visible = true;
            icc.Parent = pnlMain;
            ics.Parent = pnlOtherVideo;
            

            icc.Call(ipToCall, videoPort, 0, 0, displayName, ics.CallBackId, myIp, videoPort, audioTcpPort, audioUdpPort, "");
            
            pbHangup.Visible = true;
            pbCall.Visible = false;

            HideOptionsPanel();

        }

        private void lblOptions_Click(object sender, EventArgs e)
        {
            if (!pnlMenu.Visible)
            {
                ShowOptionsPanel();
            }
            else
            {
                HideOptionsPanel();
            }

        }

        private void HideOptionsPanel()
        {
             pnlMenu.Visible = false;
             pnlOptions.Location = new Point(pnlOptions.Location.X, 0);
        }

        private void ShowOptionsPanel()
        {
            pnlMenu.Visible = true;
            pnlMenu.BringToFront();
            pnlOptions.Location = new Point(pnlOptions.Location.X, 112);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            icc.Disconnect();
            ics.Listen(false, "", 0, 0, 0);
            ics.StopPreview();
        }

        private void pbHangup_Click(object sender, EventArgs e)
        {
            ics.DisconnectClient(-1);
            icc.Disconnect();
            pbHangup.Visible = false;
            pbCall.Visible = true;
            CloseScreenSharingForm();
            HideOptionsPanel();
            DisplayMessage("Call ended");
            icc.SetImage(null);
            icc.Parent = pnlOtherVideo;
            ics.Parent = pnlMain;
            pnlOtherVideo.Visible = false;
        }

        private void cbCam_SelectedIndexChanged(object sender, EventArgs e)
        {
            StartVideoPreview(cbCam.SelectedIndex);
        }

        private void DisplayMessage( string text )
        {
            lblMessage.Text = text;
            pnlMessage.Visible = true;
            timerMessage.Enabled = true;
        }

        private void ShowIncomingCall( string[] args )
        {
            pnlIncoming.Tag = args;
            this.pnlIncoming.Left = this.Width / 2 - pnlIncoming.Width / 2;
            this.pnlIncoming.Top = this.Height / 2 - pnlIncoming.Height / 2;

            pnlIncoming.Location = new Point(this.pnlIncoming.Left, this.pnlIncoming.Top);

            pnlIncoming.Visible = true;

            lblFrom.Text = string.Format("from {0}", args[4]);
        }

        private void timerMessage_Tick(object sender, EventArgs e)
        {
            timerMessage.Enabled = false;
            lblMessage.Text = String.Empty;
            pnlMessage.Visible = false;
        }

        private void pbAccept_Click(object sender, EventArgs e)
        {
            HideIncomingCall();

            string[] args = (string[])pnlIncoming.Tag;

            int socketHandle = Convert.ToInt32(args[0]);
            int callbackVideoPort = Convert.ToInt32(args[1]);
            string callbackIpAddress = args[2];
            string callbackId = args[3];


            //accept the incoming call
            ics.AcceptCall("n/a", socketHandle);

            pnlOtherVideo.Visible = true;

            icc.Parent = pnlMain;
            ics.Parent = pnlOtherVideo;
            //call back to have a 1 on one video conference
            icc.Call(callbackIpAddress, callbackVideoPort, 0, 0, "n/a", callbackId, ics.GetLocalIp()[0].ToString(), 0, 0, 0, "");

            pbHangup.Visible = true;
            pbCall.Visible = false;
        }

        private void HideIncomingCall()
        {
            pnlIncoming.Hide();
        }

        private void pbReject_Click(object sender, EventArgs e)
        {
             HideIncomingCall();

            string[] args = (string[])pnlIncoming.Tag;

            int socketHandle = Convert.ToInt32(args[0]);
            ics.RejectCall("n/a", (IntPtr)socketHandle);
        }

        private void lblCopy_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(lblMyIp.Text);

                MessageBox.Show("IP has been copied to Clipboard", "Success", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to capture ip to clipboard : "  + ex.Message);
            }
        }

    }
}
