// <copyright file="IMapService.cs" company="SuperBet BeClean">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
using RandomChatSrc.Domain.MapLocation;

namespace RandomChatSrc.Services.MapService
{
    public interface IMapService
    {
        void MakeRequest(Guid senderId, Guid receiverId);
        List<MapLocation> GetAllUserLocations();
        List<Guid> GetAllUsers();
        void UpdateUserLocation(Guid userId, MapLocation location);
    }
}
