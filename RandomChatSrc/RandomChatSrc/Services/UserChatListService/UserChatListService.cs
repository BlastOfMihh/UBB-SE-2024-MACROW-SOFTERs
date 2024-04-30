using RandomChatSrc.Domain.ChatDomain;
using RandomChatSrc.Domain.TextChat;
using RandomChatSrc.Services.ChatroomsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RandomChatSrc.Services.UserChatListServiceDomain
{
    public class UserChatListService : IUserChatListService
    {
        private readonly ChatroomsManagementService _chatroomsManagementService;
        private readonly Guid _currentUserId;
        public UserChatListService(ChatroomsManagementService chatroomsManagementService)
        {
            this._chatroomsManagementService = chatroomsManagementService;
            string filePath = "D:\\School\\An 2\\Sem 2\\ISS\\UBB-SE-2024-MACROW-SOFTERs\\RandomChatSrc\\RandomChatSrc\\RepoMock\\CurrentUser.xml";
            try {
                XmlDocument document = new XmlDocument();
                document.Load(filePath);
                var userId = document.SelectSingleNode("/Users/CurrentUser/id").InnerText;
                if(userId == null)
                {
                    throw new Exception("User not found");
                }
                this._currentUserId = new Guid(userId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public Guid getCurrentUserGuid()
        {
            return _currentUserId;
        }
        /// <summary>
        /// Retrieves a list of all open chats that the current user is a member of.
        /// </summary>
        /// <returns>A list of open chats.</returns>
        public List<TextChat> getOpenChats()
        {
            List<TextChat> openChats = _chatroomsManagementService.getAllChats();
            openChats = openChats.Where(chat => chat.participants.Any(user => user.id == _currentUserId)).ToList();
            return openChats;
        }
    }
}
