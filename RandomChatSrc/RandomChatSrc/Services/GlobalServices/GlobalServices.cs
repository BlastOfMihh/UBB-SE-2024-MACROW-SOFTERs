// <copyright file="GlobalServices.cs" company="SuperBet BeClean">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
using RandomChatSrc.Services.ChatroomsManagement;
using RandomChatSrc.Services.MapService;
using RandomChatSrc.Services.RequestChatService;
using RandomChatSrc.Repository;

namespace RandomChatSrc.Services.GlobalServices
{
    public class GlobalServices
    {
        public IChatroomsManagementService ChatroomsManagementService { get; }
        public IMapService MapService { get; }
        public IRequestChatService RequestChatService { get; }
        public UserRepository UserRepository { get; }

        public GlobalServices(IChatroomsManagementService chatroomsManagementService,
                                IMapService mapService,
                                IRequestChatService requestChatService,
                                UserRepository userRepository)
        {
            ChatroomsManagementService = chatroomsManagementService;
            MapService = mapService;
            RequestChatService = requestChatService;
            UserRepository = userRepository;
        }
    }
}

