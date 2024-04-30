// <copyright file="RequestChatService.cs" company="SuperBet BeClean">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
using RandomChatSrc.Repository;
using RandomChatSrc.Models;

namespace RandomChatSrc.Services.RequestChatService
{
    public class RequestChatService
    {
        private readonly GlobalServices.GlobalServices globalServices;
        private readonly ChatRequestsRepository requestsChatRepo;

        public RequestChatService(ChatRequestsRepository requestsChatRepo, GlobalServices.GlobalServices globalServices)
        {
            this.requestsChatRepo = requestsChatRepo;
            this.globalServices = globalServices;
        }

        /// <summary>
        /// Retrieves all requests.
        /// </summary>
        /// <returns>A list of requests.</returns>
        public List<Request> GetAllRequests()
        {
            return this.requestsChatRepo.GetAllChatRequests();
        }

        /// <summary>
        /// Adds a chat request.
        /// </summary>
        /// <param name="senderId">The ID of the sender.</param>
        /// <param name="receiverId">The ID of the receiver.</param>
        public void AddRequest(Guid senderId, Guid receiverId)
        {
            requestsChatRepo.AddRequest(senderId, receiverId);
        }

        /// <summary>
        /// Declines a chat request.
        /// </summary>
        /// <param name="senderId">The ID of the sender.</param>
        /// <param name="receiverId">The ID of the receiver.</param>
        public void DeclineRequest(Guid senderId, Guid receiverId)
        {
            requestsChatRepo.RemoveRequest(senderId, receiverId);
        }

        /// <summary>
        /// Accepts a chat request and creates a new text chat.
        /// </summary>
        /// <param name="senderId">The ID of the sender.</param>
        /// <param name="receiverId">The ID of the receiver.</param>
        public void AcceptRequest(Guid senderId, Guid receiverId)
        {
            TextChat newTextChat = globalServices.GetChatroomsManagementService().CreateChat(5);
            newTextChat.AddParticipant(globalServices.GetUserRepo().GetUserById(senderId));
            newTextChat.AddParticipant(globalServices.GetUserRepo().GetUserById(receiverId));
            requestsChatRepo.RemoveRequest(senderId, receiverId);
        }
    }
}
