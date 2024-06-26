﻿using RandomChatSrc.Domain.ChatDomain;
using RandomChatSrc.Domain.TextChat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomChatSrc.Services.ChatroomsManagement
{
    public interface IChatroomsManagementService
    {
        TextChat GetChat();
        TextChat CreateChat(int size);
        void DeleteChat(Guid id);
        TextChat getChatById(Guid id);
        List<TextChat> getAllChats();
    }
}
