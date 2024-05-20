// <copyright file="IUserChatListService.cs" company="SuperBet BeClean">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RandomChatSrc.Services.UserChatListService
{
    using RandomChatSrc.Models;

    /// <summary>
    /// Interface for services that manage the list of chats for a user.
    /// </summary>
    public interface IUserChatListService
    {
        /// <summary>
        /// Retrieves a list of all open chats.
        /// </summary>
        /// <returns>A list of open chats.</returns>
        List<Chat> GetOpenChats();
    }
}