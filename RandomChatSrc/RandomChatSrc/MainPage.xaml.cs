// <copyright file="MainPage.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace RandomChatSrc
{
    /// <summary>
    /// The MainPage class represents the main page of the application.
    /// It inherits from ContentPage which represents a single screen of content.
    /// </summary>
    public partial class MainPage : ContentPage
    {
        /// <summary>
        /// The count of how many times the counter button has been clicked.
        /// </summary>
        private int count = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage"/> class.
        /// </summary>
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Event handler for the Counter button click event.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void OnCounterClicked(object sender, EventArgs e)
        {
            this.count++;

            if (this.count == 1)
            {
                this.CounterBtn.Text = $"Clicked {this.count} time";
            }
            else
            {
                this.CounterBtn.Text = $"Clicked {this.count} times";
            }

            // Announce the new button text to the screen reader
            SemanticScreenReader.Announce(this.CounterBtn.Text);
        }
    }
}