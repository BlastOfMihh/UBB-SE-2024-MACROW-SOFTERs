using RandomChatSrc.Domain.MapLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace RandomChatSrc.Repo
{
    public class MapRepo : IMapRepo
    {
        public List<MapLocation> locations { get; set; }
        string filePath;
        public MapRepo()
        {
            locations = new List<MapLocation>();
            loadFromMemory();
            filePath = "D:\\School\\An 2\\Sem 2\\ISS\\UBB-SE-2024-MACROW-SOFTERs\\RandomChatSrc\\RandomChatSrc\\RepoMock\\Locations.xml";
        }

        public void addUserLocation(Guid userID, MapLocation location)
        {
            //check if user already has a location
            if(locations.Contains(locations.Find(x => x.UserId == userID)))
            {
                updateUserLocation(userID, location);
                //update the xml file
                XDocument xDocument = XDocument.Load(filePath);
                xDocument.Element("MapLocations").Add(new XElement("MapLocation",
                                       new XElement("UserId", userID),
                                                          new XElement("xCoord", location.xCoord),
                                                                             new XElement("yCoord", location.yCoord),
                                                                                                new XElement("description", location.description)
                                                                                                                   ));
                xDocument.Save(filePath);
            }
            else
            {
                locations.Add(location);
                //update the xml file
                XDocument xDocument = XDocument.Load(filePath);
                xDocument.Element("MapLocations").Add(new XElement("MapLocation",
                                       new XElement("UserId", userID),
                                                          new XElement("xCoord", location.xCoord),
                                                                             new XElement("yCoord", location.yCoord),
                                                                                                new XElement("description", location.description)
                                                                                                                   ));
                xDocument.Save(filePath);
            }
            
        }

        public void removeUserLocation(Guid userID)
        {
            if (locations.Contains(locations.Find(x => x.UserId == userID)))
            {
                locations.Remove(locations.Find(x => x.UserId == userID));
            }
            //update the xml file
            XDocument xDocument = XDocument.Load(filePath);
            xDocument.Descendants("MapLocations").Where(x => x.Element("UserId").Value == userID.ToString()).Remove();
            xDocument.Save(filePath);
        }

        public void updateUserLocation(Guid userID, MapLocation location)
        {
            if(locations.Contains(locations.Find(x => x.UserId == userID)))
            {
                locations.Remove(locations.Find(x => x.UserId == userID));
                locations.Add(location);
                //update the xml file
                XDocument xDocument = XDocument.Load(filePath);
                xDocument.Descendants("MapLocations").Where(x => x.Element("UserId").Value == userID.ToString()).Remove();
                xDocument.Element("MapLocations").Add(new XElement("MapLocation",
                                       new XElement("UserId", userID),
                                                          new XElement("xCoord", location.xCoord),
                                                                             new XElement("yCoord", location.yCoord),
                                                                                                new XElement("description", location.description)
                                                                                                                   ));
                xDocument.Save(filePath);
            }
        }

        public List<MapLocation> getAllUsersLocationList()
        {
            return locations;
        }

        public void loadFromMemory()
        {
            XDocument xDocument = XDocument.Load(filePath);
            foreach (XElement location in xDocument.Descendants("MapLocations"))
            {
                Guid userId = new Guid(location.Element("UserId").Value);
                float xCoord = float.Parse(location.Element("xCoord").Value);
                float yCoord = float.Parse(location.Element("yCoord").Value);
                string description = location.Element("description").Value;
                MapLocation newLocation = new MapLocation(userId, xCoord, yCoord, description);
                locations.Add(newLocation);
            }
        }
    }
}
