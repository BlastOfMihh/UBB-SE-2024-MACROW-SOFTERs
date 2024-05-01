// <copyright file="OpenChatsWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RandomChatSrc.Pages
{
    using System.Xml;
    using RandomChatSrc.Models;
    using RandomChatSrc.Services.ChatroomsManagement;
    using RandomChatSrc.Services.MessageService;
    using RandomChatSrc.Services.RandomMatchingService;
    using RandomChatSrc.Services.UserChatListServiceDomain;

    /// <summary>
    /// Represents the OpenChatsWindow view.
    /// </summary>
    public partial class OpenChatsWindow : ContentPage
    {
        private readonly ChatroomsManagementService chatService;
        private readonly Guid currentUserId;

        private readonly UserChatConfig currentUserConfig;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenChatsWindow"/> class.
        /// </summary>
        /// <param name="chatService">The chat service instance.</param>
        public OpenChatsWindow(ChatroomsManagementService chatService)
        {
            this.chatService = chatService;
            this.WidthRequest = 800;
            this.HeightRequest = 600;
            this.BackgroundColor = Color.FromArgb("#FFFFFF");

            string filePath = "/Users/mirceamaierean/UBB-SE-2024-MACROW-SOFTERs/RandomChatSrc/RandomChatSrc/RepoMock/CurrentUser.xml";
            try
            {
                XmlDocument doc = new ();
                doc.Load(filePath);
                var currentNode = doc.SelectSingleNode("/Users/CurrentUser/Id");
                if (currentNode != null)
                {
                    var userId = currentNode.InnerText ?? throw new Exception("User not found");
                    this.currentUserId = new Guid(userId);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            this.InitializeComponent();
            this.RefreshActiveChats();

            User currentUser = new ("current User")
            {
                Id = this.currentUserId,
            };

            this.currentUserConfig = new UserChatConfig(currentUser);
            this.currentUserConfig.User.AddInterest(new ("music"));
        }

        /// <summary>
        /// Refreshes the list of active chats displayed on the UI.
        /// </summary>
        private void RefreshActiveChats()
        {
            // Clear the layout
            this.chatStackLayout.Children.Clear();

            // Parse the chats
            foreach (TextChat chat in this.chatService.GetAllChats())
            {
                // Create a custom UI element for each chat
                var chatLayout = new StackLayout
                {
                    Margin = new Thickness(7),
                    BackgroundColor = Color.FromArgb("#E2E2E2"),
                };

                var chatHeaderLayout = new StackLayout { Orientation = StackOrientation.Horizontal, Margin = new Thickness(10) };
                var chatInfoLayout = new StackLayout { VerticalOptions = LayoutOptions.Center, Margin = new Thickness(8) };
                var chatIdLabel = new Label
                {
                    Text = $"Chat ID: {chat.Id}",
                    FontSize = 18,
                    FontAttributes = FontAttributes.Bold,
                    TextColor = Color.FromArgb("#000000"),
                };

                var lastMessageLabel = new Label
                {
                    Text = $"Last Message: {((chat.Messages.Count != 0) ? chat.Messages.Last().Content : "No messages yet")}",
                    FontSize = 15,
                    TextColor = Color.FromArgb("#000000"),
                };

                chatInfoLayout.Children.Add(chatIdLabel);
                chatInfoLayout.Children.Add(lastMessageLabel);
                chatHeaderLayout.Children.Add(chatInfoLayout);
                chatLayout.Children.Add(chatHeaderLayout);
                chatLayout.GestureRecognizers.Add(new TapGestureRecognizer
                {
                    CommandParameter = chat,
                    Command = new Command(this.OpenDummyPage),
                });

                // Add the custom UI element to the stack layout
                this.chatStackLayout.Children.Add(chatLayout);
            }
        }

        /// <summary>
        /// Opens the chat page corresponding to the selected chat.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        private async void OpenDummyPage(object sender)
        {
            if (sender is TextChat selectedChat)
            {
                // Open the chat page
                MessageService messageService = new (selectedChat, this.currentUserId);
                await this.Navigation.PushAsync(new ChatRoomPage(this.currentUserId, messageService));
            }
        }

        /// <summary>
        /// Handles the event when the random chat button is clicked.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event arguments.</param>
        private async void RandomChatButton_Clicked(object sender, EventArgs e)
        {
            this.RefreshActiveChats();
            RandomMatchingService randomMatchingService = new (this.chatService, new UserChatListService(this.chatService));
            TextChat textChat = randomMatchingService.RequestMatchingChatRoom(this.currentUserConfig);
            MessageService messageService = new (textChat, this.currentUserId);
            await this.Navigation.PushAsync(new ChatRoomPage(this.currentUserId, messageService));
        }

        /// <summary>
        /// Handles the event when the open chat button is clicked.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event arguments.</param>
        private void OpenChatButton_Clicked(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Handles the event when the requests button is clicked.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event arguments.</param>
        private void RequestsButton_Clicked(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Handles the event when a chat item is clicked.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event arguments.</param>
        private void ChatItem_Clicked(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Handles the event when the map button is clicked.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event arguments.</param>
        private async void MapButton_Clicked(object sender, EventArgs e)
        {
            await this.Navigation.PushAsync(new MapWindow());
        }
    }
}