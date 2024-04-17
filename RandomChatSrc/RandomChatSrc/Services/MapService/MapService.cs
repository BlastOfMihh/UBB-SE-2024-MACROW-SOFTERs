using RandomChatSrc.Domain.MapLocation;
using RandomChatSrc.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomChatSrc.Services.MapService
{
    public class MapService : IMapService
    {
        GlobalServices globalServices;
        MapRepo mapRepo;
        public MapService(GlobalServices globalServices) {
            mapRepo = new MapRepo();
            this.globalServices = globalServices;
        }
        public List<MapLocation> getAllUserLocations()
        {
            return mapRepo.getAllUsersLocationList();
        }

        public List<Guid> getAllUsers()
        {
            List<Guid> users = new List<Guid>();
            foreach (MapLocation mapLocation in mapRepo.getAllUsersLocationList())
            {
                if (mapLocation.UserId != null)
                {
                    users.Add(mapLocation.UserId);
                }
            }
            return users;
        }

        public void makeRequest(Guid senderId, Guid receiverId)
        {
            //call the requestService to make a request using the currentUserId as sender and the receiverId as receiver
            //the requestService will be called from the globalServices per Mihnea's request
        }

        public void updaUserLocation(Guid userId, MapLocation location)
        {
            mapRepo.updateUserLocation(userId, location);
        }
    }
}
