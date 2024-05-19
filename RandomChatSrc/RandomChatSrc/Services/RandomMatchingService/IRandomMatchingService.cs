// <copyright file="IRandomMatchingService.cs" company="SuperBet BeClean">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RandomChatSrc.Services.RandomMatchingService
{
    using RandomChatSrc.Models;

    /// <summary>
    /// Interface for services that provide random chatroom matching.
    /// </summary>
    public interface IRandomMatchingService
    {
        /// <summary>
        /// Requests a matching chatroom based on the provided chat configuration.
        /// </summary>
        /// <param name="chatConfig">The chat configuration based on which to find a matching chatroom.</param>
        /// <returns>A chatroom that matches the provided configuration.</returns>
        TextChat RequestMatchingChatRoom(User user);
    }
}