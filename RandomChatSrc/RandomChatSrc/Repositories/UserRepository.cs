// <copyright file="MapRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RandomChatSrc.Repository
{
    using RandomChatSrc.Domain.UserDomain;

    /// <summary>
    ///     Class responsible for storing and getting Users from the repository.
    /// </summary>
    public class UserRepository
    {
        private List<User> users {  get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        public UserRepository(List<User> users)
        {
            this.users = users;
        }

        /// <summary>
        ///     Searches for a user with the specified ID in the repository.
        /// </summary>
        /// <param name="id">The ID of the user to search for.</param>
        /// <returns>The user with the specified ID, if it's found.</returns>
        public User getUserById(Guid id)
        {
            return this.users.FirstOrDefault(user => user.id == id);
        }
    }
}
