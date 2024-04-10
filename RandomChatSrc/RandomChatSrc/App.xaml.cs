using RandomChatSrc.Pages;
using RandomChatSrc.Domain;
using RandomChatSrc.Domain.TextChat;
using RandomChatSrc.Domain.ChatDomain;
using RandomChatSrc.Services.ChatroomsManagement;

namespace RandomChatSrc
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            string folderPath1 = "D:\\School\\An 2\\Sem 2\\ISS\\UBB-SE-2024-MACROW-SOFTERs\\RandomChatSrc\\RandomChatSrc\\MockEverything\\Textchat1\\";

            TextChat textChat = new TextChat([], folderPath1);

            // Add some test messages
            /*textChat.AddMessage(senderId: 1, messageContent: "Hello");
            textChat.AddMessage(senderId: 2, messageContent: "Hi there!");
            textChat.AddMessage(senderId: 1, messageContent: "How are you?");*/

            string folderPath2 = "D:\\School\\An 2\\Sem 2\\ISS\\UBB-SE-2024-MACROW-SOFTERs\\RandomChatSrc\\RandomChatSrc\\MockEverything\\Textchat2\\";

            TextChat textChat2 = new TextChat([], folderPath2);

            // Add some test messages
            textChat2.AddMessage(senderId: 4, messageContent: "alooo");
            textChat2.AddMessage(senderId: 3, messageContent: "cf vere");

            string folderPath3 = "D:\\School\\An 2\\Sem 2\\ISS\\UBB-SE-2024-MACROW-SOFTERs\\RandomChatSrc\\RandomChatSrc\\MockEverything\\Textchat3\\";

            TextChat textChat3 = new TextChat([], folderPath3);

            // Add some test messages
            textChat3.AddMessage(senderId: 1, messageContent: "nudes in bio");
            textChat3.AddMessage(senderId: 3, messageContent: "huh?");

            List<Chat> chats = new List<Chat>();
            chats = [textChat, textChat2, textChat3];

            ChatroomsManagementService service = new ChatroomsManagementService(chats);

            MainPage = new NavigationPage(new OpenChatsWindow(service));

            // In order to see the chatroom page uncomment the below line and comment the other main page
            //MainPage = new NavigationPage(new ChatRoomPage());

            //MainPage = new AppShell();
        }
    }
}
