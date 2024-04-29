using RandomChatSrc.Models;
using RandomChatSrc.Services.MessageService;

namespace RandomChatSrc.Pages;

public partial class ChatRoomPage : ContentPage
{
    private readonly TextChat textChat;
    private readonly Guid currentUserId;
    MessageService messageService;

    public ChatRoomPage(TextChat textChat, Guid currentUser)
    {
        InitializeComponent();
        this.textChat = textChat;
        this.currentUserId = currentUser;
        messageService = new MessageService(textChat, currentUserId);
        LoadConversation();
    }

    private void LoadConversation()
    {
        if (textChat == null)
            return;

        MessageContainer.Children.Clear();
        var chatHeaderLayout = new StackLayout { Orientation = StackOrientation.Horizontal, BackgroundColor = Color.FromHex("#332769"), Padding = new Thickness(8) };
        var chatIdLabel = new Label { Text = $"Chatroom: {textChat.Id}", HorizontalOptions = LayoutOptions.CenterAndExpand,
            FontSize = 16,
            FontAttributes = FontAttributes.Bold
        };
        chatHeaderLayout.Children.Add( chatIdLabel );
        MessageContainer.Children.Add( chatHeaderLayout );

        foreach (Message message in textChat.Messages)
        {
            var messageLabel = new Label
            {
                Text = $"[{message.SentTime}] User {message.SenderId}: {message.Content}",
                HorizontalOptions = message.SenderId == currentUserId.ToString() ? LayoutOptions.EndAndExpand : LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Start,
                BackgroundColor = message.SenderId == currentUserId.ToString() ? Color.FromHex("ADD8E6") : Color.FromHex("CCCCCC"),
                TextColor = Color.FromHex("000000"),
                Padding = new Thickness(10),
                Margin = new Thickness(10, 5, 10, 5),
                HorizontalTextAlignment = message.SenderId == currentUserId.ToString() ? TextAlignment.End : TextAlignment.Start,
                VerticalTextAlignment = TextAlignment.Center
            };

            MessageContainer.Children.Add(messageLabel);
        }
    }

    [Obsolete]
    private void SendMessage_Clicked(object sender, EventArgs e)
    {
        string messageText = MessageEntry.Text.Trim();
        if (!string.IsNullOrEmpty(messageText))
        {

            messageService.SendMessage(messageText);

            // Display the new message in the conversation UI
            var messageLabel = new Label
            {
                Text = $"[Now] User {currentUserId.ToString()}: {messageText}",
                HorizontalOptions = LayoutOptions.EndAndExpand,
                VerticalOptions = LayoutOptions.Start,
                BackgroundColor = Color.FromHex("ADD8E6"),
                TextColor = Color.FromHex("000000"),
                Padding = new Thickness(10),
                Margin = new Thickness(10, 5, 10, 5),
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalTextAlignment = TextAlignment.Center
            };

            MessageContainer.Children.Add(messageLabel);

            // Clear the message entry
            MessageEntry.Text = string.Empty;
        }
    }
}