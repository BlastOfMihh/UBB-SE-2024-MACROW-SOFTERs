using RandomChatSrc.Domain;
using RandomChatSrc.Domain.ChatDomain;
using RandomChatSrc.Domain.TextChat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace RandomChatSrc.Services.ChatroomsManagement
{
    public class ChatroomsManagementService : IChatroomsManagementService
    {

        //string universalPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "\\RandomChatSrc\\RandomChatSrc\\ChatRepo\\");


        string textChatsPath = "C:\\uni\\MSGAPP\\RandomChatSrc\\RandomChatSrc\\ChatRepo\\";
        public List<TextChat> activeChats { get; set; }
        public ChatroomsManagementService(List<Chat> chats) {
            activeChats = new List<TextChat>();
            loadActiveChats();
           // if (!Directory.Exists(textChatsPath)) { 
           //     Directory.CreateDirectory(textChatsPath);
           //     XDocument chatDoc=new XDocument(
           //         new XElement("Chats", new XElement("Chat", new XElement("directoryPath")  )

           //         )
           // }
        }

        private string getIdFromPath(string folderPath)
        {
            string ans="";
            for (int i = folderPath.Length - 1; folderPath[i]!='\\' && i>=0; ++i)
            {
                ans.Append(folderPath[i]);
            }
            // for (int i=0, j= folderPath.Length - 1; i<j; ++i, --j)
            //     (ans[i], ans[j]) = (ans[j], ans[i]);
            return ans.Reverse().ToString();
        }
        private void loadActiveChats()
        {
            foreach(string chatFolderPath in Directory.GetDirectories(textChatsPath))
            {
                string foundId = this.getIdFromPath(chatFolderPath) ;
                // TextChat newTextChat = new TextChat(new List<Message>(),  this.textChatsPath, foundId);
                TextChat newTextChat = new TextChat(new List<Message>(),  this.textChatsPath); // foundId missing, dunno why
                activeChats.Add(newTextChat);
            }
        }
        public TextChat CreateChat(int size)
        {
            var newChat = new TextChat(new List<Message>(), this.textChatsPath);
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
