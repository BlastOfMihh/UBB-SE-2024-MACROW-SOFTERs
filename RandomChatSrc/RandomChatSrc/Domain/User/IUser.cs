using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomChatSrc.Domain.User
{
    internal interface IUser
    {
        string id { get;  }
        string Name { get; }
    }
}
