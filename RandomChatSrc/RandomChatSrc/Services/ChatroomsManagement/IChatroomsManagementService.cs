using RandomChatSrc.Domain.ChatDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomChatSrc.Services.ChatroomsManagement
{
    public interface IChatroomsManagementService
    {
        Chat GetChat();
        Chat CreateChat(int size);
        void DeleteChat(Guid id);
        Chat getChatById(Guid id);
        List<Chat> getAllChats();
    }
}
