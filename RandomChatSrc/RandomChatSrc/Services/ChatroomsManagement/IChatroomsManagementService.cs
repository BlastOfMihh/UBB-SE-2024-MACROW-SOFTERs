// <copyright file="IChatroomsManagementService.cs" company="SuperBet BeClean">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
using RandomChatSrc.Domain.TextChat;

namespace RandomChatSrc.Services.ChatroomsManagement
{
    public interface IChatroomsManagementService
    {
        TextChat GetChat();
        TextChat CreateChat(int size);
        void DeleteChat(Guid id);
        TextChat GetChatById(Guid id);
        List<TextChat> GetAllChats();
    }
}
