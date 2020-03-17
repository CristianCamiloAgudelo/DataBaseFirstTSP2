using Com.OneSignal;
using Plugin.LocalNotifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSP.Forms.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TSP.Forms.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        
               
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginListViewModel();
        }
        

        public void login_Clicked(object sender, EventArgs e)
        {
            ShowPlayerIdHandler(sender,e);
            
        }

        private void ShowPlayerIdHandler(object sender, EventArgs e)
        {
            OneSignal.Current.IdsAvailable(new Com.OneSignal.Abstractions.IdsAvailableCallback((playerID, pushToken) =>
            {
                
            }));
        }
    }
}