using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomChatSrc.Domain.UserDomain;

namespace RandomChatSrc.Domain.UserConfig
{
    public class UserChatConfig
    {
        User user { get;  }
        public UserChatConfig(User user) { 
            this.user = user;
        }
    }
}
