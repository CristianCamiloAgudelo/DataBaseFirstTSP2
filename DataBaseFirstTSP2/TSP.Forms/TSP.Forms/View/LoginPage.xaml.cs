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
            login.Clicked += login_Clicked;
            BindingContext = new LoginListViewModel();
        }

        void login_Clicked(object sender, EventArgs e)
        {
            CrossLocalNotifications.Current.Show("Registro Exitoso", "Ahora puedes ingresar con tu correo y tu contraseña", 0, DateTime.Now.AddSeconds(2));
        }

        private void ShowPlayerIdHandler(object sender, EventArgs e)
        {
            OneSignal.Current.IdsAvailable(new Com.OneSignal.Abstractions.IdsAvailableCallback((playerID, pushToken) =>
            {
                
            }));
        }
    }
}