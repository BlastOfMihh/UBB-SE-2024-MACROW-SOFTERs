// <copyright file="IMessageService.cs" company="SuperBet BeClean">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace RandomChatSrc.Services.MessageService
{
    using RandomChatSrc.Models;

    /// <summary>
    /// Interface for services that handle sending messages.
    /// </summary>
    public interface IMessageService
    {
        /// <summary>
        /// Sends a message.
        /// </summary>
        /// <param name="message">The message to send.</param>
        void SendMessage(string message);

        /// <summary>
        /// Returns the text chat to which messages are sent.
        /// </summary>
        /// <returns> The text chat.</returns>
        TextChat GetTextChat();
    }
}