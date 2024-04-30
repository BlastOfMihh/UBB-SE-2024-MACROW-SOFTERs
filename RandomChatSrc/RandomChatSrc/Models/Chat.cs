namespace RandomChatSrc.Models
{
    /// <summary>
    /// Represents a chat room. Contains the chat's identifier, the list of participants and the maximum number of participants.
    /// </summary>
    public class Chat : IChat
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public List<User> Participants { get; } = new List<User>();
        public int MaximumParticipants { get; set; }

        public Chat(int maximumParticipants = 5)
        {
            MaximumParticipants = maximumParticipants;
        }

        public void AddParticipant(User user)
        {
            if (Participants.Count < MaximumParticipants)
            {
                Participants.Add(user);
            }
            else
            {
                throw new Exception("Exceeded max Participants count");
            }
        }
        public int AvailableParticipantsCount()
        {
            return MaximumParticipants - Participants.Count;
        }
    }
}
