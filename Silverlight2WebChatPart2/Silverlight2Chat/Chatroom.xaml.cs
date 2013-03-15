using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows.Threading;
using System.Windows.Controls.Primitives;

namespace Silverlight2Chat
{
    public partial class Chatroom : UserControl
    {
        DispatcherTimer timer;
        private bool _isTimerStarted;
        private bool _isWithBackground = false;
        private int _lastMessageId = 0;
        private int _roomId;
        private int _userID;
        private DateTime _timeUserJoined;

        public Chatroom()
        {
            InitializeComponent();
            
            App app = (App)Application.Current;

            if (String.IsNullOrEmpty(app.UserName))
            {
                app.RedirectTo(new Login());
            }
            else
            {
                _userID = app.UserID;
                _timeUserJoined = DateTime.Now;
                _roomId = app.RoomID;
                TxtbRoomName.Text = app.RoomName;
                TxtbLoggedInUser.Text = "[ " + app.UserName + " ]";
            }
        }

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {            
            TxtMessage.Focus();
            InsertNewlyJoinedMessage();
            GetUsers();
            SetTimer();
        }

        private void GetUsers()
        {
            LinqChatReference.LinqChatServiceClient proxy = new LinqChatReference.LinqChatServiceClient();
            proxy.GetUsersCompleted += new EventHandler<Silverlight2Chat.LinqChatReference.GetUsersCompletedEventArgs>(proxy_GetUsersCompleted);
            proxy.GetUsersAsync(_roomId, _userID);
        }

    void proxy_GetUsersCompleted(object sender, Silverlight2Chat.LinqChatReference.GetUsersCompletedEventArgs e)
    {
        if (e.Error == null)
        {
            ObservableCollection<LinqChatReference.UserContract> users = e.Result;
            SpnlUserList.Children.Clear();

            foreach (var user in users)
            {
                // show the current user as a non-clickable text only
                // all other users should be hyperlinks
                App app = (App)Application.Current;

                if (user.UserID == app.UserID)
                {
                    TextBlock tb = new TextBlock();
                    tb.Text = user.UserName;
                    tb.Foreground = new SolidColorBrush(Colors.Black);
                    tb.FontWeight = FontWeights.Bold;

                    SpnlUserList.Children.Add(tb);
                }
                else
                {
                    HyperlinkButton hb = new HyperlinkButton();
                    hb.Content = user.UserName;

                    // build the absolute url
                    Uri url = System.Windows.Browser.HtmlPage.Document.DocumentUri;
                    string link = url.OriginalString;
                    int lastSlash = link.LastIndexOf('/') + 1;
                    link = link.Remove(lastSlash, link.Length - lastSlash) +
                        "Chatroom.aspx?fromuserid=" + app.UserID.ToString() +
                        "&fromusername=" + app.UserName +
                        "&touserid=" + user.UserID +
                        "&tousername=" + user.UserName +
                        "&isinvited=false";

                    // build the hyperlink
                    hb.TargetName = "_blank";
                    hb.NavigateUri = new Uri(link);

                    SpnlUserList.Children.Add(hb);
                }  
            }
        }
    }

        private void InsertNewlyJoinedMessage()
        {
            string message = "joined the room.";
            LinqChatReference.LinqChatServiceClient proxy = new LinqChatReference.LinqChatServiceClient();
            proxy.InsertMessageAsync(_roomId, _userID, null, message, "Gray");
        }

        private void SetTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 3, 0);
            timer.Tick += new EventHandler(TimerTick);
            timer.Start();

