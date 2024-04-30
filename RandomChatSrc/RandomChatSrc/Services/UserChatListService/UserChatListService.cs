// <copyright file="UserChatListService.cs" company="SuperBet BeClean">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
using System.Xml;
using RandomChatSrc.Domain.TextChat;
using RandomChatSrc.Services.ChatroomsManagement;

namespace RandomChatSrc.Services.UserChatListServiceDomain
{
    public class UserChatListService : IUserChatListService
    {
        private readonly ChatroomsManagementService chatroomsManagementService;
        private readonly Guid currentUserId;
        public UserChatListService(ChatroomsManagementService chatroomsManagementService)
        {
            this.chatroomsManagementService = chatroomsManagementService;
            string filePath = "D:\\School\\An 2\\Sem 2\\ISS\\UBB-SE-2024-MACROW-SOFTERs\\RandomChatSrc\\RandomChatSrc\\RepoMock\\CurrentUser.xml";
            try
            {
                XmlDocument document = new XmlDocument();
                document.Load(filePath);
                var userId = document.SelectSingleNode("/Users/CurrentUser/id").InnerText ?? throw new Exception("User not found");
                this.currentUserId = new Guid(userId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public Guid getCurrentUserGuid()
        {
            return currentUserId;
        }

        /// <summary>
        /// Retrieves a list of all open chats that the current user is a member of.
        /// </summary>
        /// <returns>A list of open chats.</returns>
        public List<TextChat> getOpenChats()
        {
            List<TextChat> openChats = chatroomsManagementService.GetAllChats();
            openChats = openChats.Where(chat => chat.participants.Any(user => user.id == currentUserId)).ToList();
            return openChats;
        }
    }
}
