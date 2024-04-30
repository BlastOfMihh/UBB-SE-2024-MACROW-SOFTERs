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
            private IChatroomsManagementService ChatroomsManagementService { get; }
            private IMapService MapService { get; }
            private IRequestChatService RequestChatService { get; }
            private UserRepository UserRepository { get; }

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
        public IChatroomsManagementService GetChatroomsManagementService()
        {
            return ChatroomsManagementService;
        }

        public IMapService GetMapService()
        {
            return MapService;
        }

        public IRequestChatService GetRequestChatService()
        {
            return RequestChatService;
        }

        public UserRepository GetUserRepo()
        {
            return UserRepository;
        }
    }
    }

