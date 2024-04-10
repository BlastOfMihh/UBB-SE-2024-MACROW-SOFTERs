using RandomChatSrc.Domain;
using RandomChatSrc.Domain.ChatDomain;
using RandomChatSrc.Domain.TextChat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RandomChatSrc.Services.ChatroomsManagement
{
    public class ChatroomsManagementService : IChatroomsManagementService
    {
        string messagePath = "./ChatRepo/";
        public List<TextChat> activeChats { get; set; }
        public ChatroomsManagementService() {
            activeChats = new List<TextChat>();
        }
        public TextChat CreateChat(int size)
        {
            List<Message> messages = new List<Message>();
            if(!Directory.Exists(messagePath))
            {
                Directory.CreateDirectory(messagePath);
            }
            var newChat = new TextChat(messages, messagePath);
            activeChats.Add(newChat);
            return newChat;
        }

        public void DeleteChat(Guid id)
        {
            foreach (TextChat chat in activeChats)
            {
                //if (Guid.Parse(chat.id) == id)
                if (chat.id == id)
                {
                    activeChats.Remove(chat);
                    return;
                }
            }
        }

        public TextChat GetChat()
        {
            Random random = new Random();
            int index = random.Next(activeChats.Count);
            return activeChats[index];
        }

        public TextChat getChatById(Guid id)
        {
            foreach (TextChat chat in activeChats)
            {
                if (chat.id == id)
                {
                    return chat;
                }
            }
            throw new Exception("Chat not found");
        }

        public List<TextChat> getAllChats()
        {
            return activeChats;
        }
    }
}
