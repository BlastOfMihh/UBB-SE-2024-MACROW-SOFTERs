// <copyright file="IChatroomsManagementService.cs" company="SuperBet BeClean">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RandomChatSrc.Services.ChatroomsManagement
{
    using RandomChatSrc.Models;

    /// <summary>
    /// Interface for managing chatrooms.
    /// </summary>
    public interface IChatroomsManagementService
    {
        /// <summary>
        /// Retrieves a random chatroom.
        /// </summary>
        /// <returns>A random chatroom.</returns>
        Chat GetChat();

        /// <summary>
        /// Creates a new chatroom with the existing chats.
        /// </summary>CreateChat
        /// <returns>The created chatroom.</returns>
        Chat CreateChat();

        /// <summary>
        /// Deletes a chatroom with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the chatroom to delete.</param>
        void DeleteChat(Guid id);

        /// <summary>
        /// Retrieves a chatroom by its ID.
        /// </summary>
        /// <param name="id">The ID of the chatroom.</param>
        /// <returns>The chatroom with the specified ID.</returns>
        Chat GetChatById(Guid id);

        /// <summary>
        /// Retrieves all active chatrooms.
        /// </summary>
        /// <returns>A list of all active chatrooms.</returns>
        List<Chat> GetAllChats();
    }
}