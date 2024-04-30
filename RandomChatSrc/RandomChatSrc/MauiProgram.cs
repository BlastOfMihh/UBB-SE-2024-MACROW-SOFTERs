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
        public static void Test()
        {
            // test the ChatroomsManagementService
            ChatroomsManagementService chatroomsManagementService = new ChatroomsManagementService();
            chatroomsManagementService.CreateChat(2);
            var chats = chatroomsManagementService.GetAllChats();
            foreach (TextChat chat in chats)
            {
                Trace.WriteLine(chat.AvailableParticipantsCount());
            }
            User user = new ("richard");
            user.AddInterest(new Interest("music"));
            user.Id = new Guid("10030000-0300-0200-0000-000000000000");

            User user2 = new ("user2");
            user2.Id = new Guid("20030000-0300-0200-0000-000000000001");
            user2.AddInterest(new Interest("music"));

            // todo should add User interests here idk?
            Trace.WriteLine(chats[^1].Id);

            chats[^1].AddParticipant(user2);

            Trace.WriteLine(chats[^1].AvailableParticipantsCount());
            UserChatListService userChatListService = new (chatroomsManagementService);
            Trace.WriteLine(userChatListService.GetCurrentUserGuid().ToString());
            var openChats = userChatListService.GetOpenChats();

            foreach (TextChat chat in openChats)
            {
                Trace.WriteLine(chat.Participants[0].Name);
            }
            // test the RandomMatchingService
            // RandomMatchingService randomMatchingService = new RandomMatchingService(chatroomsManagementService, userChatListService);
            // TextChat newChat = randomMatchingService.RequestMatchingChatRoom(new UserChatConfig(user));
            // Trace.WriteLine(newChat.participants[0].name);
        }
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.Services.AddSingleton<IChatroomsManagementService, ChatroomsManagementService>();
            builder.Services.AddSingleton<IRandomMatchingService, RandomMatchingService>();
            Trace.WriteLine("Hello World");
            // test();
            // test git push
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
