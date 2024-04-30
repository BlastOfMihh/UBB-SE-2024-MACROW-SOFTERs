using System.Xml;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
namespace RandomChatSrc.Pages;
public partial class MapWindow : ContentPage
{
    private Guid currentUserId;

    public MapWindow()
    {
        InitializeComponent();
        map.MoveToRegion(MapSpan.FromCenterAndRadius(new Location(46.773545, 23.622010), Distance.FromKilometers(0)));
        var pin = new Microsoft.Maui.Controls.Maps.Pin()
        {
            Location = new Location(46.773545, 23.622010),
            Label = $"You",
        };
        map.Pins.Add(pin);

        pin.MarkerClicked += Pin_Clicked;
        pin.InfoWindowClicked += InfoWindow_Clicked;
    }

    private void InfoWindow_Clicked(object sender, PinClickedEventArgs e)
    {
         DisplayAlert("Chat Request sent", $"Sent request to {currentUserId}", "Ok");
    }

    private void Pin_Clicked(object sender, PinClickedEventArgs e)
    {
    }
}