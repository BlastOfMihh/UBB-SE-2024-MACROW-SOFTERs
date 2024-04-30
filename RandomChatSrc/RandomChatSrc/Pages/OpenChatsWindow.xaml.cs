using RandomChatSrc.Services.ChatroomsManagement;
using RandomChatSrc.Domain.TextChat;
using RandomChatSrc.Services.RandomMatchingService;
using RandomChatSrc.Services.UserChatListServiceDomain;
using RandomChatSrc.Domain.UserConfig;
using RandomChatSrc.Services.MessageService;
using Microsoft.Maui.Graphics.Text;
using RandomChatSrc.Domain.UserDomain;

namespace RandomChatSrc.Pages;

public partial class OpenChatsWindow : ContentPage
{
    private ChatroomsManagementService chatService;
    private Guid currentUserId;
    private UserChatConfig currentUserConfig;
    public OpenChatsWindow(ChatroomsManagementService chatService)
	{
        this.chatService = chatService;
        this.WidthRequest = 800;
        this.HeightRequest = 600;
        this.BackgroundColor = Color.FromHex("#FFFFFF");
        // Hardcoded user (wtf)
        this.currentUserConfig = new UserChatConfig(new User("Alex"));
        InitializeComponent();
        RefreshActiveChats();
    }

    private void RefreshActiveChats()
    {
        // Clear the layout
        chatStackLayout.Children.Clear();

        // Parse the chats
        foreach (TextChat chat in chatService.GetAllChats())
        {
            // Create a custom UI element for each chat
            var chatLayout = new StackLayout
            {
                Margin = new Thickness(7),
                BackgroundColor = Color.FromHex("#E2E2E2"),
            };
            var chatHeaderLayout = new StackLayout
            {
                Margin = new Thickness(10),
                Orientation = StackOrientation.Horizontal,
            };
            var chatInfoLayout = new StackLayout
            {
                Margin = new Thickness(8),
                VerticalOptions = LayoutOptions.Center,
            };
            var chatIDLabel = new Label
            {
                Text = $"Chat ID: {chat.id}",
                FontSize = 18,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.FromHex("#000000"),
            };
            var lastMessageLabel = new Label
            {
                Text = $"Last Message: {((chat.Messages.Count != 0) ? chat.Messages.Last().Content : "No messages yet")}",
                FontSize = 15,
                TextColor = Color.FromHex("#000000"),
            };
            chatInfoLayout.Children.Add(chatIDLabel);
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
            // Open the chat page
            MessageService messageService = new MessageService(selectedChat, currentUserId);
            await Navigation.PushAsync(new ChatRoomPage(currentUserId, messageService));
        }
    }

    private async void RandomChatButton_Clicked(object sender, EventArgs e)
    {
        RefreshActiveChats();
        RandomMatchingService randomMatchingService = new RandomMatchingService(chatService, new UserChatListService(chatService));
        TextChat textChat = randomMatchingService.RequestMatchingChatRoom(currentUserConfig);
        MessageService messageService = new MessageService(textChat, currentUserId);
        await Navigation.PushAsync(new ChatRoomPage(currentUserId, messageService));
    }

    private void OpenChatButton_Clicked(object sender, EventArgs e)
    {
    }

    private async void RequestsButton_Clicked(object sender, EventArgs e)
    {
    }

    private async void ChatItem_Clicked(object sender, EventArgs e)
    {
    }

    private async void MapButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MapWindow());
    }
}