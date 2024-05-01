using Moq;
using RandomChatSrc.Models;
using RandomChatSrc.Repositories;

namespace RandomChatSrc_Tests.Services.MapService
{
    [TestClass]
    public class MapServiceUnitTests
    {
        private Mock<IMapRepository> mockMapRepo;
        private Mock<RandomChatSrc.Services.GlobalServices.GlobalServices> mockGlobalServices;
        private RandomChatSrc.Services.MapService.IMapService mapService;

        [TestInitialize]
        public void Initialize()
        {
            // Initialize mock objects
            mockMapRepo = new Mock<IMapRepository>();
            mockGlobalServices = new Mock<RandomChatSrc.Services.GlobalServices.GlobalServices>();

            // Initialize MapService with mocked dependencies
            mapService = new RandomChatSrc.Services.MapService.MapService(mockMapRepo.Object, mockGlobalServices.Object);
        }

        [TestMethod]
        public void Constructor_ValidParameters_CreatesInstance()
        {
            // Arrange & Act
            mapService = new RandomChatSrc.Services.MapService.MapService(mockMapRepo.Object, mockGlobalServices.Object);

            // Assert
            Assert.IsNotNull(mapService);
        }

        [TestMethod]
        public void GetAllUserLocations_ValidData_ReturnsLocations()
        {
            // Arrange
            var expectedLocations = new List<MapLocation> { new MapLocation(Guid.NewGuid(), 1.0f, 2.0f), new MapLocation(Guid.NewGuid(), 3.0f, 4.0f) };
            mockMapRepo.Setup(repo => repo.GetAllUsersLocationList()).Returns(expectedLocations);

            // Act
            var result = mapService.GetAllUserLocations();

            // Assert
            CollectionAssert.AreEqual(expectedLocations, result);
        }

        [TestMethod]
        public void GetAllUsers_ValidData_ReturnsUserIds()
        {
            // Arrange
            var userId1 = Guid.NewGuid();
            var userId2 = Guid.NewGuid();
            var locations = new List<MapLocation>
            {
                new MapLocation(userId1, 1.0f, 2.0f),
                new MapLocation(Guid.Empty, 3.0f, 4.0f), // Ignored
                new MapLocation(userId2, 5.0f, 6.0f)
            };
            mockMapRepo.Setup(repo => repo.GetAllUsersLocationList()).Returns(locations);

            // Act
            var result = mapService.GetAllUsers();

            // Assert
            CollectionAssert.AreEqual(new List<Guid> { userId1, userId2 }, result);
        }

        [TestMethod]
        public void MakeRequest_ValidParameters_CallsAddRequest()
        {
            // Arrange
            var senderId = Guid.NewGuid();
            var receiverId = Guid.NewGuid();

            // Act
            mapService.MakeRequest(senderId, receiverId);

            // Assert
            mockGlobalServices.Verify(gs => gs.RequestChatService.AddRequest(senderId, receiverId), Times.Once);
        }

        
        [TestMethod]
        public void UpdateUserLocation_ValidData_CallsUpdateUserLocation()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var location = new MapLocation(userId, 1.0f, 2.0f);

            // Act
            mapService.UpdateUserLocation(userId, location);

            // Assert
            mockMapRepo.Verify(repo => repo.UpdateUserLocation(userId, location), Times.Once);
        }
    }
}
