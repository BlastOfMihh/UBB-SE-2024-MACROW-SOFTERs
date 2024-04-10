using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomChatSrc.Domain.User;

namespace RandomChatSrc.Domain.ChatDomain
{
    internal interface IChat
    {
        public string id { get; }
        public void addParticipant(IUser user);
        List<IUser> participants { get; }
        public int maxParticipants { get; }

        public int availableParticipantsCount();
    }
}
