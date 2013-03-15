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

namespace Silverlight2Chat
{
    public partial class Rooms : UserControl
    {
        public Rooms()
        {
            InitializeComponent();

            App app = (App)Application.Current;

            if (String.IsNullOrEmpty(app.UserName))
                app.RedirectTo(new Login());

            GetChatRooms();  
        }

        private void GetChatRooms()
        {
            LinqChatReference.LinqChatServiceClient proxy = new LinqChatReference.LinqChatServiceClient();
            proxy.GetRoomsCompleted += new EventHandler<Silverlight2Chat.LinqChatReference.GetRoomsCompletedEventArgs>(proxy_GetRoomsCompleted);
            proxy.GetRoomsAsync();
        }

        void proxy_GetRoomsCompleted(object sender, Silverlight2Chat.LinqChatReference.GetRoomsCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                ObservableCollection<LinqChatReference.RoomContract> rooms = e.Result;

                foreach (var room in rooms)
                {
                    HyperlinkButton linkButton = new HyperlinkButton();
                    linkButton.Name = room.RoomID.ToString();
                    linkButton.Content = room.Name;
                    linkButton.Click += new RoutedEventHandler(linkButton_Click);

                    SpnlRoomList.Children.Add(linkButton);
                }
            }
        }

        void linkButton_Click(object sender, RoutedEventArgs e)
        {
            HyperlinkButton linkButton = sender as HyperlinkButton;

            // assign the room 
            App app = (App)Application.Current;
            app.RoomID = Convert.ToInt32(linkButton.Name);
            app.RoomName = linkButton.Content.ToString();

            // redirect
            app.RedirectTo(new Chatroom());
        }
    }
}
