using RandomChatSrc.Domain.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomChatSrc.Services.ChatroomsManagementService
{
    public interface IChatroomsManagementService
    {
        MockChat GetChat();
        MockChat CreateChat(int size);
        void DeleteChat(Guid id);
    }
}
