using Moq;
using RandomChatSrc.Models;
using RandomChatSrc.Repository;

namespace RandomChatSrc_Tests.Repositories.ChatRequestsRepositoryUnitTests
{
    [TestClass]
    public class ChatRequestsRepositoryUnitTests
    {

        private string requestsRepoPath = "";
        private Mock<List<Request>> mockRequests = null!;

        [TestInitialize]
        public void Initialize()
        {
            requestsRepoPath = "C:\\Users\\Admin\\Desktop\\ubb\\iss\\newapp\\UBB-SE-2024-MACROW-SOFTERs\\RandomChatSrc\\RandomChatSrc\\RequestRepo\\";
            mockRequests = new Mock<List<Request>>();
        }

        [TestMethod]
        public void TestGetChatRequestsRepository_CorrectlyInstantiated_ReturnsInstance()
        {
            // Arrange
            var requestsRepository = new ChatRequestsRepository(mockRequests.Object, requestsRepoPath);

            // Act
            // No action needed since we're testing the constructor

            // Assert
            Assert.IsNotNull(requestsRepository);
        }

        [TestMethod]
        public void TestGetChatRequestsRepository_CorrectlyLoadedExistingGuid_ReturnsInstance()
        {
            // Arrange
            var requestsRepository = new ChatRequestsRepository(mockRequests.Object, requestsRepoPath, new Guid("00000000-0000-0000-0000-000000000000"));
            // Act
            // No action needed since we're testing the constructor

            // Assert
            Assert.IsNotNull(requestsRepository);
        }

        [TestMethod]
        public void TestGetChatRequestsRepository_CorrectlyLoadedNewGuid_ReturnsInstance()
        {
            // Arrange
            var requestsRepository = new ChatRequestsRepository(mockRequests.Object, requestsRepoPath, new Guid("00000000-0000-0000-0000-000000000001"));

            // Act
            // Delete the directory for future testing
            DirectoryInfo di = new DirectoryInfo("C:\\Users\\Admin\\Desktop\\ubb\\iss\\newapp\\UBB-SE-2024-MACROW-SOFTERs\\RandomChatSrc\\RandomChatSrc\\RequestRepo\\00000000-0000-0000-0000-000000000001\\");
            di.Delete(true);

            // Assert
            Assert.IsNotNull(requestsRepository);
        }

        [TestMethod]
        public void TestGetAllChatRequests_ReturnsInstance()
        {
            // Arrange 
            var requestsRepository = new ChatRequestsRepository(mockRequests.Object, requestsRepoPath);

            // Act
            var allChatRequests = requestsRepository.GetAllChatRequests();

            // Assert
            Assert.IsNotNull(allChatRequests);
        }

        [TestMethod]
        public void TestAddRequest_ValidRequest_CallsAddRequest()
        {
            // Arrange
            var requestsRepository = new ChatRequestsRepository(mockRequests.Object, requestsRepoPath);
            var senderId_1 = Guid.NewGuid();
            var receiverId_1 = Guid.NewGuid();
            var senderId_2 = Guid.NewGuid();
            var receiverId_2 = Guid.NewGuid();

            // Act
            requestsRepository.AddRequest(senderId_1, receiverId_1);
            requestsRepository.AddRequest(senderId_2, receiverId_2);
            var allChatRequests = requestsRepository.GetAllChatRequests();
            var addedRequest_1 = allChatRequests[0];
            var addedRequest_2 = allChatRequests[1];

            // Assert
            Assert.IsNotNull(addedRequest_1);
            Assert.IsNotNull(addedRequest_2);
            Assert.AreEqual(2, allChatRequests.Count);
            Assert.AreEqual(senderId_1, addedRequest_1.SenderUserId);
            Assert.AreEqual(receiverId_1, addedRequest_1.ReceiverUserId);
            Assert.AreEqual(senderId_2, addedRequest_2.SenderUserId);
            Assert.AreEqual(receiverId_2, addedRequest_2.ReceiverUserId);
        }

        [TestMethod]
        public void TestRemoveRequest_ValidRequest_CallsRemoveRequest()
        {
            // Arrange
            var requestsRepository = new ChatRequestsRepository(mockRequests.Object, requestsRepoPath);
            var senderId_1 = Guid.NewGuid();
            var receiverId_1 = Guid.NewGuid();
            var senderId_2 = Guid.NewGuid();
            var receiverId_2 = Guid.NewGuid();

            // Act
            requestsRepository.AddRequest(senderId_1, receiverId_1);
            requestsRepository.AddRequest(senderId_2, receiverId_2);
            requestsRepository.RemoveRequest(senderId_1, receiverId_1);
            var allChatRequests = requestsRepository.GetAllChatRequests();
            var addedRequest_2 = allChatRequests[0];

            // Assert
            Assert.IsNotNull(addedRequest_2);
            Assert.AreEqual(1, allChatRequests.Count);
            Assert.AreEqual(senderId_2, addedRequest_2.SenderUserId);
            Assert.AreEqual(receiverId_2, addedRequest_2.ReceiverUserId);
        }


    }
}
