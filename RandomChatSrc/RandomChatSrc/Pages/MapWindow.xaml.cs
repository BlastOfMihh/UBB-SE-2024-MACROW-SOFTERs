// <copyright file="MapWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RandomChatSrc.Pages
{
    using Microsoft.Maui.Controls.Maps;
    using Microsoft.Maui.Maps;

    /// <summary>
    /// The MapWindow class represents a page that displays a map.
    /// It inherits from ContentPage which represents a single screen of content.
    /// </summary>
    public partial class MapWindow : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MapWindow"/> class.
        /// </summary>
        public MapWindow()
        {
            this.InitializeComponent();

            // Move the map to a specific region
            this.map.MoveToRegion(MapSpan.FromCenterAndRadius(new Location(46.773545, 23.622010), Distance.FromKilometers(0)));

            // Create a new pin at the specified location
            var pin = new Pin()
            {
                Location = new Location(46.773545, 23.622010),
                Label = $"You",
            };

            // Add the pin to the map
            this.map.Pins.Add(pin);
        }
    }
}