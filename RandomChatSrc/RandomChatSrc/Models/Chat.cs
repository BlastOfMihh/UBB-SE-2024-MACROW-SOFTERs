// <copyright file="Chat.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RandomChatSrc.Models
{
    /// <summary>
    /// Represents a chat room. Contains the chat's identifier, the list of participants and the maximum number of participants.
    /// </summary>
    public class Chat
    {
        private const int MAXPARTICIPANTS = 5;

        /// <summary>
        /// Initializes a new instance of the <see cref="Chat"/> class with a specified maximum number of participants.
        /// </summary>
        /// <param name="maximumParticipants">The maximum number of participants allowed in the chat. Defaults to 5 if not specified.</param>
        public Chat(int maximumParticipants = MAXPARTICIPANTS)
        {
            this.MaximumParticipants = maximumParticipants;
        }

        /// <summary>
        /// Gets or sets the unique identifier for the chat.
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Gets the list of participants in the chat.
        /// </summary>
        public List<User> Participants { get; } = new List<User>();

        /// <summary>
        /// Gets or sets the maximum number of participants allowed in the chat.
        /// </summary>
        public int MaximumParticipants { get; set; }

        /// <summary>
        /// Adds a participant to the chat if the maximum number of participants has not been reached.
        /// </summary>
        /// <param name="user">The user to add as a participant.</param>
        public void AddParticipant(User user)
        {
            if (this.Participants.Count < this.MaximumParticipants)
            {
                this.Participants.Add(user);
            }
            else
            {
                throw new InvalidOperationException("The chat is full.");
            }
        }

        /// <summary>
        /// Computes the number of available participants that can join the chat.
        /// </summary>
        /// <returns> The number of available participants that can join the chat</returns>
        public int AvailableParticipantsCount()
        {
            return this.MaximumParticipants - this.Participants.Count;
        }
    }
}