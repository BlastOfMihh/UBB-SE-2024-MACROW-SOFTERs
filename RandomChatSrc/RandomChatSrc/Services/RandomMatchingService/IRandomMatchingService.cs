// <copyright file="IRandomMatchingService.cs" company="SuperBet BeClean">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
using RandomChatSrc.Domain.TextChat;
using RandomChatSrc.Domain.UserConfig;

namespace RandomChatSrc.Services.RandomMatchingService
{
    public interface IRandomMatchingService
    {
        TextChat RequestMatchingChatRoom(UserChatConfig chatConfig);
    }
}
