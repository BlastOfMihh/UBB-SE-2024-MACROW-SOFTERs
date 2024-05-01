using Moq;
using RandomChatSrc.Repositories;
using RandomChatSrc.Services.ChatroomsManagement;
using RandomChatSrc.Services.GlobalServices;
using RandomChatSrc.Services.MapService;
using RandomChatSrc.Services.RequestChatService;

namespace RandomChatSrc.RandomChatSrc_Tests.Services.GlobalServiceUnitTests
{
    [TestClass]
    public class GlobalServiceUnitTests
    {
        private Mock<IChatroomsManagementService> mockChatroomsManagementService = null!;
        private Mock<IMapService> mockMapService = null!;
        private Mock<IRequestChatService> mockRequestChatService = null!;
        private Mock<IUserRepository> mockUserRepository = null!;

        [TestInitialize]
        public void Initialize()
        {
            mockChatroomsManagementService = new Mock<IChatroomsManagementService>();
            mockMapService = new Mock<IMapService>();
            mockRequestChatService = new Mock<IRequestChatService>();
            mockUserRepository = new Mock<IUserRepository>();
        }

        [TestMethod]
        public void TestGetGlobalService_CorrectlyInstantiated_ReturnsInstance()
        {
            // Arrange
            var globalServices = new GlobalServices(mockChatroomsManagementService.Object, mockMapService.Object, mockRequestChatService.Object, mockUserRepository.Object);

            // Act
            // No action needed since we're testing the constructor

            // Assert
            Assert.IsNotNull(globalServices);
        }

        [TestMethod]
        public void TestGetChatroomsManagementService_ReturnsInstance()
        {
            // Arrange
            var globalServices = new GlobalServices(mockChatroomsManagementService.Object, mockMapService.Object, mockRequestChatService.Object, mockUserRepository.Object);

            // Act
            var chatroomsManagementService = globalServices.ChatroomsManagementService;

            // Assert
            Assert.IsNotNull(chatroomsManagementService);
        }

        [TestMethod]
        public void TestGetMapService_ReturnsInstance()
        {
            // Arrange
            var globalServices = new GlobalServices(mockChatroomsManagementService.Object, mockMapService.Object, mockRequestChatService.Object, mockUserRepository.Object);

            // Act
            var mapService = globalServices.MapService;

            // Assert
            Assert.IsNotNull(mapService);
        }

        [TestMethod]
        public void TestGetRequestChatService_ReturnsInstance()
        {
            // Arrange
            var globalServices = new GlobalServices(mockChatroomsManagementService.Object, mockMapService.Object, mockRequestChatService.Object, mockUserRepository.Object);

            // Act
            var requestChatService = globalServices.RequestChatService;

            // Assert
            Assert.IsNotNull(requestChatService);
        }

        [TestMethod]
        public void TestGetUserRepository_ReturnsInstance()
        {
            // Arrange
            var globalServices = new GlobalServices(mockChatroomsManagementService.Object, mockMapService.Object, mockRequestChatService.Object, mockUserRepository.Object);

            // Act
            var userRepository = globalServices.UserRepository;

            // Assert
            Assert.IsNotNull(userRepository);
        }
    }
}
