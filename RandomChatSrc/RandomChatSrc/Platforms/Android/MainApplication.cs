// <copyright file="MainApplication.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RandomChatSrc
{
    using Android.App;
    using Android.Runtime;

    /// <summary>
    /// The MainApplication class is the main entry point for the Android application.
    /// It inherits from MauiApplication which provides base functionality for MAUI applications on Android.
    /// </summary>
    [Application]
    public class MainApplication : MauiApplication
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainApplication"/> class.
        /// </summary>
        /// <param name="handle">A handle to the managed peer of the Java object.</param>
        /// <param name="ownership">Enumeration value indicating whether Java owns the raw handle.</param>
        public MainApplication(IntPtr handle, JniHandleOwnership ownership)
            : base(handle, ownership)
        {
        }

        /// <summary>
        /// Creates the MauiApp instance for the application.
        /// This method is called by the runtime to get the MauiApp instance.
        /// </summary>
        /// <returns>The MauiApp instance created by the MauiProgram.</returns>
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}