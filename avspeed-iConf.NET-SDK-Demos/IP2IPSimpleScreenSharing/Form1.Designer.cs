namespace IP2IPSimpleScreenSharing
{
    partial class Form1
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnHangUp = new System.Windows.Forms.Button();
            this.ics = new iConfServer.NET.iConfServerDotNet();
            this.btnCall = new System.Windows.Forms.Button();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.icc = new iConfClient.NET.iConfClientDotNet();
            this.btnStartScreenSharing = new System.Windows.Forms.Button();
            this.btnStopScreenSharing = new System.Windows.Forms.Button();
            this.btnChangeVideoDevice = new System.Windows.Forms.Button();
            this.lblDevice = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(634, 339);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Remote Video";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 235);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "My Video :";
            // 
            // btnHangUp
            // 
            this.btnHangUp.Location = new System.Drawing.Point(510, 351);
            this.btnHangUp.Name = "btnHangUp";
            this.btnHangUp.Size = new System.Drawing.Size(57, 23);
            this.btnHangUp.TabIndex = 15;
            this.btnHangUp.Text = "Hang up";
            this.btnHangUp.UseVisualStyleBackColor = true;
            this.btnHangUp.Click += new System.EventHandler(this.btnHangUp_Click);
            // 
            // ics
            // 
            this.ics.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ics.CallbackObject = null;
            this.ics.EncryptedData = false;
            this.ics.Location = new System.Drawing.Point(34, 23);
            this.ics.Name = "ics";
            this.ics.Size = new System.Drawing.Size(214, 207);
            this.ics.TabIndex = 14;
            this.ics.VideoRateControl = iConfServer.NET.iConfServerDotNet.RateControl.ConstantBitRate;
            this.ics.VideoPreviewStarted += new iConfServer.NET.iConfServerDotNet.VideoPreviewStartedDelegate(this.ics_VideoPreviewStarted);
            this.ics.ClientDisconnected += new iConfServer.NET.iConfServerDotNet.ClientDisconnectedDelegate(this.ics_ClientDisconnected);
            this.ics.IncomingCall += new iConfServer.NET.iConfServerDotNet.IncomingCallDelegate(this.ics_IncomingCall);
            this.ics.CannotRunGraph += new iConfServer.NET.iConfServerDotNet.CannotRunGraphDelegate(this.ics_CannotRunGraph);
            // 
            // btnCall
            // 
            this.btnCall.Location = new System.Drawing.Point(454, 351);
            this.btnCall.Name = "btnCall";
            this.btnCall.Size = new System.Drawing.Size(50, 23);
            this.btnCall.TabIndex = 13;
            this.btnCall.Text = "Call";
            this.btnCall.UseVisualStyleBackColor = true;
            this.btnCall.Click += new System.EventHandler(this.btnCall_Click);
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(310, 354);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(138, 20);
            this.txtIP.TabIndex = 12;
            // 
            // icc
            // 
            this.icc.AutoReconnect = false;
            this.icc.BackColor = System.Drawing.Color.Gray;
            this.icc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.icc.CallbackObject = null;
            this.icc.EncryptedData = false;
            this.icc.Location = new System.Drawing.Point(310, 23);
            this.icc.Name = "icc";
            this.icc.Size = new System.Drawing.Size(398, 313);
            this.icc.TabIndex = 11;
            this.icc.RequestToShareScreen += new iConfClient.NET.iConfClientDotNet.RequestToShareScreenDelegate(this.icc_RequestToShareScreen);
            this.icc.ScreenSharingStopped += new iConfClient.NET.iConfClientDotNet.ScreenSharingStoppedDelegate(this.icc_ScreenSharingStopped);
            // 
            // btnStartScreenSharing
            // 
            this.btnStartScreenSharing.Location = new System.Drawing.Point(34, 338);
            this.btnStartScreenSharing.Name = "btnStartScreenSharing";
            this.btnStartScreenSharing.Size = new System.Drawing.Size(75, 36);
            this.btnStartScreenSharing.TabIndex = 18;
            this.btnStartScreenSharing.Text = "Start Screen Sharing";
            this.btnStartScreenSharing.UseVisualStyleBackColor = true;
            this.btnStartScreenSharing.Click += new System.EventHandler(this.btnStartScreenSharing_Click);
            // 
            // btnStopScreenSharing
            // 
            this.btnStopScreenSharing.Location = new System.Drawing.Point(173, 338);
            this.btnStopScreenSharing.Name = "btnStopScreenSharing";
            this.btnStopScreenSharing.Size = new System.Drawing.Size(75, 36);
            this.btnStopScreenSharing.TabIndex = 19;
            this.btnStopScreenSharing.Text = "Stop Screen Sharing";
            this.btnStopScreenSharing.UseVisualStyleBackColor = true;
            this.btnStopScreenSharing.Click += new System.EventHandler(this.btnStopScreenSharing_Click);
            // 
            // btnChangeVideoDevice
            // 
            this.btnChangeVideoDevice.Location = new System.Drawing.Point(34, 272);
            this.btnChangeVideoDevice.Name = "btnChangeVideoDevice";
            this.btnChangeVideoDevice.Size = new System.Drawing.Size(122, 23);
            this.btnChangeVideoDevice.TabIndex = 20;
            this.btnChangeVideoDevice.Text = "Change Video Device";
            this.btnChangeVideoDevice.UseVisualStyleBackColor = true;
            this.btnChangeVideoDevice.Click += new System.EventHandler(this.btnChangeVideoDevice_Click);
            // 
            // lblDevice
            // 
            this.lblDevice.Location = new System.Drawing.Point(85, 235);
            this.lblDevice.Name = "lblDevice";
            this.lblDevice.Size = new System.Drawing.Size(163, 21);
            this.lblDevice.TabIndex = 21;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 389);
            this.Controls.Add(this.lblDevice);
            this.Controls.Add(this.btnChangeVideoDevice);
            this.Controls.Add(this.btnStopScreenSharing);
            this.Controls.Add(this.btnStartScreenSharing);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnHangUp);
            this.Controls.Add(this.ics);
            this.Controls.Add(this.btnCall);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.icc);
            this.Name = "Form1";
            this.Text = "Main Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnHangUp;
        private iConfServer.NET.iConfServerDotNet ics;
        internal System.Windows.Forms.Button btnCall;
        internal System.Windows.Forms.TextBox txtIP;
        internal iConfClient.NET.iConfClientDotNet icc;
        private System.Windows.Forms.Button btnStartScreenSharing;
        private System.Windows.Forms.Button btnStopScreenSharing;
        private System.Windows.Forms.Button btnChangeVideoDevice;
        private System.Windows.Forms.Label lblDevice;
    }
}

