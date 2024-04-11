using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomChatSrc.Domain.User
{
    internal class User
    {
        Guid id { get ;}
        string name { get; }
        public User(string name)
        {
            this.name= name;
            this.id=Guid.NewGuid();
        }
    }
}
