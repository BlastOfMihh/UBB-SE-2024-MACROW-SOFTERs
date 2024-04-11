using Microsoft.Extensions.Logging;
using RandomChatSrc.Services.ChatroomsManagement;
using RandomChatSrc.Pages;
using RandomChatSrc.Services.RandomMatchingService;
using System.Diagnostics;
using RandomChatSrc.Domain.TextChat;
using RandomChatSrc.Services.UserChatListService;
using RandomChatSrc.Domain.UserDomain;

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
            user.id = new Guid("10030000-0300-0200-0000-000000000000");
            chats[0].addParticipant(user);
            UserChatListService userChatListService = new UserChatListService(chatroomsManagementService);
            Trace.WriteLine(userChatListService.currentUserId.ToString());
            var openChats = userChatListService.getOpenChats();
            foreach (TextChat chat in openChats)
            {
                Trace.WriteLine(chat.participants[0].name);
            }
            //test the RandomMatchingService
            RandomMatchingService randomMatchingService = new RandomMatchingService(chatroomsManagementService);
            User user2 = new User("test2");
            user2.id = new Guid("20030000-0300-0200-0000-000000000001");
            
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
