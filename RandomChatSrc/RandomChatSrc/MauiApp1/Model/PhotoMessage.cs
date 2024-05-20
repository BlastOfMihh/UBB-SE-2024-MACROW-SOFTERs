namespace MauiApp1.Model
{
    public class PhotoMessage : Message
    {
        private readonly string photoPath;

        public PhotoMessage(int messageId, int chatId, int senderId, DateTime timestamp, string status, string photoPath) : base(messageId, chatId, senderId, timestamp, status)
        {
            this.photoPath = photoPath;
        }

        public override string GetMessageContent()
        {
            return photoPath;
        }
    }
}
