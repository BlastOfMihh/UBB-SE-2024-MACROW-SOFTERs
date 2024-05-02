using Moq;
using RandomChatSrc.Models;
using RandomChatSrc.Services.ChatroomsManagement;
using RandomChatSrc.Services.UserChatListService;
namespace RandomChatSrc_Tests.Services.UserChatListService
{
    [TestClass]
    public class UserChatListServiceUnitTests
    {
        private Mock<IChatroomsManagementService> mockChatroomsManagementService=null!;
        private Guid testCurrentUserId;

        private RandomChatSrc.Services.UserChatListService.UserChatListService userChatListService = null! ;

        [TestInitialize]
        public void Initialize()
        {
            mockChatroomsManagementService=new Mock<IChatroomsManagementService>();
            testCurrentUserId= Guid.NewGuid();
            userChatListService = new RandomChatSrc.Services.UserChatListService.UserChatListService(mockChatroomsManagementService.Object);
        }

        [TestMethod]
        public void GetOpenChats_ActiveUsers_ReturnsCorrectChats()
        {
            //Arrange
            
            var chat1 = new TextChat(new List<Message>(),"mockPath","");
            var chat2 = new TextChat(new List<Message>(), "mockPath", "");
            var allChats = new List<TextChat>{chat1, chat2}; 
            mockChatroomsManagementService.Setup(m=>m.GetAllChats()).Returns(allChats);
            User firstUser = new User("userA");
            User secondUser = new User("userB");
            User thirdUser = new User("userC");
            firstUser.Id = testCurrentUserId; 
            userChatListService.CurrentUserId = testCurrentUserId;
            chat1.AddParticipant(firstUser);
            chat1.AddParticipant(thirdUser);
            chat2.AddParticipant(secondUser);
            chat2.AddParticipant(firstUser);

            //Act
          
            var openChats=userChatListService.GetOpenChats();

            //Assert
            Assert.IsNotNull(openChats);
            Assert.AreEqual(2, openChats.Count);
            Assert.IsTrue(openChats.All(chat=>chat.Participants.Any(user=>user.Id == testCurrentUserId)));

        }

        [TestMethod]
        public void GetOpenChats_CurrentUserNotParticipant_ReturnsCorrectChats()
        {
            //Arrange
            var chat1 = new TextChat(new List<Message>(), "mockPath", "");
            var chat2 = new TextChat(new List<Message>(), "mockPath", "");
            var allChats = new List<TextChat> { chat1, chat2 };
            mockChatroomsManagementService.Setup(m => m.GetAllChats()).Returns(allChats);
            User firstUser = new User("userA");
            User secondUser = new User("userB");
            User thirdUser = new User("userC");
            firstUser.Id = testCurrentUserId;
            firstUser.Id = testCurrentUserId;
            chat1.AddParticipant(secondUser);
            chat2.AddParticipant(thirdUser);

            //Act
            var openChats = userChatListService.GetOpenChats();

            // Assert
            Assert.IsNotNull(openChats);
            Assert.AreEqual(0, openChats.Count);

        }

        [TestMethod]
        public void GetOpenChats_NoChatsReturned()
        {
            // Arrange
            mockChatroomsManagementService.Setup(m => m.GetAllChats()).Returns(new List<TextChat>());

            // Act
            var openChats = userChatListService.GetOpenChats();

            // Assert
            Assert.IsNotNull(openChats);
            Assert.AreEqual(0, openChats.Count);
        }
        
        [TestMethod]
        public void InvalidPathForFile_Returns0()
        {
            // Arrange
            var invalidPath = "invalidPath";
            mockChatroomsManagementService.Setup(m => m.GetAllChats()).Returns(new List<TextChat>());
            userChatListService = new RandomChatSrc.Services.UserChatListService.UserChatListService(mockChatroomsManagementService.Object, invalidPath);

            // Assert
            Assert.AreEqual(0, userChatListService.GetOpenChats().Count);
        }
    }
}
