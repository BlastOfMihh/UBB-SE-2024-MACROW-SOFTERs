using Moq;
using RandomChatSrc.Models;

namespace RandomChatSrc_Tests.Services.MessageService
{
    [TestClass]
    public class MessageServiceUnitTests
    {
        private Mock<TextChat> mockTextChat = null!;
        private Guid testUserId;

        [TestInitialize]
        public void Initialize()
        {
            mockTextChat = new Mock<TextChat>(
                    new List<Message>(),
                    "mockPath",
                    "")
            {
                CallBase = true
            };
            testUserId = Guid.NewGuid();
        }

        [TestMethod]
        public void Constructor_ValidParameters_CreatesInstance()
        {
            // Arrange & Act
            var messageService = new RandomChatSrc.Services.MessageService.MessageService(mockTextChat.Object, testUserId);

            // Assert
            Assert.IsNotNull(messageService);
        }

        public Guid GetTestUserId()
        {
            return testUserId;
        }

        [TestMethod]
        public void SendMessage_ValidMessage_CallsAddMessage()
        {
            // Arrange
            var textChat = new TextChat(
                new List<Message>(),
                "mockPath");
            var testUserId = Guid.NewGuid();
            var messageService = new RandomChatSrc.Services.MessageService.MessageService(textChat, testUserId);
            string message = "Random test message";

            // Act
            messageService.SendMessage(message);

            // Assert
            Assert.IsTrue(textChat.Messages.Any(m => m.SenderId == testUserId.ToString() && m.Content == message));
        }


        [TestMethod]
        public void GetTextChat_ReturnsTextChatInstance()
        {
            // Arrange
            var messageService = new RandomChatSrc.Services.MessageService.MessageService(mockTextChat.Object, testUserId);

            // Act
            var result = messageService.GetTextChat();

            // Assert
            Assert.AreEqual(mockTextChat.Object, result);
        }
    }
}
