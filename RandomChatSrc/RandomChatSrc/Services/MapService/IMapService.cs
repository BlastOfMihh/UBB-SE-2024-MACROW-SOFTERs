using RandomChatSrc.Domain.MapLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomChatSrc.Services.MapService
{
    public interface IMapService
    {
        void makeRequest(Guid senderId, Guid receiverId);
        List<MapLocation> getAllUserLocations();
        List<Guid> getAllUsers();
        void updaUserLocation(Guid userId, MapLocation location);
    }
}
