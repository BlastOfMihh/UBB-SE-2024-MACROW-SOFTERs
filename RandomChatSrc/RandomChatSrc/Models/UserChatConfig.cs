// <copyright file="UserChatConfig.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RandomChatSrc.Models
{
    /// <summary>
    /// Represents the User's chat configuration.
    /// </summary>
    public class UserChatConfig
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserChatConfig"/> class.
        /// </summary>
        /// <param name="user">The User associated with this chat configuration.</param>
        public UserChatConfig(User user)
        {
            this.User = user;
        }

        /// <summary>
        /// Gets or sets the User associated with this chat configuration.
        /// </summary>
        public User User { get; set; }
    }
}