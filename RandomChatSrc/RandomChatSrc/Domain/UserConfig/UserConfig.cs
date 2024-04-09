using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomChatSrc.Domain.User;

namespace RandomChatSrc.Domain.UserConfig
{
    public class UserConfig
    {
        IUser user { get;  }
        public UserConfig(IUser user) { 
            this.user = user;
        }
    }
}
