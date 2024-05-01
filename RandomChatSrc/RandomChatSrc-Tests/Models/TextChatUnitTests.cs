namespace RandomChatTests.Models
{
    using RandomChatSrc.Models;
    using System.Xml.Linq;

    [TestClass]
    public class TextChatUnitTests
    {
        [TestMethod]
        public void TestTextChatConstructor_SetsProperties()
        {
            // Arrange
            var messages = new List<Message>
            {
                new Message(Guid.NewGuid(), "user1", "/Users/mirceamaierean/UBB-SE-2024-MACROW-SOFTERs/RandomChatSrc/RandomChatSrc/ChatRepo", "/path/to/message1.xml", DateTime.Now, "Hello"),
                new Message(Guid.NewGuid(), "user2", "/Users/mirceamaierean/UBB-SE-2024-MACROW-SOFTERs/RandomChatSrc/RandomChatSrc/ChatRepo", "/path/to/message2.xml", DateTime.Now, "Hi there")
            };
            string chatFolderPath = "/path/to/chat/folder";

            // Act
            var textChat = new TextChat(messages, chatFolderPath);

            // Assert
            Assert.IsNotNull(textChat.Id);
            CollectionAssert.AreEqual(messages, textChat.Messages);
            Assert.AreEqual(Path.Combine(chatFolderPath, textChat.Id.ToString()), textChat.MessagesFolderPath);
        }

        [TestMethod]
        public void TestAddMessage_AddsMessageToListAndCreatesFile()
        {
            // Arrange
            var textChat = new TextChat(new List<Message>(), "/Users/mirceamaierean/UBB-SE-2024-MACROW-SOFTERs/RandomChatSrc/RandomChatSrc/ChatRepo");
            string senderId = "user1";
            string messageContent = "Hello, world!";

            // Act
            textChat.AddMessage(senderId, messageContent);

            // Assert
            Assert.AreEqual(1, textChat.Messages.Count);
            Assert.IsTrue(textChat.Messages.Any(m => m.SenderId == senderId && m.Content == messageContent));
            Assert.IsTrue(File.Exists(Path.Combine(textChat.MessagesFolderPath, $"message_{textChat.Messages[0].Id}.xml")));
        }

        [TestMethod]
        public void TestLoadStoredMessages_LoadsMessagesFromFiles()
        {
            // Arrange
            string chatFolderPath = "/Users/mirceamaierean/UBB-SE-2024-MACROW-SOFTERs/RandomChatSrc/RandomChatSrc/ChatRepo";
            var message1 = new Message(Guid.NewGuid(), "10030000-0300-0200-0000-000000000000", chatFolderPath, "/Users/mirceamaierean/UBB-SE-2024-MACROW-SOFTERs/RandomChatSrc/RandomChatSrc/ChatRepo/1e49c926-4cb5-4add-93ee-589d8ec48137/message_14da8097-74e8-4c83-8791-ffe09d6b3576.xml", DateTime.Now, "hello");
            var message2 = new Message(Guid.NewGuid(), "00000000-0000-0000-0000-000000000000", chatFolderPath, "/Users/mirceamaierean/UBB-SE-2024-MACROW-SOFTERs/RandomChatSrc/RandomChatSrc/ChatRepo/1e49c926-4cb5-4add-93ee-589d8ec48137/message_b9f90344-6241-4a4b-953a-54f818a5eb8d.xml", DateTime.Now, "a");
            var messages = new List<Message> { message1, message2 };
            Directory.CreateDirectory(chatFolderPath);
            messages.ForEach(message =>
            {
                var messageDoc = new XDocument(
                    new XElement(
                        "messages",
                        new XElement(
                            "message",
                            new XElement("sender", message.SenderId),
                            new XElement("timestamp", message.SentTime.ToString("yyyy-MM-ddTHH:mm:ss")),
                            new XElement("content", message.Content))));
                messageDoc.Save(Path.Combine(chatFolderPath, $"message_{message.Id}.xml"));
            });

            // Act
            var textChat = new TextChat(new List<Message>(), chatFolderPath);

            // Assert
            CollectionAssert.AreEqual(messages, textChat.Messages);
        }

        [TestMethod]
        public void TestExtractMessageIdFromPath_ReturnsCorrectId()
        {
            // Arrange
            var textChat = new TextChat(new List<Message>(), "/Users/mirceamaierean/UBB-SE-2024-MACROW-SOFTERs/RandomChatSrc/RandomChatSrc/ChatRepo");
            string path = "/Users/mirceamaierean/UBB-SE-2024-MACROW-SOFTERs/RandomChatSrc/RandomChatSrc/ChatRepo/1e49c926-4cb5-4add-93ee-589d8ec48137/message_14da8097-74e8-4c83-8791-ffe09d6b3576.xml";

            // Act
            var messageId = textChat.ExtractMessageIdFromPath(path);

            // Assert
            Assert.AreEqual("sender", messageId.ToString());
        }

        [TestMethod]
        public void TestEnsureDirectoryExists_CreatesDirectoryIfNotExists()
        {
            // Arrange
            string path = "/Users/mirceamaierean/UBB-SE-2024-MACROW-SOFTERs/RandomChatSrc/RandomChatSrc/ChatRepo";

            // Assert
            Assert.IsTrue(Directory.Exists(path));

            // Cleanup
            Directory.Delete(path);
        }
    }
}
