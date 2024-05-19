// <copyright file="MapRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RandomChatSrc.Repositories
{
    using System.Xml.Linq;
    using RandomChatSrc.Models;

    /// <summary>
    ///     Class responsible for getting and writing User Locations entities to the XML file.
    /// </summary>
    public class MapRepository : IMapRepository
    {
        private string locationsPath;

        /// <summary>
        /// Initializes a new instance of the <see cref="MapRepository"/> class.
        /// </summary>
        public MapRepository(string filePath = "C:\\Users\\Admin\\Desktop\\ubb\\iss\\newapp\\UBB-SE-2024-MACROW-SOFTERs\\RandomChatSrc\\RandomChatSrc\\RepoMock\\Locations.xml")
        {
            this.locationsPath = filePath;
            this.Locations = new List<MapLocation>();
            this.LoadFromMemory();
        }

        public List<MapLocation> Locations { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MapRepository"/> class.
        /// </summary>

        /// <summary>
        ///     Retrieves all User Locations from the XML file.
        /// </summary>
        public void LoadFromMemory()
        {
            XDocument userLocationsXML = XDocument.Load(this.locationsPath);
            foreach (XElement location in userLocationsXML.Descendants("MapLocations"))
            {
                // get for each location "MapLocation" the UserId, xCoordinates, yCoordinates and description
                XElement? mapLocationElement = location.Element("MapLocation");
                if (mapLocationElement != null)
                {
                    XElement? userIdElement = mapLocationElement.Element("UserId");
                    XElement? xCoordinatesElement = mapLocationElement.Element("xCoordinates");
                    XElement? yCoordinatesElement = mapLocationElement.Element("yCoordinates");
                    XElement? descriptionElement = mapLocationElement.Element("description");

                    if (userIdElement != null && xCoordinatesElement != null && yCoordinatesElement != null &&
                        descriptionElement != null)
                    {

                        Guid userId = new(userIdElement.Value);
                        float xCoordinates = float.Parse(xCoordinatesElement.Value);
                        float yCoordinates = float.Parse(yCoordinatesElement.Value);
                        string description = descriptionElement.Value;

                        MapLocation newLocation = new(userId, xCoordinates, yCoordinates, description);
                        this.Locations.Add(newLocation);
                    }
                }
            }
        }

        /// <summary>
        ///     Adds a new User Location to the XML file. If the user already has a location,
        ///     his location will be updated.
        /// </summary>
        /// <param name="userID">The ID of the user.</param>
        /// <param name="userLocation">The location of the user.</param>
        public void AddUserLocation(Guid userID, MapLocation userLocation)
        {
            // Check if the user location already exists
            MapLocation? existingLocation = this.Locations.FirstOrDefault(x => x.UserId == userID);

            // Add the new location if it doesn't exist
            this.Locations.Add(userLocation);

            // Add the user location to the XML file
            XDocument userLocationsXML = XDocument.Load(this.locationsPath);
            XElement? mapLocationsElement = userLocationsXML.Element("MapLocations");

            if (mapLocationsElement != null)
            {
                mapLocationsElement.Add(new XElement(
                    "MapLocation",
                    new XElement("UserId", userID),
                    new XElement("xCoordinates", userLocation.XCoordinates),
                    new XElement("yCoordinates", userLocation.YCoordinates),
                    new XElement("description", userLocation.Description)));

                userLocationsXML.Save(this.locationsPath);
            }
        }

        /// <summary>
        ///     Deletes the User Location with ID from the XML file.
        /// </summary>
        /// <param name="userID">The ID of the User to delete.</param>
        public void RemoveUserLocation(Guid userID)
        {
            MapLocation? locationToRemove = this.Locations.Find(x => x.UserId == userID);
            if (locationToRemove != null)
            {
                this.Locations.Remove(locationToRemove);
            }

            XDocument userLocationsXML = XDocument.Load(this.locationsPath);
            IEnumerable<XElement> elementsToRemove = userLocationsXML.Descendants("MapLocations").Where(x => x.Element("UserId")?.Value == userID.ToString());
            if (elementsToRemove != null)
            {
                elementsToRemove.Remove();
                userLocationsXML.Save(this.locationsPath);
            }
        }

        /// <summary>
        ///     Updates the User Location with ID from the XML file.
        /// </summary>
        /// <param name="userID">The ID of the User to delete.</param>
        /// <param name="newLocation">The new location of the User.</param>
        public void UpdateUserLocation(Guid userID, MapLocation newLocation)
        {
            MapLocation? locationToUpdate = this.Locations.Find(x => x.UserId == userID);
            if (locationToUpdate != null)
            {
                this.Locations.Remove(locationToUpdate);
                this.Locations.Add(newLocation);

                XDocument userLocationsXML = XDocument.Load(this.locationsPath);
                IEnumerable<XElement> elementsToRemove = userLocationsXML.Descendants("MapLocations").Where(x => x.Element("UserId")?.Value == userID.ToString());
                if (elementsToRemove != null)
                {
                    elementsToRemove.Remove();
                    XElement? mapLocationsElement = userLocationsXML.Element("MapLocations");
                    if (mapLocationsElement != null)
                    {
                        mapLocationsElement.Add(new XElement(
                            "MapLocation",
                            new XElement("UserId", userID),
                            new XElement("xCoordinates", newLocation.XCoordinates),
                            new XElement("yCoordinates", newLocation.YCoordinates),
                            new XElement("description", newLocation.Description)));
                        userLocationsXML.Save(this.locationsPath);
                    }
                }
            }
        }

        /// <summary>
        ///     Retrieves all User Locations from the repository.
        /// </summary>
        /// <returns>A list of all user locations from the repository.</returns>
        public List<MapLocation> GetAllUsersLocationList()
        {
            return this.Locations;
        }
    }
}