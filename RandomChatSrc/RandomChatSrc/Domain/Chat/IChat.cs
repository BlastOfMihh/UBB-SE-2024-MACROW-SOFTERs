using RandomChatSrc.Domain.UserDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomChatSrc.Domain.ChatDomain
{
    internal interface IChat
    {
        public Guid id { get; }
        public void addParticipant(User user);
        List<User> participants { get; }
        public int maxParticipants { get; }

        public int availableParticipantsCount();
    }
}
