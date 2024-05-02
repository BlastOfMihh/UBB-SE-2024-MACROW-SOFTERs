using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomChatSrc.Models;
using RandomChatSrc.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RandomChatTests.Repositories
{
    [TestClass]
    public class UserRepositoryUnitTests
    {
        [TestMethod]
        public void TestUserRepositoryConstructor_SetsUsers()
        {
            // Arrange
            var users = new List<User>
            {
                new User("Alice"),
                new User("Bob"),
                new User("Charlie")
            };

            // Act
            var userRepository = new UserRepository(users);

            // Assert
            CollectionAssert.AreEqual(users, userRepository.Users);
        }

        [TestMethod]
        public void TestGetUserById_ReturnsUserWithSpecifiedId()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var users = new List<User>
            {
                new User("Alice") { Id = userId },
                new User("Bob"),
                new User("Charlie")
            };
            var userRepository = new UserRepository(users);

            // Act
            var user = userRepository.GetUserById(userId);

            // Assert
            Assert.IsNotNull(user);
            Assert.AreEqual(userId, user.Id);
        }

        [TestMethod]
        public void TestGetUserById_UserNotFound_ReturnsNull()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var users = new List<User>
            {
                new User("Alice"),
                new User("Bob"),
                new User("Charlie")
            };
            var userRepository = new UserRepository(users);

            // Act
            var user = userRepository.GetUserById(userId);

            // Assert
            Assert.IsNull(user);
        }
    }
}