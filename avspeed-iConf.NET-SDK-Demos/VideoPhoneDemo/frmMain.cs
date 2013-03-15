using System;
using System.Diagnostics;
using System.Windows.Forms;
using iConfServer.NET;
using iConfClient.NET;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using iConfServer.NET.HelperClasses;

namespace VideoPhoneDemo
{
    /// <summary>
    /// iConf SDK Video Phone Demo
    /// For questions and support please email us at : support@avspeed.com
    /// or visit http://www.avspeed.com
    /// </summary>
    public partial class frmMain : Form
    {
        private iConfServerDotNet recordingics;

        private bool loading;

        private bool closing;

        private iConfServerDotNet ics;
        private iConfClientDotNet icc;
        private Viewer scf;

       

        public frmMain()
        {
            try
            {
                InitializeComponent();

                #region iconf server initialization
                ics = new iConfServerDotNet { Parent = pnlics, Dock = DockStyle.Fill, Visible = true };

                ics.VideoPreviewStarted += new iConfServerDotNet.VideoPreviewStartedDelegate(ics_VideoPreviewStarted);
                ics.VideoDeviceSelected += new iConfServerDotNet.VideoDeviceSelectedDelegate(ics_VideoDeviceSelected);
                ics.ClientDisconnected += new iConfServerDotNet.ClientDisconnectedDelegate(ics_ClientDisconnected);
                ics.IncomingCall += new iConfServerDotNet.IncomingCallDelegate(ics_IncomingCall);
                ics.ScreenSharingSessionAccepted += new iConfServerDotNet.ScreenSharingSessionAcceptedDelegate(ics_ScreenSharingSessionAccepted);
                ics.ScreenSharingSessionRejected += new iConfServerDotNet.ScreenSharingSessionRejectedDelegate(ics_ScreenSharingSessionRejected);
                #endregion

                #region iconfclient initialization
                icc = new iConfClient.NET.iConfClientDotNet { Parent = pnlicc, Dock = DockStyle.Fill, Visible = true };

                icc.ClientDisconnected +=
                    icc_ClientDisconnected;

                icc.RequestToShareScreen += icc_RequestToShareScreen;

                //set ip to call to local ip
                icc.ScreenSharingStopped += icc_ScreenSharingStopped; 
                #endregion

                txtIpToCall.Text = ics.GetLocalIp()[0].ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //new video device has been selected.New video sizeds are available for the new device. Restart the Preview
        void ics_VideoDeviceSelected(string deviceName)
        {
            Invoke(new MethodInvoker(delegate
            {
                LoadVideoSizes(cbVideoPreviewSizes);
                RestartPreview();
            }));
        }

        void ics_VideoPreviewStarted(int videoWidth, int videoHeight, string deviceName)
        {
            Invoke(new MethodInvoker(delegate
            {
                ics.SetEncoderProperties(VideoCodecs.MPEG4, 100, 6400, 0, 0, 0);
            }));
            
        }

        void icc_ScreenSharingStopped(int sessionid)
        {
            Invoke(new MethodInvoker(delegate
            {
                foreach (Form form in Application.OpenForms)
                {
                    if (form.Tag != null && Convert.ToInt32(form.Tag) == sessionid)
                    {
                        form.Close();
                        break;
                    }
                }
            }));
        }

        private void ics_ScreenSharingSessionRejected(int socketHandle, string rejectionMessage)
        {
            Invoke(new MethodInvoker(delegate
            {
                MessageBox.Show("Screen sharing session rejected", "Response", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }));
            
        }

        private void ics_ScreenSharingSessionAccepted(int socketHandle)
        {
            Invoke(new MethodInvoker(delegate
            {
                textBox1.Text += System.Environment.NewLine + " > Screen sharing sesssion accepted " + System.Environment.NewLine;
            }));
        }


        private void frmMain_Load(object sender, EventArgs e)
        {
            loading = true;

            LoadVideoDevices(cbVideoDevices);
            
            ics.SelectVideoDevice(1);

            ics.StartPreview(cbVideoPreviewSizes.SelectedIndex);

            loading = false;
            
        }


        /// <summary>
        /// Load list of video capture devices
        /// </summary>
        /// <param name="cb"></param>
        private void LoadVideoDevices( ComboBox cb)
        {
          
            cb.DataSource = ics.GetVideoDevices();    
        }

        /// <summary>
        /// Load list of Video Preview Sizes
        /// </summary>
        /// <param name="cb"></param>
        private void LoadVideoSizes(ComboBox cb)
        {
            cb.DataSource = null;
            cb.DataSource = ics.GetVideoSizes();
        }


        private void cbVideoDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
           
                //assign selected video device to iConf Server
                Invoke(new MethodInvoker(delegate
                                             {
                                                 ics.SelectVideoDevice(cbVideoDevices.SelectedIndex);
                                             }));

            
        }

        /// <summary>
        /// Restarts the preview based on new params
        /// </summary>
        private void RestartPreview()
        {
            //start the preview
            ics.StartPreview(cbVideoPreviewSizes.SelectedIndex);  
        }

        private void btnStartPreview_Click(object sender, EventArgs e)
        {
            int listeningVideoPort = Convert.ToInt32(txtVideoport.Text);
            int listeningAudioTcpPort = Convert.ToInt32(txtAudioporttcp.Text);
            int listeningAudioUdpPort = Convert.ToInt32(txtaudioportudp.Text);

            //start listening for incoming calls on local ip and listening ports

            if (!ics.IsListening)
            ics.Listen(true, ics.GetLocalIp()[0].ToString(), listeningVideoPort,
                       listeningAudioTcpPort, listeningAudioUdpPort);

            btnStartPreview.Enabled = false;
            btnStopPreview.Enabled = true;
                
            
        }

        private void btnStopPreview_Click(object sender, EventArgs e)
        {
            //stop listening for incoming calls
            ics.Listen(false, "", 0,0,0);
            
            btnStartPreview.Enabled = true;
            btnStopPreview.Enabled = false;
        }

        private void cbVideoPreviewSizes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                ics.StartPreview(cbVideoPreviewSizes.SelectedIndex);
                ics.SetEncoderProperties("MPEG4", 10, 6400, 0, 0, 0, 720, 576);

            }
        }

        
        private void ics_IncomingCall(object sender, string authenticationData, int socketHandle, string callbackid, string callbackipaddress, int callbackvideoport, int callbackaudiotcpport, int callbackaudiudpport)
        {
            Invoke(new MethodInvoker(delegate
            {
                if (MessageBox.Show("Accept call?", "Incoming Call", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //accept the incoming call
                    ics.AcceptCall("n/a", socketHandle);

                
                    //call back to have a 1 on one video conference
                    icc.Call(callbackipaddress, callbackvideoport, 0, 0, "n/a", callbackid, "n/a", 0, 0, 0, "");
                }
                else
                {
                    ics.RejectCall("Call not accepted",  (IntPtr)socketHandle);
                }
            }));
        }

        private void btnCall_Click(object sender, EventArgs e)
        {
            if (btnStartPreview.Enabled)
            {
                MessageBox.Show("Please start Listening first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnStartPreview.Focus();
                return;
            }

            string iptocall = txtIpToCall.Text;
            int outvideoPort = Convert.ToInt32(txtoutVideoPort.Text);
            int callbackVideoPort = Convert.ToInt32(txtVideoport.Text);
            int callbackAudioTcpPort = Convert.ToInt32(txtAudioporttcp.Text);
            int callbackAudioUdpPort = Convert.ToInt32(txtaudioportudp.Text);

            //place a call using our iConf Client and send our servers callback id - so that when the callback happens we 
            //can automatically authenticate

            icc.Call(iptocall , outvideoPort,
                     0,0, "n/a", ics.CallBackId,
                     ics.GetLocalIp()[0].ToString(), callbackVideoPort,
                     callbackAudioTcpPort, callbackAudioUdpPort, "");
        }


        private void ics_ClientDisconnected(object sender, string ipAddress, int port)
        {
            if (!closing)
            {
                Invoke(new MethodInvoker(delegate
                {
                    icc.Disconnect();
                    icc.SetImage(null);
                }));
            }
        }

        private void btnHangup_Click(object sender, EventArgs e)
        {
            icc.Disconnect();
            icc.SetImage(null);
        }

        private void icc_ClientDisconnected(object sender, string ipAddress, int port)
        {
            Invoke(new MethodInvoker(delegate
            {
                icc.SetImage(null); 
            })); 
        }


        private void icc_RequestToShareScreen( string fromIp, string keyToConnect, string invitationMessage )
        {
            Invoke(new MethodInvoker(delegate
            {
                if (MessageBox.Show("Would you like to accept this invitation : " + invitationMessage, "Invitation - Screen Sharing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    icc.AcceptScreenSharingSession(keyToConnect);

                    scf = new Viewer(icc);
                    scf.Tag = Convert.ToInt32(keyToConnect);
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

        private void btnRecord_Click(object sender, EventArgs e)
        {

            icc.StartRecording(25, "test.mp4", 20);

            btnStopRecording.Enabled = true;
            btnRecord.Enabled = false;
        }

        private void btnStopRecording_Click(object sender, EventArgs e)
        {
            icc.StopRecording();
            btnStopRecording.Enabled = false;
            btnRecord.Enabled = true;

            ////open avi file
            //Process.Start("testing.wmv");     
        }

        private void btnTakePic_Click(object sender, EventArgs e)
        {
            //capture an image and save it to the application path 
            icc.CaptureImage("CapturedImage.jpg");
            Process.Start("CapturedImage.jpg");
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //stop listening ..
            ics.Listen(false, "", 0, 0, 0);

            //stop the preview
            ics.StopPreview();
            closing = true;
        }

        

        private void btnSendRequestToShareScreen_Click(object sender, EventArgs e)
        {
            ics.StartScreenSharing( iConfServerDotNet.DesktopSharingType.Full );
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

        private void btnPopout_Click(object sender, EventArgs e)
        {
            frmPopOut popoutform = new frmPopOut(this, icc);
            popoutform.Show();
            popoutform.Width = icc.CurrentVideoWidth;
            popoutform.Height = icc.CurrentVideoHeight;

            icc.Parent = popoutform.pnlViewer;
            icc.Dock = DockStyle.Fill;
        }

        




    }
}
