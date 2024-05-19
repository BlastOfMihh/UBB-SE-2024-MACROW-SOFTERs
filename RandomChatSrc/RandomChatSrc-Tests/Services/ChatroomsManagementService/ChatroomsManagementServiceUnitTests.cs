using RandomChatSrc.Models;
using RandomChatSrc.Services.ChatroomsManagement;


namespace RandomChatSrc_Tests.Services.ChatroomsManagement
{
    [TestClass]
    public class ChatroomsManagementServiceUnitTests
    {
        private ChatroomsManagementService chatroomsManagementService = null!;
        private List<TextChat> activeChats = new List<TextChat>();
        private string mockChatFolderPath = "C:\\Users\\Admin\\Desktop\\ubb\\iss\\newapp\\UBB-SE-2024-MACROW-SOFTERs\\RandomChatSrc\\RandomChatSrc\\ChatRepoTesting\\";
        [TestInitialize]
        public void Initialize()
        {
            Directory.CreateDirectory(mockChatFolderPath);
            chatroomsManagementService = new ChatroomsManagementService(mockChatFolderPath);
            activeChats = chatroomsManagementService.GetAllChats();
        }

        [TestMethod]
        public void Constructor_InitializesActiveChats()
        {
            // Assert
            Assert.IsNotNull(activeChats);
            Assert.AreEqual(0, activeChats.Count);
        }

        [TestMethod]
        public void CreateChat_ReturnsNewChat()
        {
            // Act
            var newChat = chatroomsManagementService.CreateChat();
            activeChats = chatroomsManagementService.GetAllChats();

            // Assert
            Assert.IsNotNull(newChat);
            Assert.IsTrue(activeChats.Contains(newChat));
        }

        [TestMethod]
        public void DeleteChat_RemovesChat()
        {
            // Arrange
            var newChat = chatroomsManagementService.CreateChat();
            var chatId = newChat.Id;

            // Act
            chatroomsManagementService.DeleteChat(chatId);
            activeChats = chatroomsManagementService.GetAllChats();

            // Assert
            Assert.IsFalse(activeChats.Contains(newChat));
        }

        [TestMethod]
        public void GetChat_ReturnsRandomChat()
        {
            // Arrange
            var newChat1 = chatroomsManagementService.CreateChat();
            var newChat2 = chatroomsManagementService.CreateChat();

            // Act
            var randomChat1 = chatroomsManagementService.GetChat();
            var randomChat2 = chatroomsManagementService.GetChat();

            // Assert
            Assert.IsNotNull(randomChat1);
            Assert.IsNotNull(randomChat2);
        }

        [TestMethod]
        public void GetChatById_ReturnsCorrectChat()
        {
            // Arrange
            var newChat = chatroomsManagementService.CreateChat();
            var chatId = newChat.Id;

            // Act
            var retrievedChat = chatroomsManagementService.GetChatById(chatId);

            // Assert
            Assert.AreEqual(newChat, retrievedChat);
        }

        [TestMethod]
        public void GetAllChats_ReturnsAllActiveChats()
        {
            // Arrange
            var newChat1 = chatroomsManagementService.CreateChat();
            var newChat2 = chatroomsManagementService.CreateChat();

            // Act
            var allChats = chatroomsManagementService.GetAllChats();

            // Assert
            Assert.IsNotNull(allChats);
            CollectionAssert.Contains(allChats, newChat1);
            CollectionAssert.Contains(allChats, newChat2);
        }
    }
}
