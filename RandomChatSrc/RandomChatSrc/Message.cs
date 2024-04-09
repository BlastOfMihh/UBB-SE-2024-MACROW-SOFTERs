using System;


namespace domain
{
    public class Message(int id, String textChatFolderPath, String messagePath, DateTime sentTime, String content)
    {
        private int Id { get; } = id;
        private string TextChatFolderPath { get; } = textChatFolderPath;
	private string MessagePath { get; } = messagePath;
	private DateTime SentTime { get; } = sentTime;
	private string Content { get; } = content;
    }
}
