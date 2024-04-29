using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomChatSrc.Models;

namespace RandomChatSrc.Services.UserChatListServiceDomain
{
    public interface IUserChatListService
    {
        List<TextChat> getOpenChats();
    }
}
