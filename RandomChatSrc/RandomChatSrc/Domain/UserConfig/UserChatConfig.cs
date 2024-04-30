using RandomChatSrc.Models;

namespace RandomChatSrc.Domain.UserConfig
{
    public class UserChatConfig
    {
        public User User { get; set; }

        public UserChatConfig(User user)
        {
            User = user;
        }
    }
}
