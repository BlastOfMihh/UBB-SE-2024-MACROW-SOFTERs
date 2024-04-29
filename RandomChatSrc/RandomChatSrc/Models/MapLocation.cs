namespace RandomChatSrc.Models
{
    /// <summary>
    /// Represents information about a User's location on the map,
    /// including the User's identifier, the coordinates and the Description.
    /// </summary>

    public class MapLocation(Guid guid, float xCoordinates, float yCoordinates, string description = "")
    {
        public Guid UserId { get; set; } = guid;
        public float XCoordinates { get; set; } = xCoordinates;
        public float YCoordinates { get; set; } = yCoordinates;
        public string Description { get; set; } = description;
    }
}
