using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomChatSrc.Domain.Chat;
using RandomChatSrc.Domain.UserConfig;


using IChatroomsManagementService = RandomChatSrc.Services.Mocks.IChatroomsManagementServicMock;


namespace RandomChatSrc.Services.RandomMatchingService
{
    internal class RandomMatchingService
    {
        IChatroomsManagementService chatroomsManagementService;
        //Queue<User> randomMatchingQueue;
        public RandomMatchingService(IChatroomsManagementService chatroomsManagementService) {
            this.chatroomsManagementService = chatroomsManagementService;
        }
        public Chat RequestMatchingChatRoom(IUserConfig chatConfig) {
            var allChats = chatroomsManagementService.GetChats();
            foreach (var chat in allChats)
            {
                if (chat.availableParticipantsCount() > 0)
                    chat.addParticipant(chatConfig.user);

            }
            return chatroomsManagementService.GetChat();
        }
           
    }
}
