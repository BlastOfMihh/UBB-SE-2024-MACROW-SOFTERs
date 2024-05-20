using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using RandomChatSrc.Models;
using RandomChatSrc.Services.MapService;

namespace RandomChatSrc.Pages
{
    /// <summary>
    /// The MapWindow class represents a page that displays a map.
    /// It inherits from ContentPage which represents a single screen of content.
    /// </summary>
    public partial class MapWindow : ContentPage
    {
        private IMapService mapService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MapWindow"/> class.
        /// </summary>
        public MapWindow(IMapService mapService)
        {
            InitializeComponent();
            this.mapService = mapService;
            SetLocationAsync();
        }

        private async void SetLocationAsync()
        {
            MapLocation currentMapLocation = await this.mapService.GetCurrentLocation();

            if (currentMapLocation.UserId != Guid.Empty)
            {
                // Move the map to a specific region
                map.MoveToRegion(MapSpan.FromCenterAndRadius(new Location(currentMapLocation.XCoordinates, currentMapLocation.YCoordinates), Distance.FromKilometers(0.5)));

                // Create a new pin at the specified location
                var pin = new Pin()
                {
                    Location = new Location(currentMapLocation.XCoordinates, currentMapLocation.YCoordinates),
                    Label = "You",
                };

                // Add the pin to the map
                map.Pins.Add(pin);
            }
            else
            {
                await DisplayAlert("Error", "Unable to get location.", "OK");
            }
        }
    }
}
