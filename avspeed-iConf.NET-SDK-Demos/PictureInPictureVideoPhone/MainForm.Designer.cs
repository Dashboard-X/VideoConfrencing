namespace PictureInPictureVideoPhone
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlIncoming = new System.Windows.Forms.Panel();
            this.lblFrom = new System.Windows.Forms.Label();
            this.pbReject = new System.Windows.Forms.PictureBox();
            this.pbAccept = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlMessage = new System.Windows.Forms.Panel();
            this.lblMessage = new System.Windows.Forms.Label();
            this.pnlOptions = new System.Windows.Forms.Panel();
            this.lblOptions = new System.Windows.Forms.Label();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.lblCopy = new System.Windows.Forms.Label();
            this.lblMyIp = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbCam = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pbHangup = new System.Windows.Forms.PictureBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.pbCall = new System.Windows.Forms.PictureBox();
            this.pnlOtherVideo = new System.Windows.Forms.Panel();
            this.timerMessage = new System.Windows.Forms.Timer(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.pnlMain.SuspendLayout();
            this.pnlIncoming.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbReject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAccept)).BeginInit();
            this.pnlMessage.SuspendLayout();
            this.pnlOptions.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHangup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCall)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlIncoming);
            this.pnlMain.Controls.Add(this.pnlMessage);
            this.pnlMain.Controls.Add(this.pnlOptions);
            this.pnlMain.Controls.Add(this.pnlMenu);
            this.pnlMain.Controls.Add(this.pnlOtherVideo);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(422, 380);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlIncoming
            // 
            this.pnlIncoming.BackColor = System.Drawing.Color.White;
            this.pnlIncoming.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlIncoming.Controls.Add(this.lblFrom);
            this.pnlIncoming.Controls.Add(this.pbReject);
            this.pnlIncoming.Controls.Add(this.pbAccept);
            this.pnlIncoming.Controls.Add(this.label2);
            this.pnlIncoming.Location = new System.Drawing.Point(118, 133);
            this.pnlIncoming.Name = "pnlIncoming";
            this.pnlIncoming.Size = new System.Drawing.Size(219, 111);
            this.pnlIncoming.TabIndex = 4;
            this.pnlIncoming.Visible = false;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.Location = new System.Drawing.Point(50, 41);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(0, 16);
            this.lblFrom.TabIndex = 3;
            // 
            // pbReject
            // 
            this.pbReject.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbReject.Image = global::PictureInPictureVideoPhone.Properties.Resources._1290577031_001_19;
            this.pbReject.Location = new System.Drawing.Point(131, 66);
            this.pbReject.Name = "pbReject";
            this.pbReject.Size = new System.Drawing.Size(24, 24);
            this.pbReject.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbReject.TabIndex = 2;
            this.pbReject.TabStop = false;
            this.toolTip.SetToolTip(this.pbReject, "Reject Incoming call");
            this.pbReject.Click += new System.EventHandler(this.pbReject_Click);
            // 
            // pbAccept
            // 
            this.pbAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbAccept.Image = global::PictureInPictureVideoPhone.Properties.Resources._1290577015_001_18;
            this.pbAccept.Location = new System.Drawing.Point(53, 66);
            this.pbAccept.Name = "pbAccept";
            this.pbAccept.Size = new System.Drawing.Size(24, 24);
            this.pbAccept.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbAccept.TabIndex = 1;
            this.pbAccept.TabStop = false;
            this.toolTip.SetToolTip(this.pbAccept, "Accept incoming call");
            this.pbAccept.Click += new System.EventHandler(this.pbAccept_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(49, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Incoming Call";
            // 
            // pnlMessage
            // 
            this.pnlMessage.BackColor = System.Drawing.Color.PaleGreen;
            this.pnlMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMessage.Controls.Add(this.lblMessage);
            this.pnlMessage.Location = new System.Drawing.Point(74, 145);
            this.pnlMessage.Name = "pnlMessage";
            this.pnlMessage.Size = new System.Drawing.Size(200, 27);
            this.pnlMessage.TabIndex = 3;
            this.pnlMessage.Visible = false;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMessage.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblMessage.Location = new System.Drawing.Point(0, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(28, 23);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "...";
            // 
            // pnlOptions
            // 
            this.pnlOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOptions.BackColor = System.Drawing.Color.Silver;
            this.pnlOptions.Controls.Add(this.lblOptions);
            this.pnlOptions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlOptions.Location = new System.Drawing.Point(361, 1);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Size = new System.Drawing.Size(60, 19);
            this.pnlOptions.TabIndex = 2;
            this.pnlOptions.Click += new System.EventHandler(this.lblOptions_Click);
            // 
            // lblOptions
            // 
            this.lblOptions.AutoSize = true;
            this.lblOptions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblOptions.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblOptions.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOptions.ForeColor = System.Drawing.Color.White;
            this.lblOptions.Location = new System.Drawing.Point(0, 0);
            this.lblOptions.Name = "lblOptions";
            this.lblOptions.Size = new System.Drawing.Size(27, 13);
            this.lblOptions.TabIndex = 3;
            this.lblOptions.Text = "Call";
            this.lblOptions.Click += new System.EventHandler(this.lblOptions_Click);
            // 
            // pnlMenu
            // 
            this.pnlMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMenu.BackColor = System.Drawing.Color.LightGray;
            this.pnlMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMenu.Controls.Add(this.lblCopy);
            this.pnlMenu.Controls.Add(this.lblMyIp);
            this.pnlMenu.Controls.Add(this.label3);
            this.pnlMenu.Controls.Add(this.cbCam);
            this.pnlMenu.Controls.Add(this.label1);
            this.pnlMenu.Controls.Add(this.pbHangup);
            this.pnlMenu.Controls.Add(this.txtIP);
            this.pnlMenu.Controls.Add(this.pbCall);
            this.pnlMenu.Location = new System.Drawing.Point(236, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(186, 112);
            this.pnlMenu.TabIndex = 1;
            this.pnlMenu.Visible = false;
            // 
            // lblCopy
            // 
            this.lblCopy.AutoSize = true;
            this.lblCopy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCopy.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopy.ForeColor = System.Drawing.Color.Blue;
            this.lblCopy.Location = new System.Drawing.Point(123, 97);
            this.lblCopy.Name = "lblCopy";
            this.lblCopy.Size = new System.Drawing.Size(28, 11);
            this.lblCopy.TabIndex = 8;
            this.lblCopy.Text = "Copy";
            this.lblCopy.Click += new System.EventHandler(this.lblCopy_Click);
            // 
            // lblMyIp
            // 
            this.lblMyIp.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMyIp.Location = new System.Drawing.Point(39, 97);
            this.lblMyIp.Name = "lblMyIp";
            this.lblMyIp.Size = new System.Drawing.Size(92, 11);
            this.lblMyIp.TabIndex = 7;
            this.lblMyIp.Text = "255.255.255.255";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 11);
            this.label3.TabIndex = 6;
            this.label3.Text = "My ip";
            // 
            // cbCam
            // 
            this.cbCam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCam.DropDownWidth = 175;
            this.cbCam.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCam.FormattingEnabled = true;
            this.cbCam.Location = new System.Drawing.Point(54, 37);
            this.cbCam.Name = "cbCam";
            this.cbCam.Size = new System.Drawing.Size(121, 19);
            this.cbCam.TabIndex = 4;
            this.cbCam.SelectedIndexChanged += new System.EventHandler(this.cbCam_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 11);
            this.label1.TabIndex = 3;
            this.label1.Text = "Camera";
            // 
            // pbHangup
            // 
            this.pbHangup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbHangup.Image = global::PictureInPictureVideoPhone.Properties.Resources.hang;
            this.pbHangup.Location = new System.Drawing.Point(151, 0);
            this.pbHangup.Name = "pbHangup";
            this.pbHangup.Size = new System.Drawing.Size(32, 32);
            this.pbHangup.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbHangup.TabIndex = 2;
            this.pbHangup.TabStop = false;
            this.pbHangup.Visible = false;
            this.pbHangup.Click += new System.EventHandler(this.pbHangup_Click);
            // 
            // txtIP
            // 
            this.txtIP.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIP.Location = new System.Drawing.Point(12, 3);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(133, 21);
            this.txtIP.TabIndex = 1;
            // 
            // pbCall
            // 
            this.pbCall.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbCall.Image = global::PictureInPictureVideoPhone.Properties.Resources._1284699889_Phone;
            this.pbCall.Location = new System.Drawing.Point(151, 0);
            this.pbCall.Name = "pbCall";
            this.pbCall.Size = new System.Drawing.Size(32, 32);
            this.pbCall.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbCall.TabIndex = 0;
            this.pbCall.TabStop = false;
            this.pbCall.Click += new System.EventHandler(this.pbCall_Click);
            // 
            // pnlOtherVideo
            // 
            this.pnlOtherVideo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOtherVideo.BackColor = System.Drawing.Color.Black;
            this.pnlOtherVideo.Location = new System.Drawing.Point(314, 280);
            this.pnlOtherVideo.Name = "pnlOtherVideo";
            this.pnlOtherVideo.Size = new System.Drawing.Size(108, 100);
            this.pnlOtherVideo.TabIndex = 0;
            this.pnlOtherVideo.Visible = false;
            // 
            // timerMessage
            // 
            this.timerMessage.Interval = 3000;
            this.timerMessage.Tick += new System.EventHandler(this.timerMessage_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 380);
            this.Controls.Add(this.pnlMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Video Phone";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.pnlMain.ResumeLayout(false);
            this.pnlIncoming.ResumeLayout(false);
            this.pnlIncoming.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbReject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAccept)).EndInit();
            this.pnlMessage.ResumeLayout(false);
            this.pnlMessage.PerformLayout();
            this.pnlOptions.ResumeLayout(false);
            this.pnlOptions.PerformLayout();
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHangup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCall)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlOtherVideo;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.PictureBox pbCall;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Panel pnlOptions;
        private System.Windows.Forms.Label lblOptions;
        private System.Windows.Forms.PictureBox pbHangup;
        private System.Windows.Forms.ComboBox cbCam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlMessage;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Timer timerMessage;
        private System.Windows.Forms.Panel pnlIncoming;
        private System.Windows.Forms.PictureBox pbAccept;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pbReject;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label lblCopy;
        private System.Windows.Forms.Label lblMyIp;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lblFrom;
    }
}

