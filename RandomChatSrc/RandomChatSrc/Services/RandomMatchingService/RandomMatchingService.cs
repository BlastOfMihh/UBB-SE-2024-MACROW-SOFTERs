﻿// <copyright file="RandomMatchingService.cs" company="SuperBet BeClean">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
using RandomChatSrc.Domain.TextChat;
using RandomChatSrc.Domain.UserConfig;
using RandomChatSrc.Services.ChatroomsManagement;
using RandomChatSrc.Services.UserChatListServiceDomain;

namespace RandomChatSrc.Services.RandomMatchingService
{
    public class RandomMatchingService : IRandomMatchingService
    {
        private readonly ChatroomsManagementService chatroomsManagementService;
        private readonly UserChatListService userChatListService;

        public RandomMatchingService(ChatroomsManagementService chatroomsManagementService, UserChatListService userChatListService)
        {
            this.chatroomsManagementService = chatroomsManagementService;
            this.userChatListService = userChatListService;
        }

        /// <summary>
        /// Requests a matching chat room for a user based on their configuration.
        /// </summary>
        /// <param name="chatConfig">The user's chat configuration.</param>
        /// <returns>The matched text chat room.</returns>
        public TextChat RequestMatchingChatRoom(UserChatConfig chatConfig)
        {
            var allChats = chatroomsManagementService.GetAllChats();
            int currentChatIndex = -1;
            List<int> bestChatIndexes = new List<int>();

            // score - the number of matching interests of the user we want to assign
            // to a chat (i.e. `chatConfig` parameter) across all users that are members
            // of that chat.
            // example to understand better:
            // say we have a chat with 3 users (user1, user2, user3), and:
            // user1 has 2 matching interests with the user we would like to add to a chat;
            // user2 has 1 matching interest -''-;
            // user3 has 2 matching interests -''-;
            // => for this chat, the score will simply be 2 + 1 + 2 = 5.
            int currentScore = -1, bestScore = -1;
            foreach (var chat in allChats)
            {
                ++currentChatIndex;
                if (chat.availableParticipantsCount() == 0 || chat.participants.Any(participant => participant.id == userChatListService.getCurrentUserGuid()))
                {
                    continue;
                }
                currentScore = 0;
                foreach (var participant in chat.participants)
                {
                    foreach (var participantInterest in participant.interests)
                    {
                        currentScore += Convert.ToInt32(chatConfig.user.interests.Any(curUserInterest => curUserInterest.Equals(participantInterest)));
                    }
                }
                if (currentScore > bestScore)
                {
                    bestScore = currentScore;
                    bestChatIndexes = new List<int> { currentChatIndex };
                }
                else if (currentScore == bestScore)
                {
                    bestChatIndexes.Add(currentChatIndex);
                }
            }
            if (bestChatIndexes.Count == 0)
            {
                // All chats are full, or user is a member of all chats
                TextChat newChat = chatroomsManagementService.CreateChat(5);
                newChat.addParticipant(chatConfig.user);
                return newChat;
            }
            // choose an index randomly from the list of the best available indexes.
            int randomIndex = new Random().Next(bestChatIndexes.Count);
            int selectedChatIndex = bestChatIndexes[randomIndex];
            allChats[selectedChatIndex].addParticipant(chatConfig.user);
            return allChats[selectedChatIndex];
        }
    }
}
