namespace VideoPhoneDemo
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbMyVideo = new System.Windows.Forms.GroupBox();
            this.pnlics = new System.Windows.Forms.Panel();
            this.btnSendRequestToShareScreen = new System.Windows.Forms.Button();
            this.gbClient = new System.Windows.Forms.GroupBox();
            this.btnPopout = new System.Windows.Forms.Button();
            this.pnlicc = new System.Windows.Forms.Panel();
            this.btnTakePic = new System.Windows.Forms.Button();
            this.btnStopRecording = new System.Windows.Forms.Button();
            this.btnRecord = new System.Windows.Forms.Button();
            this.cbVideoDevices = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbVideoPreviewSizes = new System.Windows.Forms.ComboBox();
            this.txtIpToCall = new System.Windows.Forms.TextBox();
            this.btnStartPreview = new System.Windows.Forms.Button();
            this.btnStopPreview = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtaudioportudp = new System.Windows.Forms.TextBox();
            this.txtAudioporttcp = new System.Windows.Forms.TextBox();
            this.txtVideoport = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnHangup = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnCall = new System.Windows.Forms.Button();
            this.txtoutVideoPort = new System.Windows.Forms.TextBox();
            this.btnStopScreenSharing = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.gbMyVideo.SuspendLayout();
            this.gbClient.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbMyVideo
            // 
            this.gbMyVideo.Controls.Add(this.pnlics);
            this.gbMyVideo.Location = new System.Drawing.Point(12, 12);
            this.gbMyVideo.Name = "gbMyVideo";
            this.gbMyVideo.Size = new System.Drawing.Size(225, 203);
            this.gbMyVideo.TabIndex = 2;
            this.gbMyVideo.TabStop = false;
            this.gbMyVideo.Text = "My Video";
            // 
            // pnlics
            // 
            this.pnlics.Location = new System.Drawing.Point(7, 20);
            this.pnlics.Name = "pnlics";
            this.pnlics.Size = new System.Drawing.Size(212, 173);
            this.pnlics.TabIndex = 0;
            // 
            // btnSendRequestToShareScreen
            // 
            this.btnSendRequestToShareScreen.Location = new System.Drawing.Point(5, 15);
            this.btnSendRequestToShareScreen.Name = "btnSendRequestToShareScreen";
            this.btnSendRequestToShareScreen.Size = new System.Drawing.Size(101, 23);
            this.btnSendRequestToShareScreen.TabIndex = 2;
            this.btnSendRequestToShareScreen.Text = "Start";
            this.btnSendRequestToShareScreen.UseVisualStyleBackColor = true;
            this.btnSendRequestToShareScreen.Click += new System.EventHandler(this.btnSendRequestToShareScreen_Click);
            // 
            // gbClient
            // 
            this.gbClient.Controls.Add(this.btnPopout);
            this.gbClient.Controls.Add(this.pnlicc);
            this.gbClient.Controls.Add(this.btnTakePic);
            this.gbClient.Controls.Add(this.btnStopRecording);
            this.gbClient.Controls.Add(this.btnRecord);
            this.gbClient.Location = new System.Drawing.Point(248, 12);
            this.gbClient.Name = "gbClient";
            this.gbClient.Size = new System.Drawing.Size(233, 251);
            this.gbClient.TabIndex = 3;
            this.gbClient.TabStop = false;
            // 
            // btnPopout
            // 
            this.btnPopout.Location = new System.Drawing.Point(125, 228);
            this.btnPopout.Name = "btnPopout";
            this.btnPopout.Size = new System.Drawing.Size(89, 23);
            this.btnPopout.TabIndex = 5;
            this.btnPopout.Text = "Pop out >";
            this.btnPopout.UseVisualStyleBackColor = true;
            this.btnPopout.Click += new System.EventHandler(this.btnPopout_Click);
            // 
            // pnlicc
            // 
            this.pnlicc.Location = new System.Drawing.Point(6, 17);
            this.pnlicc.Name = "pnlicc";
            this.pnlicc.Size = new System.Drawing.Size(212, 176);
            this.pnlicc.TabIndex = 4;
            // 
            // btnTakePic
            // 
            this.btnTakePic.Location = new System.Drawing.Point(17, 224);
            this.btnTakePic.Name = "btnTakePic";
            this.btnTakePic.Size = new System.Drawing.Size(90, 23);
            this.btnTakePic.TabIndex = 3;
            this.btnTakePic.Text = "Take Picture";
            this.btnTakePic.UseVisualStyleBackColor = true;
            this.btnTakePic.Click += new System.EventHandler(this.btnTakePic_Click);
            // 
            // btnStopRecording
            // 
            this.btnStopRecording.Enabled = false;
            this.btnStopRecording.Location = new System.Drawing.Point(125, 198);
            this.btnStopRecording.Name = "btnStopRecording";
            this.btnStopRecording.Size = new System.Drawing.Size(89, 23);
            this.btnStopRecording.TabIndex = 2;
            this.btnStopRecording.Text = "Stop recording";
            this.btnStopRecording.UseVisualStyleBackColor = true;
            this.btnStopRecording.Click += new System.EventHandler(this.btnStopRecording_Click);
            // 
            // btnRecord
            // 
            this.btnRecord.Location = new System.Drawing.Point(17, 199);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(90, 23);
            this.btnRecord.TabIndex = 1;
            this.btnRecord.Text = "Record";
            this.btnRecord.UseVisualStyleBackColor = true;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // cbVideoDevices
            // 
            this.cbVideoDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVideoDevices.FormattingEnabled = true;
            this.cbVideoDevices.Location = new System.Drawing.Point(15, 252);
            this.cbVideoDevices.Name = "cbVideoDevices";
            this.cbVideoDevices.Size = new System.Drawing.Size(222, 21);
            this.cbVideoDevices.TabIndex = 4;
            this.cbVideoDevices.SelectedIndexChanged += new System.EventHandler(this.cbVideoDevices_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 236);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Video Devices";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 276);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Video Preview Size";
            // 
            // cbVideoPreviewSizes
            // 
            this.cbVideoPreviewSizes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVideoPreviewSizes.FormattingEnabled = true;
            this.cbVideoPreviewSizes.Location = new System.Drawing.Point(15, 292);
            this.cbVideoPreviewSizes.Name = "cbVideoPreviewSizes";
            this.cbVideoPreviewSizes.Size = new System.Drawing.Size(222, 21);
            this.cbVideoPreviewSizes.TabIndex = 6;
            this.cbVideoPreviewSizes.SelectedIndexChanged += new System.EventHandler(this.cbVideoPreviewSizes_SelectedIndexChanged);
            // 
            // txtIpToCall
            // 
            this.txtIpToCall.Location = new System.Drawing.Point(32, 23);
            this.txtIpToCall.Name = "txtIpToCall";
            this.txtIpToCall.Size = new System.Drawing.Size(182, 20);
            this.txtIpToCall.TabIndex = 10;
            // 
            // btnStartPreview
            // 
            this.btnStartPreview.Location = new System.Drawing.Point(15, 331);
            this.btnStartPreview.Name = "btnStartPreview";
            this.btnStartPreview.Size = new System.Drawing.Size(95, 23);
            this.btnStartPreview.TabIndex = 12;
            this.btnStartPreview.Text = "&Start Listening";
            this.btnStartPreview.UseVisualStyleBackColor = true;
            this.btnStartPreview.Click += new System.EventHandler(this.btnStartPreview_Click);
            // 
            // btnStopPreview
            // 
            this.btnStopPreview.Enabled = false;
            this.btnStopPreview.Location = new System.Drawing.Point(113, 331);
            this.btnStopPreview.Name = "btnStopPreview";
            this.btnStopPreview.Size = new System.Drawing.Size(95, 23);
            this.btnStopPreview.TabIndex = 13;
            this.btnStopPreview.Text = "Sto&p Listening";
            this.btnStopPreview.UseVisualStyleBackColor = true;
            this.btnStopPreview.Click += new System.EventHandler(this.btnStopPreview_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.txtaudioportudp);
            this.groupBox5.Controls.Add(this.txtAudioporttcp);
            this.groupBox5.Controls.Add(this.txtVideoport);
            this.groupBox5.Location = new System.Drawing.Point(248, 369);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(233, 100);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Incoming Call Listening ports";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Audio port (udp)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Audio port (tcp)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Video port (tcp)";
            // 
            // txtaudioportudp
            // 
            this.txtaudioportudp.Location = new System.Drawing.Point(99, 75);
            this.txtaudioportudp.Name = "txtaudioportudp";
            this.txtaudioportudp.Size = new System.Drawing.Size(116, 20);
            this.txtaudioportudp.TabIndex = 3;
            this.txtaudioportudp.Text = "17861";
            // 
            // txtAudioporttcp
            // 
            this.txtAudioporttcp.Location = new System.Drawing.Point(99, 49);
            this.txtAudioporttcp.Name = "txtAudioporttcp";
            this.txtAudioporttcp.Size = new System.Drawing.Size(116, 20);
            this.txtAudioporttcp.TabIndex = 2;
            this.txtAudioporttcp.Text = "17860";
            // 
            // txtVideoport
            // 
            this.txtVideoport.Location = new System.Drawing.Point(99, 23);
            this.txtVideoport.Name = "txtVideoport";
            this.txtVideoport.Size = new System.Drawing.Size(116, 20);
            this.txtVideoport.TabIndex = 1;
            this.txtVideoport.Text = "9990";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnHangup);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.btnCall);
            this.groupBox1.Controls.Add(this.txtIpToCall);
            this.groupBox1.Controls.Add(this.txtoutVideoPort);
            this.groupBox1.Location = new System.Drawing.Point(248, 265);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(233, 102);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Outgoing Call Settings";
            // 
            // btnHangup
            // 
            this.btnHangup.Image = global::VideoPhoneDemo.Properties.Resources.Away;
            this.btnHangup.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHangup.Location = new System.Drawing.Point(125, 75);
            this.btnHangup.Name = "btnHangup";
            this.btnHangup.Size = new System.Drawing.Size(89, 23);
            this.btnHangup.TabIndex = 13;
            this.btnHangup.Text = "&Hang up";
            this.btnHangup.UseVisualStyleBackColor = true;
            this.btnHangup.Click += new System.EventHandler(this.btnHangup_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(15, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "ip";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Video port (tcp)";
            // 
            // btnCall
            // 
            this.btnCall.Image = global::VideoPhoneDemo.Properties.Resources.Available;
            this.btnCall.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCall.Location = new System.Drawing.Point(32, 75);
            this.btnCall.Name = "btnCall";
            this.btnCall.Size = new System.Drawing.Size(87, 23);
            this.btnCall.TabIndex = 11;
            this.btnCall.Text = "&Call";
            this.btnCall.UseVisualStyleBackColor = true;
            this.btnCall.Click += new System.EventHandler(this.btnCall_Click);
            // 
            // txtoutVideoPort
            // 
            this.txtoutVideoPort.Location = new System.Drawing.Point(98, 49);
            this.txtoutVideoPort.Name = "txtoutVideoPort";
            this.txtoutVideoPort.Size = new System.Drawing.Size(116, 20);
            this.txtoutVideoPort.TabIndex = 1;
            this.txtoutVideoPort.Text = "9990";
            // 
            // btnStopScreenSharing
            // 
            this.btnStopScreenSharing.Location = new System.Drawing.Point(134, 16);
            this.btnStopScreenSharing.Name = "btnStopScreenSharing";
            this.btnStopScreenSharing.Size = new System.Drawing.Size(90, 23);
            this.btnStopScreenSharing.TabIndex = 3;
            this.btnStopScreenSharing.Text = "Stop";
            this.btnStopScreenSharing.UseVisualStyleBackColor = true;
            this.btnStopScreenSharing.Click += new System.EventHandler(this.btnStopScreenSharing_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnSendRequestToShareScreen);
            this.groupBox3.Controls.Add(this.btnStopScreenSharing);
            this.groupBox3.Location = new System.Drawing.Point(248, 470);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(233, 42);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Screen Sharing";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 370);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(225, 138);
            this.textBox1.TabIndex = 25;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 520);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.btnStopPreview);
            this.Controls.Add(this.btnStartPreview);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbVideoPreviewSizes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbVideoDevices);
            this.Controls.Add(this.gbClient);
            this.Controls.Add(this.gbMyVideo);
            this.Name = "frmMain";
            this.Text = "iConf .NET SDK Video phone demo - AVSPEED,Inc.";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.gbMyVideo.ResumeLayout(false);
            this.gbClient.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.GroupBox groupBox5;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox txtaudioportudp;
        public System.Windows.Forms.TextBox txtAudioporttcp;
        public System.Windows.Forms.TextBox txtVideoport;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox txtoutVideoPort;
        public System.Windows.Forms.GroupBox gbMyVideo;
        public System.Windows.Forms.GroupBox gbClient;
        public System.Windows.Forms.ComboBox cbVideoDevices;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cbVideoPreviewSizes;
        public System.Windows.Forms.TextBox txtIpToCall;
        public System.Windows.Forms.Button btnCall;
        public System.Windows.Forms.Button btnStartPreview;
        public System.Windows.Forms.Button btnStopPreview;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.Button btnHangup;
        public System.Windows.Forms.Button btnRecord;
        public System.Windows.Forms.Button btnStopRecording;
        public System.Windows.Forms.Button btnTakePic;
        public System.Windows.Forms.Panel pnlics;
        public System.Windows.Forms.Panel pnlicc;
        public System.Windows.Forms.Button btnSendRequestToShareScreen;
        public System.Windows.Forms.Button btnStopScreenSharing;
        public System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.Button btnPopout;
        private System.Windows.Forms.TextBox textBox1;
    }
}

