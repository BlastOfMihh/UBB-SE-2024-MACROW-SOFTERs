// <copyright file="MapService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RandomChatSrc.Services.MapService
{
    using RandomChatSrc.Models;
    using RandomChatSrc.Repositories;

    /// <summary>
    /// Service for managing user locations on the map and handling user requests.
    /// </summary>
    public class MapService : IMapService
    {
        private IMapRepository mapRepo;
        private GlobalServices.GlobalServices globalServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="MapService"/> class.
        /// </summary>
        /// <param name="mapRepo">The repository for map-related operations.</param>
        /// <param name="globalServices">The global services for handling requests.</param>
        public MapService(IMapRepository mapRepo, GlobalServices.GlobalServices globalServices)
        {
            this.mapRepo = mapRepo;
            this.globalServices = globalServices;
        }

        /// <summary>
        /// Retrieves the locations of all users on the map.
        /// </summary>
        /// <returns>A list of map locations for all users.</returns>
        public List<MapLocation> GetAllUserLocations()
        {
            return this.mapRepo.GetAllUsersLocationList();
        }

        /// <summary>
        /// Retrieves the IDs of all users with known locations on the map.
        /// </summary>
        /// <returns>A list of user IDs.</returns>
        public List<Guid> GetAllUsers()
        {
            List<Guid> users = new();
            foreach (MapLocation mapLocation in this.mapRepo.GetAllUsersLocationList())
            {
                if (mapLocation.UserId != Guid.Empty)
                {
                    users.Add(mapLocation.UserId);
                }
            }

            return users;
        }

        /// <summary>
        /// Updates the location of a user on the map.
        /// </summary>
        /// <param name="userId">The ID of the user whose location is being updated.</param>
        /// <param name="location">The new location of the user.</param>
        public void UpdateUserLocation(Guid userId, MapLocation location)
        {
            this.mapRepo.UpdateUserLocation(userId, location);
        }
    }
}
