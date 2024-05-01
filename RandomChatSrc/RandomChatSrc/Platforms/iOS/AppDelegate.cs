// <copyright file="AppDelegate.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace RandomChatSrc
{
    using Foundation;

    /// <summary>
    /// The AppDelegate class is the main entry point of the application.
    /// It inherits from MauiUIApplicationDelegate which provides base functionality for MAUI applications.
    /// </summary>
    [Register("AppDelegate")]
    public class AppDelegate : MauiUIApplicationDelegate
    {
        /// <summary>
        /// Creates the MauiApp instance for the application.
        /// This method is called by the runtime to get the MauiApp instance.
        /// </summary>
        /// <returns>The MauiApp instance created by the MauiProgram.</returns>
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}