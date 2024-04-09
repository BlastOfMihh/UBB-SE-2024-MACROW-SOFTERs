using RandomChatSrc.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomChatSrc.Domain.UserConfig
{
    internal interface IUserConfig
    {
        IUser user { get; }

    }
}
