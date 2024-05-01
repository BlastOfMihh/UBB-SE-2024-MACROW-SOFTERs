// <copyright file="IChatRequestRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RandomChatSrc.Repositories
{
    using RandomChatSrc.Models;

    /// <summary>
    /// Defines the operations for managing chat requests.
    /// </summary>
    public interface IChatRequestRepository
    {
        /// <summary>
        /// Loads chat requests from memory.
        /// </summary>
        void LoadFromMemory();

        /// <summary>
        /// Adds a new chat request.
        /// </summary>
        /// <param name="senderUserId">The ID of the user who sent the request.</param>
        /// <param name="receiverUserId">The ID of the user who received the request.</param>
        void AddRequest(Guid senderUserId, Guid receiverUserId);

        /// <summary>
        /// Removes a chat request.
        /// </summary>
        /// <param name="senderUserId">The ID of the user who sent the request.</param>
        /// <param name="receiverUserId">The ID of the user who received the request.</param>
        void RemoveRequest(Guid senderUserId, Guid receiverUserId);

        /// <summary>
        /// Retrieves all chat requests.
        /// </summary>
        /// <returns>A list of all chat requests.</returns>
        List<Request> GetAllChatRequests();
    }
}