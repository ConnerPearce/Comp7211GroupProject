using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Comp7211GroupProject
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new NavigationPage(new MainPage());
            var navi = Application.Current.MainPage as NavigationPage;
            navi.BarBackgroundColor = Color.Black;
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
