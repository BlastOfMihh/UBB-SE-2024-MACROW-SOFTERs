using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RandomChatSrc.Models;
using RandomChatSrc.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace RandomChatSrc_Tests.Repositories
{
    [TestClass]
    public class MapRepositoryUnitTests
    {
        private MapRepository mapRepository = null!;
        private string mockFilePath = "C:\\Users\\Admin\\Desktop\\ubb\\iss\\newapp\\UBB-SE-2024-MACROW-SOFTERs\\RandomChatSrc\\RandomChatSrc\\RepoMock\\Locations_Testing.xml";
        [TestInitialize]
        public void Initialize()
        {
            // Create a mock XML file
            CreateMockXMLFile();

            // Initialize the map repository
            mapRepository = new MapRepository(mockFilePath);
        }

        [TestCleanup]
        public void Cleanup()
        {
            // Delete the mock XML file
            if (File.Exists(mockFilePath))
            {
                File.Delete(mockFilePath);
            }
        }

        [TestMethod]
        public void Constructor_InitializesMapRepository()
        {
            // Assert
            Assert.IsNotNull(mapRepository);
            Assert.IsNotNull(mapRepository.Locations);
            Assert.AreEqual(1, mapRepository.Locations.Count);
        }

        [TestMethod]
        public void AddUserLocation_AddsNewLocation()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var location = new MapLocation(userId, 10.5f, 20.7f, "Test Location");

            // Act
            mapRepository.AddUserLocation(userId, location);

            // Assert
            Assert.AreEqual(2, mapRepository.Locations.Count);
        }

        [TestMethod]
        public void RemoveUserLocation_RemovesLocation()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var location = new MapLocation(userId, 10.5f, 20.7f, "Test Location");
            mapRepository.AddUserLocation(userId, location);

            // Act
            mapRepository.RemoveUserLocation(userId);

            // Assert
            Assert.AreEqual(1, mapRepository.Locations.Count);
        }

        [TestMethod]
        public void UpdateUserLocation_UpdatesLocation()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var oldLocation = new MapLocation(userId, 10.5f, 20.7f, "Old Location");
            var newLocation = new MapLocation(userId, 30.5f, 40.7f, "New Location");
            mapRepository.AddUserLocation(userId, oldLocation);

            // Act
            mapRepository.UpdateUserLocation(userId, newLocation);

            // Assert
            Assert.AreEqual(2, mapRepository.Locations.Count);
        }

        private void CreateMockXMLFile(bool isEmpty = false)
        {
            // Create a sample XML file
            XDocument doc = new XDocument(
                new XElement("MapLocations")
            );
            if (!isEmpty)
            {
                doc = new XDocument(
                    new XElement("MapLocations",
                        new XElement("MapLocation",
                            new XElement("UserId", Guid.NewGuid()),
                            new XElement("xCoordinates", 10.5),
                            new XElement("yCoordinates", 20.7),
                            new XElement("description", "Sample Location"))
                    )
                );
            }

            doc.Save(mockFilePath);
        }
        
        [TestMethod]
        public void GetAllUsersLocationList_Returns_AllUserLocations()
        {
            // Arrange
            List<MapLocation> expectedLocations = new List<MapLocation>
            {
                new MapLocation(Guid.NewGuid(), 10.5f, 20.7f, "Location 1"),
                new MapLocation(Guid.NewGuid(), 30.2f, 40.9f, "Location 2")
            };

            // Create an instance of MapRepository and set the Locations property to the expected locations
            MapRepository mapRepository = new MapRepository();
            mapRepository.Locations = expectedLocations;

            // Act
            List<MapLocation> result = mapRepository.GetAllUsersLocationList();

            // Assert
            CollectionAssert.AreEqual(expectedLocations, result);
        }
    }
}
