using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomChatSrc.Domain.InterestDomain;


namespace RandomChatSrc.Domain.UserDomain
{
    public class User
    {
        public Guid id { get; set; }
        public string name { get; set; }

        public List<Interest> interests { get; set; }

        public User(string name)
        {
            this.name= name;
            this.id=Guid.NewGuid();
            this.interests = new List<Interest>();
        }
    }
}
