using RandomChatSrc.Pages;

namespace RandomChatSrc
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new OpenChatsWindow());

        }
    }
}
