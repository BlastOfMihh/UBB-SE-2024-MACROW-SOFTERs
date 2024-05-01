// <copyright file="TextChat.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RandomChatSrc.Models
{
    using System.Xml.Linq;

    /// <summary>
    /// This class represents a text chat. It inherits from the Chat class,
    /// and contains a list of messages that have been sent in the chat.
    /// </summary>
    public class TextChat : Chat
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TextChat"/> class.
        /// </summary>
        /// <param name="messages">The initial list of messages in the chat.</param>
        /// <param name="chatFolderPath">The path to the folder where the chat is stored.</param>
        /// <param name="oldId">The ID of the chat, if it already exists.</param>
        public TextChat(List<Message> messages, string chatFolderPath, string oldId = "")
            : base()
        {
            this.Id = string.IsNullOrEmpty(oldId) ? Guid.NewGuid() : new Guid(oldId);
            this.Messages = messages;
            this.MessagesFolderPath = Path.Combine(chatFolderPath, this.Id.ToString());

            this.EnsureDirectoryExists(this.MessagesFolderPath);
            this.LoadStoredMessages();
        }

        /// <summary>
        /// Gets the list of messages in the chat.
        /// </summary>
        public List<Message> Messages { get; private set; }

        /// <summary>
        /// Gets the path to the folder where messages are stored.
        /// </summary>
        public string MessagesFolderPath { get; private set; }

        /// <summary>
        ///   Adds a new message to the chat.
        /// </summary>
        /// <param name="senderId"> The ID of the user who sent the message.</param>
        /// <param name="messageContent"> The content of the message.</param>
        public void AddMessage(string senderId, string messageContent)
        {
            var messageId = Guid.NewGuid();
            var messagePath = Path.Combine(this.MessagesFolderPath, $"message_{messageId}.xml");
            var messageTimestamp = DateTime.Now;
            var curMessage = new Message(messageId, senderId, this.MessagesFolderPath, messagePath, messageTimestamp, messageContent);
            this.Messages.Add(curMessage);

            var messageDoc = new XDocument(
                new XElement(
                    "messages",
                    new XElement(
                        "message",
                        new XElement("sender", senderId),
                        new XElement("timestamp", messageTimestamp.ToString("yyyy-MM-ddTHH:mm:ss")),
                        new XElement("content", messageContent))));
            messageDoc.Save(messagePath);
        }

        /// <summary>
        /// Loads stored messages from the file system into the Messages list.
        /// </summary>
        private void LoadStoredMessages()
        {
            var messageFiles = Directory.GetFiles(this.MessagesFolderPath);
            foreach (var messageFilePath in messageFiles)
            {
                var messageDoc = XDocument.Load(messageFilePath);

                var messageElement = messageDoc.Root?.Element("message");
                if (messageElement == null)
                {
                    continue;
                }

                var senderId = messageElement.Element("sender")?.Value;
                var timestampStr = messageElement.Element("timestamp")?.Value;
                var content = messageElement.Element("content")?.Value;

                if (string.IsNullOrEmpty(senderId) || string.IsNullOrEmpty(timestampStr) || string.IsNullOrEmpty(content))
                {
                    continue;
                }

                var timestamp = DateTime.ParseExact(timestampStr, "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                var messageId = this.ExtractMessageIdFromPath(messageFilePath);
                var curMessage = new Message(messageId, senderId, this.MessagesFolderPath, messageFilePath, timestamp, content);
                this.Messages.Add(curMessage);
            }

            this.Messages.Sort((m1, m2) => m1.SentTime.CompareTo(m2.SentTime));
        }

        /// <summary>
        /// Extracts the message ID from the file path.
        /// </summary>
        /// <param name="path">The path to the message file.</param>
        /// <returns>The ID of the message as a Guid.</returns>
        public Guid ExtractMessageIdFromPath(string path)
        {
            var filename = Path.GetFileNameWithoutExtension(path);
            var idStr = filename.Split('_').Last();
            return Guid.Parse(idStr);
        }

        /// <summary>
        /// Ensures that a directory exists at the specified path.
        /// If the directory does not exist, it is created.
        /// </summary>
        /// <param name="path">The path to the directory.</param>
        private void EnsureDirectoryExists(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
