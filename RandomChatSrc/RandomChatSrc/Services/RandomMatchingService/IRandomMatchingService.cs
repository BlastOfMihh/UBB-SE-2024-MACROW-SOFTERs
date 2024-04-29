using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomChatSrc.Models;

namespace RandomChatSrc.Services.RandomMatchingService
{
    public interface IRandomMatchingService
    {
        public TextChat RequestMatchingChatRoom(UserChatConfig chatConfig);
    }
}
