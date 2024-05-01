// <copyright file="UserRepository.cs" company="Superbet Beclean">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RandomChatSrc.Repositories
{
    using RandomChatSrc.Models;

    /// <summary>
    ///     Class responsible for storing and getting Users from the repository.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="users">The list of users to store in the repository.</param>
        public UserRepository(List<User> users)
        {
            this.Users = users;
        }

        private List<User> Users { get; set; }

        /// <summary>
        ///     Searches for a user with the specified ID in the repository.
        /// </summary>
        /// <param name="id">The ID of the user to search for.</param>
        /// <returns>The user with the specified ID, if it's found.</returns>
        public User GetUserById(Guid id)
        {
            return this.Users.FirstOrDefault(user => user.Id == id);
        }
    }
}
