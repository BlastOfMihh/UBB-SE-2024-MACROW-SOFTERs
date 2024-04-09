using RandomChatSrc.Domain.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomChatSrc.Services.ChatroomsManagementService
{
    public class ChatroomsManagementService : IChatroomsManagementService
    {
        public List<MockChat> activeChats { get; set; }
        public ChatroomsManagementService() {
            activeChats = new List<MockChat>();
        }
        public MockChat CreateChat(int size)
        {
            var newChat = new MockChat();
            activeChats.Add(newChat);
            return newChat;
        }

        public void DeleteChat(Guid id)
        {
            foreach( MockChat chat in activeChats)
            {
                if (chat.Id == id)
                {
                    activeChats.Remove(chat);
                    return;
                }
            }
        }

        public MockChat GetChat()
        {
            Random random = new Random();
            int index = random.Next(activeChats.Count);
            return activeChats[index];
        }
    }
}
