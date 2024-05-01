// <copyright file="IRequestChatService.cs" company="SuperBet BeClean">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RandomChatSrc.Services.RequestChatService
{
    using RandomChatSrc.Models;

    /// <summary>
    /// Represents the interface for handling chat requests.
    /// </summary>
    public interface IRequestChatService
    {
        /// <summary>
        /// Gets all chat requests.
        /// </summary>
        /// <returns>A list of all chat requests.</returns>
        List<Request> GetAllRequests();

        /// <summary>
        /// Adds a new chat request from the sender to the receiver.
        /// </summary>
        /// <param name="senderId">The ID of the sender.</param>
        /// <param name="receiverId">The ID of the receiver.</param>
        void AddRequest(Guid senderId, Guid receiverId);

        /// <summary>
        /// Declines a chat request from the sender to the receiver.
        /// </summary>
        /// <param name="senderId">The ID of the sender.</param>
        /// <param name="receiverId">The ID of the receiver.</param>
        void DeclineRequest(Guid senderId, Guid receiverId);

        /// <summary>
        /// Accepts a chat request from the sender to the receiver.
        /// </summary>
        /// <param name="senderId">The ID of the sender.</param>
        /// <param name="receiverId">The ID of the receiver.</param>
        void AcceptRequest(Guid senderId, Guid receiverId);
    }
}
