using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MvvmDemo2.Views;


namespace MvvmDemo2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();                        // if no stack to be used
            MainPage = new NavigationPage(new MainPage());      // if stack to be used
        }

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
    }
}