            _isTimerStarted = true;
        }

        private void InsertMessage()
        {      
            LinqChatReference.LinqChatServiceClient proxy = new LinqChatReference.LinqChatServiceClient();
            proxy.InsertMessageAsync(_roomId, _userID, null, TxtMessage.Text, CbxFontColor.SelectionBoxItem.ToString());
        }

        private void GetMessages()
        {
            LinqChatReference.LinqChatServiceClient proxy = new LinqChatReference.LinqChatServiceClient();
            proxy.GetMessagesCompleted += new EventHandler<Silverlight2Chat.LinqChatReference.GetMessagesCompletedEventArgs>(proxy_GetMessagesCompleted);
            proxy.GetMessagesAsync(_lastMessageId, _roomId, _timeUserJoined);
        }

        void proxy_GetMessagesCompleted(object sender, Silverlight2Chat.LinqChatReference.GetMessagesCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                ObservableCollection<LinqChatReference.MessageContract> messages = e.Result;

                foreach (var message in messages)
                {
                    // add a horizontal stack panel
                    StackPanel sp = new StackPanel();
                    sp.Orientation = Orientation.Horizontal;
                    sp.HorizontalAlignment = HorizontalAlignment.Left;
                    sp.Width = SpnlMessages.ActualWidth;

                    // put an alternating background
                    if (!_isWithBackground)
                        sp.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(100, 235, 235, 235));

                    // add a TextBlock to hold the user's name to the stack panel
                    TextBlock name = new TextBlock();
                    name.Text = message.UserName + ": ";
                    name.FontSize = 12.0;
                    name.FontWeight = FontWeights.Bold;
                    name.Padding = new Thickness(4, 8, 0, 8);

                    if (message.Color == "Gray")
                        name.Foreground = new SolidColorBrush(Colors.Gray);
                    else
                        name.Foreground = new SolidColorBrush(Colors.Black);

                    sp.Children.Add(name);

                    // add a TextBox to hold the user's message to the stack panel
                    TextBox text = new TextBox();
                    text.BorderBrush = new SolidColorBrush(Colors.Transparent);
                    text.FontSize = 12.0;
                    text.Text = message.Text.Trim();
                    text.VerticalAlignment = VerticalAlignment.Top;
                    text.Width = SpnlMessages.ActualWidth - name.ActualWidth;
                    text.TextWrapping = TextWrapping.Wrap;
                    text.Margin = new Thickness(0, 4, 4, 0);
                    text.IsReadOnly = true;
                    
                    // change text color based on the user's chosen color
                    if(message.Color == "Red")
                        text.Foreground = new SolidColorBrush(Colors.Red);
                    else if (message.Color == "Blue")
                        text.Foreground = new SolidColorBrush(Colors.Blue);
                    else if (message.Color == "Gray")
                        text.Foreground = new SolidColorBrush(Colors.Gray);
                    else
                        text.Foreground = new SolidColorBrush(Colors.Black);

                    // put an alternating background
                    if (!_isWithBackground)
                    {
                        text.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(100, 235, 235, 235));
                        _isWithBackground = true;
                    }
                    else
                    {
                        _isWithBackground = false;
                    }

                    sp.Children.Add(text);

                    // add the horizontal stack panel to the base stack panel
                    SpnlMessages.Children.Add(sp);

                    // remember the last message id
                    _lastMessageId = message.MessageID;
                }

                SetScrollBarToBottom();
                TxtMessage.Text = String.Empty;
                TxtMessage.Focus();
            }
        }

        private void SetScrollBarToBottom()
        {
            // set the scroll bar to the bottom
            SvwrMessages.UpdateLayout();
            SvwrMessages.ScrollToVerticalOffset(double.MaxValue);
        }

        private void TxtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SendMessage();
                timer.Start();
                _isTimerStarted = true;
            }
            else
            {
                if (_isTimerStarted)
                {
                    timer.Stop();
                    _isTimerStarted = false;
                }
            }
        }

        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            SendMessage();
        }

        private void SendMessage()
        {
            if(!String.IsNullOrEmpty(TxtMessage.Text))
            {
                InsertMessage();
                GetMessages();
                GetUsers();
            }
        }

        void TimerTick(object sender, EventArgs e)
        {
            GetMessages();
            GetUsers();
            GetPrivateMessages();
        }

        private void GetPrivateMessages()
        {
            // get the private message invitations sent to me by other chatters
            LinqChatReference.LinqChatServiceClient proxy = new LinqChatReference.LinqChatServiceClient();
            proxy.GetPrivateMessageInvitesCompleted += new EventHandler<Silverlight2Chat.LinqChatReference.GetPrivateMessageInvitesCompletedEventArgs>(proxy_GetPrivateMessageInvitesCompleted);
            proxy.GetPrivateMessageInvitesAsync(_userID);
        }

        void proxy_GetPrivateMessageInvitesCompleted(object sender, Silverlight2Chat.LinqChatReference.GetPrivateMessageInvitesCompletedEventArgs e)
        {
            ObservableCollection<LinqChatReference.PrivateMessageContract> invitations = e.Result;

            foreach (var invitation in invitations)
            {
                Popup popUp = new Popup();
                Grid grid = new Grid();
                popUp.Child = grid;
                popUp.IsOpen = true;
                popUp.Name = "PopUpInvitation" + invitation.PrivateMessageID.ToString();

                // add popup to the root grid
                LayoutRoot.Children.Add(popUp);

                grid.Width = 200;
                grid.Height = 100;
                grid.HorizontalAlignment = HorizontalAlignment.Center;

                // pop-up border
                Border border = new Border();
                border.BorderBrush = new SolidColorBrush(Colors.Black);
                border.BorderThickness = new Thickness(2);
                border.CornerRadius = new CornerRadius(8);
                border.Background = new SolidColorBrush(Colors.White);

                // pop-up text
                App app = (App)Application.Current;

                TextBlock textBlock = new TextBlock();
                textBlock.Text = app.UserName  + " wants to chat privately.";
                textBlock.HorizontalAlignment = HorizontalAlignment.Center;
                textBlock.VerticalAlignment = VerticalAlignment.Top;
                textBlock.Margin = new Thickness(8);

                // accept button - background only
                Button btnAccept = new Button();
                btnAccept.Width = 100;
                btnAccept.Height = 24;
                btnAccept.HorizontalAlignment = HorizontalAlignment.Left;
                btnAccept.VerticalAlignment = VerticalAlignment.Bottom;
                btnAccept.Margin = new Thickness(8);

                // accept hyperlink - put on top of the accept button
                HyperlinkButton hpBtn = new HyperlinkButton();
                hpBtn.Name = "HbtnChatNow" + invitation.PrivateMessageID.ToString();
                hpBtn.Width = 100;
                hpBtn.Height = 22;
                hpBtn.Content = "     Chat Now    ";
                hpBtn.Foreground = new SolidColorBrush(Colors.Green);
                hpBtn.Background = new SolidColorBrush(Colors.Transparent);
                hpBtn.HorizontalAlignment = HorizontalAlignment.Left;
                hpBtn.VerticalAlignment = VerticalAlignment.Bottom;
                hpBtn.Margin = new Thickness(8);

                // build the absolute url
                Uri url = System.Windows.Browser.HtmlPage.Document.DocumentUri;
                string link = url.OriginalString;
                int lastSlash = link.LastIndexOf('/') + 1;
                link = link.Remove(lastSlash, link.Length - lastSlash) +
                    "Chatroom.aspx?fromuserid=" + app.UserID.ToString() +
                    "&fromusername=" + app.UserName +
                    "&touserid=" + invitation.UserID +
                    "&tousername=" + invitation.UserName +
                    "&isinvited=true" +
                    "&timeusersentinvitation=" + invitation.TimeUserSentInvitation.ToString();

                // build the hyperlink
                hpBtn.TargetName = "_blank";
                hpBtn.NavigateUri = new Uri(link);
                hpBtn.Click += new RoutedEventHandler(hpBtn_Click);

                // close button
                Button btnClose = new Button();
                btnClose.Name = "BtnClose" + invitation.PrivateMessageID.ToString();
                btnClose.Width = 50;
                btnClose.Height = 24;
                btnClose.Content = "Close";
                btnClose.HorizontalAlignment = HorizontalAlignment.Right;
                btnClose.VerticalAlignment = VerticalAlignment.Bottom;
                btnClose.Margin = new Thickness(8);
                btnClose.Click += new RoutedEventHandler(btnClose_Click);

                // add to grid
                grid.Children.Add(border);
                grid.Children.Add(textBlock);
                grid.Children.Add(btnAccept);
                grid.Children.Add(hpBtn);
                grid.Children.Add(btnClose);

                // delete private message invation from database
                LinqChatReference.LinqChatServiceClient proxy = new LinqChatReference.LinqChatServiceClient();
                proxy.DeletePrivateMessageAsync(invitation.PrivateMessageID);
            }
        }

        void hpBtn_Click(object sender, RoutedEventArgs e)
        {
            // get the name of the pop-up to close
            // based from the name of the hyperlink button
            HyperlinkButton button = sender as HyperlinkButton;
            string privateMessageID = button.Name.Replace("HbtnChatNow", "");

            Popup popUp = (Popup)LayoutRoot.FindName("PopUpInvitation" + privateMessageID);
            popUp.IsOpen = false;
        }

        void btnClose_Click(object sender, RoutedEventArgs e)
        {
            // get the name of the pop-up to close
            // based from the name of the button
            Button button = sender as Button;
            string privateMessageID = button.Name.Replace("BtnClose", "");

            Popup popUp = (Popup) LayoutRoot.FindName("PopUpInvitation" + privateMessageID);
            popUp.IsOpen = false;
        }

        private void BtnLogOut_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            App app = (App)Application.Current;
            
            LinqChatReference.LinqChatServiceClient proxy = new LinqChatReference.LinqChatServiceClient();
            proxy.LogOutUserAsync(_userID, _roomId, app.UserName);  
 
            // redirect to the login page
            app.RedirectTo(new Login());
        }

        private void BtnChooseRoom_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            App app = (App)Application.Current;

            // leave the room to choose another room
            LinqChatReference.LinqChatServiceClient proxy = new LinqChatReference.LinqChatServiceClient();
            proxy.LeaveRoomAsync(_userID, _roomId, app.UserName);
            
            // redirect to the rooms page
            app.RedirectTo(new Rooms());
        }
    }
}
