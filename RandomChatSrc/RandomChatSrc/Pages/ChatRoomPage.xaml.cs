namespace RandomChatSrc.Pages;

public partial class ChatRoomPage : ContentPage
{
	public ChatRoomPage()
	{
		InitializeComponent();
	}


    [Obsolete]
    private void SendMessage_Clicked(object sender, EventArgs e)
        {
            string messageText = MessageEntry.Text.Trim();
            if (!string.IsNullOrEmpty(messageText))
            {
                Label messageLabel = new Label
                {
                    Text = messageText,
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

                MessageEntry.Text = string.Empty;
            }
        }
}