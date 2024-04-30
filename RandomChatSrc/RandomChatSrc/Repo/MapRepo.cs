using System.Xml.Linq;
using RandomChatSrc.Models;

namespace RandomChatSrc.Repo
{
    public class MapRepo
    {
        public List<MapLocation> Locations { get; set; }
        private readonly string locationsPath;
        public MapRepo()
        {
            // this.locationsPath = "C:\\Users\\RichardToth\\Projects\\UBB-ISS\\RandomChatSrc\\RandomChatSrc\\RepoMock\\Locations.xml";
            // this.locationsPath = "C:\\Users\\MiHH\\Gits\\UBB-SE-2024-MACROW-SOFTERs\\RandomChatSrc\\RandomChatSrc\\RepoMock\\";
            this.locationsPath = "C:\\GitHub_Repos\\UBB-SE-2024-MACROW-SOFTERs\\RandomChatSrc\\RandomChatSrc\\RepoMock\\";
            Locations = new List<MapLocation>();
            LoadFromMemory();
        }

        public void AddUserLocation(Guid userID, MapLocation location)
        {
            // check if User already has a location
            if (Locations.Contains(Locations.Find(x => x.UserId == userID)))
            {
                UpdateUserLocation(userID, location);
                // update the xml file
                XDocument xDocument = XDocument.Load(locationsPath);
                xDocument.Element("MapLocations").Add(new XElement("MapLocation",
                                       new XElement("UserId", userID),
                                                          new XElement("XCoordinates", location.XCoordinates),
                                                                             new XElement("YCoordinates", location.YCoordinates),
                                                                                                new XElement("Description", location.Description)));
                xDocument.Save(locationsPath);
            }
            else
            {
                Locations.Add(location);
                // update the xml file
                XDocument xDocument = XDocument.Load(locationsPath);
                xDocument.Element("MapLocations").Add(new XElement("MapLocation",
                                       new XElement("UserId", userID),
                                                          new XElement("XCoordinates", location.XCoordinates),
                                                                             new XElement("YCoordinates", location.YCoordinates),
                                                                                                new XElement("Description", location.Description)));
                xDocument.Save(locationsPath);
            }
        }

        public void RemoveUserLocation(Guid userID)
        {
            if (Locations.Contains(Locations.Find(x => x.UserId == userID)))
            {
                Locations.Remove(Locations.Find(x => x.UserId == userID));
            }
            // update the xml file
            XDocument xDocument = XDocument.Load(locationsPath);
            xDocument.Descendants("MapLocations").Where(x => x.Element("UserId").Value == userID.ToString()).Remove();
            xDocument.Save(locationsPath);
        }

        public void UpdateUserLocation(Guid userID, MapLocation location)
        {
            if (Locations.Contains(Locations.Find(x => x.UserId == userID)))
            {
                Locations.Remove(Locations.Find(x => x.UserId == userID));
                Locations.Add(location);
                // update the xml file
                XDocument xDocument = XDocument.Load(locationsPath);
                xDocument.Descendants("MapLocations").Where(x => x.Element("UserId").Value == userID.ToString()).Remove();
                xDocument.Element("MapLocations").Add(new XElement("MapLocation",
                                       new XElement("UserId", userID),
                                                          new XElement("XCoordinates", location.XCoordinates),
                                                                             new XElement("YCoordinates", location.YCoordinates),
                                                                                                new XElement("Description", location.Description)));
                xDocument.Save(locationsPath);
            }
        }

        public List<MapLocation> GetAllUsersLocationList()
        {
            return Locations;
        }

        public void LoadFromMemory()
        {
            XDocument xDocument = XDocument.Load(locationsPath);
            foreach (XElement location in xDocument.Descendants("MapLocations"))
            {
                Guid userId = new Guid(location.Element("UserId").Value);
                float xCoord = float.Parse(location.Element("XCoordinates").Value);
                float yCoord = float.Parse(location.Element("YCoordinates").Value);
                string description = location.Element("Description").Value;
                MapLocation newLocation = new MapLocation(userId, xCoord, yCoord, description);
                Locations.Add(newLocation);
            }
        }
    }
}
