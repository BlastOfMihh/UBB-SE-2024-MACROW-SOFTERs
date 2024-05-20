// <copyright file="IMapService.cs" company="SuperBet BeClean">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RandomChatSrc.Services.MapService
{
    using RandomChatSrc.Models;

    /// <summary>
    /// Interface for services that handle map-related operations.
    /// </summary>
    public interface IMapService
    {
        /// <summary>
        /// Retrieves all user locations.
        /// </summary>
        /// <returns>A list of all user locations.</returns>
        List<MapLocation> GetAllUserLocations();

        /// <summary>
        /// Retrieves all users.
        /// </summary>
        /// <returns>A list of all user IDs.</returns>
        List<Guid> GetAllUsers();

        /// <summary>
        /// Updates the location of a user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="location">The new location of the user.</param>
        void UpdateUserLocation(Guid userId, MapLocation location);
        Task<MapLocation> GetCurrentLocation();
    }
}