using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomChatSrc.Domain.MapLocation
{
    public class MapLocation
    {
        public Guid UserId { get; set; }
        public float xCoord { get; set; }
        public float yCoord { get; set; }
        public string description { get; set; }
        public MapLocation(Guid guid, float xCoord, float yCoord, string description="")
        {
            this.UserId = guid;
            this.xCoord = xCoord;
            this.yCoord = yCoord;
            this.description = description;
        }
    }
}
