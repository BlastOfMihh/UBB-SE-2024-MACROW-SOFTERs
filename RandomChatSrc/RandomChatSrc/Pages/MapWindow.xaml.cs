

using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using System.Xml;


namespace RandomChatSrc.Pages;
public partial class MapWindow : ContentPage
{
    private Guid currentUserId;

    public MapWindow()
    {
        string filePath = "D:\\School\\An 2\\Sem 2\\ISS\\UBB-SE-2024-MACROW-SOFTERs\\RandomChatSrc\\RandomChatSrc\\RepoMock\\CurrentUser.xml";
        try
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            var userId = doc.SelectSingleNode("/Users/CurrentUser/Id").InnerText;
            if (userId == null)
            {
                throw new Exception("User not found");
            }
            this.currentUserId = new Guid(userId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        InitializeComponent();
        map.MoveToRegion(MapSpan.FromCenterAndRadius(new Location(46.773545, 23.622010), Distance.FromKilometers(0)));
        var pin1 = new Microsoft.Maui.Controls.Maps.Pin()
        {
            Location = new Location(46.773545, 23.622010),
            Label = $"You",
        };
        map.Pins.Add(pin1);

        pin1.MarkerClicked += Pin_Clicked;
        pin1.InfoWindowClicked += InfoWindow_Clicked;
        
    }

    private void InfoWindow_Clicked(object sender, PinClickedEventArgs e)
    {
         DisplayAlert("Chat Request sent", $"Sent request to {currentUserId}", "Ok");
    }

    private void Pin_Clicked(object sender, PinClickedEventArgs e)
    {
        
    }
}