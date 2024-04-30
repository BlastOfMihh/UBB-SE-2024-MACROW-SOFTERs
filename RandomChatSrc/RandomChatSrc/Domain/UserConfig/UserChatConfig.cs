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
        public User user { get; set; }
        public UserChatConfig(User user) {
            this.user = user;
        }
    }
}
