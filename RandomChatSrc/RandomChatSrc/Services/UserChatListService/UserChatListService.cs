// <copyright file="UserChatListService.cs" company="SuperBet BeClean">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace RandomChatSrc.Services.UserChatListService
{
    using System.Xml;
    using RandomChatSrc.Models;
    using RandomChatSrc.Services.ChatroomsManagement;

    /// <summary>
    /// Service for managing the list of chats for a user.
    /// </summary>
    public class UserChatListService : IUserChatListService
    {
        private readonly IChatroomsManagementService chatroomsManagementService;
        private Guid currentUserId;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserChatListService"/> class.
        /// </summary>
        /// <param name="chatroomsManagementService">The service for managing chatrooms.</param>
        public UserChatListService(IChatroomsManagementService chatroomsManagementService, string fileName = @"/Users/mirceamaierean/UBB-SE-2024-MACROW-SOFTERs/RandomChatSrc/RandomChatSrc/RepoMock/CurrentUser.xml")
        {
            this.chatroomsManagementService = chatroomsManagementService;
            string filePath = fileName;
            try
            {
                XmlDocument doc = new ();
                doc.Load(filePath);

                var currentNode = doc.SelectSingleNode("/Users/CurrentUser");

                if (currentNode != null)
                {
                    var userIdNode = currentNode.SelectSingleNode("Id");
                    if (userIdNode != null)
                    {
                        var userId = userIdNode.InnerText ?? throw new Exception("User not found");
                        this.currentUserId = Guid.Parse(userId);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public UserChatListService()
        {
            // parameterless Constructor
        }

        /// <summary>
        /// Gets the ID of the current user.
        /// </summary>
        public Guid CurrentUserId // Use uppercase for public properties
        {
            set => currentUserId = value;
        }

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