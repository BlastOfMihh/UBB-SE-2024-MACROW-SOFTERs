using MauiApp1.ViewModel;

namespace MauiApp1
{
    public partial class ChatAppMainPage : ContentPage
    {
        private readonly MainPageViewModel viewModel;

        public ChatAppMainPage(MainPageViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            this.BindingContext = viewModel;
        }

        public void OnSearchBarTextChanged(object sender, TextChangedEventArgs eventArguments)
        {
            string text = eventArguments.NewTextValue;
            viewModel.FilterContacts(text);
        }

        private async void OnSelectionChanged(object sender, SelectionChangedEventArgs eventArguments)
        {
            if (eventArguments.CurrentSelection.FirstOrDefault() is ContactLastMessage selectedContact)
            {
                // string route = $"///ChatPage?chatId={selectedContact.ChatId}";
                // await Shell.Current.GoToAsync(route
                int userId = 1;
                ChatPageViewModel chatPageViewModel = new ChatPageViewModel(viewModel.GetService(), userId);
                await this.Navigation.PushAsync(new ChatPage(chatPageViewModel));
                ((CollectionView)sender).SelectedItem = null;
            }
        }

        protected override void OnNavigatedTo(NavigatedToEventArgs arguments)
        {
            base.OnNavigatedTo(arguments);

            viewModel.RefreshContacts(string.Empty);
        }
    }
}
