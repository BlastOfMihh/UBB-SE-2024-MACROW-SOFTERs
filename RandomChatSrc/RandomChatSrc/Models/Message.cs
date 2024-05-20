// <copyright file="Message.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RandomChatSrc.Models
{
    /// <summary>
    /// Represents a message in a chat. Contains the message's identifier,
    /// the sender's identifier, the path to the text chat folder, the path to the message,
    /// the time the message was sent and the message content.
    /// </summary>
    public class Message
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Message"/> class.
        /// </summary>
        /// <param name="id">The unique identifier of the message.</param>
        /// <param name="senderId">The unique identifier of the sender.</param>
        /// <param name="textChatFolderPath">The path to the text chat folder.</param>
        /// <param name="messagePath">The path to the message.</param>
        /// <param name="sentTime">The time the message was sent.</param>
        /// <param name="content">The content of the message.</param>
        public Message(Guid id, string senderId, string textChatFolderPath, string messagePath, DateTime sentTime, string content)
        {
            this.Id = id;
            this.SenderId = senderId;
            this.ChatFolderPath = textChatFolderPath;
            this.MessagePath = messagePath;
            this.SentTime = sentTime;
            this.Content = content;
        }

        /// <summary>
        /// Gets the unique identifier of the message.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Gets the unique identifier of the sender.
        /// </summary>
        public string SenderId { get; }

        /// <summary>
        /// Gets the path to the text chat folder.
        /// </summary>
        public string ChatFolderPath { get; }

        /// <summary>
        /// Gets the path to the message.
        /// </summary>
        public string MessagePath { get; }

        /// <summary>
        /// Gets the time the message was sent.
        /// </summary>
        public DateTime SentTime { get; }

        /// <summary>
        /// Gets the content of the message.
        /// </summary>
        public string Content { get; }
    }
}