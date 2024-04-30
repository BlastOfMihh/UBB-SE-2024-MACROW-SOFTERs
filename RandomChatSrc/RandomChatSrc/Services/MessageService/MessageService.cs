using RandomChatSrc.Domain.TextChat;
using RandomChatSrc.Services.UserChatListServiceDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomChatSrc.Services.MessageService
{
    /// <summary>
    /// Service for sending messages to a text chat.
    /// </summary>
    internal class MessageService
    {
        private readonly TextChat _textChat;
        private readonly Guid _userId;

        /// <summary>
        /// Initializes a new instance of the MessageService class.
        /// </summary>
        /// <param name="textChat">The text chat to which messages will be sent.</param>
        /// <param name="userId">The ID of the user sending the messages.</param>
            public MessageService(TextChat textChat, Guid userId)
            {
                _textChat = textChat;
                _userId = userId;
            }

        /// <summary>
        /// Sends a message to the text chat.
        /// </summary>
        /// <param name="message">The message to send.</param>
        public void SendMessage(string message)
        {
            _textChat.AddMessage(_userId.ToString(), message);
        }
    }
}
