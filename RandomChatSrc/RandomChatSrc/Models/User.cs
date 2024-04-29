namespace RandomChatSrc.Models
{
    public class User(string name, List<Interest>? interests = null)
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = name;

        public List<Interest> Interests { get; set; } = interests ?? [];

        public void AddInterest(Interest interest)
        {
            Interests.Add(interest);
        }
    }
}
