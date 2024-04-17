using RandomChatSrc.Services.ChatroomsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomChatSrc.Services.GlobalServices
{
    public class GlobalServices
    {   
        ChatroomsManagementService chatroomsManagementService;
        public GlobalServices(ChatroomsManagementService chatroomsManagementService) {
            this.chatroomsManagementService = chatroomsManagementService;
        }
    }
}
