using RandomChatSrc.Domain.TextChat;
using RandomChatSrc.Services.UserChatListServiceDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomChatSrc.Services.MessageService
{
    internal class MessageService{
        TextChat chat;
        Guid userID;

        public MessageService(TextChat chat, Guid userID)
        {
            this.chat = chat;
            this.userID = userID;
        }
        public void SendMessage(string message)
        {
            chat.AddMessage(userID.ToString(), message);
        }
    }
}
