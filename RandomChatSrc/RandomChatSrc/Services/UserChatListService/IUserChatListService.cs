using RandomChatSrc.Domain.ChatDomain;
using RandomChatSrc.Domain.TextChat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomChatSrc.Services.UserChatListServiceDomain
{
    public interface IUserChatListService
    {
        List<TextChat> getOpenChats();
    }
}
