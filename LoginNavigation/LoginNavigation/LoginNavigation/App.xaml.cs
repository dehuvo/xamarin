﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace LoginNavigation {
  public partial class App : Application {
    public static bool IsUserLoggedIn { get; set; }

    public App() {
      InitializeComponent();

      if (IsUserLoggedIn) {
        MainPage = new NavigationPage(new MainPage());
      } else {
        MainPage = new NavigationPage(new LoginPage());
      }
    }

    protected override void OnStart() {
      // Handle when your app starts
    }

    protected override void OnSleep() {
      // Handle when your app sleeps
    }

    protected override void OnResume() {
      // Handle when your app resumes
    }
  }
}
