using RandomChatSrc.Domain.RequestDomain;
using RandomChatSrc.Domain.UserConfig;
using RandomChatSrc.Repository;
using RandomChatSrc.Services.RequestChatService;

namespace RandomChatSrc.Pages
{
    public partial class ChatRequestsPage : ContentPage
    {
        private UserChatConfig _user;
        private RequestChatService _requestChatService;
        private StackLayout _stackLayout;

        public ChatRequestsPage(UserChatConfig user)
        {
            _user = user;
            InitializeComponent();
            _stackLayout = new StackLayout();
            Content = _stackLayout;

            string requestsFolderPath = "C:\\PC\\Info\\Facultate\\Semestru2An2\\ISS\\UBB-SE-2024-MACROW-SOFTERs\\RandomChatSrc\\RandomChatSrc\\RepoMock\\";
            RequestsChatRepo requestsChatRepo = new RequestsChatRepo(new List<Request>(), requestsFolderPath);
            _requestChatService = new RequestChatService(requestsChatRepo);
            LoadRequests();
        }

        private void LoadRequests()
        {
            List<Request> allRequests = _requestChatService.getAllRequests();
            List<Request> userRequests = allRequests.FindAll(r => r.ReceiverUserId == _user.user.id);

            foreach (var request in userRequests)
            {
                var senderUserNameLabel = new Label
                {
                    Text = request.SenderUserId.ToString(),
                    FontSize = 16
                };

                var acceptButton = new Button
                {
                    Text = "Accept",
                    BackgroundColor = Color.FromRgb(0,255,0),
                    TextColor = Color.FromRgb(255,255,255),
                    Margin = new Thickness(10)
                };
                acceptButton.Clicked += async (sender, args) =>
                {
                    _requestChatService.acceptRequest(request.RequestId, _user.user.id);
                    LoadRequests();
                    await DisplayAlert("Request Accepted", "You accepted the chat request!", "OK");
                };

                var declineButton = new Button
                {
                    Text = "Decline",
                    BackgroundColor = Color.FromRgb(255,0,0),
                    TextColor = Color.FromRgb(255, 255, 255),
                    Margin = new Thickness(10)
                };
                declineButton.Clicked += async (sender, args) =>
                {
                    _requestChatService.declineRequest(request.RequestId, _user.user.id);
                    LoadRequests();
                    await DisplayAlert("Request Declined", "You declined the chat request.", "OK");
                };

                var buttonLayout = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Margin = new Thickness(0, 10, 0, 0)
                };
                buttonLayout.Children.Add(acceptButton);
                buttonLayout.Children.Add(declineButton);

                var itemLayout = new StackLayout
                {
                    Padding = new Thickness(10),
                    Children =
                    {
                        senderUserNameLabel,
                        buttonLayout
                    }
                };

                _stackLayout.Children.Add(itemLayout);
            }
        }
    }
}
