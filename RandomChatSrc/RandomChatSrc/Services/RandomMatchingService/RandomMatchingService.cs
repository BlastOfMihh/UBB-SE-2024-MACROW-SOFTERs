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
        public RandomMatchingService(ChatroomsManagementService chatroomsManagementService, UserChatListService userChatListService)
        {
            this.chatroomsManagementService = chatroomsManagementService;
            this.userChatListService = userChatListService;
        }
        public TextChat RequestMatchingChatRoom(UserChatConfig chatConfig)
        {
            var allChats = this.chatroomsManagementService.activeChats;
            int bestIdx = -1, curIdx = -1;

            // score - the number of matching interests of the user we want to assign
            // to a chat (i.e. `chatConfig` parameter) across all users that are members
            // of that chat.
            // example to understand better:
            // say we have a chat with 3 users (user1, user2, user3), and:
            // user1 has 2 matching interests with the user we would like to add to a chat;
            // user2 has 1 matching interest -''-;
            // user3 has 2 matching interests -''-;
            // => for this chat, the score will simply be 2 + 1 + 2 = 5.
            int curScore = -1, bestScore = -1;
            foreach (var chat in allChats)
            {
                ++curIdx;
                if (chat.availableParticipantsCount() == 0)
                {
                    continue;
                }

                // check if our user is already part of this chat
                // todo: couldn't we have done `participant.id == chatConfig.user.id` ?
                if (chat.participants.Any(participant => participant.id == userChatListService.currentUserId))
                {
                    continue;
                }

                curScore = 0;
                foreach (var participant in chat.participants)
                {
                    foreach (var participantInterest in participant.interests)
                    {
                        curScore += Convert.ToInt32(chatConfig.user.interests.Any(curUserInterest => curUserInterest.Equals(participantInterest)));
                    }
                }
                if (curScore > bestScore)
                {
                    bestScore = curScore;
                    bestIdx = curIdx;
                }
            }
            if (bestIdx == -1)
            {
                // all chats are full, or user is a member of all chats

                // Create a new textchat to put the current user in.
                // todo maybe should have another way to select the size of the new chat? 
                TextChat newTextChat = this.chatroomsManagementService.CreateChat(5);  // todo: i suppose this would be passed by reference?
                newTextChat.addParticipant(chatConfig.user);
                return newTextChat;
            }
            allChats[bestIdx].addParticipant(chatConfig.user);
            return allChats[bestIdx];
        }
    }
}
