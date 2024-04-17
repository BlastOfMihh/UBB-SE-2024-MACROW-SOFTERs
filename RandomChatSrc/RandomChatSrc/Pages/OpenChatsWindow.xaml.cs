using RandomChatSrc.Services.ChatroomsManagement;
using RandomChatSrc.Domain.TextChat;
using RandomChatSrc.Domain.UserDomain;
using System.Xml;
using RandomChatSrc.Services.RandomMatchingService;
using RandomChatSrc.Services.UserChatListServiceDomain;
using RandomChatSrc.Domain.UserConfig;

namespace RandomChatSrc.Pages;

public partial class OpenChatsWindow : ContentPage
{
   
    private ChatroomsManagementService chatService;
    private Guid currentUserId;
    private UserChatListService userChatListService;
    public OpenChatsWindow()
	{
        this.chatService = new ChatroomsManagementService();
        this.userChatListService = new UserChatListService(chatService);
        currentUserId = userChatListService.currentUserId;
        InitializeComponent();
        RefreshActiveChats();
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
        UserChatConfig userChatConfig = new UserChatConfig(new User("randomUser"));
        TextChat textChat = randomMatchingService.RequestMatchingChatRoom(userChatConfig);
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