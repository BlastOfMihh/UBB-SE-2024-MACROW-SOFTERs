using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomChatSrc.Domain.User;

namespace RandomChatSrc.Domain.Chat
{
    internal class Chat : IChat
    {
        public string id { get; }
        public List<IUser> participants { get; }
        public int maxParticipants { get; }
        public Chat(int maxParticipants=5)
        {
            id = Guid.NewGuid().ToString();
            this.maxParticipants = maxParticipants;
            participants = new List<IUser>();
        }
        public void addParticipant(IUser user)
        {
            if (participants.Count <= maxParticipants)
                participants.Add(user);
            else throw new Exception("Exceeded max participants count");
        }
        public int availableParticipantsCount()
        {
            return maxParticipants - participants.Count;
        }
    }
}
