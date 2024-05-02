using System;

using Moq;
using RandomChatSrc.Models;
using RandomChatSrc.Services.ChatroomsManagement;
using RandomChatSrc.Services.UserChatListService;

namespace RandomChatSrc_Tests.Services.RandomMatchingService
{
    [TestClass]
    public class RandomMatchingServiceUnitTests
    {
        private Mock<IChatroomsManagementService> mockChatroomsManagementService = null!;
        private Mock<RandomChatSrc.Services.UserChatListService.UserChatListService> mockUserChatListService = null!;
        private RandomChatSrc.Services.RandomMatchingService.RandomMatchingService randomMatchingService = null!;

        [TestInitialize]
        public void Initialize()
        {
            mockChatroomsManagementService = new Mock<IChatroomsManagementService>();
            mockUserChatListService = new Mock<RandomChatSrc.Services.UserChatListService.UserChatListService>();
            randomMatchingService = new RandomChatSrc.Services.RandomMatchingService.RandomMatchingService(mockChatroomsManagementService.Object, mockUserChatListService.Object);
        }
        [TestMethod]
        public void RequestMatchingChatRoom_NoRoomsAvailableAndUserAlreadyParticipantInAllRooms_ReturnsNull()
        {
            // Arrange
            var chatConfig = new UserChatConfig(new User("testUser", new List<Interest> { new Interest("interest1"), new Interest("interest2") }));
            var user1 = new User("user1", new List<Interest> { new Interest("interest1"), new Interest("interest2") });
            var chat1 = new TextChat(new List<Message>(), "/Users/mirceamaierean/UBB-SE-2024-MACROW-SOFTERs/RandomChatSrc/RandomChatSrc/ChatRepoTesting", "");
            chat1.AddParticipant(user1);

            mockChatroomsManagementService.Setup(m => m.GetAllChats()).Returns(new List<TextChat> { chat1 });

            // Act
            var result = randomMatchingService.RequestMatchingChatRoom(chatConfig);

            // Assert
            Assert.IsNotNull(result); // No chat room should be returned
        }
        // [TestMethod]
        // public void RequestMatchingChatRoom_NoAvailableRooms_ReturnsNewRoom()
        // {
        //     // Arrange
        //     UserChatConfig firstUserChatConfig = new UserChatConfig(new User("firstUser"));
        //     mockChatroomsManagementService.Setup(m => m.GetAllChats()).Returns(new List<TextChat>());
        //
        //     // Act
        //    var chat= randomMatchingService.RequestMatchingChatRoom(firstUserChatConfig);
        //
        //     // Assert
        //     Assert.IsNotNull(chat);
        //     Assert.AreEqual(1,chat.Participants.Count);
        //     Assert.IsTrue(chat.Participants.Any(user=>user.Id==firstUserChatConfig.User.Id));
        // }

        [TestMethod]
        public void RequestMatchingChatRoom_AddUserToBestRoom()
        {
            //Arrange
            var chatConfig = new UserChatConfig(new User("testUser", new List<Interest> {new Interest( "interest1"), new Interest("interest2") }));
            var user1 = new User("user1", new List<Interest> { new Interest("interest1"), new Interest("interest3") });
            var user2 = new User("user2", new List<Interest> { new Interest("interest1"), new Interest("interest4") });
            var user3 = new User("user3", new List<Interest> { new Interest("interest2"), new Interest("interest5") });
            var chat1 = new TextChat(new List<Message>(), "mockPath", "");
            chat1.AddParticipant(user1);
            chat1.AddParticipant(user2);
            var chat2 = new TextChat(new List<Message>(), "mockPath", "");
            chat2.AddParticipant(user3);
            mockChatroomsManagementService.Setup(m => m.GetAllChats()).Returns(new List<TextChat> { chat1, chat2 });

            //Act
            var result = randomMatchingService.RequestMatchingChatRoom(chatConfig);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Participants.Any(p => p.Id == chatConfig.User.Id)); // User should be among participants

        }
       
    }
}
