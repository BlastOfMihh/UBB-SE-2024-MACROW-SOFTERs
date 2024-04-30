using RandomChatSrc.Domain.MapLocation;
using RandomChatSrc.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomChatSrc.Services.GlobalServices;

namespace RandomChatSrc.Services.MapService
{   /// <summary>
    /// Service for managing user locations on the map and handling user requests.
    /// </summary>
    public class MapService : IMapService
    {
        private readonly MapRepo _mapRepo;
        private readonly GlobalServices.GlobalServices _globalServices;

        /// <summary>
        /// Initializes a new instance of the MapService class.
        /// </summary>
        /// <param name="mapRepo">The repository for map-related operations.</param>
        /// <param name="globalServices">The global services for handling requests.</param>

        public MapService(MapRepo mapRepo, GlobalServices.GlobalServices globalServices)
        {
            _mapRepo = mapRepo;
            _globalServices = globalServices;
        }

        /// <summary>
        /// Retrieves the locations of all users on the map.
        /// </summary>
        /// <returns>A list of map locations for all users.</returns>
        public List<MapLocation> getAllUserLocations()
        {
            return _mapRepo.getAllUsersLocationList();
        }

        /// <summary>
        /// Retrieves the IDs of all users with known locations on the map.
        /// </summary>
        /// <returns>A list of user IDs.</returns>
        public List<Guid> getAllUsers()
        {
            List<Guid> users = new List<Guid>();
            foreach (MapLocation mapLocation in _mapRepo.getAllUsersLocationList())
            {
                if (mapLocation.UserId != Guid.Empty)
                {
                    users.Add(mapLocation.UserId);
                }
            }
            return users;
        }

        /// <summary>
        /// Initiates a chat request from a sender to a receiver.
        /// </summary>
        /// <param name="senderId">The ID of the sender initiating the request.</param>
        /// <param name="receiverId">The ID of the receiver being requested.</param>

        public void makeRequest(Guid senderId, Guid receiverId)
        {
            _globalServices.GetRequestChatService().addRequest(senderId, receiverId);
        }
        /// <summary>
        /// Updates the location of a user on the map.
        /// </summary>
        /// <param name="userId">The ID of the user whose location is being updated.</param>
        /// <param name="location">The new location of the user.</param>

        public void updateUserLocation(Guid userId, MapLocation location)
        {
            _mapRepo.updateUserLocation(userId, location);
        }
    }
}
