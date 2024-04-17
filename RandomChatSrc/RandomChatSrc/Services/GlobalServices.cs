using RandomChatSrc.Services.ChatroomsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomChatSrc.Services
{
    public class GlobalServices
    {
        public ChatroomsManagementService chatroomsManagementService;
        
        public GlobalServices()
        {
        }
        public void setChatroomsManagementService(ChatroomsManagementService chatroomsManagementService)
        {
            this.chatroomsManagementService = chatroomsManagementService;
        }
    }
}
