// <copyright file="UserChatListService.cs" company="SuperBet BeClean">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace RandomChatSrc.Services.UserChatListServiceDomain
{
    using System.Xml;
    using RandomChatSrc.Models;
    using RandomChatSrc.Services.ChatroomsManagement;

    /// <summary>
    /// Service for managing the list of chats for a user.
    /// </summary>
    public class UserChatListService : IUserChatListService
    {
        private readonly ChatroomsManagementService chatroomsManagementService;
        private readonly Guid currentUserId;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserChatListService"/> class.
        /// </summary>
        /// <param name="chatroomsManagementService">The service for managing chatrooms.</param>
        public UserChatListService(ChatroomsManagementService chatroomsManagementService)
        {
            this.chatroomsManagementService = chatroomsManagementService;
            string filePath = @"/Users/mirceamaierean/UBB-SE-2024-MACROW-SOFTERs/RandomChatSrc/RandomChatSrc/RepoMock/CurrentUser.xml";
            try
            {
                XmlDocument doc = new ();
                doc.Load(filePath);

                var currentNode = doc.SelectSingleNode("/Users/CurrentUser");

                if (currentNode != null)
                {
                    var userId = currentNode.InnerText ?? throw new Exception("User not found");
                    this.currentUserId = Guid.Parse(userId);
                }
                else
                {
                    throw new Exception("User not found");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Gets the ID of the current user.
        /// </summary>
        public Guid CurrentUserId { get => this.currentUserId; }

        /// <summary>
        /// Retrieves a list of all open chats that the current user is a member of.
        /// </summary>
        /// <returns>A list of open chats.</returns>
        public List<TextChat> GetOpenChats()
        {
            List<TextChat> openChats = this.chatroomsManagementService.GetAllChats();
            openChats = openChats.Where(chat => chat.Participants.Any(user => user.Id == this.currentUserId)).ToList();
            return openChats;
        }
    }
}