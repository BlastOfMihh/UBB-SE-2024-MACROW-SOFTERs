// <copyright file="MauiProgram.cs" company="SuperBet BeClean">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
using System.Diagnostics;
using CommunityToolkit.Maui.Maps;
using Microsoft.Extensions.Logging;
using RandomChatSrc.Models;
using RandomChatSrc.Services.ChatroomsManagement;
using RandomChatSrc.Services.RandomMatchingService;
using RandomChatSrc.Services.UserChatListServiceDomain;

namespace RandomChatSrc
{
    public static class MauiProgram
        // va bat
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.Services.AddSingleton<IChatroomsManagementService, ChatroomsManagementService>();
            builder.Services.AddSingleton<IRandomMatchingService, RandomMatchingService>();
            Trace.WriteLine("Hello World");

            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkitMaps("AuWwu13opzaX2zDZ2q3J38mL94MNzfRNmfiJkN4fvv_LfS-vhB19UvBNV27ER4iw")
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
#if DEBUG
            builder.Logging.AddDebug();
            Console.WriteLine("Debug");
#endif

            return builder.Build();
        }
    }
}
