// C# demo for the iConf SDK .NET
// this is just a demo and should be treated as such
// questions ? contact us at support@avspeed.com
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using iConfServer.NET;
using InputBoxSample;
using System.Xml.Serialization;
using System.Xml;

namespace CentralServerDemo
{
	/// <summary>
	/// iConf SDK.NET Central Server Demo
	/// This application demonstrates the use of the iConf.NET SDK and the Central Server service
	/// to create a 'multi party' conferencing application
	/// 
	/// </summary>
	public partial class MainForm
	{

		private RegisterForm regForm;
		private FormPending pendingForm;
		private AudioDevsForm audioDevicesForm;
		private frmChat chatForm;
		private Viewer scf;


		internal MainForm()
		{
			InitializeComponent();

			regForm = new RegisterForm();
			pendingForm = new FormPending(ics);
			audioDevicesForm = new AudioDevsForm();
			chatForm = new frmChat(ics);

		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			//prep work ...

            LoadVideoDevices();
            LoadAudioDevices();

            audioDevicesForm.cbAudioInDevices.SelectedIndex = 0;
            audioDevicesForm.cbAudioOutDevices.SelectedIndex = 0;

            //select the first available device ..
            cbWebcam.SelectedIndex = 0;

            txtCentralIp.Text = "184.175.121.100"; // this is our sample central server for testing .. //ics.GetLocalIp()[0].ToString();

            ////initialize the audio system ! required
            ics.InitializeAudioSystem(iConfServerDotNet.audioType.DirectSound, -1, -1, 16000, 5);

            timerInputLevel.Enabled = true;

            masterVolume.Value = ics.GetVolume();

            ics.RemoveNoiseFromOutgoingAudio(true);
		}

		/// <summary>
		/// Loads the list of video capture devices found on the system
		/// </summary>
		private void LoadVideoDevices()
		{
		    ArrayList vdevs = ics.GetVideoDevices();

		    for (int i = 0; i < vdevs.Count; i++)
			{
				cbWebcam.Items.Add(vdevs[i].ToString());
			}
		}

	    /// <summary>
		/// Laods the list of audio devices found on the system
		/// </summary>
		private void LoadAudioDevices()
		{
			List<KeyValuePair<int, string>> inputDevs = ics.GetAudioInputDevicesList();

			foreach (KeyValuePair<int, string> de in inputDevs)
			{
				audioDevicesForm.cbAudioInDevices.Items.Add(new myComboBoxItem(de.Value, de.Key.ToString()));
			}

			List<KeyValuePair<int, string>> outputDevs = ics.GetAudioOutputDevicesList();

			foreach (KeyValuePair<int, string> de in outputDevs)
			{
				audioDevicesForm.cbAudioOutDevices.Items.Add(new myComboBoxItem(de.Value, de.Key.ToString()));
			}

		}


		private void MainForm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
		{

			//stop the video preview before closing
			ics.StopPreview();

			//if we are conneected to the central server , logout
			if (ics.IsConnectedToCentralServer)
			{
				ics.Logout();
				//give it some time to logout
				System.Threading.Thread.Sleep(2000);

				e.Cancel = false;

			}



		}

		private void btnLogin_Click(object sender, System.EventArgs e)
		{
			//login
			btnLogin.Enabled = false;
			btnLogout.Enabled = true;

			try
			{
				ics.Login(txtCentralIp.Text, Convert.ToInt32(txtCentralPort.Text), txtUserName.Text, txtPassword.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Unable to login - make sure that the Central Server Service is running and check the Port that it is listening on :\n" +
					ex.Message);
				btnLogin.Enabled = true;
				btnLogout.Enabled = false;
			}
		}

		

