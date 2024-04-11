using RandomChatSrc.Domain.ChatDomain;
using RandomChatSrc.Domain.TextChat;
using RandomChatSrc.Services.ChatroomsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RandomChatSrc.Services.UserChatListService
{
    public class UserChatListService : IUserChatListService
    {
        public ChatroomsManagementService chatroomsManagementService;
        public Guid currentUserId;
        public UserChatListService(ChatroomsManagementService chatroomsManagementService)
        {
            this.chatroomsManagementService = chatroomsManagementService;
            string filePath = "C:\\Users\\RichardToth\\Projects\\UBB-ISS\\RandomChatSrc\\RandomChatSrc\\RepoMock\\CurrentUser.xml";
            try {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePath);
                var userId = doc.SelectSingleNode("/Users/CurrentUser/id").InnerText;
                if(userId == null)
                {
                    throw new Exception("User not found");
                }
                this.currentUserId = new Guid(userId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public List<TextChat> getOpenChats()
        {
            List<TextChat> openChats = chatroomsManagementService.getAllChats();
            openChats = openChats.Where(chat => chat.participants.Any(user => user.id == currentUserId)).ToList();
            return openChats;
        }
    }
}
