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

        /// <summary>
        /// Initializes a new instance of the <see cref="MapService"/> class.
        /// </summary>
        /// <param name="mapRepo">The repository for map-related operations.</param>
        /// <param name="globalServices">The global services for handling requests.</param>
        public MapService(IMapRepository mapRepo)
        {
            this.mapRepo = mapRepo;
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
            List<Guid> users = new ();
            foreach (MapLocation mapLocation in this.mapRepo.GetAllUsersLocationList())
            {
                if (mapLocation.UserId != Guid.Empty)
                {
                    users.Add(mapLocation.UserId);
                }
            }

            return users;
        }
        public async Task<MapLocation> GetCurrentLocation()
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location == null)
                {
                    location = await Geolocation.GetLocationAsync(new GeolocationRequest
                    {
                        DesiredAccuracy = GeolocationAccuracy.Medium,
                        Timeout = TimeSpan.FromSeconds(30)
                    });
                }

                if (location != null)
                {
                    var mapLocation = new MapLocation(Guid.NewGuid(), (float)location.Latitude, (float)location.Longitude, "Current Location");
                    return mapLocation;
                }
                else
                {
                    // Handle location not found
                    return new MapLocation();
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                return new MapLocation();
            }
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
