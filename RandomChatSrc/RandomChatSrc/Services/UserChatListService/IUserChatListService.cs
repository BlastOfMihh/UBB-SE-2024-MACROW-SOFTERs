using RandomChatSrc.Domain.ChatDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomChatSrc.Services.UserChatListService
{
    public interface IUserChatListService
    {
        List<Chat> getOpenChats();
    }
}
