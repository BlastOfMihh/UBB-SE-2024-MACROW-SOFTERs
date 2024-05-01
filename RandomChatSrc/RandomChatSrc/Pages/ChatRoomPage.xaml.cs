// <copyright file="ChatRoomPage.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RandomChatSrc.Pages
{
    using RandomChatSrc.Models;
    using RandomChatSrc.Services.MessageService;

    /// <summary>
    /// The ChatRoomPage class represents a page that displays a chat room.
    /// It inherits from ContentPage which represents a single screen of content.
    /// </summary>
    public partial class ChatRoomPage : ContentPage
    {
        private readonly Guid currentUserId;
        private MessageService messageService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatRoomPage"/> class.
        /// </summary>
        /// <param name="currentUser">The ID of the current user.</param>
        /// <param name="messageService">The service used to send and receive messages.</param>
        public ChatRoomPage(Guid currentUser, MessageService messageService)
        {
            this.InitializeComponent();
            this.currentUserId = currentUser;
            this.messageService = messageService;
            this.LoadConversation();
        }

        /// <summary>
        /// Loads the conversation from the message service into the UI.
        /// </summary>
        private void LoadConversation()
        {
            TextChat textChat = this.messageService.GetTextChat();
            this.MessageContainer.Children.Clear();
            var chatHeaderLayout = new StackLayout { Orientation = StackOrientation.Horizontal, BackgroundColor = Color.FromArgb("#332769"), Padding = new Thickness(8) };
            var chatIdLabel = new Label
            {
                Text = $"Chatroom: {textChat.Id}",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = 16,
                FontAttributes = FontAttributes.Bold,
            };
            chatHeaderLayout.Children.Add(chatIdLabel);
            this.MessageContainer.Children.Add(chatHeaderLayout);

            foreach (Message message in textChat.Messages)
            {
                var messageLabel = new Label
                {
                    Text = $"[{message.SentTime}] User {message.SenderId}: {message.Content}",
                    HorizontalOptions = message.SenderId == this.currentUserId.ToString() ? LayoutOptions.End : LayoutOptions.Start,
                    VerticalOptions = LayoutOptions.Start,
                    BackgroundColor = message.SenderId == this.currentUserId.ToString() ? Color.FromArgb("#ADD8E6") : Color.FromArgb("#CCCCCC"),
                    TextColor = Color.FromArgb("#000000"),
                    Padding = new Thickness(10),
                    Margin = new Thickness(10, 5, 10, 5),
                    HorizontalTextAlignment = message.SenderId == this.currentUserId.ToString() ? TextAlignment.End : TextAlignment.Start,
                    VerticalTextAlignment = TextAlignment.Center,
                };

                this.MessageContainer.Children.Add(messageLabel);
            }
        }

        /// <summary>
        /// Event handler for the Send Message button click event.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void SendMessage_Clicked(object sender, EventArgs e)
        {
            string messageText = this.MessageEntry.Text.Trim();
            if (!string.IsNullOrEmpty(messageText))
            {
                this.messageService.SendMessage(messageText);

                // Display the new message in the conversation UI
                var messageLabel = new Label
                {
                    Text = $"[Now] User {this.currentUserId}: {messageText}",
                    HorizontalOptions = LayoutOptions.End,
                    VerticalOptions = LayoutOptions.Start,
                    BackgroundColor = Color.FromArgb("ADD8E6"),
                    TextColor = Color.FromArgb("000000"),
                    Padding = new Thickness(10),
                    Margin = new Thickness(10, 5, 10, 5),
                    HorizontalTextAlignment = TextAlignment.Start,
                    VerticalTextAlignment = TextAlignment.Center,
                };

                this.MessageContainer.Children.Add(messageLabel);

                // Clear the message entry
                this.MessageEntry.Text = string.Empty;
            }
        }
    }
}