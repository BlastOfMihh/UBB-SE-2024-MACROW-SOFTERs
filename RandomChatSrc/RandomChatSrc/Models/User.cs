// <copyright file="User.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RandomChatSrc.Models
{
    /// <summary>
    /// Represents a User in the chat application.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="name">The name of the User.</param>
        /// <param name="interests">A list of the User's interests. If null, an empty list will be assigned.</param>
        public User(string name, List<Interest>? interests = null)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Interests = interests ?? new List<Interest>();
        }

        /// <summary>
        /// Gets or sets the unique identifier for the User.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the User.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the list of interests of the User.
        /// </summary>
        public List<Interest> Interests { get; set; }

        /// <summary>
        /// Adds a new interest to the User's list of interests.
        /// </summary>
        /// <param name="interest">The interest to add.</param>
        public void AddInterest(Interest interest)
        {
            this.Interests.Add(interest);
        }
    }
}