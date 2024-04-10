using RandomChatSrc.Domain.ChatDomain;
using RandomChatSrc.Domain.TextChat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomChatSrc.Services.UserChatListService
{
    public interface IUserChatListService
    {
        List<TextChat> getOpenChats();  // tibu modified this so that it matches mih's code; not decided that this is the definitive version
    }
}
