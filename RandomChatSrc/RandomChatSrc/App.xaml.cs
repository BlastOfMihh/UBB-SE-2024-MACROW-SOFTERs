namespace RandomChatSrc
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

<<<<<<< Updated upstream
            MainPage = new AppShell();
=======
            MainPage = new NavigationPage(new OpenChatsWindow());

            // In order to see the chatroom page uncomment the below line and comment the other main page
            // MainPage = new NavigationPage(new ChatRoomPage());

            //MainPage = new AppShell();
>>>>>>> Stashed changes
        }
    }
}
