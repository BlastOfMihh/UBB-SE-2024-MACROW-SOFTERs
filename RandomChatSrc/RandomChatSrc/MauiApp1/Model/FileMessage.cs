namespace MauiApp1.Model
{
    public class FileMessage : Message
    {
        private readonly string filePath;

        public FileMessage(int messageId, int chatId, int senderId, DateTime timestamp, string status, string filePath) : base(messageId, chatId, senderId, timestamp, status)
        {
            this.filePath = filePath;
        }

        public override string GetMessageContent()
        {
            return filePath;
        }
    }
}
