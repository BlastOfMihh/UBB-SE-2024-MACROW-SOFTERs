// <copyright file="IUserChatListService.cs" company="SuperBet BeClean">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
using RandomChatSrc.Domain.TextChat;

namespace RandomChatSrc.Services.UserChatListServiceDomain
{
    public interface IUserChatListService
    {
        List<TextChat> getOpenChats();
        Guid getCurrentUserGuid();
    }
}
