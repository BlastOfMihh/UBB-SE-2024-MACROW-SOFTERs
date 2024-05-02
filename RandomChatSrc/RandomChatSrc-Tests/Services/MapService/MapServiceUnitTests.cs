using Moq;
using RandomChatSrc.Models;
using RandomChatSrc.Repositories;
using RandomChatSrc.Services.ChatroomsManagement;
using RandomChatSrc.Services.MapService;
using RandomChatSrc.Services.RequestChatService;

namespace RandomChatSrc_Tests.Services.MapService
{
    [TestClass]
    public class MapServiceUnitTests
    {
        private Mock<IMapRepository> mockMapRepo = null!;

        private Mock<IChatroomsManagementService> mockChatroomsManagementService = null!;
        private Mock<IMapService> mockMapService = null!;
        private Mock<IRequestChatService> mockRequestChatService = null!;
        private Mock<IUserRepository> mockUserRepository = null!;

        private RandomChatSrc.Services.GlobalServices.GlobalServices mockGlobalServices;
        private RandomChatSrc.Services.MapService.MapService mapService = null!;

        [TestInitialize]
        public void Initialize()
        {
            mockChatroomsManagementService = new Mock<IChatroomsManagementService>();
            mockMapService = new Mock<IMapService>();
            mockRequestChatService = new Mock<IRequestChatService>(MockBehavior.Strict); // Set MockBehavior to Strict
            mockUserRepository = new Mock<IUserRepository>();

            mockMapRepo = new Mock<IMapRepository>();
            mockGlobalServices = new RandomChatSrc.Services.GlobalServices.GlobalServices(mockChatroomsManagementService.Object, mockMapService.Object, mockRequestChatService.Object, mockUserRepository.Object);
            mapService = new RandomChatSrc.Services.MapService.MapService(mockMapRepo.Object, mockGlobalServices);
        }
        [TestMethod]
        public void Constructor_ValidParameters_CreatesInstance()
        {
            // Arrange & Act
            var mapService = new RandomChatSrc.Services.MapService.MapService(mockMapRepo.Object, mockGlobalServices);

            // Assert
            Assert.IsNotNull(mapService);
        }

        [TestMethod]
        public void GetAllUserLocations_Returns_AllUserLocations()
        {
            // Arrange
            var expectedLocations = new List<MapLocation>
            {
                new MapLocation(Guid.NewGuid(), 10.5f, 20.7f, "Location 1"),
                new MapLocation(Guid.NewGuid(), 30.2f, 40.9f, "Location 2")
            };
            mockMapRepo.Setup(repo => repo.GetAllUsersLocationList()).Returns(expectedLocations);

            // Act
            var result = mapService.GetAllUserLocations();

            // Assert
            CollectionAssert.AreEqual(expectedLocations, result);
        }

        [TestMethod]
        public void GetAllUsers_Returns_AllUserIdsWithKnownLocations()
        {
            // Arrange
            var expectedUserIds = new List<Guid>
            {
                Guid.NewGuid(),
                Guid.NewGuid()
            };
            var locations = new List<MapLocation>
            {
                new MapLocation(expectedUserIds[0], 10.5f, 20.7f, "Location 1"),
                new MapLocation(Guid.Empty, 30.2f, 40.9f, "Location 2"),
                new MapLocation(expectedUserIds[1], 50.3f, 60.1f, "Location 3")
            };
            mockMapRepo.Setup(repo => repo.GetAllUsersLocationList()).Returns(locations);

            // Act
            var result = mapService.GetAllUsers();

            // Assert
            CollectionAssert.AreEqual(expectedUserIds, result);
        }

        [TestMethod]
        public void UpdateUserLocation_Calls_UpdateUserLocation_In_MapRepository()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var location = new MapLocation(userId, 10.5f, 20.7f, "New Location");

            // Act
            mapService.UpdateUserLocation(userId, location);

            // Assert
            mockMapRepo.Verify(repo => repo.UpdateUserLocation(userId, location), Times.Once);
        }
    }
}
