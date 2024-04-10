using RandomChatSrc.Domain.ChatDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RandomChatSrc.Services.ChatroomsManagement
{
    public class ChatroomsManagementService : IChatroomsManagementService
    {
        public List<Chat> activeChats { get; set; }
        public ChatroomsManagementService() {
            activeChats = new List<Chat>();
        }
        public Chat CreateChat(int size)
        {
            var newChat = new Chat();
            activeChats.Add(newChat);
            return newChat;
        }

        public void DeleteChat(Guid id)
        {
            foreach (Chat chat in activeChats)
            {
                //if (Guid.Parse(chat.id) == id)
                if (chat.id == id)
                {
                    activeChats.Remove(chat);
                    return;
                }
            }
        }

        public Chat GetChat()
        {
            Random random = new Random();
            int index = random.Next(activeChats.Count);
            return activeChats[index];
        }

        public MockChat getChatById(Guid id)
        {
            foreach (MockChat chat in activeChats)
            {
                if (chat.Id == id)
                {
                    return chat;
                }
            }
            throw new Exception("Chat not found");
        }

        public List<MockChat> getAllChats()
        {
            return activeChats;
        }
    }
}