		/// <summary>
		/// Login response event handler
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="loginSuccess"></param>
		/// <param name="messageFromServer"></param>
		private void ics_LoginResponse(object sender, System.Boolean loginSuccess, System.String messageFromServer)
		{
			Invoke(new MethodInvoker(delegate
			{
				if (loginSuccess)
				{
					lblLoginStatus.Text = "Logged in..";

					pbLoginStatus.Image = Properties.Resources.Online;

					pbProfile.Image = ics.GetProfilePicture(txtUserName.Text);

					//get the list of contacts
					ics.GetContactList();

					this.ics.GetPendingContactRequests();
				}
				else
				{
					pbProfile.Image = null;

					btnLogin.Enabled = true;

					btnLogout.Enabled = false;


					this.lblLoginStatus.Text = "Not logged in..";

					this.pbLoginStatus.Image = CentralServerDemo.Properties.Resources.Offline;

					this.lvContact.Items.Clear();

					MessageBox.Show(messageFromServer, "Unable to login", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			));

		}

		private void btnLogout_Click(object sender, System.EventArgs e)
		{
			try
			{
				ics.Logout();
				lvInConferenceWith.Items.Clear();
				lstShareFiles.Items.Clear();
               
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

	  
		private void ProcessLogout()
		{
            try
            {
                pbProfile.Image = null;

                btnLogin.Enabled = true;

                btnLogout.Enabled = false;


                this.lblLoginStatus.Text = "Not logged in..";

                this.pbLoginStatus.Image = Properties.Resources.Offline;

                this.lvContact.Items.Clear();

                lblRoomName.Text = "";
            }
            catch ( Exception ex)
            {
                
            }
		}
		private void ics_LogoutResponse(object sender, System.Boolean logoutSuccess, System.String messageFromServer)
		{
			if (logoutSuccess)
			{
				Invoke(new MethodInvoker(ProcessLogout));
			}
		}

		public delegate void UpdateContactListDelegate(Hashtable contactList);

		public void UpdateContactList(Hashtable contactList)
		{
							


		}

		public delegate void ContactListUpdatedDelegate();

		public void ContactListUpdated()
		{

		}

		private void ics_ContactListReceived(object sender, System.Collections.Hashtable contactListHash,
											 System.String contactList)
		{
			Invoke(new MethodInvoker(delegate
			{
				this.lvContact.Items.Clear();

				foreach (DictionaryEntry de in contactListHash)
				{
					ListViewItem contactItem = new ListViewItem(de.Key.ToString());

					if (de.Value.ToString() == "NLN")
					{
						contactItem.ForeColor = Color.Green;
					}
					else
					{
						contactItem.ForeColor = Color.Gray;
					}


					lvContact.Items.Add(contactItem);
					lvContact.Invalidate();
					lvContact.Refresh();

					Invoke(new ContactListUpdatedDelegate(ContactListUpdated), null);

				}

			}
			));

		}



		private void ics_ContactStatusChanged(object sender, System.String contactUserName, System.String newStatusCode)
		{
			Invoke(new MethodInvoker(delegate
			{
				if (newStatusCode == "NLN")
				{
					this.lvContact.FindItemWithText(contactUserName).ForeColor = Color.Green;

				}
				else
				{
					this.lvContact.FindItemWithText(contactUserName).ForeColor = Color.Gray;

				}
			}
			));

		}

		private void btnStartConference_Click(object sender, System.EventArgs e)
		{
			if (lvContact.SelectedItems.Count != 0)
			{

				ArrayList usersToInvite = new ArrayList();

				foreach (ListViewItem item in lvContact.SelectedItems)
				{
					usersToInvite.Add(item.Text);
				}

				ics.StartConference(usersToInvite);
			}
		}

		

		private void ics_ConferenceRequest(object sender, System.String leader, System.Collections.ArrayList otherUsers,
										   System.String otherUsersStr, System.String conferenceId)
		{
			Invoke(new MethodInvoker(delegate
			{
				if (MessageBox.Show("Would you like to accept a conference request from " + leader + "?", "Confirm",
							   MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==  System.Windows.Forms.DialogResult.Yes)
				{
					ics.JoinConference(conferenceId);
				}
				else ics.RejectConferenceRequest(leader, "No reason");
			}
			));
		}

		

		private void ics_UserJoinedConference(object sender, System.String userName)
		{
			Invoke(new MethodInvoker(delegate
			{
				ListViewItem confUser = new ListViewItem();
				confUser.Text = userName;
				confUser.Tag = 0;

				this.lvInConferenceWith.Items.Add(userName);
			}
			));
		}

		private void lblLeaveConference_Click(object sender, System.EventArgs e)
		{
			lstShareFiles.Clear();
			ics.LeaveConference();
			lvInConferenceWith.Items.Clear();

		}

		

		private void ics_UserLeftConference(object sender, System.String userName)
		{
			Invoke(new MethodInvoker(delegate
			{
				this.lvInConferenceWith.FindItemWithText(userName).Remove();

				for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
				{
					if (Application.OpenForms[i].Tag != null)
					{
						if (Application.OpenForms[i].Tag.ToString() == userName)
						{
							Application.OpenForms[i].Close();
							return;
						}
					}
				}
			}
			));
		}


		private void btnMuteUnmute_Click(object sender, System.EventArgs e)
		{
			if (lvInConferenceWith.SelectedItems.Count > 0)
			{
				ListViewItem lvit = lvInConferenceWith.SelectedItems[0];

				if (Convert.ToInt32(lvit.Tag) == 0)
				{
					ics.MuteContactInConference(lvit.Text, true);
					lvit.Tag = 1;

				}
				else
				{
					ics.MuteContactInConference(lvit.Text, false);
					lvit.Tag = 0;

					lvInConferenceWith.Invalidate();
					lvInConferenceWith.Refresh();
				}


			}

		}

		private void lvInConferenceWith_DoubleClick(object sender, System.EventArgs e)
		{
			//view selected user
			string selectedUser = null;

			if (lvInConferenceWith.SelectedItems.Count <= 0)
			{
				return;

			}

			selectedUser = lvInConferenceWith.SelectedItems[0].Text;

			ics.ViewUser(selectedUser);

		}

		private void ics_ViewUserResponseReceived(object sender, System.String userName, System.Int32 port,
												  System.Int32 videoWidth, System.Int32 videoHeight,
												  System.String videoCodec)
		{
			Invoke(new MethodInvoker(delegate
			{
				//check to see if we are already viewing that user
				//if so bring form in front
				for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
				{
					if (Application.OpenForms[i].Tag != null)
					{
						if (Application.OpenForms[i].Tag.ToString() == userName)
						{
							Application.OpenForms[i].BringToFront();
							return;
						}
					}
				}

				ClientForm client = null;

				client = new ClientForm();


				client.Tag = userName;

				client.Text = "Viewing > " + userName;

				client.Show();

				client.icc.Call(txtCentralIp.Text, port, videoWidth, videoHeight, "n/a", "n/a", "n/a", 0, 0, 0, videoCodec);
			}
			));

		}

		private void ics_DisconnectedFromCentralServer(object sender)
		{
			Invoke(new MethodInvoker(ProcessLogout));    
		}

		private void lblLoginStatus_Click(object sender, EventArgs e)
		{

		}

		private void btnRegister_Click(object sender, EventArgs e)
		{
			try
			{


				if (regForm.ShowDialog() == DialogResult.OK)
				{
					string userName = regForm.txtUserName.Text;
					string password = regForm.txtPassword.Text;
					string note = regForm.txtNote.Text.Trim();
					if (note == String.Empty)
					{
						note = "N/A";
					}

					string centralIp = txtCentralIp.Text;
					int centralPort = Convert.ToInt32(txtCentralPort.Text);

					ics.RegisterUser(centralIp, centralPort, userName, password, note);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}


		/// <summary>
		/// Registration response event handler
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="registrationSuccess"></param>
		/// <param name="messageFromServer"></param>
		private void ics_RegistrationResponse(object sender, bool registrationSuccess, string messageFromServer)
		{
			Invoke(new MethodInvoker(delegate
			{
				if (registrationSuccess)
				{
					txtUserName.Text = regForm.txtUserName.Text;
					txtPassword.Text = regForm.txtPassword.Text;

					MessageBox.Show("User successfully registered, please login", "Success", MessageBoxButtons.OK,
									MessageBoxIcon.Information);

				}
				else
				{
					MessageBox.Show("Unable to register user : " + messageFromServer, "Error", MessageBoxButtons.OK,
									MessageBoxIcon.Error);
				}
			}
			));

		}

		private void txtUserName_Enter(object sender, EventArgs e)
		{
			((TextBox) sender).SelectAll();
		}

		private void lblAdd_Click(object sender, EventArgs e)
		{
			try
			{
				var contactForm = new ContactForm();
				if (contactForm.ShowDialog() == DialogResult.OK)
				{
					if (contactForm.txtContactToAdd.Text.Trim() != String.Empty)
						ics.AddUserAsContact(contactForm.txtContactToAdd.Text);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

	 


		private void ics_AddContactRequestResponse(object sender, bool addContactSuccess, string messageFromServer)
		{
			Invoke(new MethodInvoker(delegate
			{
				if (addContactSuccess)
				{
					ics.GetContactList();
				}
				else
				{
					MessageBox.Show(messageFromServer, "Unable to add contact", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
			));
		}

		public delegate void NewContactRequestDelegate(string fromUser);

		private void NewContactRequest(string fromUser)
		{
				
		}

		private void ics_NewContactRequest(object sender, string fromuser)
		{
			Invoke(new MethodInvoker(delegate
			{
				if (MessageBox.Show("New contact request from " + fromuser, "Contact Request", MessageBoxButtons.YesNo,
								MessageBoxIcon.Question) == DialogResult.Yes)
				{
					ics.AcceptContactRequest(fromuser);
				}

			}
			));

		}

		private void lblRemove_Click(object sender, EventArgs e)
		{
			try
			{
				if (lvContact.SelectedItems.Count > 0)
					ics.RemoveContact(lvContact.SelectedItems[0].Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		
		private void ics_PendingContactRequest(object sender, Hashtable contactsHash, string contacts)
		{
			Invoke(new MethodInvoker(delegate
			{
				if (contactsHash.Count > 0)
				{
					this.pendingForm.lstPending.Items.Clear();

					foreach (DictionaryEntry de in contactsHash)
					{
						pendingForm.lstPending.Items.Add(de.Value.ToString());
					}
					pendingForm.Show();
				}
			}
			));
		}

		private void btnSnapPicture_Click(object sender, EventArgs e)
		{
			try
			{
				if (ics.IsConnectedToCentralServer)
					ics.UpdateProfilePicture();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void ics_ProfilePictureUpdated()
		{
			Invoke(new MethodInvoker(delegate
			{
				this.pbProfile.Image = this.ics.GetProfilePicture(txtUserName.Text);
			}
			));
			
		}

		
		private void ics_RemoveContactResponse(object sender, string messageFromServer, bool removalSuccess,
											   string userToRemove)
		{
			Invoke(new MethodInvoker(delegate
			{
				if (removalSuccess)
				{
					lvContact.Items.Remove(this.lvContact.FindItemWithText(userToRemove));
				}
				else
				{
					MessageBox.Show("Contact could not be removed " + messageFromServer, "Error", MessageBoxButtons.OK,
									MessageBoxIcon.Error);
				}
			}
			));

		}


		private void cbWebcam_SelectedIndexChanged(object sender, EventArgs e)
		{
			ics.SelectVideoDevice(cbWebcam.SelectedIndex);

			ics.StartPreview(0);

		}

		private void timerInputLevel_Tick(object sender, EventArgs e)
		{
			progressInput.Value = ics.GetAudioInputLevel();
		}

		private void chkVoiceActivation_CheckedChanged(object sender, EventArgs e)
		{
			if (chkVoiceActivation.Checked)
			{
				ics.StopTransmittingAudio();

				ics.EnableVoiceActivation(true);

				ics.SetVoiceActivationLevel(voiceActivationLevel.Value);
			}
			else
			{
				ics.EnableVoiceActivation(false);

				ics.StartTransmittingAudio();

			}
		}

		private void voiceActivationLevel_ValueChanged(object sender, EventArgs e)
		{
			if (chkVoiceActivation.Checked)
				ics.SetVoiceActivationLevel(voiceActivationLevel.Value);
		}

		private void masterVolume_ValueChanged(object sender, EventArgs e)
		{
			ics.SetVolume(masterVolume.Value);
		}

		private void btnAudioSettings_Click(object sender, EventArgs e)
		{
			if (audioDevicesForm.ShowDialog() == DialogResult.OK)
			{
				myComboBoxItem objInDevice = (myComboBoxItem) audioDevicesForm.cbAudioInDevices.SelectedItem;

				myComboBoxItem objOutDevice = (myComboBoxItem) audioDevicesForm.cbAudioOutDevices.SelectedItem;

				ics.ReconfigureAudioSystem(iConfServer.NET.iConfServerDotNet.audioType.DirectSound,
										   Convert.ToInt32(objInDevice.ItemData), Convert.ToInt32(objOutDevice.ItemData));
			}
		}

		private void btnViewConferenceChat_Click(object sender, EventArgs e)
		{
            chatForm.Show();
            chatForm.BringToFront();
		}

		private void ics_ConferenceMessageReceived(object sender, string messageReceived, string fromUser)
		{
			Invoke(new MethodInvoker(delegate
			{
				var _rtBox = new ExRichTextBox();
				int _index;


				_rtBox.AppendTextAsRtf(fromUser + " Says\n",
									   new Font(this.Font, FontStyle.Bold), RtfColor.Blue);
				_rtBox.AppendTextAsRtf(messageReceived, new Font(this.Font, FontStyle.Bold), RtfColor.Gray);
				if ((_index = _rtBox.Find(":)")) > -1)
				{
					_rtBox.Select(_index, ":)".Length);
					_rtBox.InsertImage(pbSmile.Image);
				}
				chatForm.rtBox.AppendRtf(_rtBox.Rtf);
				// Scroll to bottom so newly added text is seen.
				chatForm.rtBox.Select(chatForm.rtBox.TextLength, 0);
				chatForm.rtBox.ScrollToCaret();

				// Return focus to message text box
				chatForm.txtSendMessage.Focus();
			}
			));
			
		}


	   

		private void ics_ConferenceRequestRejected(string rejectedByUser, string reasonsForRejection)
		{
			Invoke(new MethodInvoker(delegate
			{
				MessageBox.Show(rejectedByUser + " has rejected our conference request", "Conference request rejected",
						   MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			));
			

		}

		private void btnDeletePic_Click(object sender, EventArgs e)
		{
			///delete the profile picture from the server
			if (ics.IsConnectedToCentralServer)
				ics.DeleteProfilePicture();
		}

		private void btnJoinPrivateRoom_Click(object sender, EventArgs e)
		{
			InputBoxResult result = InputBox.Show("Room name:", "Enter room name", "", null);

			if (result == null)
				return;

			InputBoxResult result2 = InputBox.Show("Password:", "Enter Password", "", null);

			if (result2 == null)
				return;

			string password = result2.Text.Trim();

			if (result.OK)
			{
				if (result.Text.Trim() != "")
					//Use JoinConferenceRoom to join a private room
					// if the room does not exist it gets created.
					// If the room already exist, you will join it
					// and the UserJoinedConference event will be fired
					// for each user that is presnet in the room

					ics.JoinConferenceRoom(result.Text, password);
			}
		}

		public delegate void ProcessJoinedConferenceRoomDelegate(string roomName);

		private void ProcessJoinedConferenceRoom(string roomName)
		{
			lblRoomName.Text = roomName;
		}

		private void ics_JoinedConferenceRoom(string roomName)
		{
			Invoke(new ProcessJoinedConferenceRoomDelegate(ProcessJoinedConferenceRoom), new object[] {roomName});

		}


		private void btnSelectMovieFile_Click(object sender, EventArgs e)
		{
			if (movieFileDlg.ShowDialog() == DialogResult.OK)
			{
				ics.SelectVideoFileAsVideoSource(movieFileDlg.FileName);
			}
		}

		private void rdWebcam_CheckedChanged(object sender, EventArgs e)
		{
			if (rdWebcam.Checked)
			{
				ics.SelectVideoCaptureDeviceAsVideoSource();

				ics.SelectVideoDevice(cbWebcam.SelectedIndex);

				//h264

				//mpeg4
				//ics.SetEncoderProperties("MPEG4", 100, 128000, 0, 0, 0, 352, 288);

				//h.263
				//ics.SetEncoderProperties(iConfServer.NET.iConfServerDotNet.H263, 200, 2000, 0, 0, 0, 352, 288);

				//starts the video preview using the default preview size
				ics.StartPreview(cbWebcam.SelectedIndex);
			}
			else
			{
				btnSelectMovieFile_Click(null, null);
			}
		}

		private void shareFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (lvInConferenceWith.SelectedItems.Count > 0)
			{
				if (shareFileDlg.ShowDialog() == DialogResult.OK)
				{
					string fileId = ics.ShareFile(shareFileDlg.FileName);
					ics.SendShareFileRequest(fileId, lvInConferenceWith.SelectedItems[0].Text);
				}
			}
		}

		public delegate void ProcessFileShareRequestDelegate(
			string fileId, string fromuser, string filename, long fileSize);

		private void ProcessFileShareRequest(string fileId, string fromuser, string filename, long fileSize)
		{
			string message = string.Empty;

			message = fromuser + " is sharing a file with you\n\n";
			message += " Filename : " + filename + "\n";
			message += "Size : " + GetHumanReadableFileSize(fileSize) + "\n\n";
			message += "Would you like to accept ?\n";

			if (MessageBox.Show(message, @"File sharing request", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
				DialogResult.Yes)
			{
				saveFileDlg.FileName = filename;

				if (saveFileDlg.ShowDialog() == DialogResult.OK)
				{
					ListViewItem lvi = new ListViewItem();
					lvi.Text = saveFileDlg.FileName;
					lvi.Tag = fileId;
					lvi.SubItems.Add(GetHumanReadableFileSize(fileSize));
					lvi.SubItems.Add("0");
					lvi.SubItems.Add("Pending");
					lstShareFiles.Items.Add(lvi);
					ics.GetFile(fileId, filename, saveFileDlg.FileName);
				}
			}
		}

		private void ics_NewFileShareRequest(string fileId, string fromuser, string filename, long fileSize)
		{
			Invoke(new ProcessFileShareRequestDelegate(ProcessFileShareRequest),
				   new object[] {fileId, fromuser, filename, fileSize});

		}

		/// <summary>
		///     Convert bytes to a human readable format
		/// </summary>
		/// <param name="fileSize">the number bytes</param>
		/// <returns>apropriate amount of bytes (Gb, Mb, Kb, bytes)</returns>
		private string GetHumanReadableFileSize(long fileSize)
		{
			#region Gb

			if ((fileSize/(1024*1024*1024)) > 0)
			{

				return String.Format("{0} Gb", (double) Math.Round((double) (fileSize/(1024*1024*1024)), 2));
			}

			#endregion

			#region Mb

			if ((fileSize/(1024*1024)) > 0)
			{
				return String.Format("{0} Mb", (double) Math.Round((double) (fileSize/(1024*1024)), 2));
			}

			#endregion

			#region Kb

			if ((fileSize/1024) > 0)
			{
				return String.Format("{0} Kb", (double) Math.Round((double) (fileSize/1024), 2));
			}

			#endregion

			#region Bytes

			return String.Format("{0} b", fileSize);

			#endregion
		}

		private void ics_FileDownloadProgress(string fileId, string originalFileName, string saveFileTo,
											  int progressPercentage, long bytesReceived, long totalBytesToReceive)
		{
			lstShareFiles.FindItemWithText(saveFileTo).SubItems[2].Text = GetHumanReadableFileSize(bytesReceived);

		}

		private void ics_FileDownloadCompleted(string fileId, string originalFileName, string saveFileTo)
		{
			lstShareFiles.FindItemWithText(saveFileTo).SubItems[3].Text = "Downloaded";
			lstShareFiles.FindItemWithText(saveFileTo).SubItems[3].ForeColor = Color.Green;
		}

		private void toolStripMenuItemShareFileWithContact_Click(object sender, EventArgs e)
		{
			if (lvContact.SelectedItems.Count > 0)
			{
				if (shareFileDlg.ShowDialog() == DialogResult.OK)
				{
					string fileId = ics.ShareFile(shareFileDlg.FileName);
					ics.SendShareFileRequest(fileId, lvContact.SelectedItems[0].Text);
				}
			}
		}

		private void lstShareFiles_DoubleClick(object sender, EventArgs e)
		{
			if (lstShareFiles.SelectedItems.Count > 0)
			{
				if (lstShareFiles.SelectedItems[0].SubItems[3].Text == "Downloaded")
				{
					Process.Start(lstShareFiles.SelectedItems[0].Text);
				}
			}
		}




		public delegate void ViewScreenDelegate(string keyToConnect, string fromUser);

		private void ViewScreen(string keyToConnect, string fromUser)
		{
            if (scf == null)
            {

                scf = new Viewer(ics);
                scf.Tag = keyToConnect;
                scf.Text = fromUser;
                scf.Show();
                scf.timer1.Enabled = true;
            }
            else scf.Show();    	
		}


		private void ics_ScreenSharingSessionAvailable(string fromUser, string keyToConnect)
		{
			if (
				MessageBox.Show(fromUser + " would like to invite you to a screen sharing session\n Accept?",
								"Screen sharing invitation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
				System.Windows.Forms.DialogResult.Yes)
				Invoke(new ViewScreenDelegate(ViewScreen), new object[] {keyToConnect, fromUser});
		}

		private void btnScreenShare_Click(object sender, EventArgs e)
		{




		}

		public delegate void ReadyToShareScreenDelegate();

		private void ReadyToShareScreen()
		{

		}

		private void ics_ReadyToShareScreen()
		{
			Invoke(new ReadyToShareScreenDelegate(ReadyToShareScreen), null);
		}

		public delegate void ScreenControlRequestedDelegate(bool accept, string toUser);

		private void ScreenControlRequested(bool accept, string toUser)
		{
			ics.GrantScreenControl(toUser);
		}

		

		private void btnScreenSharing_CheckedChanged(object sender, EventArgs e)
		{
			if (btnScreenSharing.Checked)
			{
				if (lvInConferenceWith.SelectedItems.Count == 0)
				{
					MessageBox.Show(
						@"Please select 1 or more users that are in a conference wih you, to share the screen with.");
					return;
				}

				ics.StartScreenSharing(iConfServerDotNet.DesktopSharingType.Full);

				var usersToInvite = new List<string>();

				foreach (ListViewItem item in lvInConferenceWith.SelectedItems)
				{
					usersToInvite.Add(item.Text);
				}

				//usersToInvite.Add("user1");

				ics.InviteUsersToViewScreen(usersToInvite);

				btnScreenSharing.Text = "Sharing Screen";
				btnScreenSharing.BackColor = Color.LimeGreen;
			}
			else
			{
				ics.StopScreenSharing();
				btnScreenSharing.Text = "Share Screen";
				btnScreenSharing.BackColor = Control.DefaultBackColor;
			}
		}

		private void ics_ChangePasswordReponse(string response, bool success)
		{
			if (success)
			{
				MessageBox.Show("Your password was successfully changed", "Success", MessageBoxButtons.OK,
								MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show("Error changing password " + response, "Error", MessageBoxButtons.OK,
								MessageBoxIcon.Error);
			}
		}

		private void btnChangePassword_Click(object sender, EventArgs e)
		{
			ChangePasswordForm frmChangePassword = new ChangePasswordForm();
			if (frmChangePassword.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				string oldpass = frmChangePassword.txtOldPass.Text;
				string newpass = frmChangePassword.txtNewPass.Text;

				if ((oldpass.Trim() != string.Empty) && (newpass.Trim() != string.Empty))
					ics.ChangePassword(oldpass, newpass);
				else
					MessageBox.Show("Unable to change password .. old or new password is blank", "Error",
									MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnChangeStatusMessage_Click(object sender, EventArgs e)
		{
			InputBoxResult result = InputBox.Show("Status message ?", "Enter status message", "", null);

			if (result == null)
				return;

			if (result.OK)
				ics.SetStatusMessage(result.Text);
		}

		private void ics_ContactStatusMessageChanged(string contactUserName, string newStatusMessage)
		{
			MessageBox.Show(contactUserName + " : " + newStatusMessage);
		}



		private void ics_VideoPreviewStarted(int videoWidth, int videoHeight, string deviceName)
		{
            //set up codec properties
			ics.SetEncoderProperties(iConfServerDotNet.MPEG4, 100, 6400, 0, 0, 0, videoWidth,
									 videoHeight, 30);
		}

		private void ics_Talking(string userName, bool talking)
		{

		}

		private void sendCustomObjectTestToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var p = new Person();
			p.Name = "Fred";

			XmlSerializer ser = new XmlSerializer(p.GetType());
			var sb = new System.Text.StringBuilder();
			var writer = new System.IO.StringWriter(sb);
			ser.Serialize(writer, p);

			var toUser = new ArrayList();
			toUser.Add(lvInConferenceWith.SelectedItems[0].Text);

			ics.SendCustomObject(sb.ToString(), toUser);


		}

		private void ics_CustomObjectReceived(string fromuser, string customobject)
		{
			var doc = new XmlDocument();
			doc.LoadXml(customobject);
			var reader = new XmlNodeReader(doc.DocumentElement);
			var ser = new XmlSerializer(typeof (Person));
			object obj = ser.Deserialize(reader);
			// Then you just need to cast obj into whatever type it is eg:
			var personReceived = (Person) obj;
			MessageBox.Show("Received => " + personReceived.Name);

		}


		

        private void btnCheckConnection_Click(object sender, EventArgs e)
        {
            bool isConnected = ics.IsConnectedToCentralServer;

            MessageBox.Show("IsConnectedToCentralServer returned " + isConnected.ToString(), "info");
        }

        private void ics_Log(string logMessage)
        {
            logBox.AppendText(Environment.NewLine + "> " + logMessage);

            logBox.SelectionStart = logBox.Text.Length;
            logBox.ScrollToCaret();
        }


	    private void ics_ConferencePrivateMessageReceived(string messagereceived, string fromuser)
	    {
            //handle here
	       // throw new NotImplementedException();
	    }

        private void btnHelpIP_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is the IP Address of the computer where your central server service is running..",
                            "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
	}

	class myComboBoxItem
	{
		protected string strText;
		protected string strItemData;
		protected string strItemData2;
		protected string strDispalyValue;

		//Adding only the visible text.
		public myComboBoxItem(string strTextToAdd)
		{
			strText = strTextToAdd;
			strDispalyValue = strTextToAdd;
			strItemData = "0";
		}
		//Adding the text and ItemData
		public myComboBoxItem(string strTextToAdd, string strItemDataToAdd)
		{
			strText = strTextToAdd;
			strItemData = strItemDataToAdd;
			strDispalyValue = strTextToAdd;
		}
		//Adding the text and ItemData
		public myComboBoxItem(string strTextToAdd, string strItemDataToAdd, string strItemDataToAdd2)
		{
			strText = strTextToAdd;
			strItemData = strItemDataToAdd;
			strItemData2 = strItemDataToAdd2;
			strDispalyValue = strTextToAdd;
		}

		public string ItemData
		{
			get { return strItemData; }
			set { strItemData = value; }
		}

		public string ItemData2
		{
			get { return strItemData2; }
			set { strItemData2 = value; }
		}

		public string DisplayValue
		{
			get { return strDispalyValue; }
			set { strDispalyValue = value; }
		}
		//This is text that will be added in to the ComboBox (display to user)
		public override string ToString()
		{
			return strText;
		}

	}

} //end of root namespace