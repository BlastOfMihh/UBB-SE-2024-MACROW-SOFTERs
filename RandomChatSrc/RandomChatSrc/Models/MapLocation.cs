// <copyright file="MapLocation.cs" company="SuperBet Beclean">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RandomChatSrc.Models
{
    /// <summary>
    /// Represents information about a User's location on the map,
    /// including the User's identifier, the coordinates and the Description.
    /// </summary>
    public class MapLocation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MapLocation"/> class.
        /// </summary>
        /// <param name="guid">The unique identifier of the user.</param>
        /// <param name="xCoordinates">The x-coordinate of the user's location.</param>
        /// <param name="yCoordinates">The y-coordinate of the user's location.</param>
        /// <param name="description">The description of the location.</param>
        public MapLocation(Guid guid, float xCoordinates, float yCoordinates, string description = "")
        {
            this.UserId = guid;
            this.XCoordinates = xCoordinates;
            this.YCoordinates = yCoordinates;
            this.Description = description;
        }

        /// <summary>
        /// Gets or sets the unique identifier of the user.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the x-coordinate of the user's location.
        /// </summary>
        public float XCoordinates { get; set; }

        /// <summary>
        /// Gets or sets the y-coordinate of the user's location.
        /// </summary>
        public float YCoordinates { get; set; }

        /// <summary>
        /// Gets or sets the description of the location.
        /// </summary>
        public string Description { get; set; }
    }
}