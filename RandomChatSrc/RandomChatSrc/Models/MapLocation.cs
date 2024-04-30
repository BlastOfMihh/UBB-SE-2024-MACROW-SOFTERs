namespace RandomChatSrc.Models
{
    /// <summary>
    /// Represents information about a User's location on the map,
    /// including the User's identifier, the coordinates and the Description.
    /// </summary>
    public class MapLocation
    {
        public Guid UserId { get; set; }
        public float XCoordinates { get; set; }
        public float YCoordinates { get; set; }
        public string Description { get; set; }

        public MapLocation(Guid guid, float xCoordinates, float yCoordinates, string description = "")
        {
            UserId = guid;
            XCoordinates = xCoordinates;
            YCoordinates = yCoordinates;
            Description = description;
        }
    }
}
