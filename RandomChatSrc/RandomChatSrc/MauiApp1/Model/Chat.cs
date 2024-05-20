using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MauiApp1.Model
{
    public class Chat
    {
        public int ChatId { get; private set; }
        public int SenderId { get; private set; }
        public int ReceiverId { get; private set; }

        private List<Message> messageList = new List<Message>();

        public Chat(int chatId, int senderId, int receiverId)
        {
            this.ChatId = chatId;
            this.SenderId = senderId;
            this.ReceiverId = receiverId;
        }

        public void AddMessage(Message newMessage)
        {
            this.messageList.Add(newMessage);
        }

        public Message GetLastMessage()
        {
            return this.messageList.Last();
        }

        public void SetMessageList(List<Message> newMessageList)
        {
            this.messageList = newMessageList;
        }

        public List<Message> GetAllMessages()
        {
            return this.messageList;
        }
    }
}
