namespace MauiApp1.Model
{
    public interface IRepository
    {
        void AddMessageToChat(int chatId, Message message);
        Chat? GetChat(int chatId);
        List<Chat> GetChatsByUser(int userId);
        User? GetUser(int userId);
        void SortChatMessages(Chat chat);
    }
}