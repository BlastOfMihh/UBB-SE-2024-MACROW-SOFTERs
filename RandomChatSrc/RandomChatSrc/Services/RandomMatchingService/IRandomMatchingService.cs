using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomChatSrc.Domain.ChatDomain;

namespace RandomChatSrc.Services.RandomMatchingService
{
    public interface IRandomMatchingService
    {
        public Chat RequestMatchingChatRoom();
    }
}
