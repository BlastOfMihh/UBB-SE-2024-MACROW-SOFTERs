using RandomChatSrc.Domain.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RandomChatSrc.Services.Mocks
{
    internal interface IChatroomsManagementServicMock
    {
        Chat GetChat();
        Chat CreateChat(int size);
        void DeleteChat(String id);
        List<Chat> GetChats();
    }
}
