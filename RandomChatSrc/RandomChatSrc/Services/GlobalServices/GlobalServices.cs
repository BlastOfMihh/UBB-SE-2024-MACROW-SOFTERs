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
        public ChatroomsManagementService chatroomsManagementService { get; set; }
        public MapService.MapService mapService { get; set; }
        public RequestChatService.RequestChatService requestChatService {  get; set; }
        public UserRepo userRepo { get; set; }

        public GlobalServices(ChatroomsManagementService chatroomsManagementService, MapService.MapService mapService,
                              RequestChatService.RequestChatService requestChatService, UserRepo userRepo)
        {
            this.chatroomsManagementService = chatroomsManagementService;
            this.mapService = mapService;
            this.requestChatService = requestChatService;
            this.userRepo = userRepo;
        }
    }
}
