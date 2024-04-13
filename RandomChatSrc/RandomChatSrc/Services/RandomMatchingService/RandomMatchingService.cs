using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomChatSrc.Domain.ChatDomain;
using RandomChatSrc.Domain.TextChat;
using RandomChatSrc.Domain.UserConfig;
using RandomChatSrc.Services.ChatroomsManagement;
using RandomChatSrc.Services.UserChatListServiceDomain;

namespace RandomChatSrc.Services.RandomMatchingService
{
    public class RandomMatchingService : IRandomMatchingService
    {
        ChatroomsManagementService chatroomsManagementService;
        UserChatListService userChatListService;
        public RandomMatchingService(ChatroomsManagementService chatroomsManagementService, UserChatListService userChatListService) {
            this.chatroomsManagementService = chatroomsManagementService;
            this.userChatListService = userChatListService;
        }
        public TextChat RequestMatchingChatRoom(UserChatConfig chatConfig) {
            var allChats = this.chatroomsManagementService.activeChats;
            foreach (var chat in allChats)
            {
                if (chat.availableParticipantsCount() == 0)
                {
                    continue;
                }
                foreach (var participant in chat.participants)
                {
                    if (participant.id != userChatListService.currentUserId)
                    {
                        chat.addParticipant(chatConfig.user);
                        return chat;
                    }
                }
                chat.addParticipant(chatConfig.user);
                return chat;
            }
            return chatroomsManagementService.GetChat();
        }
    }
}
