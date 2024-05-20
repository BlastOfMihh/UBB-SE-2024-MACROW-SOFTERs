namespace MauiApp1.Model
{
    public class VoiceMessage : Message
    {
        private readonly string voiceNotePath;

        public VoiceMessage(int messageId, int chatId, int senderId, DateTime timestamp, string status, string voiceNotePath) : base(messageId, chatId, senderId, timestamp, status)
        {
            this.voiceNotePath = voiceNotePath;
        }

        public override string GetMessageContent()
        {
            return voiceNotePath;
        }
    }
}
