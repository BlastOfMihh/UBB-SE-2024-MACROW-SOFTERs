namespace RandomChatSrc.Models
{
    /// <summary>
    /// Interface for a chat room. Contains the chat's identifier, the list of participants and the maximum number of participants.
    /// </summary>
    internal interface IChat
    {
        public Guid Id { get; }
        public void AddParticipant(User user);
        List<User> Participants { get; }
        public int MaximumParticipants { get; }

        public int AvailableParticipantsCount();
    }
}
