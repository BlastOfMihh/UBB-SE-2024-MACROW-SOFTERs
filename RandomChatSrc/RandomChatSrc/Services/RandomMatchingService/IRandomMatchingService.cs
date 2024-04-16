using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomChatSrc.Domain.ChatDomain;
using RandomChatSrc.Domain.TextChat;
using RandomChatSrc.Domain.UserConfig;

namespace RandomChatSrc.Services.RandomMatchingService
{
    public interface IRandomMatchingService
    {
        public TextChat RequestMatchingChatRoom(UserChatConfig chatConfig);
    }
}
