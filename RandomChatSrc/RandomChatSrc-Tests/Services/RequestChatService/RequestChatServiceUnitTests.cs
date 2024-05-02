using Moq;
using RandomChatSrc.Models;
using RandomChatSrc.Repositories;
using RandomChatSrc.Repository;
using RandomChatSrc.Services.ChatroomsManagement;
using RandomChatSrc.Services.GlobalServices;
using RandomChatSrc.Services.MapService;
using RandomChatSrc.Services.RequestChatService;

namespace RandomChatSrc_Tests.Services.RequestChatServiceUnitTest
{
    [TestClass]
    public class RequestChatServiceUnitTests
    {
        private string requestsRepoPath = "";
        private Mock<List<Request>> mockRequests = null!;
        private GlobalServices mockGlobalServices = null!;
        private ChatRequestsRepository mockRequestsRepo = null!;
        private ChatroomsManagementService mockChatroomsManagementService = null!;
        private Mock<IMapService> mockMapService = null!;
        private Mock<IRequestChatService> mockRequestChatService = null!;
        private Mock<IUserRepository> mockUserRepository = null!;

        [TestInitialize]
        public void Initialize()
        {
            requestsRepoPath = "";
            mockRequests = new Mock<List<Request>>();
            mockRequestsRepo = new ChatRequestsRepository(mockRequests.Object, requestsRepoPath);

            mockChatroomsManagementService = new ChatroomsManagementService();
            mockMapService = new Mock<IMapService>();
            mockRequestChatService = new Mock<IRequestChatService>();
            mockUserRepository = new Mock<IUserRepository>();

            mockGlobalServices = new GlobalServices(mockChatroomsManagementService, mockMapService.Object,
                mockRequestChatService.Object, mockUserRepository.Object);
        }

        [TestMethod]
        public void TestConstructor_ValidParameters_CreatesInstance()
        {
            // Arrange
            var requestService = new RequestChatService(mockRequestsRepo, mockGlobalServices);

            // Act
            // No need since we only test the constructor            

            // Assert
            Assert.IsNotNull(requestService);
        }

        [TestMethod]
        public void TestGetAllRequests_ReturnsInstance()
        {
            // Arrange
            var requestService = new RequestChatService(mockRequestsRepo, mockGlobalServices);

            // Act
            var allRequests = requestService.GetAllRequests();

            // Assert
            Assert.IsNotNull(allRequests);
        }


        [TestMethod]
        public void TestAddRequest_ValidGuid_CallsAddRequest()
        {
            // Arrange
            var requestService = new RequestChatService(mockRequestsRepo, mockGlobalServices);
            var senderId = Guid.NewGuid();
            var receiverId = Guid.NewGuid();

            // Act
            requestService.AddRequest(senderId, receiverId);
            var requests = requestService.GetAllRequests();
            var addedRequest = requests.First();

            // Assert
            Assert.IsNotNull(addedRequest);
            Assert.AreEqual(1, requests.Count);
            Assert.AreEqual(senderId, addedRequest.SenderUserId);
            Assert.AreEqual(receiverId, addedRequest.ReceiverUserId);
        }

        [TestMethod]
        public void TestDeclineRequest_ValidGuid_CallsDeclineRequest()
        {
            // Arrange
            var requestService = new RequestChatService(mockRequestsRepo, mockGlobalServices);
            var senderId = Guid.NewGuid();
            var receiverId = Guid.NewGuid();

            // Act
            requestService.AddRequest(senderId, receiverId);
            requestService.DeclineRequest(senderId, receiverId);
            var requests = requestService.GetAllRequests();

            // Assert
            Assert.AreEqual(0, requests.Count);
        }

        [TestMethod]
        public void TestAcceptRequest_ValidGuid_CallsAcceptRequest()
        {
            // Arrange
            var requestService = new RequestChatService(mockRequestsRepo, mockGlobalServices);
            var senderId = Guid.NewGuid();
            var receiverId = Guid.NewGuid();

            // Act
            requestService.AddRequest(senderId, receiverId);
            requestService.AcceptRequest(senderId, receiverId);
            var requests = requestService.GetAllRequests();

            // Assert
            Assert.AreEqual(0, requests.Count);
        }
    }
}