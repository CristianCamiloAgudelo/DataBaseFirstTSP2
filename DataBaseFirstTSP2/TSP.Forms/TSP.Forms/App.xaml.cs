using System;
using TSP.Forms.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Com.OneSignal;

namespace TSP.Forms
{
    public partial class App : Application
    {
        
        public App()
        {
            InitializeComponent();
       
        MainPage = new NavigationPage(new LoginPage());
            OneSignal.Current.StartInit("c6daf915-ef4d-41be-9860-ab7832c2195f").EndInit();
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
