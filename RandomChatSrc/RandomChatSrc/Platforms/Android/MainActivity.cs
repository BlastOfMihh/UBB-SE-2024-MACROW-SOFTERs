// <copyright file="MainActivity.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RandomChatSrc
{
    using Android.App;
    using Android.Content.PM;

    /// <summary>
    /// The MainActivity class is the main entry point for the Android application.
    /// It inherits from MauiAppCompatActivity which provides base functionality for MAUI applications on Android.
    /// </summary>
    [Activity(
        Theme = "@style/Maui.SplashTheme",
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)
        ]
    public class MainActivity : MauiAppCompatActivity
    {
    }
}