﻿using LandsXamarin.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace LandsXamarin
{
  public partial class App : Application
  {
    #region Constores
    public App()
    {
      InitializeComponent();

      MainPage = new NavigationPage(new LoginPage());
    }

    #endregion

    #region Métodos Página
    protected override void OnStart()
    {
      // Handle when your app starts
    }

    protected override void OnSleep()
    {
      // Handle when your app sleeps
    }

    protected override void OnResume()
    {
      // Handle when your app resumes
    }

    #endregion
  }//fin clase
}//fin namespace
