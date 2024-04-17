

using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using System.Xml;
using RandomChatSrc.Domain.MapLocation;
using RandomChatSrc.Services.MapService;
using RandomChatSrc.Services.GlobalServices;



namespace RandomChatSrc.Pages;
public partial class MapWindow : ContentPage
{
    private Guid currentUserId;
    private MapService mapService;

    public MapWindow(Guid currentUserId)
    {
        this.currentUserId = currentUserId;
        this.mapService = new MapService();

        InitializeComponent();
        RefreshPins();

        map.MoveToRegion(MapSpan.FromCenterAndRadius(new Location(46.773545, 23.622010), Distance.FromKilometers(0)));
        var currentUserPin = new Pin()
        {
            Location = new Location(46.773545, 23.622010),
            Label = $"You",
        };
        map.Pins.Add(currentUserPin);


    }

    private void RefreshPins()
    {
        map.Pins.Clear();

        foreach (MapLocation location in mapService.getAllUserLocations())
        {
            var pin = new Pin()
            {
                Location = new Location(location.xCoord, location.yCoord),
                Label = $"{location.UserId}",
            };

            map.Pins.Add(pin);
            pin.InfoWindowClicked += InfoWindow_Clicked;
        }
    }

    private void InfoWindow_Clicked(object sender, PinClickedEventArgs e)
    {
        if (sender is Pin userPin)
        {
            DisplayAlert("Chat Request sent", $"Sent request to {userPin.Label}", "Ok");
        }
    }

    private void Pin_Clicked(object sender, PinClickedEventArgs e)
    {

    }
}