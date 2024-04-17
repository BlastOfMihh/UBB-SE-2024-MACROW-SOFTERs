using RandomChatSrc.Domain.MapLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomChatSrc.Repo
{
    public interface IMapRepo
    {
        void addUserLocation(Guid userID, MapLocation location);
        void removeUserLocation(Guid userID);
        void updateUserLocation(Guid userID, MapLocation location);
        List<MapLocation> getUsersLocationDictionary();
        void loadFromMemory();
    }
}
