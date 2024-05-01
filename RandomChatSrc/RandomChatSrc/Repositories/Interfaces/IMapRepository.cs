// <copyright file="IMapRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RandomChatSrc.Repositories
{
    using RandomChatSrc.Models;

    /// <summary>
    /// Defines the operations for managing user locations on a map.
    /// </summary>
    public interface IMapRepository
    {
        /// <summary>
        /// Adds a user's location to the map.
        /// </summary>
        /// <param name="userID">The ID of the user.</param>
        /// <param name="location">The location of the user.</param>
        void AddUserLocation(Guid userID, MapLocation location);

        /// <summary>
        /// Removes a user's location from the map.
        /// </summary>
        /// <param name="userID">The ID of the user.</param>
        void RemoveUserLocation(Guid userID);

        /// <summary>
        /// Updates a user's location on the map.
        /// </summary>
        /// <param name="userID">The ID of the user.</param>
        /// <param name="location">The new location of the user.</param>
        void UpdateUserLocation(Guid userID, MapLocation location);

        /// <summary>
        /// Retrieves the locations of all users.
        /// </summary>
        /// <returns>A list of all user locations.</returns>
        List<MapLocation> GetAllUsersLocationList();

        /// <summary>
        /// Loads user locations from memory.
        /// </summary>
        void LoadFromMemory();
    }
}