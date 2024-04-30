// <copyright file="IUserChatListService.cs" company="SuperBet BeClean">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
using RandomChatSrc.Models;

namespace RandomChatSrc.Services.UserChatListServiceDomain
{
    public interface IUserChatListService
    {
        List<TextChat> GetOpenChats();
        Guid GetCurrentUserGuid();
    }
}
