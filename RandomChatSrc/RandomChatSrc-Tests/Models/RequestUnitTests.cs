using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomChatSrc.Models;
using System;

namespace RandomChatTests.Models
{
    [TestClass]
    public class RequestUnitTests
    {
        [TestMethod]
        public void TestRequestConstructor_SetsProperties()
        {
            // Arrange
            Guid requestId = Guid.NewGuid();
            Guid senderUserId = Guid.NewGuid();
            Guid receiverUserId = Guid.NewGuid();
            string requestPath = "/path/to/request";

            // Act
            var request = new Request(requestId, senderUserId, receiverUserId, requestPath);

            // Assert
            Assert.AreEqual(requestId, request.RequestId);
            Assert.AreEqual(senderUserId, request.SenderUserId);
            Assert.AreEqual(receiverUserId, request.ReceiverUserId);
            Assert.AreEqual(requestPath, request.RequestPath);
        }
    }
}