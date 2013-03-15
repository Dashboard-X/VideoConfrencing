using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using iConfServer.NET.HelperClasses;

namespace IP2IPDemo
{
    public partial class Form1 : Form
    {
        
        /// <summary>
        /// THIS APPLICATION NEEDS RUN THIS APPLICATION NEEDS TO RUN ON 2 DIFFERENT PCS
        /// (OR Virtual Machines)
        /// OR CAN BE USED IN CALLBACK mode by using the local ip when placing a call
        /// This is a simple demo which uses basic settings
        /// For help email us at support@avspeed.com
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            txtIP.Text = ics.GetLocalIp()[0].ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                ics.InitializeAudioSystem(iConfServer.NET.iConfServerDotNet.audioType.DirectSound, -1, -1, 16000, 10);
               
                //select the first available video device
                ics.SelectVideoDevice(0);

               
                ArrayList lst = ics.GetVideoSizes();
                
                //start previewing video using the default video size 
                ics.StartPreview(0);
            }
            catch(Exception ex)
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
            // thid is where we are going to initialize the video encoder -
            // note that this is a change from previous versions

            Invoke(new MethodInvoker(delegate
            {
                this.Text = string.Format("Simple IP 2 IP Demo - {0}x{1}", videoWidth, videoHeight);

                ics.VideoRateControl = iConfServer.NET.iConfServerDotNet.RateControl.ConstantQuality;
                //Initialize Codec
                ics.SetEncoderProperties(VideoCodecs.MPEG4, 20, 8000, 0, 0, 0);

                if (!ics.IsListening)
                //listen for incoming connections
                ics.Listen(true, ics.GetLocalIp()[0].ToString(), 9990, 17860, 17861);
            }));
        }

       

        
    }
}
