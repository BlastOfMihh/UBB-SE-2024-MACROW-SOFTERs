// <copyright file="App.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RandomChatSrc
{
    using RandomChatSrc.Pages;
    using RandomChatSrc.Services.ChatroomsManagement;

    /// <summary>
    ///     Entry point of the MauiApp.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            ChatroomsManagementService cms = new ();
            this.MainPage = new NavigationPage(new OpenChatsWindow(cms));
        }
    }
}
