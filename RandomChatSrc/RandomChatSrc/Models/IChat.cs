// <copyright file="IChat.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RandomChatSrc.Models
{
    /// <summary>
    /// Interface for a chat room. Contains the chat's identifier, the list of participants and the maximum number of participants.
    /// </summary>
    internal interface IChat
    {
        /// <summary>
        /// Gets the list of all participants in the chat room.
        /// </summary>
        List<User> Participants { get; }

        /// <summary>
        /// Adds a new participant to the chat room.
        /// </summary>
        /// <param name="user">The user to be added as a participant in the chat room.</param>
        public void AddParticipant(User user);

        /// <summary>
        /// Returns the number of all available participants in the chat room.
        /// </summary>
        /// <returns>The number of available participants.</returns>
        public int AvailableParticipantsCount();
    }
}