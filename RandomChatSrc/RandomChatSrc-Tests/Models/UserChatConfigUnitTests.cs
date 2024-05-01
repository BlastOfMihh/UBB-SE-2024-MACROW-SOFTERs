using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomChatSrc.Models;
using System;

namespace RandomChatTests.Models
{
    [TestClass]
    public class UserChatConfigUnitTests
    {
        [TestMethod]
        public void TestUserChatConfigConstructor_SetsUser()
        {
            // Arrange
            var user = new User("John");

            // Act
            var userChatConfig = new UserChatConfig(user);

            // Assert
            Assert.AreEqual(user, userChatConfig.User);
        }
    }
}