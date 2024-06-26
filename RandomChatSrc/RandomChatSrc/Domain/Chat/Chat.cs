using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomChatSrc.Domain.UserDomain;

namespace RandomChatSrc.Domain.ChatDomain
{
    public class Chat : IChat
    {
        public Guid id { get; set; }
        public List<User> participants { get; }
        public int maxParticipants { get; }
        public Chat(int maxParticipants=5)
        {
            id = Guid.NewGuid();
            this.maxParticipants = maxParticipants;
            participants = new List<User>();
        }
        public void addParticipant(User user)
        {
            if (participants.Count <= maxParticipants)  // todo shouldnt this be < maxParticipants?
                participants.Add(user);
            else throw new Exception("Exceeded max participants count");
        }
        public int availableParticipantsCount()  // remaining number of people who can join this chat
        {
            return maxParticipants - participants.Count;
        }
    }
}
