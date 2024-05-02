// <copyright file="MauiProgram.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace RandomChatSrc
{
    using System.Diagnostics;
    using CommunityToolkit.Maui.Maps;
    using Microsoft.Extensions.Logging;
    using Microsoft.Maui.Hosting;
    using RandomChatSrc.Services.ChatroomsManagement;
    using RandomChatSrc.Services.RandomMatchingService;

    /// <summary>
    /// Represents the main entry point of the Maui application.
    /// </summary>
    public static class MauiProgram
    {
        /// <summary>
        /// Creates and configures the Maui application.
        /// </summary>
        /// <returns>The configured Maui application.</returns>
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