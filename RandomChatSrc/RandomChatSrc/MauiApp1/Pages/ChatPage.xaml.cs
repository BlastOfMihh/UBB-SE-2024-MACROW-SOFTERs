using MauiApp1.ViewModel;

namespace MauiApp1;

[QueryProperty(nameof(ChatId), "chatId")]
public partial class ChatPage : ContentPage
{
    private readonly ChatPageViewModel viewModel;

    private int chatId;
    public int ChatId
    {
        get => chatId;
        set
        {
            chatId = value;
            viewModel.SetChatId(chatId);
        }
    }

    public ChatPage(ChatPageViewModel viewModel)
    {
        InitializeComponent();
        this.viewModel = viewModel;
        this.BindingContext = viewModel;
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        string route = "///MainPage";
        await Shell.Current.GoToAsync(route);
    }

    private async void OnFileClicked(object sender, EventArgs e)
    {
        var customFileTypes = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
        {
            [DevicePlatform.WinUI] = new[] { ".pdf", ".txt", ".cs", ".docx", ".xslx", ".pptx" }
        });

        try
        {
            // Set up pick options to filter for specific file types
            var pickOptions = new PickOptions
            {
                PickerTitle = "Please select a file",
                FileTypes = customFileTypes
            };

            // Open the file picker
            var result = await FilePicker.Default.PickAsync(pickOptions);
            if (result != null)
            {
                // Handle the file
                viewModel.AddTextMessageToChat(result.FullPath);
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Error picking file: {exception.Message}");
        }
    }

    private async void OnImageClicked(object sender, EventArgs e)
    {
        var customFileTypes = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
        {
            [DevicePlatform.WinUI] = new[] { ".jpg", ".jpeg", ".png", ".mp4", ".mov", ".wmv" }
        });

        try
        {
            // Set up pick options to filter for specific file types
            var pickOptions = new PickOptions
            {
                PickerTitle = "Please select an image",
                FileTypes = customFileTypes
            };

            // Open the file picker
            var result = await FilePicker.Default.PickAsync(pickOptions);
            if (result != null)
            {
                // Handle the file
                viewModel.AddTextMessageToChat(result.FullPath);
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Error picking file: {exception.Message}");
        }
    }

    private async void OnMicrophoneClicked(object sender, EventArgs e)
    {
        var customFileTypes = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
        {
            [DevicePlatform.WinUI] = new[] { ".mp3" }
        });

        try
        {
            // Set up pick options to filter for specific file types
            var pickOptions = new PickOptions
            {
                PickerTitle = "Please select a file",
                FileTypes = customFileTypes
            };

            // Open the file picker
            var result = await FilePicker.Default.PickAsync(pickOptions);
            if (result != null)
            {
                // Handle the file
                viewModel.AddTextMessageToChat(result.FullPath);
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Error picking file: {exception.Message}");
        }
    }

    private void OnSendClicked(object sender, EventArgs e)
    {
        string text = this.MessageInput.Text;
        viewModel.AddTextMessageToChat(text);
        this.MessageInput.Text = string.Empty;
    }
}
