namespace MauiApp1.Model
{
    public class UsersChatsRepository : IRepository
    {
        private string usersFilePath;
        private string chatsFilePath;
        private List<User> allUsers;
        private List<Chat> allChats;

        public UsersChatsRepository(string usersFilePath, string chatsFilePath)
        {
            this.usersFilePath = usersFilePath;
            this.chatsFilePath = chatsFilePath;
            LoadUsersAndChats();
        }

        public void SortChatMessages(Chat chat)
        {
            List<Message> sortedMessages = chat.GetAllMessages().OrderBy(message => message.GetTimestamp()).ToList();
            chat.SetMessageList(sortedMessages);
        }

        private void LoadUsersAndChats()
        {
            allUsers = Utils.ReadUsersFromXml(usersFilePath);
            allChats = Utils.ReadChatsFromXml(chatsFilePath);
            foreach (Chat c in allChats)
            {
                SortChatMessages(c);
            }
        }

        private void SaveChats()
        {
            Utils.WriteChatsToXml(allChats, chatsFilePath);
        }

        public List<Chat> GetChatsByUser(int userId)
        {
            List<Chat> chats = new List<Chat>();
            foreach (Chat chat in allChats)
            {
                if (chat.SenderId == userId)
                {
                    chats.Add(chat);
                }
            }

            return chats;
        }

        public User? GetUser(int userId)
        {
            return allUsers.Find(user => user.UserId == userId);
        }

        public Chat? GetChat(int chatId)
        {
            return allChats.Find(chat => chat.ChatId == chatId);
        }

        public void AddMessageToChat(int chatId, Message messageToAdd)
        {
            Chat? chat = GetChat(chatId);
            if (chat == null)
            {
                return;
            }

            int oppositeChatId = chatId % 2 == 0 ? chatId - 1 : chatId + 1;
            Chat? oppositeChat = GetChat(oppositeChatId);
            if (oppositeChat == null)
            {
                return;
            }

            int lastId = 0;
            foreach (Message message in chat.GetAllMessages())
            {
                int messageId = message.GetMessageId();
                if (messageId > lastId)
                {
                    lastId = messageId;
                }
            }

            messageToAdd.SetMessageId(lastId + 1);
            messageToAdd.SetStatus("Sent");

            Message newMessage;

            if (messageToAdd is TextMessage)
            {
                newMessage = new TextMessage(lastId + 1, oppositeChatId, messageToAdd.GetSenderId(), messageToAdd.GetTimestamp(), "New", messageToAdd.GetMessageContent());
            }
            else if (messageToAdd is FileMessage)
            {
                newMessage = new FileMessage(lastId + 1, oppositeChatId, messageToAdd.GetSenderId(), messageToAdd.GetTimestamp(), "New", messageToAdd.GetMessageContent());
            }
            else if (messageToAdd is VoiceMessage)
            {
                newMessage = new VoiceMessage(lastId + 1, oppositeChatId, messageToAdd.GetSenderId(), messageToAdd.GetTimestamp(), "New", messageToAdd.GetMessageContent());
            }
            else if (messageToAdd is VideoMessage)
            {
                newMessage = new VideoMessage(lastId + 1, oppositeChatId, messageToAdd.GetSenderId(), messageToAdd.GetTimestamp(), "New", messageToAdd.GetMessageContent());
            }
            else
            {
                newMessage = new PhotoMessage(lastId + 1, oppositeChatId, messageToAdd.GetSenderId(), messageToAdd.GetTimestamp(), "New", messageToAdd.GetMessageContent());
            }

            chat.AddMessage(messageToAdd);
            oppositeChat.AddMessage(newMessage);
            SortChatMessages(chat);
            SortChatMessages(oppositeChat);

            SaveChats();
        }
    }
}
