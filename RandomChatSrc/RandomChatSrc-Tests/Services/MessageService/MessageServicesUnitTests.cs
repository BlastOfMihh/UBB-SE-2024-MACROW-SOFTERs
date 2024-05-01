using RandomChatSrc.Services.MessageService;
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
            mockTextChat = new Mock<TextChat>();
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

        [TestMethod]
        public void SendMessage_ValidMessage_CallsAddMessage()
        {
            // Arrange
            var messageService = new RandomChatSrc.Services.MessageService.MessageService(mockTextChat.Object, testUserId);
            string message = "Random test message";

            // Act
            messageService.SendMessage(message);

            // Assert
            mockTextChat.Verify(chat => chat.AddMessage(testUserId.ToString(), message), Times.Once);
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
