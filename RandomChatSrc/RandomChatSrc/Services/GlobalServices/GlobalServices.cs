using RandomChatSrc.Services.ChatroomsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            private UserRepo UserRepo { get; }

            public GlobalServices(IChatroomsManagementService chatroomsManagementService,
                                  IMapService mapService,
                                  IRequestChatService requestChatService,
                                  UserRepo userRepo)
            {
                ChatroomsManagementService = chatroomsManagementService;
                MapService = mapService;
                RequestChatService = requestChatService;
                UserRepo = userRepo;
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

        public UserRepo GetUserRepo()
        {
            return UserRepo;
        }
    }
    }

