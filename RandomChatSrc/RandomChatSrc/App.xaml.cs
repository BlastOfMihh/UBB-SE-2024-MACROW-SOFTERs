// <copyright file="App.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RandomChatSrc
{
    using RandomChatSrc.Pages;
    using RandomChatSrc.Repositories;
    using RandomChatSrc.Services.ChatroomsManagement;
    using RandomChatSrc.Services.MapService;

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
            this.MainPage = new NavigationPage(new AppStart());
        }
    }
}
