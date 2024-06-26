using System;


namespace RandomChatSrc.Domain
{
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
