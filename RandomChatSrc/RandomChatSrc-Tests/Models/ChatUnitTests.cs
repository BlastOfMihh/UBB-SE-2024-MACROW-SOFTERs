using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomChatSrc.Models;

namespace RandomChatTests.Models
{
    [TestClass]
    public class ChatUnitTests
    {
        [TestMethod]
        public void TestAddParticipant_ChatNotFull_AddsParticipant()
        {
            // Arrange
            var chat = new Chat();
            var user = new User("randomUserName");

            // Act
            chat.AddParticipant(user);

            // Assert
            Assert.IsTrue(chat.Participants.Contains(user));
        }

        [TestMethod]
        public void TestAddParticipant_ChatFull_ThrowsException()
        {
            // Arrange
            var chat = new Chat(2);
            var firstUserForTesting = new User("randomUserName");
            var secondUserForTesting = new User("randomUserName");
            var thirdUserForTesting = new User("randomUserName");

            // Act
            chat.AddParticipant(firstUserForTesting);
            chat.AddParticipant(secondUserForTesting);

            // Assert
            Assert.ThrowsException<InvalidOperationException>(() => chat.AddParticipant(thirdUserForTesting));
        }

        [TestMethod]
        public void TestAvailableParticipantsCount_ReturnsCorrectCount()
        {
            // Arrange
            var chat = new Chat(3);
            var firstUserForTesting = new User("randomUserName");
            var secondUserForTesting = new User("randomUserName");
            // Act
            chat.AddParticipant(firstUserForTesting);
            chat.AddParticipant(secondUserForTesting);

            // Assert
            Assert.AreEqual(1, chat.AvailableParticipantsCount());
        }
    }
}