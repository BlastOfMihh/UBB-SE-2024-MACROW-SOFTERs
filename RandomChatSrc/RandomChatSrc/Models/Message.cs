namespace RandomChatSrc.Models
{
    /// <summary>
    /// Represents a message in a chat. Contains the message's identifier,
    /// the sender's identifier, the path to the text chat folder, the path to the message,
    /// the time the message was sent and the message content.
    /// </summary>

    public class Message(Guid id, string senderId, string textChatFolderPath, string messagePath, DateTime sentTime, string content)
    {
        private Guid Id { get; } = id;
        public string TextChatFolderPath { get; } = textChatFolderPath;
        public string MessagePath { get; } = messagePath;
        public DateTime SentTime { get; } = sentTime;
        public string Content { get; } = content;
        public string SenderId { get; } = senderId;
    }
}
