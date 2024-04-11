using RandomChatSrc.Services.ChatroomsManagement;
using RandomChatSrc.Domain.TextChat;
using RandomChatSrc.Domain.UserDomain;
using System.Xml;

namespace RandomChatSrc.Pages;

public partial class OpenChatsWindow : ContentPage
{
   
    private ChatroomsManagementService chatService;
    private Guid currentUserId;
    public OpenChatsWindow()
	{
        this.chatService = new ChatroomsManagementService();
        string filePath = "D:\\School\\An 2\\Sem 2\\ISS\\UBB-SE-2024-MACROW-SOFTERs\\RandomChatSrc\\RandomChatSrc\\RepoMock\\CurrentUser.xml";
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
            var lastMessageLabel = new Label { Text = $"Last Message: {chat.LastAvailableMessageId}", FontSize = 15 };
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