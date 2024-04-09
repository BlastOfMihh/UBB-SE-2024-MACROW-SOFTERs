using System;


namespace domain
{
    public class Message(Guid id, int senderId, String textChatFolderPath, String messagePath, DateTime sentTime, String content)
    {
        private Guid Id { get; } = id;
        public string TextChatFolderPath { get; } = textChatFolderPath;
        public string MessagePath { get; } = messagePath;
        public DateTime SentTime { get; } = sentTime;
        public string Content { get; } = content;
        public int SenderId { get; } = senderId;
    }
}
