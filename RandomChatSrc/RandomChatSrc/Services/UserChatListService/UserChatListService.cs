// <copyright file="UserChatListService.cs" company="SuperBet BeClean">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
using System.Xml;
using RandomChatSrc.Models;
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
                XmlDocument doc = new XmlDocument();
                doc.Load(filePath);
                var userId = doc.SelectSingleNode("/Users/CurrentUser/Id").InnerText;
                if (userId == null)
                {
                    throw new Exception("User not found");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public Guid GetCurrentUserGuid()
            {
                return currentUserId;
            }

        /// <summary>
        /// Retrieves a list of all open chats that the current user is a member of.
        /// </summary>
        /// <returns>A list of open chats.</returns>
        public List<TextChat> GetOpenChats()
        {
            List<TextChat> openChats = chatroomsManagementService.GetAllChats();
            openChats = openChats.Where(chat => chat.Participants.Any(user => user.Id == currentUserId)).ToList();
            return openChats;
        }
    }
    }
