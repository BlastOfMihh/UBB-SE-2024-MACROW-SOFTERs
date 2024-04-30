using Microsoft.Extensions.Logging;
using RandomChatSrc.Services.ChatroomsManagement;
using RandomChatSrc.Pages;
using RandomChatSrc.Services.RandomMatchingService;
using System.Diagnostics;
using RandomChatSrc.Domain.TextChat;
using RandomChatSrc.Services.UserChatListServiceDomain;
using RandomChatSrc.Domain.UserDomain;
using RandomChatSrc.Domain.UserConfig;
using RandomChatSrc.Domain.InterestDomain;
using CommunityToolkit.Maui.Maps;
using RandomChatSrc.Services.GlobalServices;

namespace RandomChatSrc
{
    public static class MauiProgram
        // va bat
    {
        public static void test()
        {
            //test the ChatroomsManagementService
            ChatroomsManagementService chatroomsManagementService = new ChatroomsManagementService();
            chatroomsManagementService.CreateChat(2);
            var chats = chatroomsManagementService.getAllChats();
            foreach (TextChat chat in chats)
            {
                Trace.WriteLine(chat.availableParticipantsCount());
            }
            User user = new User("richard");
            user.AddInterest(new Interest("music"));
            user.id = new Guid("10030000-0300-0200-0000-000000000000");
            User user2 = new User("user2");
            user2.id = new Guid("20030000-0300-0200-0000-000000000001");
            user2.AddInterest(new Interest("music"));
            // todo should add user interests here idk?
            Trace.WriteLine(chats[chats.Count - 1].id);
            chats[chats.Count - 1].addParticipant(user2);
            Trace.WriteLine(chats[chats.Count - 1].availableParticipantsCount());
            UserChatListService userChatListService = new UserChatListService(chatroomsManagementService);
            Trace.WriteLine(userChatListService._currentUserId.ToString());
            var openChats = userChatListService.getOpenChats();
            foreach (TextChat chat in openChats)
            {
                Trace.WriteLine(chat.participants[0].name);
            }
            //test the RandomMatchingService
            //RandomMatchingService randomMatchingService = new RandomMatchingService(chatroomsManagementService, userChatListService);
            //TextChat newChat = randomMatchingService.RequestMatchingChatRoom(new UserChatConfig(user));
            //Trace.WriteLine(newChat.participants[0].name);
        }
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.Services.AddSingleton<IChatroomsManagementService, ChatroomsManagementService>();
            builder.Services.AddSingleton<IRandomMatchingService, RandomMatchingService>();
            Trace.WriteLine("Hello World");
            //test();
            //test git push
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
