using RandomChatSrc.Domain;
using RandomChatSrc.Domain.TextChat;
using RandomChatSrc.Domain.User;
using RandomChatSrc.Pages;

namespace RandomChatSrc
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // MainPage = new NavigationPage(new OpenChatsWindow());

            // In order to see the chatroom page uncomment the below line and comment the other main page
            List<Message> mockMessages = new List<Message>
        {
            new Message(Guid.NewGuid(), "sender1", "mockMessagesFilePath", "mockMessagePath1", DateTime.Now, "Hello!"),
            new Message(Guid.NewGuid(), "sender2", "mockMessagesFilePath", "mockMessagePath2", DateTime.Now, "Hi there!"),
            new Message(Guid.NewGuid(), "sender1", "mockMessagesFilePath", "mockMessagePath3", DateTime.Now, "How are you?")
        };

            // Folder path where mock messages are stored
            string mockMessagesFilePath = Path.Combine(Environment.CurrentDirectory, "RepoMock");

            // Initialize TextChat instance with mock messages and folder path
            TextChat mockTextChat = new TextChat(mockMessages, mockMessagesFilePath);

            User mockUser = new User("Lucian");
            User mockUser2 = new User("George");
            //MainPage = new NavigationPage(new ChatRoomPage(mockTextChat, mockUser));
            NavigationPage page = new NavigationPage(new ChatRoomPage(mockTextChat, mockUser2));

            //MainPage = new AppShell();
        }
    }
}
