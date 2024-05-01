// <copyright file="MessageService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RandomChatSrc.Services.MessageService
{
    using System;
    using RandomChatSrc.Models;

    /// <summary>
    /// Service for sending messages to a text chat.
    /// </summary>
    public class MessageService
    {
        private readonly TextChat textChat;
        private readonly Guid userId;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageService"/> class.
        /// </summary>
        /// <param name="textChat">The text chat to which messages will be sent.</param>
        /// <param name="userId">The ID of the user sending the messages.</param>
        public MessageService(TextChat textChat, Guid userId)
        {
            this.textChat = textChat;
            this.userId = userId;
        }

        /// <summary>
        /// Sends a message to the text chat.
        /// </summary>
        /// <param name="message">The message to send.</param>
        public void SendMessage(string message)
        {
            this.textChat.AddMessage(this.userId.ToString(), message);
        }

        /// <summary>
        /// Gets the text chat to which messages are sent.
        /// </summary>
        /// <returns>The text chat.</returns>
        public TextChat GetTextChat()
        {
            return this.textChat;
        }
    }
}
