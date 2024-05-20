using Moq;
using RandomChatSrc.Models;

namespace RandomChatSrc_Tests.Services.MessageService
{
    [TestClass]
    public class MessageServiceUnitTests
    {
        private Mock<Chat> mockChat = null!;
        private Guid testUserId;

        [TestInitialize]
        public void Initialize()
        {
            mockChat = new Mock<Chat>(
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
            var messageService = new RandomChatSrc.Services.MessageService.MessageService(mockChat.Object, testUserId);

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
            var textChat = new Chat(
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
        public void GetChat_ReturnsChatInstance()
        {
            // Arrange
            var messageService = new RandomChatSrc.Services.MessageService.MessageService(mockChat.Object, testUserId);

            // Act
            var result = messageService.GetChat();

            // Assert
            Assert.AreEqual(mockChat.Object, result);
        }
    }
}
