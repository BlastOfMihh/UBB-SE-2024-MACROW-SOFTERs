using RandomChatSrc.Services.ChatroomsManagement;
using RandomChatSrc.Domain.TextChat;
using RandomChatSrc.Domain.UserDomain;
using System.Xml;
using RandomChatSrc.Services.RandomMatchingService;
using RandomChatSrc.Services.UserChatListServiceDomain;
using RandomChatSrc.Domain.UserConfig;
using RandomChatSrc.Domain.InterestDomain;

namespace RandomChatSrc.Pages;

public partial class OpenChatsWindow : ContentPage
{
   
    private ChatroomsManagementService chatService;
    private Guid currentUserId;
    private UserChatConfig currentUserConfig;
    public OpenChatsWindow()
	{
        this.chatService = new ChatroomsManagementService();
        //start test code
        //we test the matching with a dummy user
        User user = new User("gigel");
        user.AddInterest(new Interest("music"));
        TextChat textChat = chatService.getAllChats()[2];
        textChat.addParticipant(user);
        //end test code
        string filePath = "C:\\Users\\RichardToth\\Projects\\UBB-ISS\\RandomChatSrc\\RandomChatSrc\\RepoMock\\CurrentUser.xml";
        try
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            var userId = doc.SelectSingleNode("/Users/CurrentUser/id").InnerText;
            if (userId == null)
            {
                throw new Exception("User not found");
            }
            this.currentUserId = new Guid(userId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        InitializeComponent();
        RefreshActiveChats();
        //code to test current user
        //we should have a current user in the system, which we read and save at the start of the app
        //for now, we create a dummy user at the start of the app
        //we create it in the constructor of the OpenChatsWindow, since it's the first page that is opened
        User currentUser = new User("current user");
        currentUser.id = currentUserId;
        this.currentUserConfig = new UserChatConfig(currentUser);
        currentUserConfig.user.AddInterest(new Interest("music"));
    }

    private void RefreshActiveChats()
    {
        // dunno really how to make viewModels so I simply used what I had in the .XAML file
        // Clear existing items
        chatStackLayout.Children.Clear();

        // Iterate through active chats and add them to the UI
        foreach (TextChat chat in chatService.getAllChats())
        {
            // Create a custom UI element for each chat
            var chatLayout = new StackLayout { Margin = new Thickness(8) };
            chatLayout.BackgroundColor = Color.FromHex("#E2E2E2");

            var chatHeaderLayout = new StackLayout { Orientation = StackOrientation.Horizontal, Margin = new Thickness(10) };
            var chatInfoLayout = new StackLayout { VerticalOptions = LayoutOptions.Center, Margin = new Thickness(8) };
            var chatIdLabel = new Label { Text = $"Chat ID: {chat.id}", FontSize = 18, FontAttributes = FontAttributes.Bold };
            chatIdLabel.TextColor = Color.FromHex("#000000");
            var lastMessageLabel = new Label { Text = $"Last Message: {((chat.Messages.Count != 0) ? chat.Messages.Last().Content : "No messages yet")}", FontSize = 15 };
            lastMessageLabel.TextColor = Color.FromHex("#000000");

            chatInfoLayout.Children.Add(chatIdLabel);
            chatInfoLayout.Children.Add(lastMessageLabel);

            chatHeaderLayout.Children.Add(chatInfoLayout);

            chatLayout.Children.Add(chatHeaderLayout);
            chatLayout.GestureRecognizers.Add(new TapGestureRecognizer
            {
                CommandParameter = chat,
                Command = new Command(this.OpenDummyPage)
            });

            // Add the custom UI element to the stack layout
            chatStackLayout.Children.Add(chatLayout);
        }
    }

    private async void OpenDummyPage(object sender)
    {
        if (sender is TextChat selectedChat)
        {
            await Navigation.PushAsync(new ChatRoomPage(selectedChat, currentUserId));
        }
    }

    private async void RandomChatButton_Clicked(object sender, EventArgs e)
    {
        RefreshActiveChats();
        RandomMatchingService randomMatchingService = new RandomMatchingService(chatService, new UserChatListService(chatService));
        TextChat textChat = randomMatchingService.RequestMatchingChatRoom(currentUserConfig);
        await Navigation.PushAsync(new ChatRoomPage(textChat, currentUserId));
    }   


    private  void OpenChatButton_Clicked(object sender, EventArgs e)
    {
    
    }

    private async void RequestsButton_Clicked(object sender, EventArgs e)
    {
       
    }

    private async void ChatItem_Clicked(object sender, EventArgs e)
    {
       
    }

}