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
        Task<MapLocation> GetCurrentLocation();
    }
}