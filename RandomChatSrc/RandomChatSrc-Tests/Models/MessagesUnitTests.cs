using RandomChatSrc.Models;

namespace RandomChatTests.Models
{
    [TestClass]
    public class MessageUnitTests
    {
        [TestMethod]
        public void TestMessageConstructor_SetsProperties()
        {
            // Arrange
            Guid messageId = Guid.NewGuid();
            string senderId = "user123";
            string textChatFolderPath = "/path/to/folder";
            string messagePath = "/path/to/message";
            DateTime sentTime = DateTime.Now;
            string content = "Hello, world!";

            // Act
            var message = new Message(messageId, senderId, textChatFolderPath, messagePath, sentTime, content);

            // Assert
            Assert.AreEqual(messageId, message.Id);
            Assert.AreEqual(senderId, message.SenderId);
            Assert.AreEqual(textChatFolderPath, message.ChatFolderPath);
            Assert.AreEqual(messagePath, message.MessagePath);
            Assert.AreEqual(sentTime, message.SentTime);
            Assert.AreEqual(content, message.Content);
        }
    }
}