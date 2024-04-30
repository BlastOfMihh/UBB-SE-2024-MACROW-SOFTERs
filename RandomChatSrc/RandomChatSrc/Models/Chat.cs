namespace RandomChatSrc.Models
{
    /// <summary>
    /// Represents a chat room. Contains the chat's identifier, the list of participants and the maximum number of participants.
    /// </summary>

    public class Chat(int maximumParticipants = 5) : IChat
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public List<User> Participants { get; } = [];
        public int MaximumParticipants { get; } = maximumParticipants;

        public void AddParticipant(User user)
        {
            if (Participants.Count < MaximumParticipants)
                Participants.Add(user);
            else throw new Exception("Exceeded max Participants count");
        }
        public int AvailableParticipantsCount() 
        {
            return MaximumParticipants - Participants.Count;
        }
    }
}
