using RandomChatSrc.Domain.ChatDomain;
using RandomChatSrc.Domain.TextChat;
using RandomChatSrc.Pages;
using RandomChatSrc.Services.ChatroomsManagement;

namespace RandomChatSrc
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            string folderPath1 = "C:\\uni\\MSGAPP\\RandomChatSrc\\RandomChatSrc\\MockEverything\\Textchat1\\";

            // Get the base directory for storing files
            string baseDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            // Append the relative path to your project directory
            string folderPath1Android = Path.Combine(baseDirectory, "\\RandomChatSrc\\RandomChatSrc\\MockEverything\\", "Textchat1");


            TextChat textChat = new TextChat([], folderPath1Android);

            // Add some test messages
            /*textChat.AddMessage(senderId: 1, messageContent: "Hello");
            textChat.AddMessage(senderId: 2, messageContent: "Hi there!");
            textChat.AddMessage(senderId: 1, messageContent: "How are you?");*/

            string folderPath2 = "C:\\uni\\MSGAPP\\RandomChatSrc\\RandomChatSrc\\MockEverything\\Textchat2\\";
            string folderPath2Android = Path.Combine(baseDirectory, "\\RandomChatSrc\\RandomChatSrc\\MockEverything\\", "Textchat2");

            TextChat textChat2 = new TextChat([], folderPath2Android);

            // Add some test messages
            textChat2.AddMessage(senderId: 4, messageContent: "alooo");
            textChat2.AddMessage(senderId: 3, messageContent: "cf vere");

            string folderPath3 = "C:\\uni\\MSGAPP\\RandomChatSrc\\RandomChatSrc\\MockEverything\\Textchat3";
            string folderPath3Android = Path.Combine(baseDirectory, "\\RandomChatSrc\\RandomChatSrc\\MockEverything\\", "Textchat3");

            TextChat textChat3 = new TextChat([], folderPath3Android);

            // Add some test messages
            textChat3.AddMessage(senderId: 1, messageContent: "nudes in bio");
            textChat3.AddMessage(senderId: 3, messageContent: "huh?");

            List<Chat> chats = new List<Chat>();
            chats = [textChat, textChat2, textChat3];

            ChatroomsManagementService service = new ChatroomsManagementService(chats);

            MainPage = new NavigationPage(new OpenChatsWindow(service));

        }
    }
}
