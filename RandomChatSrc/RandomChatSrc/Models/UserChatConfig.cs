namespace RandomChatSrc.Models
{
    /// <summary>
    /// Represents the User's chat configuration
    /// </summary>

    public class UserChatConfig(User user)
    {
        public User User { get; set; } = user;
    }
}
