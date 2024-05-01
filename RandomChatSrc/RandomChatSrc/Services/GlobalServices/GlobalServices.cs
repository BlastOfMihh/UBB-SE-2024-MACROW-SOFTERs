// <copyright file="GlobalServices.cs" company="SuperBet BeClean">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RandomChatSrc.Services.GlobalServices
{
    using RandomChatSrc.Repositories;
    using RandomChatSrc.Services.ChatroomsManagement;
    using RandomChatSrc.Services.MapService;
    using RandomChatSrc.Services.RequestChatService;

    /// <summary>
    /// The GlobalServices class provides a centralized access point to various services in the application.
    /// </summary>
    public class GlobalServices
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GlobalServices"/> class.
        /// </summary>
        /// <param name="chatroomsManagementService">The chatrooms management service.</param>
        /// <param name="mapService">The map service.</param>
        /// <param name="requestChatService">The request chat service.</param>
        /// <param name="userRepository">The user repository.</param>
        public GlobalServices(
            IChatroomsManagementService chatroomsManagementService,
            IMapService mapService,
            IRequestChatService requestChatService,
            IUserRepository userRepository)
        {
            this.ChatroomsManagementService = chatroomsManagementService;
            this.MapService = mapService;
            this.RequestChatService = requestChatService;
            this.UserRepository = userRepository;
        }

        /// <summary>
        /// Gets the chatrooms management service.
        /// </summary>
        public IChatroomsManagementService ChatroomsManagementService { get; }

        /// <summary>
        /// Gets the map service.
        /// </summary>
        public IMapService MapService { get; }

        /// <summary>
        /// Gets the request chat service.
        /// </summary>
        public IRequestChatService RequestChatService { get; }

        /// <summary>
        /// Gets the user repository.
        /// </summary>
        public IUserRepository UserRepository { get; }
    }
}