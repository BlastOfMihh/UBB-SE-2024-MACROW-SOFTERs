using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomChatSrc.Domain.Chat;

namespace RandomChatSrc.Services.RandomMatchingService
{
    internal interface IRandomMatchingService
    {
        public Chat RequestMatchingChatRoom();
    }
}
