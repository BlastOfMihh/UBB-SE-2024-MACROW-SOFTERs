using Microsoft.Extensions.Logging;
using RandomChatSrc.Services.ChatroomsManagement;
using RandomChatSrc.Pages;
using RandomChatSrc.Services.RandomMatchingService;
using System.Diagnostics;
using RandomChatSrc.Domain.TextChat;
using RandomChatSrc.Services.UserChatListService;

namespace RandomChatSrc
{
    public static class MauiProgram
        // va bat
    {
        public static void test()
        {
            //test the ChatroomsManagementService
            ChatroomsManagementService chatroomsManagementService = new ChatroomsManagementService();
            UserChatListService userChatListService = new UserChatListService(chatroomsManagementService);
            Trace.WriteLine(userChatListService.currentUserId.ToString());
            var openChats = userChatListService.getOpenChats();
            foreach (TextChat chat in openChats)
            {
                Trace.WriteLine(chat.availableParticipantsCount());
            }

        }
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.Services.AddSingleton<IChatroomsManagementService, ChatroomsManagementService>();
            builder.Services.AddSingleton<IRandomMatchingService, RandomMatchingService>();
            Trace.WriteLine("Hello World");
            test();
            //test git push
            builder
                .UseMauiApp<App>()
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
