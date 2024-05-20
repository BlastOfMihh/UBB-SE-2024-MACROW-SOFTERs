using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Model
{
    public abstract class Message
    {
        protected int messageId;
        protected int chatId;
        protected int senderId;
        protected DateTime timestamp;
        protected string status;

        public Message(int messageId, int chatId, int senderId, DateTime timestamp, string status)
        {
            this.messageId = messageId;
            this.chatId = chatId;
            this.senderId = senderId;
            this.timestamp = timestamp;
            this.status = status;
        }

        public abstract string GetMessageContent();

        public int GetMessageId()
        {
            return messageId;
        }
        public void SetMessageId(int messageId)
        {
            this.messageId = messageId;
        }
        public int GetChatId()
        {
            return chatId;
        }
        public int GetSenderId()
        {
            return senderId;
        }
        public DateTime GetTimestamp()
        {
            return timestamp;
        }
        public string GetStatus()
        {
            return status;
        }
        public void SetStatus(string status)
        {
            this.status = status;
        }
    }
}
