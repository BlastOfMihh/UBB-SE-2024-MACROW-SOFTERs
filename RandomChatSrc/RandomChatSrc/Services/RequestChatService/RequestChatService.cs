// <copyright file="RequestChatService.cs" company="SuperBet BeClean">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
using RandomChatSrc.Repository;
using RandomChatSrc.Domain.RequestDomain;
using RandomChatSrc.Domain.TextChat;

namespace RandomChatSrc.Services.RequestChatService
{
    public class RequestChatService
    {
        private readonly GlobalServices.GlobalServices globalServices;
        private readonly RequestsChatRepository requestsChatRepo;

        public RequestChatService(RequestsChatRepository requestsChatRepo, GlobalServices.GlobalServices globalServices)
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
            return this.requestsChatRepo.getAllChatRequests();
        }

        /// <summary>
        /// Adds a chat request.
        /// </summary>
        /// <param name="senderId">The ID of the sender.</param>
        /// <param name="receiverId">The ID of the receiver.</param>
        public void AddRequest(Guid senderId, Guid receiverId)
        {
            requestsChatRepo.addRequest(senderId, receiverId);
        }

        /// <summary>
        /// Declines a chat request.
        /// </summary>
        /// <param name="senderId">The ID of the sender.</param>
        /// <param name="receiverId">The ID of the receiver.</param>
        public void DeclineRequest(Guid senderId, Guid receiverId)
        {
            requestsChatRepo.removeRequest(senderId, receiverId);
        }

        /// <summary>
        /// Accepts a chat request and creates a new text chat.
        /// </summary>
        /// <param name="senderId">The ID of the sender.</param>
        /// <param name="receiverId">The ID of the receiver.</param>
        public void AcceptRequest(Guid senderId, Guid receiverId)
        {
            TextChat newTextChat = globalServices.GetChatroomsManagementService().CreateChat(5);
            newTextChat.addParticipant(globalServices.GetUserRepo().getUserById(senderId));
            newTextChat.addParticipant(globalServices.GetUserRepo().getUserById(receiverId));
            requestsChatRepo.removeRequest(senderId, receiverId);
        }
    }
}
