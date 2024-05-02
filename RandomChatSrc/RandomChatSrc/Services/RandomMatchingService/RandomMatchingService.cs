// <copyright file="RandomMatchingService.cs" company="SuperBet BeClean">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RandomChatSrc.Services.RandomMatchingService
{
    using RandomChatSrc.Models;
    using RandomChatSrc.Services.ChatroomsManagement;
    using RandomChatSrc.Services.UserChatListService;

    /// <summary>
    /// Service responsible for random matching users to chat rooms based on their configurations.
    /// </summary>
    public class RandomMatchingService : IRandomMatchingService
    {
        private readonly IChatroomsManagementService chatroomsManagementService;
        private readonly UserChatListService userChatListService;

        /// <summary>
        /// Initializes a new instance of the <see cref="RandomMatchingService"/> class.
        /// </summary>
        /// <param name="chatroomsManagementService">The chatrooms management service.</param>
        /// <param name="userChatListService">The user chat list service.</param>
        public RandomMatchingService(IChatroomsManagementService chatroomsManagementService, UserChatListService userChatListService)
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
            var allChats = this.chatroomsManagementService.GetAllChats();
            int currentChatIndex = -1;
            List<int> bestChatIndexes = new ();

            // score - the number of matching interests of the User we want to assign
            // to a chat (i.e. `chatConfig` parameter) across all users that are members
            // of that chat.
            // example to understand better:
            // say we have a chat with 3 users (user1, user2, user3), and:
            // user1 has 2 matching interests with the User we would like to add to a chat;
            // user2 has 1 matching interest -''-;
            // user3 has 2 matching interests -''-;
            // => for this chat, the score will simply be 2 + 1 + 2 = 5.
            int currentScore = -1, bestScore = -1;

            foreach (var chat in allChats)
            {
                ++currentChatIndex;

                currentScore = 0;

                foreach (var participant in chat.Participants)
                {
                    foreach (var participantInterest in participant.Interests)
                    {
                        currentScore += Convert.ToInt32(chatConfig.User.Interests.Any(curUserInterest => curUserInterest.Equals(participantInterest)));
                    }
                }

                if (currentScore > bestScore)
                {
                    bestScore = currentScore;
                    bestChatIndexes = new List<int> { currentChatIndex };
                }
            }

            int randomIndex = new Random().Next(bestChatIndexes.Count);
            int selectedChatIndex = bestChatIndexes[randomIndex];
            allChats[selectedChatIndex].AddParticipant(chatConfig.User);
            return allChats[selectedChatIndex];
        }
    }
}
