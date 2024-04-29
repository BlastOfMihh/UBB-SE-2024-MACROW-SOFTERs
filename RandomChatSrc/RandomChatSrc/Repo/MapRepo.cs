using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using RandomChatSrc.Models;

namespace RandomChatSrc.Repo
{
    public class MapRepo : IMapRepo
    {
        public List<MapLocation> locations { get; set; }
        string locationsPath;
        public MapRepo()
        {
            //this.locationsPath = "C:\\Users\\RichardToth\\Projects\\UBB-ISS\\RandomChatSrc\\RandomChatSrc\\RepoMock\\Locations.xml";
            //this.locationsPath = "C:\\Users\\MiHH\\Gits\\UBB-SE-2024-MACROW-SOFTERs\\RandomChatSrc\\RandomChatSrc\\RepoMock\\";
            this.locationsPath = "C:\\GitHub_Repos\\UBB-SE-2024-MACROW-SOFTERs\\RandomChatSrc\\RandomChatSrc\\RepoMock\\";
            locations = new List<MapLocation>();
            loadFromMemory();
        }

        public void addUserLocation(Guid userID, MapLocation location)
        {
            //check if User already has a location
            if(locations.Contains(locations.Find(x => x.UserId == userID)))
            {
                updateUserLocation(userID, location);
                //update the xml file
                XDocument xDocument = XDocument.Load(locationsPath);
                xDocument.Element("MapLocations").Add(new XElement("MapLocation",
                                       new XElement("UserId", userID),
                                                          new XElement("XCoordinates", location.XCoordinates),
                                                                             new XElement("YCoordinates", location.YCoordinates),
                                                                                                new XElement("Description", location.Description)
                                                                                                                   ));
                xDocument.Save(locationsPath);
            }
            else
            {
                locations.Add(location);
                //update the xml file
                XDocument xDocument = XDocument.Load(locationsPath);
                xDocument.Element("MapLocations").Add(new XElement("MapLocation",
                                       new XElement("UserId", userID),
                                                          new XElement("XCoordinates", location.XCoordinates),
                                                                             new XElement("YCoordinates", location.YCoordinates),
                                                                                                new XElement("Description", location.Description)
                                                                                                                   ));
                xDocument.Save(locationsPath);
            }
            
        }

        public void removeUserLocation(Guid userID)
        {
            if (locations.Contains(locations.Find(x => x.UserId == userID)))
            {
                locations.Remove(locations.Find(x => x.UserId == userID));
            }
            //update the xml file
            XDocument xDocument = XDocument.Load(locationsPath);
            xDocument.Descendants("MapLocations").Where(x => x.Element("UserId").Value == userID.ToString()).Remove();
            xDocument.Save(locationsPath);
        }

        public void updateUserLocation(Guid userID, MapLocation location)
        {
            if(locations.Contains(locations.Find(x => x.UserId == userID)))
            {
                locations.Remove(locations.Find(x => x.UserId == userID));
                locations.Add(location);
                //update the xml file
                XDocument xDocument = XDocument.Load(locationsPath);
                xDocument.Descendants("MapLocations").Where(x => x.Element("UserId").Value == userID.ToString()).Remove();
                xDocument.Element("MapLocations").Add(new XElement("MapLocation",
                                       new XElement("UserId", userID),
                                                          new XElement("XCoordinates", location.XCoordinates),
                                                                             new XElement("YCoordinates", location.YCoordinates),
                                                                                                new XElement("Description", location.Description)
                                                                                                                   ));
                xDocument.Save(locationsPath);
            }
        }

        public List<MapLocation> getAllUsersLocationList()
        {
            return locations;
        }

        public void loadFromMemory()
        {
            XDocument xDocument = XDocument.Load(locationsPath);
            foreach (XElement location in xDocument.Descendants("MapLocations"))
            {
                Guid userId = new Guid(location.Element("UserId").Value);
                float xCoord = float.Parse(location.Element("XCoordinates").Value);
                float yCoord = float.Parse(location.Element("YCoordinates").Value);
                string description = location.Element("Description").Value;
                MapLocation newLocation = new MapLocation(userId, xCoord, yCoord, description);
                locations.Add(newLocation);
            }
        }
    }
}
