using RandomChatSrc.Domain;
using RandomChatSrc.Domain.TextChat;
using RandomChatSrc.Domain.User;

namespace RandomChatSrc.Pages;

public partial class ChatRoomPage : ContentPage
{
    private readonly TextChat textChat;
    private readonly User currentUser;

    public ChatRoomPage(TextChat textChat, User currentUser)
	{
		InitializeComponent();
        this.textChat = textChat;
        this.currentUser = currentUser;
        LoadConversation();
	}

    private void LoadConversation()
    {
        if (textChat == null)
            return;

        MessageContainer.Children.Clear();

        foreach (Message message in textChat.Messages)
        {
            var messageLabel = new Label
            {
                Text = $"[{message.SentTime}] User {message.SenderId}: {message.Content}",
                HorizontalOptions = message.SenderId == currentUser.id ? LayoutOptions.EndAndExpand : LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Start,
                BackgroundColor = message.SenderId == currentUser.id ? Color.FromHex("ADD8E6") : Color.FromHex("CCCCCC"),
                TextColor = Color.FromHex("000000"),
                Padding = new Thickness(10),
                Margin = new Thickness(10, 5, 10, 5),
                HorizontalTextAlignment = message.SenderId == currentUser.id ? TextAlignment.End : TextAlignment.Start,
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
            textChat.AddMessage(currentUser.id, messageText);

            // Display the new message in the conversation UI
            var messageLabel = new Label
            {
                Text = $"[Now] User {currentUser.id}: {messageText}",
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