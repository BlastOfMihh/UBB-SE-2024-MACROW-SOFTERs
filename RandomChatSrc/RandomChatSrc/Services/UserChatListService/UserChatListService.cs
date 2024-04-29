using RandomChatSrc.Services.ChatroomsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using RandomChatSrc.Models;

namespace RandomChatSrc.Services.UserChatListServiceDomain
{
    public class UserChatListService : IUserChatListService
    {
        public ChatroomsManagementService chatroomsManagementService;
        public Guid currentUserId;
        public UserChatListService(ChatroomsManagementService chatroomsManagementService)
        {
            this.chatroomsManagementService = chatroomsManagementService;
            string filePath = "D:\\School\\An 2\\Sem 2\\ISS\\UBB-SE-2024-MACROW-SOFTERs\\RandomChatSrc\\RandomChatSrc\\RepoMock\\CurrentUser.xml";
            try {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePath);
                var userId = doc.SelectSingleNode("/Users/CurrentUser/Id").InnerText;
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

        // get a list of all chats which the User with Id 'currentUserId' is a member of.
        public List<TextChat> getOpenChats()
        {
            List<TextChat> openChats = chatroomsManagementService.getAllChats();
            openChats = openChats.Where(chat => chat.Participants.Any(user => user.Id == currentUserId)).ToList();
            return openChats;
        }
    }
}
