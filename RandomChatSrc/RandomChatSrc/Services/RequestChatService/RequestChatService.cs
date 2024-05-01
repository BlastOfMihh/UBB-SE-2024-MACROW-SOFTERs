// <copyright file="RequestChatService.cs" company="SuperBet BeClean">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace RandomChatSrc.Services.RequestChatService
{
    using RandomChatSrc.Models;
    using RandomChatSrc.Repositories;

    /// <summary>
    /// Service responsible for managing chat requests.
    /// </summary>
    public class RequestChatService
    {
        private readonly GlobalServices.GlobalServices globalServices;
        private readonly IChatRequestRepository chatRequestRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestChatService"/> class.
        /// </summary>
        /// <param name="requestsChatRepo">The chat request repository.</param>
        /// <param name="globalServices">The global services.</param>
        public RequestChatService(IChatRequestRepository requestsChatRepo, GlobalServices.GlobalServices globalServices)
        {
            this.chatRequestRepository = requestsChatRepo;
            this.globalServices = globalServices;
        }

        /// <summary>
        /// Retrieves all requests.
        /// </summary>
        /// <returns>A list of requests.</returns>
        public List<Request> GetAllRequests()
        {
            return this.chatRequestRepository.GetAllChatRequests();
        }

        /// <summary>
        /// Adds a chat request.
        /// </summary>
        /// <param name="senderId">The ID of the sender.</param>
        /// <param name="receiverId">The ID of the receiver.</param>
        public void AddRequest(Guid senderId, Guid receiverId)
        {
            this.chatRequestRepository.AddRequest(senderId, receiverId);
        }

        /// <summary>
        /// Declines a chat request.
        /// </summary>
        /// <param name="senderId">The ID of the sender.</param>
        /// <param name="receiverId">The ID of the receiver.</param>
        public void DeclineRequest(Guid senderId, Guid receiverId)
        {
            this.chatRequestRepository.RemoveRequest(senderId, receiverId);
        }

        /// <summary>
        /// Accepts a chat request and creates a new text chat.
        /// </summary>
        /// <param name="senderId">The ID of the sender.</param>
        /// <param name="receiverId">The ID of the receiver.</param>
        public void AcceptRequest(Guid senderId, Guid receiverId)
        {
            TextChat newTextChat = this.globalServices.ChatroomsManagementService.CreateChat(5);
            newTextChat.AddParticipant(this.globalServices.UserRepository.GetUserById(senderId));
            newTextChat.AddParticipant(this.globalServices.UserRepository.GetUserById(receiverId));
            this.chatRequestRepository.RemoveRequest(senderId, receiverId);
        }
    }
}
