using System.Xml.Linq;

namespace RandomChatSrc.Models
{
    /// <summary>
    /// This class represents a text chat. It inherits from the Chat class,
    /// and contains a list of messages that have been sent in the chat.
    /// </summary>
    public class TextChat : Chat
    {
        public List<Message> Messages { get; private set; }
        public string MessagesFolderPath { get; private set; }

        public TextChat(List<Message> messages, string chatFolderPath, string oldId = "") : base()
        {
            Id = string.IsNullOrEmpty(oldId) ? Guid.NewGuid() : new Guid(oldId);
            Messages = messages;
            MessagesFolderPath = Path.Combine(chatFolderPath, Id.ToString());

            EnsureDirectoryExists(MessagesFolderPath);
            LoadStoredMessages();
        }

        private void EnsureDirectoryExists(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public void AddMessage(string senderId, string messageContent)
        {
            var messageId = Guid.NewGuid();
            var messagePath = Path.Combine(MessagesFolderPath, $"message_{messageId}.xml");
            var messageTimestamp = DateTime.Now;
            var curMessage = new Message(messageId, senderId, MessagesFolderPath, messagePath, messageTimestamp, messageContent);
            Messages.Add(curMessage);

            var messageDoc = new XDocument(
                new XElement("messages",
                    new XElement("message",
                        new XElement("sender", senderId),
                        new XElement("timestamp", messageTimestamp.ToString("yyyy-MM-ddTHH:mm:ss")),
                        new XElement("content", messageContent))));
            messageDoc.Save(messagePath);
        }

        private void LoadStoredMessages()
        {
            var messageFiles = Directory.GetFiles(MessagesFolderPath);
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
                var messageId = ExtractMessageIdFromPath(messageFilePath);
                var curMessage = new Message(messageId, senderId, MessagesFolderPath, messageFilePath, timestamp, content);
                Messages.Add(curMessage);
            }

            Messages.Sort((m1, m2) => m1.SentTime.CompareTo(m2.SentTime));
        }

        private Guid ExtractMessageIdFromPath(string path)
        {
            var filename = Path.GetFileNameWithoutExtension(path);
            var idStr = filename.Split('_').Last();
            return Guid.Parse(idStr);
        }
    }
}
