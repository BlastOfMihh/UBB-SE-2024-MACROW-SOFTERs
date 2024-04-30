using RandomChatSrc.Pages;
using RandomChatSrc.Services.ChatroomsManagement;

namespace RandomChatSrc
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            ChatroomsManagementService cms = new ChatroomsManagementService();
            MainPage = new NavigationPage(new OpenChatsWindow(cms));

            // In order to see the chatroom page uncomment the below line and comment the other main page
            // MainPage = new NavigationPage(new ChatRoomPage());

            // MainPage = new AppShell();
        }
    }
}
