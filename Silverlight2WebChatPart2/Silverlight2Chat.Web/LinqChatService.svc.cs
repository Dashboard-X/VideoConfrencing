﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Silverlight2Chat.Web
{
    // NOTE: If you change the class name "LinqChatService" here, you must also update the reference to "LinqChatService" in Web.config.
    public class LinqChatService : ILinqChatService
    {
        void ILinqChatService.InsertMessage(int? roomID, int userID, int? toUserID, string messageText, string color)
        {
            Message message = new Message();
            message.RoomID = roomID;
            message.UserID = userID;
            message.ToUserID = toUserID;
            message.Text = messageText;
            message.Color = color;
            message.TimeStamp = DateTime.Now;

            LinqChatDataContext db = new LinqChatDataContext();
            db.Messages.InsertOnSubmit(message);

            try
            {
                db.SubmitChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        List<MessageContract> ILinqChatService.GetMessages(int messageID, int roomID, DateTime timeUserJoined)
        {
            LinqChatDataContext db = new LinqChatDataContext();

            var messages = (from m in db.Messages
                            where m.RoomID == roomID &&
                            m.MessageID > messageID &&
                            m.TimeStamp > timeUserJoined.AddSeconds(1)
                            orderby m.TimeStamp ascending
                            select new { m.MessageID, m.Text, m.User.Username, m.TimeStamp, m.Color });

            List<MessageContract> messageContracts = new List<MessageContract>();

            foreach (var message in messages)
            {
                MessageContract messageContract = new MessageContract();
                messageContract.MessageID = message.MessageID;
                messageContract.Text = message.Text;
                messageContract.UserName = message.Username;
                messageContract.Color = message.Color;
                messageContracts.Add(messageContract);
            }

            return messageContracts;
        }

        List<MessageContract> ILinqChatService.GetPrivateMessages(DateTime timeUserSentInvitation, int messageID, int fromUserId, int toUserId)
        {
            LinqChatDataContext db = new LinqChatDataContext();

            var messages = (from m in db.Messages
                            where 
                            ((m.UserID == fromUserId && m.ToUserID == toUserId) || 
                            (m.ToUserID == fromUserId && m.UserID == toUserId)) && 
                            m.TimeStamp >= timeUserSentInvitation &&
                            m.MessageID > messageID 
                            orderby m.TimeStamp ascending
                            select new { m.MessageID, m.Text, m.User.Username, m.TimeStamp, m.Color });

            List<MessageContract> messageContracts = new List<MessageContract>();

            foreach (var message in messages)
            {
                MessageContract messageContract = new MessageContract();
                messageContract.MessageID = message.MessageID;
                messageContract.Text = message.Text;
                messageContract.UserName = message.Username;
                messageContract.Color = message.Color;
                messageContracts.Add(messageContract);
            }

            return messageContracts;
        }

        List<UserContract> ILinqChatService.GetUsers(int roomID, int userID)
        {
            LinqChatDataContext db = new LinqChatDataContext();

            // let's check if this authenticated user exist in the
            // LoggedInUser table (means user is logged-in to this room)
            var user = (from u in db.LoggedInUsers
                        where u.UserID == userID
                        && (u.RoomID == roomID || u.RoomID == null)
                        select u).FirstOrDefault();

            // if user does not exist in the LoggedInUser table
            // then let's add/insert the user to the table
            if (user == null)
            {
                LoggedInUser loggedInUser = new LoggedInUser();
                loggedInUser.UserID = userID;
                loggedInUser.RoomID = roomID;
                db.LoggedInUsers.InsertOnSubmit(loggedInUser);
                db.SubmitChanges();
            }
            else
            {
                if (user.RoomID == null)
                { 
                    // if existing user update room id only
                    user.RoomID = roomID;
                    db.SubmitChanges();
                }
            }

            // get all logged in users to this room
            var loggedInUsers = from l in db.LoggedInUsers
                                where l.RoomID == roomID 
                                orderby l.User.Username ascending
                                select new { l.User.UserID, l.User.Username };

            List<UserContract> userContracts = new List<UserContract>();

            foreach (var loggedInUser in loggedInUsers)
            {
                UserContract userContract = new UserContract();
                userContract.UserID = loggedInUser.UserID;
                userContract.UserName = loggedInUser.Username;
                userContracts.Add(userContract);
            }

            return userContracts;
        }

        int ILinqChatService.UserExist(string username, string password)
        {
            int userID = -1;

            LinqChatDataContext db = new LinqChatDataContext();

            var user = (from u in db.Users
                        where u.Username == username
                        && u.Password == password
                        select new { u.UserID }).SingleOrDefault();

            if (user != null)
                userID = user.UserID;

            return userID;
        }

        void ILinqChatService.LogInUser(int userID)
        {
            // login the user
            LinqChatDataContext db = new LinqChatDataContext();

            LoggedInUser loggedInUser = new LoggedInUser();
            loggedInUser.UserID = userID;
            db.LoggedInUsers.InsertOnSubmit(loggedInUser);
            db.SubmitChanges();
        }

        void ILinqChatService.LogOutUser(int userID, int roomID, string username)
        {
            // log out the user by deleting from the LoggedInUser table
            LinqChatDataContext db = new LinqChatDataContext();

            var loggedInUser = (from l in db.LoggedInUsers
                                where l.UserID == userID
                                && l.RoomID == roomID
                                select l).SingleOrDefault();

            db.LoggedInUsers.DeleteOnSubmit(loggedInUser);
            db.SubmitChanges();

            // insert user "left the room" text
            Message message = new Message();
            message.RoomID = roomID;
            message.UserID = userID;
            message.ToUserID = null;
            message.Text = username + " left the room.";
            message.Color = "Gray";
            message.TimeStamp = DateTime.Now;

            db.Messages.InsertOnSubmit(message);
            db.SubmitChanges();
        }

        void ILinqChatService.LeaveRoom(int userID, int roomID, string username)
        {
            // leave the room by setting room id = null
            LinqChatDataContext db = new LinqChatDataContext();

            var loggedInUser = (from l in db.LoggedInUsers
                                where l.UserID == userID
                                && l.RoomID == roomID
                                select l).SingleOrDefault();

            loggedInUser.RoomID = null;
            db.SubmitChanges();

            // insert user "left the room" text
            Message message = new Message();
            message.RoomID = roomID;
            message.UserID = userID;
            message.ToUserID = null;
            message.Text = username + " left the room.";
            message.Color = "Gray";
            message.TimeStamp = DateTime.Now;

            db.Messages.InsertOnSubmit(message);
            db.SubmitChanges();
        }
        
        List<RoomContract> ILinqChatService.GetRooms()
        {
            // get all the rooms from the database
            LinqChatDataContext db = new LinqChatDataContext();

            var rooms = from r in db.Rooms
                        select r;

            List<RoomContract> roomContracts = new List<RoomContract>();

            foreach (var room in rooms)
            {
                RoomContract roomContract = new RoomContract();
                roomContract.RoomID = room.RoomID;
                roomContract.Name = room.Name;

                roomContracts.Add(roomContract);
            }

            return roomContracts;
        }


        void ILinqChatService.InsertPrivateMessageInvite(int userID, int toUserID)
        {
            // first check if an invitation to chat has already
            // been sent to the particular user "toUserID"
            LinqChatDataContext db = new LinqChatDataContext();

            var count = (from pvtm in db.PrivateMessages
                         where pvtm.UserID == userID &&
                         pvtm.ToUserID == toUserID
                         select new { pvtm.PrivateMessageID }).Count();

            if (count == 0)
            {
                // no invitation was found
                PrivateMessage pm = new PrivateMessage();
                pm.UserID = userID;
                pm.ToUserID = toUserID;
                pm.TimeUserSentInvitation = DateTime.Now;

                db.PrivateMessages.InsertOnSubmit(pm);

                try
                {
                    db.SubmitChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            } 
        }

        List<PrivateMessageContract> ILinqChatService.GetPrivateMessageInvites(int toUserID)
        {
            List<PrivateMessageContract> pmContracts = new List<PrivateMessageContract>();
            LinqChatDataContext db = new LinqChatDataContext();
            
            var pvtMessages = from pm in db.PrivateMessages
                              where pm.ToUserID == toUserID
                              select new { pm.PrivateMessageID, pm.UserID, pm.User.Username, pm.ToUserID, pm.TimeUserSentInvitation };

            if (pvtMessages.Count() > 0)
            {
                foreach(var privateMessage in pvtMessages)
                {
                    PrivateMessageContract pmc = new PrivateMessageContract();
                    pmc.PrivateMessageID = privateMessage.PrivateMessageID;
                    pmc.UserID = privateMessage.UserID;
                    pmc.UserName = privateMessage.Username;
                    pmc.ToUserID = privateMessage.ToUserID;
                    pmc.TimeUserSentInvitation = privateMessage.TimeUserSentInvitation;

                    pmContracts.Add(pmc);
                }
            }

            return pmContracts;
        }

        void ILinqChatService.DeletePrivateMessage(int privateMessageID)
        {
            LinqChatDataContext db = new LinqChatDataContext();

            var privateMessage = from pm in db.PrivateMessages
                                 where pm.PrivateMessageID == privateMessageID
                                 select pm;

            db.PrivateMessages.DeleteAllOnSubmit(privateMessage);
            db.SubmitChanges();
        }
    }
}
