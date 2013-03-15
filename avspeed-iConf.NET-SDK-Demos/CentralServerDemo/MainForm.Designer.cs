//INSTANT C# NOTE: Formerly VB project-level imports:
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace CentralServerDemo
{
	public partial class MainForm : System.Windows.Forms.Form
	{

		//Form overrides dispose to clean up the component list.
		[System.Diagnostics.DebuggerNonUserCode()]
		protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing && components != null)
				{
					components.Dispose();
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}

		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;

		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.  
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.gbMyVideo = new System.Windows.Forms.GroupBox();
            this.ics = new iConfServer.NET.iConfServerDotNet();
            this.label8 = new System.Windows.Forms.Label();
            this.rdMovieFile = new System.Windows.Forms.RadioButton();
            this.rdWebcam = new System.Windows.Forms.RadioButton();
            this.btnSelectMovieFile = new System.Windows.Forms.Button();
            this.pbWebCam = new System.Windows.Forms.PictureBox();
            this.cbWebcam = new System.Windows.Forms.ComboBox();
            this.btnAudioSettings = new System.Windows.Forms.Button();
            this.voiceActivationLevel = new System.Windows.Forms.TrackBar();
            this.chkVoiceActivation = new System.Windows.Forms.CheckBox();
            this.progressInput = new System.Windows.Forms.ProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.cxWebcam = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.gbCentralServerMode = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCentralIp = new System.Windows.Forms.TextBox();
            this.txtCentralPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.lblLoginStatus = new System.Windows.Forms.Label();
            this.gbContacts = new System.Windows.Forms.GroupBox();
            this.btnCheckConnection = new System.Windows.Forms.Button();
            this.btnScreenSharing = new System.Windows.Forms.CheckBox();
            this.btnJoinPrivateRoom = new System.Windows.Forms.Button();
            this.lblRemove = new System.Windows.Forms.Label();
            this.lblAdd = new System.Windows.Forms.Label();
            this.btnStartConference = new System.Windows.Forms.Button();
            this.lvContact = new System.Windows.Forms.ListView();
            this.columnContacts = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cxFileContacts = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemShareFileWithContact = new System.Windows.Forms.ToolStripMenuItem();
            this.cxFile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.shareFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendCustomObjectTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.masterVolume = new System.Windows.Forms.TrackBar();
            this.btnMuteUnmute = new System.Windows.Forms.Button();
            this.lblLeaveConference = new System.Windows.Forms.Label();
            this.lvInConferenceWith = new System.Windows.Forms.ListView();
            this.columnContact = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.btnDeletePic = new System.Windows.Forms.Button();
            this.pbProfile = new System.Windows.Forms.PictureBox();
            this.btnSnapPicture = new System.Windows.Forms.Button();
            this.pbLoginStatus = new System.Windows.Forms.PictureBox();
            this.timerInputLevel = new System.Windows.Forms.Timer(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.lblRoomName = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.logBox = new System.Windows.Forms.TextBox();
            this.lstShareFiles = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.saveFileDlg = new System.Windows.Forms.SaveFileDialog();
            this.shareFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.movieFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnViewConferenceChat = new System.Windows.Forms.Button();
            this.cxConference = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewVideoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.muteUnMuteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pbOffline = new System.Windows.Forms.PictureBox();
            this.pbOnline = new System.Windows.Forms.PictureBox();
            this.pbSmile = new System.Windows.Forms.PictureBox();
            this.btnHelpIP = new System.Windows.Forms.Button();
            this.gbMyVideo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbWebCam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.voiceActivationLevel)).BeginInit();
            this.gbCentralServerMode.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.gbContacts.SuspendLayout();
            this.cxFileContacts.SuspendLayout();
            this.cxFile.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterVolume)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoginStatus)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.cxConference.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOffline)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOnline)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSmile)).BeginInit();
            this.SuspendLayout();
            // 
            // gbMyVideo
            // 
            this.gbMyVideo.Controls.Add(this.ics);
            this.gbMyVideo.Controls.Add(this.label8);
            this.gbMyVideo.Controls.Add(this.rdMovieFile);
            this.gbMyVideo.Controls.Add(this.rdWebcam);
            this.gbMyVideo.Controls.Add(this.btnSelectMovieFile);
            this.gbMyVideo.Controls.Add(this.pbWebCam);
            this.gbMyVideo.Controls.Add(this.cbWebcam);
            this.gbMyVideo.Location = new System.Drawing.Point(15, 13);
            this.gbMyVideo.Name = "gbMyVideo";
            this.gbMyVideo.Size = new System.Drawing.Size(272, 272);
            this.gbMyVideo.TabIndex = 1;
            this.gbMyVideo.TabStop = false;
            this.gbMyVideo.Text = "My Video";
            // 
            // ics
            // 
            this.ics.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ics.CallbackObject = null;
            this.ics.EncryptedData = false;
            this.ics.Location = new System.Drawing.Point(43, 20);
            this.ics.Name = "ics";
            this.ics.Size = new System.Drawing.Size(219, 181);
            this.ics.TabIndex = 8;
            this.ics.VideoRateControl = iConfServer.NET.iConfServerDotNet.RateControl.ConstantBitRate;
            this.ics.VideoPreviewStarted += new iConfServer.NET.iConfServerDotNet.VideoPreviewStartedDelegate(this.ics_VideoPreviewStarted);
            this.ics.Talking += new iConfServer.NET.iConfServerDotNet.TalkingDelegate(this.ics_Talking);
            this.ics.CustomObjectReceived += new iConfServer.NET.iConfServerDotNet.CustomObjectReceivedDelegate(this.ics_CustomObjectReceived);
            this.ics.ReadyToShareScreen += new iConfServer.NET.iConfServerDotNet.ReadyToShareScreenDelegate(this.ics_ReadyToShareScreen);
            this.ics.ChangePasswordReponse += new iConfServer.NET.iConfServerDotNet.ChangePasswordResponseDelegate(this.ics_ChangePasswordReponse);
            this.ics.ConferenceRequestRejected += new iConfServer.NET.iConfServerDotNet.ConferenceRequestRejectedDelegate(this.ics_ConferenceRequestRejected);
            this.ics.ProfilePictureUpdated += new iConfServer.NET.iConfServerDotNet.ProfilePictureUpdatedDelegate(this.ics_ProfilePictureUpdated);
            this.ics.RegistrationResponse += new iConfServer.NET.iConfServerDotNet.RegistrationResponseDelegate(this.ics_RegistrationResponse);
            this.ics.AddContactRequestResponse += new iConfServer.NET.iConfServerDotNet.AddContactRequestResponseDelegate(this.ics_AddContactRequestResponse);
            this.ics.RemoveContactResponse += new iConfServer.NET.iConfServerDotNet.RemoveContactResponseDelegate(this.ics_RemoveContactResponse);
            this.ics.LoginResponse += new iConfServer.NET.iConfServerDotNet.LoginResponseDelegate(this.ics_LoginResponse);
            this.ics.LogoutResponse += new iConfServer.NET.iConfServerDotNet.LogoutResponseDelegate(this.ics_LogoutResponse);
            this.ics.NewContactRequest += new iConfServer.NET.iConfServerDotNet.NewContactRequestDelegate(this.ics_NewContactRequest);
            this.ics.NewFileShareRequest += new iConfServer.NET.iConfServerDotNet.NewFileShareRequestDelegate(this.ics_NewFileShareRequest);
            this.ics.PendingContactRequest += new iConfServer.NET.iConfServerDotNet.PendingContactRequestResponseDelegate(this.ics_PendingContactRequest);
            this.ics.DisconnectedFromCentralServer += new iConfServer.NET.iConfServerDotNet.DisconnectedFromCentralServerDelegate(this.ics_DisconnectedFromCentralServer);
            this.ics.ContactStatusChanged += new iConfServer.NET.iConfServerDotNet.ContactStatusChangeDelegate(this.ics_ContactStatusChanged);
            this.ics.ContactStatusMessageChanged += new iConfServer.NET.iConfServerDotNet.ContactStatusMessageChangeDelegate(this.ics_ContactStatusMessageChanged);
            this.ics.ContactListReceived += new iConfServer.NET.iConfServerDotNet.ContactListReceivedDelegate(this.ics_ContactListReceived);
            this.ics.ConferenceRequest += new iConfServer.NET.iConfServerDotNet.ConferenceRequestDelegate(this.ics_ConferenceRequest);
            this.ics.UserJoinedConference += new iConfServer.NET.iConfServerDotNet.UserJoinedConferenceDelegate(this.ics_UserJoinedConference);
            this.ics.UserLeftConference += new iConfServer.NET.iConfServerDotNet.UserLeftConferenceDelegate(this.ics_UserLeftConference);
            this.ics.JoinedConferenceRoom += new iConfServer.NET.iConfServerDotNet.JoinedConferenceRoomDelegate(this.ics_JoinedConferenceRoom);
            this.ics.ConferenceMessageReceived += new iConfServer.NET.iConfServerDotNet.ConferenceMessageReceivedDelegate(this.ics_ConferenceMessageReceived);
            this.ics.ConferencePrivateMessageReceived += new iConfServer.NET.iConfServerDotNet.ConferencePrivateMessageReceivedDelegate(this.ics_ConferencePrivateMessageReceived);
            this.ics.ViewUserResponseReceived += new iConfServer.NET.iConfServerDotNet.ViewUserResponseReceivedDelegate(this.ics_ViewUserResponseReceived);
            this.ics.FileDownloadProgress += new iConfServer.NET.iConfServerDotNet.FileDownloadProgressDelegate(this.ics_FileDownloadProgress);
            this.ics.FileDownloadCompleted += new iConfServer.NET.iConfServerDotNet.FileDownloadCompletedDelegate(this.ics_FileDownloadCompleted);
            this.ics.ScreenSharingSessionAvailable += new iConfServer.NET.iConfServerDotNet.ScreenSharingSessionAvailableDelegate(this.ics_ScreenSharingSessionAvailable);
            this.ics.Log += new iConfServer.NET.iConfServerDotNet.LogDelegate(this.ics_Log);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(2, 240);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Video source";
            // 
            // rdMovieFile
            // 
            this.rdMovieFile.AutoSize = true;
            this.rdMovieFile.Location = new System.Drawing.Point(158, 238);
            this.rdMovieFile.Name = "rdMovieFile";
            this.rdMovieFile.Size = new System.Drawing.Size(79, 17);
            this.rdMovieFile.TabIndex = 6;
            this.rdMovieFile.Text = "Movie file";
            this.rdMovieFile.UseVisualStyleBackColor = true;
            // 
            // rdWebcam
            // 
            this.rdWebcam.AutoSize = true;
            this.rdWebcam.Checked = true;
            this.rdWebcam.Location = new System.Drawing.Point(83, 238);
            this.rdWebcam.Name = "rdWebcam";
            this.rdWebcam.Size = new System.Drawing.Size(73, 17);
            this.rdWebcam.TabIndex = 5;
            this.rdWebcam.TabStop = true;
            this.rdWebcam.Text = "Webcam";
            this.rdWebcam.UseVisualStyleBackColor = true;
            this.rdWebcam.CheckedChanged += new System.EventHandler(this.rdWebcam_CheckedChanged);
            // 
            // btnSelectMovieFile
            // 
            this.btnSelectMovieFile.Location = new System.Drawing.Point(238, 236);
            this.btnSelectMovieFile.Name = "btnSelectMovieFile";
            this.btnSelectMovieFile.Size = new System.Drawing.Size(26, 21);
            this.btnSelectMovieFile.TabIndex = 3;
            this.btnSelectMovieFile.Text = "...";
            this.btnSelectMovieFile.UseVisualStyleBackColor = true;
            this.btnSelectMovieFile.Click += new System.EventHandler(this.btnSelectMovieFile_Click);
            // 
            // pbWebCam
            // 
            this.pbWebCam.Image = ((System.Drawing.Image)(resources.GetObject("pbWebCam.Image")));
            this.pbWebCam.Location = new System.Drawing.Point(17, 208);
            this.pbWebCam.Name = "pbWebCam";
            this.pbWebCam.Size = new System.Drawing.Size(16, 16);
            this.pbWebCam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbWebCam.TabIndex = 2;
            this.pbWebCam.TabStop = false;
            // 
            // cbWebcam
            // 
            this.cbWebcam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWebcam.FormattingEnabled = true;
            this.cbWebcam.Location = new System.Drawing.Point(43, 207);
            this.cbWebcam.Name = "cbWebcam";
            this.cbWebcam.Size = new System.Drawing.Size(219, 21);
            this.cbWebcam.TabIndex = 1;
            this.cbWebcam.SelectedIndexChanged += new System.EventHandler(this.cbWebcam_SelectedIndexChanged);
            // 
            // btnAudioSettings
            // 
            this.btnAudioSettings.Font = new System.Drawing.Font("Verdana", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAudioSettings.Location = new System.Drawing.Point(5, 21);
            this.btnAudioSettings.Name = "btnAudioSettings";
            this.btnAudioSettings.Size = new System.Drawing.Size(44, 36);
            this.btnAudioSettings.TabIndex = 21;
            this.btnAudioSettings.Text = "audio devices";
            this.btnAudioSettings.UseVisualStyleBackColor = true;
            this.btnAudioSettings.Click += new System.EventHandler(this.btnAudioSettings_Click);
            // 
            // voiceActivationLevel
            // 
            this.voiceActivationLevel.AutoSize = false;
            this.voiceActivationLevel.Location = new System.Drawing.Point(177, 40);
            this.voiceActivationLevel.Maximum = 20;
            this.voiceActivationLevel.Name = "voiceActivationLevel";
            this.voiceActivationLevel.Size = new System.Drawing.Size(85, 20);
            this.voiceActivationLevel.TabIndex = 20;
            this.voiceActivationLevel.TickStyle = System.Windows.Forms.TickStyle.None;
            this.voiceActivationLevel.Value = 10;
            this.voiceActivationLevel.ValueChanged += new System.EventHandler(this.voiceActivationLevel_ValueChanged);
            // 
            // chkVoiceActivation
            // 
            this.chkVoiceActivation.AutoSize = true;
            this.chkVoiceActivation.Location = new System.Drawing.Point(54, 39);
            this.chkVoiceActivation.Name = "chkVoiceActivation";
            this.chkVoiceActivation.Size = new System.Drawing.Size(115, 17);
            this.chkVoiceActivation.TabIndex = 19;
            this.chkVoiceActivation.Text = "Voice activation";
            this.chkVoiceActivation.UseVisualStyleBackColor = true;
            this.chkVoiceActivation.CheckedChanged += new System.EventHandler(this.chkVoiceActivation_CheckedChanged);
            // 
            // progressInput
            // 
            this.progressInput.Location = new System.Drawing.Point(162, 18);
            this.progressInput.Maximum = 20;
            this.progressInput.Name = "progressInput";
            this.progressInput.Size = new System.Drawing.Size(100, 15);
            this.progressInput.Step = 1;
            this.progressInput.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressInput.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Audio input level";
            // 
            // cxWebcam
            // 
            this.cxWebcam.Name = "cxWebcam";
            this.cxWebcam.ShowCheckMargin = true;
            this.cxWebcam.Size = new System.Drawing.Size(83, 4);
            // 
            // gbCentralServerMode
            // 
            this.gbCentralServerMode.Controls.Add(this.btnHelpIP);
            this.gbCentralServerMode.Controls.Add(this.label1);
            this.gbCentralServerMode.Controls.Add(this.txtCentralIp);
            this.gbCentralServerMode.Controls.Add(this.txtCentralPort);
            this.gbCentralServerMode.Controls.Add(this.label2);
            this.gbCentralServerMode.Location = new System.Drawing.Point(16, 358);
            this.gbCentralServerMode.Name = "gbCentralServerMode";
            this.gbCentralServerMode.Size = new System.Drawing.Size(272, 86);
            this.gbCentralServerMode.TabIndex = 10;
            this.gbCentralServerMode.TabStop = false;
            this.gbCentralServerMode.Text = "Central Server Options";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "IP Address";
            // 
            // txtCentralIp
            // 
            this.txtCentralIp.Location = new System.Drawing.Point(112, 29);
            this.txtCentralIp.Name = "txtCentralIp";
            this.txtCentralIp.Size = new System.Drawing.Size(152, 21);
            this.txtCentralIp.TabIndex = 5;
            this.txtCentralIp.Text = "184.175.121.100";
            // 
            // txtCentralPort
            // 
            this.txtCentralPort.Location = new System.Drawing.Point(112, 56);
            this.txtCentralPort.Name = "txtCentralPort";
            this.txtCentralPort.Size = new System.Drawing.Size(152, 21);
            this.txtCentralPort.TabIndex = 7;
            this.txtCentralPort.Text = "8081";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Port";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.btnRegister);
            this.GroupBox1.Controls.Add(this.btnLogout);
            this.GroupBox1.Controls.Add(this.btnLogin);
            this.GroupBox1.Controls.Add(this.txtPassword);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.txtUserName);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Location = new System.Drawing.Point(294, 13);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(233, 128);
            this.GroupBox1.TabIndex = 11;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Login";
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(17, 101);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(209, 23);
            this.btnRegister.TabIndex = 6;
            this.btnRegister.Text = "Register New User";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(139, 71);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(87, 23);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(17, 71);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(87, 23);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(77, 45);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(149, 21);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.Enter += new System.EventHandler(this.txtUserName_Enter);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(14, 45);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(61, 13);
            this.Label4.TabIndex = 2;
            this.Label4.Text = "Password";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(77, 20);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(149, 21);
            this.txtUserName.TabIndex = 1;
            this.txtUserName.Enter += new System.EventHandler(this.txtUserName_Enter);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(8, 20);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(69, 13);
            this.Label3.TabIndex = 0;
            this.Label3.Text = "User name";
            // 
            // lblLoginStatus
            // 
            this.lblLoginStatus.Location = new System.Drawing.Point(8, 14);
            this.lblLoginStatus.Name = "lblLoginStatus";
            this.lblLoginStatus.Size = new System.Drawing.Size(98, 20);
            this.lblLoginStatus.TabIndex = 12;
            this.lblLoginStatus.Text = "Not logged in";
            this.lblLoginStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblLoginStatus.Click += new System.EventHandler(this.lblLoginStatus_Click);
            // 
            // gbContacts
            // 
            this.gbContacts.Controls.Add(this.btnCheckConnection);
            this.gbContacts.Controls.Add(this.btnScreenSharing);
            this.gbContacts.Controls.Add(this.btnJoinPrivateRoom);
            this.gbContacts.Controls.Add(this.lblRemove);
            this.gbContacts.Controls.Add(this.lblAdd);
            this.gbContacts.Controls.Add(this.btnStartConference);
            this.gbContacts.Controls.Add(this.lvContact);
            this.gbContacts.Location = new System.Drawing.Point(739, 13);
            this.gbContacts.Name = "gbContacts";
            this.gbContacts.Size = new System.Drawing.Size(194, 431);
            this.gbContacts.TabIndex = 14;
            this.gbContacts.TabStop = false;
            this.gbContacts.Text = "Contacts";
            // 
            // btnCheckConnection
            // 
            this.btnCheckConnection.Location = new System.Drawing.Point(11, 399);
            this.btnCheckConnection.Name = "btnCheckConnection";
            this.btnCheckConnection.Size = new System.Drawing.Size(177, 23);
            this.btnCheckConnection.TabIndex = 28;
            this.btnCheckConnection.Text = "Am I connected to server?";
            this.btnCheckConnection.UseVisualStyleBackColor = true;
            this.btnCheckConnection.Click += new System.EventHandler(this.btnCheckConnection_Click);
            // 
            // btnScreenSharing
            // 
            this.btnScreenSharing.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnScreenSharing.Image = global::CentralServerDemo.Properties.Resources.Computer;
            this.btnScreenSharing.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnScreenSharing.Location = new System.Drawing.Point(11, 360);
            this.btnScreenSharing.Name = "btnScreenSharing";
            this.btnScreenSharing.Size = new System.Drawing.Size(178, 29);
            this.btnScreenSharing.TabIndex = 26;
            this.btnScreenSharing.Text = "Share Screen";
            this.btnScreenSharing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnScreenSharing.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnScreenSharing.UseVisualStyleBackColor = true;
            this.btnScreenSharing.CheckedChanged += new System.EventHandler(this.btnScreenSharing_CheckedChanged);
            // 
            // btnJoinPrivateRoom
            // 
            this.btnJoinPrivateRoom.Location = new System.Drawing.Point(10, 324);
            this.btnJoinPrivateRoom.Name = "btnJoinPrivateRoom";
            this.btnJoinPrivateRoom.Size = new System.Drawing.Size(179, 30);
            this.btnJoinPrivateRoom.TabIndex = 4;
            this.btnJoinPrivateRoom.Text = "Join Private Room";
            this.btnJoinPrivateRoom.UseVisualStyleBackColor = true;
            this.btnJoinPrivateRoom.Click += new System.EventHandler(this.btnJoinPrivateRoom_Click);
            // 
            // lblRemove
            // 
            this.lblRemove.AutoSize = true;
            this.lblRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblRemove.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemove.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblRemove.Location = new System.Drawing.Point(135, 15);
            this.lblRemove.Name = "lblRemove";
            this.lblRemove.Size = new System.Drawing.Size(54, 13);
            this.lblRemove.TabIndex = 3;
            this.lblRemove.Text = "Remove";
            this.lblRemove.Click += new System.EventHandler(this.lblRemove_Click);
            // 
            // lblAdd
            // 
            this.lblAdd.AutoSize = true;
            this.lblAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblAdd.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdd.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblAdd.Location = new System.Drawing.Point(100, 15);
            this.lblAdd.Name = "lblAdd";
            this.lblAdd.Size = new System.Drawing.Size(29, 13);
            this.lblAdd.TabIndex = 2;
            this.lblAdd.Text = "Add";
            this.lblAdd.Click += new System.EventHandler(this.lblAdd_Click);
            // 
            // btnStartConference
            // 
            this.btnStartConference.Image = ((System.Drawing.Image)(resources.GetObject("btnStartConference.Image")));
            this.btnStartConference.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStartConference.Location = new System.Drawing.Point(10, 274);
            this.btnStartConference.Name = "btnStartConference";
            this.btnStartConference.Size = new System.Drawing.Size(178, 44);
            this.btnStartConference.TabIndex = 1;
            this.btnStartConference.Text = "Start conference with Selected Contacts";
            this.btnStartConference.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStartConference.UseVisualStyleBackColor = true;
            this.btnStartConference.Click += new System.EventHandler(this.btnStartConference_Click);
            // 
            // lvContact
            // 
            this.lvContact.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnContacts});
            this.lvContact.ContextMenuStrip = this.cxFileContacts;
            this.lvContact.Location = new System.Drawing.Point(10, 34);
            this.lvContact.Name = "lvContact";
            this.lvContact.Size = new System.Drawing.Size(179, 230);
            this.lvContact.TabIndex = 0;
            this.lvContact.UseCompatibleStateImageBehavior = false;
            this.lvContact.View = System.Windows.Forms.View.Details;
            // 
            // columnContacts
            // 
            this.columnContacts.Text = "Contact";
            this.columnContacts.Width = 133;
            // 
            // cxFileContacts
            // 
            this.cxFileContacts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemShareFileWithContact});
            this.cxFileContacts.Name = "cxFile";
            this.cxFileContacts.Size = new System.Drawing.Size(125, 26);
            // 
            // toolStripMenuItemShareFileWithContact
            // 
            this.toolStripMenuItemShareFileWithContact.Name = "toolStripMenuItemShareFileWithContact";
            this.toolStripMenuItemShareFileWithContact.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItemShareFileWithContact.Text = "Share File";
            this.toolStripMenuItemShareFileWithContact.Click += new System.EventHandler(this.toolStripMenuItemShareFileWithContact_Click);
            // 
            // cxFile
            // 
            this.cxFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shareFileToolStripMenuItem,
            this.sendCustomObjectTestToolStripMenuItem});
            this.cxFile.Name = "cxFile";
            this.cxFile.Size = new System.Drawing.Size(217, 48);
            // 
            // shareFileToolStripMenuItem
            // 
            this.shareFileToolStripMenuItem.Name = "shareFileToolStripMenuItem";
            this.shareFileToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.shareFileToolStripMenuItem.Text = "Share File";
            this.shareFileToolStripMenuItem.Click += new System.EventHandler(this.shareFileToolStripMenuItem_Click);
            // 
            // sendCustomObjectTestToolStripMenuItem
            // 
            this.sendCustomObjectTestToolStripMenuItem.Name = "sendCustomObjectTestToolStripMenuItem";
            this.sendCustomObjectTestToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.sendCustomObjectTestToolStripMenuItem.Text = "Send Custom Object (Test)";
            this.sendCustomObjectTestToolStripMenuItem.Click += new System.EventHandler(this.sendCustomObjectTestToolStripMenuItem_Click);
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.pictureBox1);
            this.GroupBox2.Controls.Add(this.label6);
            this.GroupBox2.Controls.Add(this.masterVolume);
            this.GroupBox2.Controls.Add(this.btnMuteUnmute);
            this.GroupBox2.Controls.Add(this.lblLeaveConference);
            this.GroupBox2.Controls.Add(this.lvInConferenceWith);
            this.GroupBox2.Location = new System.Drawing.Point(294, 167);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(233, 222);
            this.GroupBox2.TabIndex = 15;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "in conference with";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(45, 200);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(63, 201);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Volume";
            // 
            // masterVolume
            // 
            this.masterVolume.AutoSize = false;
            this.masterVolume.Location = new System.Drawing.Point(119, 201);
            this.masterVolume.Maximum = 255;
            this.masterVolume.Name = "masterVolume";
            this.masterVolume.Size = new System.Drawing.Size(105, 20);
            this.masterVolume.TabIndex = 21;
            this.masterVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.masterVolume.Value = 10;
            this.masterVolume.ValueChanged += new System.EventHandler(this.masterVolume_ValueChanged);
            // 
            // btnMuteUnmute
            // 
            this.btnMuteUnmute.Location = new System.Drawing.Point(10, 170);
            this.btnMuteUnmute.Name = "btnMuteUnmute";
            this.btnMuteUnmute.Size = new System.Drawing.Size(105, 23);
            this.btnMuteUnmute.TabIndex = 2;
            this.btnMuteUnmute.Text = "Mute/Un-Mute";
            this.btnMuteUnmute.UseVisualStyleBackColor = true;
            this.btnMuteUnmute.Click += new System.EventHandler(this.btnMuteUnmute_Click);
            // 
            // lblLeaveConference
            // 
            this.lblLeaveConference.AutoSize = true;
            this.lblLeaveConference.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblLeaveConference.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeaveConference.ForeColor = System.Drawing.Color.Blue;
            this.lblLeaveConference.Location = new System.Drawing.Point(121, 170);
            this.lblLeaveConference.Name = "lblLeaveConference";
            this.lblLeaveConference.Size = new System.Drawing.Size(94, 13);
            this.lblLeaveConference.TabIndex = 1;
            this.lblLeaveConference.Text = "Leave conference";
            this.lblLeaveConference.Click += new System.EventHandler(this.lblLeaveConference_Click);
            // 
            // lvInConferenceWith
            // 
            this.lvInConferenceWith.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnContact});
            this.lvInConferenceWith.ContextMenuStrip = this.cxFile;
            this.lvInConferenceWith.Location = new System.Drawing.Point(10, 20);
            this.lvInConferenceWith.MultiSelect = false;
            this.lvInConferenceWith.Name = "lvInConferenceWith";
            this.lvInConferenceWith.Size = new System.Drawing.Size(214, 144);
            this.lvInConferenceWith.TabIndex = 0;
            this.lvInConferenceWith.UseCompatibleStateImageBehavior = false;
            this.lvInConferenceWith.View = System.Windows.Forms.View.Details;
            this.lvInConferenceWith.DoubleClick += new System.EventHandler(this.lvInConferenceWith_DoubleClick);
            // 
            // columnContact
            // 
            this.columnContact.Text = "Contact";
            this.columnContact.Width = 111;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnChangePassword);
            this.groupBox3.Controls.Add(this.btnDeletePic);
            this.groupBox3.Controls.Add(this.pbProfile);
            this.groupBox3.Controls.Add(this.btnSnapPicture);
            this.groupBox3.Controls.Add(this.lblLoginStatus);
            this.groupBox3.Controls.Add(this.pbLoginStatus);
            this.groupBox3.Location = new System.Drawing.Point(533, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 128);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Image = global::CentralServerDemo.Properties.Resources.key;
            this.btnChangePassword.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChangePassword.Location = new System.Drawing.Point(11, 95);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(178, 23);
            this.btnChangePassword.TabIndex = 15;
            this.btnChangePassword.Text = "Change password";
            this.btnChangePassword.UseVisualStyleBackColor = true;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // btnDeletePic
            // 
            this.btnDeletePic.Image = ((System.Drawing.Image)(resources.GetObject("btnDeletePic.Image")));
            this.btnDeletePic.Location = new System.Drawing.Point(138, 66);
            this.btnDeletePic.Name = "btnDeletePic";
            this.btnDeletePic.Size = new System.Drawing.Size(51, 23);
            this.btnDeletePic.TabIndex = 14;
            this.btnDeletePic.UseVisualStyleBackColor = true;
            this.btnDeletePic.Click += new System.EventHandler(this.btnDeletePic_Click);
            // 
            // pbProfile
            // 
            this.pbProfile.Location = new System.Drawing.Point(130, 12);
            this.pbProfile.Name = "pbProfile";
            this.pbProfile.Size = new System.Drawing.Size(59, 50);
            this.pbProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbProfile.TabIndex = 0;
            this.pbProfile.TabStop = false;
            // 
            // btnSnapPicture
            // 
            this.btnSnapPicture.Image = ((System.Drawing.Image)(resources.GetObject("btnSnapPicture.Image")));
            this.btnSnapPicture.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSnapPicture.Location = new System.Drawing.Point(11, 66);
            this.btnSnapPicture.Name = "btnSnapPicture";
            this.btnSnapPicture.Size = new System.Drawing.Size(126, 23);
            this.btnSnapPicture.TabIndex = 1;
            this.btnSnapPicture.Text = "Snap Profile Pic";
            this.btnSnapPicture.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSnapPicture.UseVisualStyleBackColor = true;
            this.btnSnapPicture.Click += new System.EventHandler(this.btnSnapPicture_Click);
            // 
            // pbLoginStatus
            // 
            this.pbLoginStatus.Image = ((System.Drawing.Image)(resources.GetObject("pbLoginStatus.Image")));
            this.pbLoginStatus.Location = new System.Drawing.Point(61, 45);
            this.pbLoginStatus.Name = "pbLoginStatus";
            this.pbLoginStatus.Size = new System.Drawing.Size(16, 16);
            this.pbLoginStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbLoginStatus.TabIndex = 13;
            this.pbLoginStatus.TabStop = false;
            // 
            // timerInputLevel
            // 
            this.timerInputLevel.Tick += new System.EventHandler(this.timerInputLevel_Tick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(296, 149);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Room :";
            // 
            // lblRoomName
            // 
            this.lblRoomName.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomName.Location = new System.Drawing.Point(348, 150);
            this.lblRoomName.Name = "lblRoomName";
            this.lblRoomName.Size = new System.Drawing.Size(179, 14);
            this.lblRoomName.TabIndex = 19;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox7);
            this.groupBox4.Controls.Add(this.lstShareFiles);
            this.groupBox4.Location = new System.Drawing.Point(533, 168);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 276);
            this.groupBox4.TabIndex = 21;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Downloaded files";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.logBox);
            this.groupBox7.Location = new System.Drawing.Point(6, 156);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(188, 113);
            this.groupBox7.TabIndex = 2;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Log";
            // 
            // logBox
            // 
            this.logBox.BackColor = System.Drawing.Color.White;
            this.logBox.ForeColor = System.Drawing.Color.Blue;
            this.logBox.Location = new System.Drawing.Point(7, 21);
            this.logBox.Multiline = true;
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logBox.Size = new System.Drawing.Size(175, 85);
            this.logBox.TabIndex = 0;
            // 
            // lstShareFiles
            // 
            this.lstShareFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lstShareFiles.FullRowSelect = true;
            this.lstShareFiles.Location = new System.Drawing.Point(6, 20);
            this.lstShareFiles.MultiSelect = false;
            this.lstShareFiles.Name = "lstShareFiles";
            this.lstShareFiles.Size = new System.Drawing.Size(188, 129);
            this.lstShareFiles.TabIndex = 1;
            this.lstShareFiles.UseCompatibleStateImageBehavior = false;
            this.lstShareFiles.View = System.Windows.Forms.View.Details;
            this.lstShareFiles.DoubleClick += new System.EventHandler(this.lstShareFiles_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "File Name";
            this.columnHeader1.Width = 82;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Size (kb)";
            this.columnHeader2.Width = 76;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Downloaded (kb)";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Status";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnAudioSettings);
            this.groupBox5.Controls.Add(this.voiceActivationLevel);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.chkVoiceActivation);
            this.groupBox5.Controls.Add(this.progressInput);
            this.groupBox5.Location = new System.Drawing.Point(15, 284);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(272, 68);
            this.groupBox5.TabIndex = 22;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Audio";
            // 
            // movieFileDlg
            // 
            this.movieFileDlg.FileName = "openFileDialog1";
            this.movieFileDlg.Filter = "AVI Files|*.avi|WMV Files|*.wmv";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnViewConferenceChat);
            this.groupBox6.Location = new System.Drawing.Point(294, 391);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(233, 53);
            this.groupBox6.TabIndex = 23;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Chat";
            // 
            // btnViewConferenceChat
            // 
            this.btnViewConferenceChat.Image = ((System.Drawing.Image)(resources.GetObject("btnViewConferenceChat.Image")));
            this.btnViewConferenceChat.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnViewConferenceChat.Location = new System.Drawing.Point(10, 15);
            this.btnViewConferenceChat.Name = "btnViewConferenceChat";
            this.btnViewConferenceChat.Size = new System.Drawing.Size(214, 32);
            this.btnViewConferenceChat.TabIndex = 23;
            this.btnViewConferenceChat.Text = "Open Chat Window";
            this.btnViewConferenceChat.UseVisualStyleBackColor = true;
            this.btnViewConferenceChat.Click += new System.EventHandler(this.btnViewConferenceChat_Click);
            // 
            // cxConference
            // 
            this.cxConference.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewVideoToolStripMenuItem,
            this.muteUnMuteToolStripMenuItem});
            this.cxConference.Name = "cxConference";
            this.cxConference.Size = new System.Drawing.Size(156, 48);
            // 
            // viewVideoToolStripMenuItem
            // 
            this.viewVideoToolStripMenuItem.Name = "viewVideoToolStripMenuItem";
            this.viewVideoToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.viewVideoToolStripMenuItem.Text = "View video";
            this.viewVideoToolStripMenuItem.Click += new System.EventHandler(this.lvInConferenceWith_DoubleClick);
            // 
            // muteUnMuteToolStripMenuItem
            // 
            this.muteUnMuteToolStripMenuItem.Name = "muteUnMuteToolStripMenuItem";
            this.muteUnMuteToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.muteUnMuteToolStripMenuItem.Text = "Mute/Un-Mute";
            this.muteUnMuteToolStripMenuItem.Click += new System.EventHandler(this.btnMuteUnmute_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::CentralServerDemo.Properties.Resources.mute;
            this.pictureBox4.Location = new System.Drawing.Point(616, 144);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(16, 16);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox4.TabIndex = 26;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Visible = false;
            // 
            // pbOffline
            // 
            this.pbOffline.Image = global::CentralServerDemo.Properties.Resources.Offline1;
            this.pbOffline.Location = new System.Drawing.Point(594, 144);
            this.pbOffline.Name = "pbOffline";
            this.pbOffline.Size = new System.Drawing.Size(16, 16);
            this.pbOffline.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbOffline.TabIndex = 25;
            this.pbOffline.TabStop = false;
            this.pbOffline.Visible = false;
            // 
            // pbOnline
            // 
            this.pbOnline.Image = global::CentralServerDemo.Properties.Resources.Online;
            this.pbOnline.Location = new System.Drawing.Point(571, 144);
            this.pbOnline.Name = "pbOnline";
            this.pbOnline.Size = new System.Drawing.Size(16, 16);
            this.pbOnline.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbOnline.TabIndex = 24;
            this.pbOnline.TabStop = false;
            this.pbOnline.Visible = false;
            // 
            // pbSmile
            // 
            this.pbSmile.Image = ((System.Drawing.Image)(resources.GetObject("pbSmile.Image")));
            this.pbSmile.Location = new System.Drawing.Point(533, 150);
            this.pbSmile.Name = "pbSmile";
            this.pbSmile.Size = new System.Drawing.Size(18, 18);
            this.pbSmile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbSmile.TabIndex = 17;
            this.pbSmile.TabStop = false;
            this.pbSmile.Visible = false;
            // 
            // btnHelpIP
            // 
            this.btnHelpIP.Location = new System.Drawing.Point(82, 29);
            this.btnHelpIP.Name = "btnHelpIP";
            this.btnHelpIP.Size = new System.Drawing.Size(24, 23);
            this.btnHelpIP.TabIndex = 8;
            this.btnHelpIP.Text = "?";
            this.btnHelpIP.UseVisualStyleBackColor = true;
            this.btnHelpIP.Click += new System.EventHandler(this.btnHelpIP_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 456);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pbOffline);
            this.Controls.Add(this.pbOnline);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.pbSmile);
            this.Controls.Add(this.lblRoomName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.gbMyVideo);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gbContacts);
            this.Controls.Add(this.gbCentralServerMode);
            this.Controls.Add(this.groupBox4);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "C# Central Server Demo - AVSPEED, Inc.";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.gbMyVideo.ResumeLayout(false);
            this.gbMyVideo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbWebCam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.voiceActivationLevel)).EndInit();
            this.gbCentralServerMode.ResumeLayout(false);
            this.gbCentralServerMode.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.gbContacts.ResumeLayout(false);
            this.gbContacts.PerformLayout();
            this.cxFileContacts.ResumeLayout(false);
            this.cxFile.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterVolume)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoginStatus)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.cxConference.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOffline)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOnline)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSmile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
		internal System.Windows.Forms.GroupBox gbMyVideo;
		public System.Windows.Forms.GroupBox gbCentralServerMode;
		public System.Windows.Forms.Label label1;
		public System.Windows.Forms.TextBox txtCentralIp;
		public System.Windows.Forms.TextBox txtCentralPort;
		public System.Windows.Forms.Label label2;
		internal System.Windows.Forms.GroupBox GroupBox1;
		internal System.Windows.Forms.Button btnLogout;
		internal System.Windows.Forms.Button btnLogin;
		internal System.Windows.Forms.TextBox txtPassword;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.TextBox txtUserName;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Label lblLoginStatus;
		internal System.Windows.Forms.PictureBox pbLoginStatus;
		internal System.Windows.Forms.GroupBox gbContacts;
		internal System.Windows.Forms.ListView lvContact;
		internal System.Windows.Forms.ColumnHeader columnContacts;
		internal System.Windows.Forms.Button btnStartConference;
		internal System.Windows.Forms.GroupBox GroupBox2;
		internal System.Windows.Forms.ListView lvInConferenceWith;
		internal System.Windows.Forms.ColumnHeader columnContact;
		internal System.Windows.Forms.Label lblLeaveConference;
        internal System.Windows.Forms.Button btnMuteUnmute;
        private Button btnRegister;
        private Label lblRemove;
        private Label lblAdd;
        private GroupBox groupBox3;
        private PictureBox pbProfile;
        private Button btnSnapPicture;
        private ContextMenuStrip cxWebcam;
        private ComboBox cbWebcam;
        private PictureBox pbWebCam;
        private Timer timerInputLevel;
        private ProgressBar progressInput;
        private Label label5;
        private CheckBox chkVoiceActivation;
        private TrackBar voiceActivationLevel;
        private Label label6;
        private TrackBar masterVolume;
        private Button btnAudioSettings;
        private Button btnViewConferenceChat;
        private PictureBox pbSmile;
        private Button btnDeletePic;
        private Button btnJoinPrivateRoom;
        private Label label7;
        private Label lblRoomName;
        private GroupBox groupBox4;
        internal ListView lstShareFiles;
        internal ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ContextMenuStrip cxFile;
        private SaveFileDialog saveFileDlg;
        private ColumnHeader columnHeader3;
        private OpenFileDialog shareFileDlg;
        private GroupBox groupBox5;
        private Button btnSelectMovieFile;
        private OpenFileDialog movieFileDlg;
        private Label label8;
        private RadioButton rdMovieFile;
        private RadioButton rdWebcam;
        private GroupBox groupBox6;
        private ContextMenuStrip cxConference;
        private ToolStripMenuItem viewVideoToolStripMenuItem;
        private ToolStripMenuItem muteUnMuteToolStripMenuItem;
        private ToolStripMenuItem shareFileToolStripMenuItem;
        private ColumnHeader columnHeader4;
        private ContextMenuStrip cxFileContacts;
        private ToolStripMenuItem toolStripMenuItemShareFileWithContact;
        private PictureBox pictureBox1;
        private CheckBox btnScreenSharing;
        private Button btnChangePassword;
        private PictureBox pbOnline;
        private PictureBox pbOffline;
        private PictureBox pictureBox4;
        private ToolStripMenuItem sendCustomObjectTestToolStripMenuItem;
        private Button btnCheckConnection;
        private iConfServer.NET.iConfServerDotNet ics;
        private GroupBox groupBox7;
        private TextBox logBox;
        private Button btnHelpIP;

	}

} //end of root namespace