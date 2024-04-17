using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomChatSrc.Domain.Location
{
    public class Location
    {
        public float xCoord { get; set; }
        public float yCoord { get; set; }
        public string description { get; set; }
        public Location(float xCoord, float yCoord, string description="")
        {
            this.xCoord = xCoord;
            this.yCoord = yCoord;
            this.description = description;
        }
    }
}
