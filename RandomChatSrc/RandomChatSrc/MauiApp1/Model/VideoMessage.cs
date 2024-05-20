namespace MauiApp1.Model
{
    public class VideoMessage : Message
    {
        private readonly string videoPath;

        public VideoMessage(int messageId, int chatId, int senderId, DateTime timestamp, string status, string videoPath) : base(messageId, chatId, senderId, timestamp, status)
        {
            this.videoPath = videoPath;
        }

        public override string GetMessageContent()
        {
            return videoPath;
        }
    }
}
