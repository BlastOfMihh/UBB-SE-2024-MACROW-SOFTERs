using RandomChatSrc.Domain.ChatDomain;
using RandomChatSrc.Domain.TextChat;
using RandomChatSrc.Services.ChatroomsManagement;

namespace RandomChatSrc.Pages;

    public partial class OpenChatsWindow : ContentPage
    {
        private ChatroomsManagementService chatService;



        public OpenChatsWindow(ChatroomsManagementService chatService)
        {
            InitializeComponent();
            this.chatService = chatService;

            RefreshActiveChats();
        }

        private void RefreshActiveChats()
        {
            // dunno really how to make viewModels so I simply used what I had in the .XAML file
            // Clear existing items
            chatStackLayout.Children.Clear();

            // Iterate through active chats and add them to the UI
            foreach (TextChat chat in chatService.activeChats)
            {
                // Create a custom UI element for each chat
                var chatLayout = new StackLayout { Margin = new Thickness(8) };
                chatLayout.BackgroundColor = Color.FromHex("#E2E2E2");

                var chatHeaderLayout = new StackLayout { Orientation = StackOrientation.Horizontal, Margin = new Thickness(10) };
                var chatInfoLayout = new StackLayout { VerticalOptions = LayoutOptions.Center, Margin = new Thickness(8) };
                //instead of chat.id we should have a proper getter
                var chatIdLabel = new Label { Text = $"Chat ID: {chat.id}", FontSize = 18, FontAttributes = FontAttributes.Bold };
                chatIdLabel.TextColor = Color.FromHex("#000000");
                //instead of chat.LastAvailableMessageId we should have a proper getter
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
            await Navigation.PushAsync(new ChatRoomPage());
        }

        private void OpenChatButton_Clicked(object sender, EventArgs e)
        {
            // Handle opening the selected chat
            if (sender is Button button && button.CommandParameter is Chat chat)
            {
                // You can navigate to a new page to display the chat details or handle it as required
                // For example:
                Navigation.PushAsync(new ChatRoomPage());
            }
        }

        // You can add similar methods for handling other actions related to chats

        private void RequestsButton_Clicked(object sender, EventArgs e)
        {
            // Handle requests button click
        }
    }
    //>>>>>>> Stashed changes
    //    }

    //    private async void OpenChatButton_Clicked(object sender, EventArgs e)
    //    {
    //        await Navigation.PushAsync(new ChatRoomPage());
    //    }

    //    private async void RequestsButton_Clicked(object sender, EventArgs e)
    //    {
    //        await Navigation.PushAsync(new ChatRoomPage());
    //    }

    //    private async void ChatItem_Clicked(object sender, EventArgs e)
    //    {
    //        await Navigation.PushAsync(new ChatRoomPage());
    //    }

    //}


