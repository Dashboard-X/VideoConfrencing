namespace IP2IPDemo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnCall = new System.Windows.Forms.Button();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.btnHangUp = new System.Windows.Forms.Button();
            this.icc = new iConfClient.NET.iConfClientDotNet();
            this.ics = new iConfServer.NET.iConfServerDotNet();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCall
            // 
            this.btnCall.Location = new System.Drawing.Point(432, 340);
            this.btnCall.Name = "btnCall";
            this.btnCall.Size = new System.Drawing.Size(50, 23);
            this.btnCall.TabIndex = 6;
            this.btnCall.Text = "Call";
            this.btnCall.UseVisualStyleBackColor = true;
            this.btnCall.Click += new System.EventHandler(this.btnCall_Click);
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(288, 343);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(138, 20);
            this.txtIP.TabIndex = 5;
            // 
            // btnHangUp
            // 
            this.btnHangUp.Location = new System.Drawing.Point(488, 340);
            this.btnHangUp.Name = "btnHangUp";
            this.btnHangUp.Size = new System.Drawing.Size(57, 23);
            this.btnHangUp.TabIndex = 8;
            this.btnHangUp.Text = "Hang up";
            this.btnHangUp.UseVisualStyleBackColor = true;
            this.btnHangUp.Click += new System.EventHandler(this.btnHangUp_Click);
            // 
            // icc
            // 
            this.icc.AutoReconnect = false;
            this.icc.BackColor = System.Drawing.Color.Gray;
            this.icc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.icc.CallbackObject = null;
            this.icc.EncryptedData = false;
            this.icc.Location = new System.Drawing.Point(288, 12);
            this.icc.Name = "icc";
            this.icc.Size = new System.Drawing.Size(398, 313);
            this.icc.TabIndex = 4;
            // 
            // ics
            // 
            this.ics.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ics.CallbackObject = null;
            this.ics.EncryptedData = false;
            this.ics.Location = new System.Drawing.Point(12, 12);
            this.ics.Name = "ics";
            this.ics.Size = new System.Drawing.Size(214, 207);
            this.ics.TabIndex = 7;
            this.ics.VideoRateControl = iConfServer.NET.iConfServerDotNet.RateControl.ConstantBitRate;
            this.ics.VideoPreviewStarted += new iConfServer.NET.iConfServerDotNet.VideoPreviewStartedDelegate(this.ics_VideoPreviewStarted);
            this.ics.ClientDisconnected += new iConfServer.NET.iConfServerDotNet.ClientDisconnectedDelegate(this.ics_ClientDisconnected);
            this.ics.IncomingCall += new iConfServer.NET.iConfServerDotNet.IncomingCallDelegate(this.ics_IncomingCall);
            this.ics.CannotRunGraph += new iConfServer.NET.iConfServerDotNet.CannotRunGraphDelegate(this.ics_CannotRunGraph);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(175, 233);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "My Video";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(612, 328);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Remote Video";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 387);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnHangUp);
            this.Controls.Add(this.ics);
            this.Controls.Add(this.btnCall);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.icc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Simple IP 2 IP Demo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btnCall;
        internal System.Windows.Forms.TextBox txtIP;
        internal iConfClient.NET.iConfClientDotNet icc;
        private iConfServer.NET.iConfServerDotNet ics;
        private System.Windows.Forms.Button btnHangUp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

