// <copyright file="IRequestChatService.cs" company="SuperBet BeClean">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
using RandomChatSrc.Domain.RequestDomain;

namespace RandomChatSrc.Services.RequestChatService
{
    public interface IRequestChatService
    {
        List<Request> GetAllRequests();

        void AddRequest(Guid senderId, Guid receiverId);

        void DeclineRequest(Guid senderId, Guid receiverId);

        void AcceptRequest(Guid senderId, Guid receiverId);
    }
}
