// <copyright file="MapRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RandomChatSrc.Repositories
{
    using RandomChatSrc.Domain.MapLocation;
    using System.Xml.Linq;

    /// <summary>
    ///     Class responsible for getting and writing User Locations entities to the XML file.
    /// </summary>
    public class MapRepository : IMapRepo
    {
        private List<MapLocation> locations { get; set; }
        private string locationsPath;

        /// <summary>
        /// Initializes a new instance of the <see cref="MapRepository"/> class.
        /// </summary>
        public MapRepository()
        {
            //this.locationsPath = "C:\\Users\\RichardToth\\Projects\\UBB-ISS\\RandomChatSrc\\RandomChatSrc\\RepoMock\\Locations.xml";
            //this.locationsPath = "C:\\Users\\MiHH\\Gits\\UBB-SE-2024-MACROW-SOFTERs\\RandomChatSrc\\RandomChatSrc\\RepoMock\\";
            locationsPath = "C:\\GitHub_Repos\\UBB-SE-2024-MACROW-SOFTERs\\RandomChatSrc\\RandomChatSrc\\RepoMock\\";
            locations = new List<MapLocation>();
            loadFromMemory();
        }

        /// <summary>
        ///     Retrieves all User Locations from the XML file.
        /// </summary>
        public void loadFromMemory()
        {
            XDocument userLocationsXML = XDocument.Load(locationsPath);
            foreach (XElement location in userLocationsXML.Descendants("MapLocations"))
            {
                Guid userId = new Guid(location.Element("UserId").Value);
                float xCoordinates = float.Parse(location.Element("xCoordinates").Value);
                float yCoordinates = float.Parse(location.Element("yCoordinates").Value);
                string description = location.Element("description").Value;
                MapLocation newLocation = new MapLocation(userId, xCoordinates, yCoordinates, description);
                locations.Add(newLocation);
            }
        }

        /// <summary>
        ///     Adds a new User Location to the XML file. If the user already has a location,
        ///     his location will be updated.
        /// </summary>
        /// <param name="userID">The ID of the user.</param>
        /// <param name="userLocation">The location of the user.</param>
        public void addUserLocation(Guid userID, MapLocation userLocation)
        {
            if (locations.Contains(locations.Find(x => x.UserId == userID)))
            {
                updateUserLocation(userID, userLocation);
                XDocument userLocationsXML = XDocument.Load(locationsPath);
                userLocationsXML.Element("MapLocations").Add(new XElement("MapLocation", 
                                                        new XElement("UserId", userID), 
                                                        new XElement("xCoordinates", userLocation.xCoord),
                                                        new XElement("yCoordinates", userLocation.yCoord),
                                                        new XElement("description", userLocation.description)));
                userLocationsXML.Save(locationsPath);
            }
            else
            {
                locations.Add(userLocation);
                XDocument userLocationsXML = XDocument.Load(locationsPath);
                userLocationsXML.Element("MapLocations").Add(new XElement("MapLocation",
                                                        new XElement("UserId", userID),
                                                        new XElement("xCoordinates", userLocation.xCoord),
                                                        new XElement("yCoordinates", userLocation.yCoord),
                                                        new XElement("description", userLocation.description)));
                userLocationsXML.Save(locationsPath);
            }
        }

        /// <summary>
        ///     Deletes the User Location with ID from the XML file.
        /// </summary>
        /// <param name="userID">The ID of the User to delete.</param>
        public void removeUserLocation(Guid userID)
        {
            if (locations.Contains(locations.Find(x => x.UserId == userID)))
            {
                locations.Remove(locations.Find(x => x.UserId == userID));
            }
            XDocument userLocationsXML = XDocument.Load(locationsPath);
            userLocationsXML.Descendants("MapLocations").Where(x => x.Element("UserId").Value == userID.ToString()).Remove();
            userLocationsXML.Save(locationsPath);
        }

        /// <summary>
        ///     Updates the User Location with ID from the XML file.
        /// </summary>
        /// <param name="userID">The ID of the User to delete.</param>
        /// <param name="newLocation">The new location of the User.</param>
        public void updateUserLocation(Guid userID, MapLocation newLocation)
        {
            if (locations.Contains(locations.Find(x => x.UserId == userID)))
            {
                locations.Remove(locations.Find(x => x.UserId == userID));
                locations.Add(newLocation);
                XDocument userLocationsXML = XDocument.Load(locationsPath);
                userLocationsXML.Descendants("MapLocations").Where(x => x.Element("UserId").Value == userID.ToString()).Remove();
                userLocationsXML.Element("MapLocations").Add(new XElement("MapLocation",
                                                                new XElement("UserId", userID),
                                                                new XElement("xCoordinates", newLocation.xCoord),
                                                                new XElement("yCoordinates", newLocation.yCoord),
                                                                new XElement("description", newLocation.description)));
                userLocationsXML.Save(locationsPath);
            }
        }

        /// <summary>
        ///     Retrieves all User Locations from the repository.
        /// </summary>
        /// <returns>A list of all user locations from the repository.</returns>
        public List<MapLocation> getAllUsersLocationList()
        {
            return locations;
        }
    }
}
