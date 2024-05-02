using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomChatSrc.Models;
using System;

namespace RandomChatTests.Models
{
    [TestClass]
    public class MapLocationUnitTests
    {
        [TestMethod]
        public void TestMapLocationConstructor_SetsProperties()
        {
            // Arrange
            Guid userId = Guid.NewGuid();
            float xCoordinates = 10.5f;
            float yCoordinates = 20.7f;
            string description = "User's current location";

            // Act
            var mapLocation = new MapLocation(userId, xCoordinates, yCoordinates, description);

            // Assert
            Assert.AreEqual(userId, mapLocation.UserId);
            Assert.AreEqual(xCoordinates, mapLocation.XCoordinates);
            Assert.AreEqual(yCoordinates, mapLocation.YCoordinates);
            Assert.AreEqual(description, mapLocation.Description);
        }

        [TestMethod]
        public void TestMapLocationConstructor_DefaultDescription_IsEmptyString()
        {
            // Arrange
            Guid userId = Guid.NewGuid();
            float xCoordinates = 10.5f;
            float yCoordinates = 20.7f;

            // Act
            var mapLocation = new MapLocation(userId, xCoordinates, yCoordinates);

            // Assert
            Assert.AreEqual(userId, mapLocation.UserId);
            Assert.AreEqual(xCoordinates, mapLocation.XCoordinates);
            Assert.AreEqual(yCoordinates, mapLocation.YCoordinates);
            Assert.AreEqual("", mapLocation.Description);
        }

        [TestMethod]
        public void TestMapLocationConstructor_NegativeCoordinates_AreSetCorrectly()
        {
            // Arrange
            Guid userId = Guid.NewGuid();
            float xCoordinates = -10.5f;
            float yCoordinates = -20.7f;

            // Act
            var mapLocation = new MapLocation(userId, xCoordinates, yCoordinates);

            // Assert
            Assert.AreEqual(userId, mapLocation.UserId);
            Assert.AreEqual(xCoordinates, mapLocation.XCoordinates);
            Assert.AreEqual(yCoordinates, mapLocation.YCoordinates);
        }
    }
}
