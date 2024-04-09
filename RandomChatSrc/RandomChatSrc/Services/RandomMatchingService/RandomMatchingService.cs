using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomChatSrc.Domain.ChatDomain;
using RandomChatSrc.Domain.UserConfig;
using RandomChatSrc.Services.ChatroomsManagement;

namespace RandomChatSrc.Services.RandomMatchingService
{
    public class RandomMatchingService
    {
        ChatroomsManagementService chatroomsManagementService;
        //Queue<User> randomMatchingQueue;
        public RandomMatchingService(ChatroomsManagementService chatroomsManagementService) {
            this.chatroomsManagementService = chatroomsManagementService;
        }
        public Chat RequestMatchingChatRoom(IUserConfig chatConfig) {
            var allChats = this.chatroomsManagementService.activeChats;
            foreach (var chat in allChats)
            {
                if (chat.availableParticipantsCount() > 0)
                    chat.addParticipant(chatConfig.user);

            }
            return chatroomsManagementService.GetChat();
        }
           
    }
}
