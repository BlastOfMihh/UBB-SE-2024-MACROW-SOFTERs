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
        /// <summary>
        /// Initializes a new instance of the <see cref="MapService"/> class.
        /// </summary>
        public MapService()
        {
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
    }
}
