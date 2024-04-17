using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomChatSrc.Domain.UserDomain;

namespace RandomChatSrc.Repository
{
    public class UserRepo
    {
        public List<User> users {  get; set; }

        public UserRepo(List<User> users)
        {
            this.users = users;
        }

        public User getUserById(Guid id)
        {
            return this.users.FirstOrDefault(user => user.id == id);
        }
    }
}
