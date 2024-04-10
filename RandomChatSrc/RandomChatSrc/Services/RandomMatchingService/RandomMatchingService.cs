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
    public class RandomMatchingService : IRandomMatchingService
    {
        ChatroomsManagementService chatroomsManagementService;
        public RandomMatchingService(ChatroomsManagementService chatroomsManagementService) {
            this.chatroomsManagementService = chatroomsManagementService;
            // change later
            chatroomsManagementService.CreateChat(5);
            chatroomsManagementService.CreateChat(5);
            chatroomsManagementService.CreateChat(5);
        }
        public Chat RequestMatchingChatRoom(IUserChatConfig chatConfig) {
            var allChats = this.chatroomsManagementService.activeChats;
            foreach (var chat in allChats)
            {
                if (chat.availableParticipantsCount() > 0)
                {
                    chat.addParticipant(chatConfig.user);
                    return chat;
                }
            }
            return chatroomsManagementService.GetChat();
        }
    }
}
