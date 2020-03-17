
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using TSP.Forms.Model;
using Xamarin.Forms;

namespace TSP.Forms.ViewModel
{
    internal class LoginListViewModel : INotifyPropertyChanged
    {
        public ICommand LoginCommand { get; set; }

        public LoginListViewModel()
        {
            LoginCommand = new Command(async () => await LoginUser());
        }


        private async Task LoginUser()
        {
            await App.Current.MainPage.Navigation.PushAsync(new MainPage());
            /**
            var httpClient = new HttpClient();
            bool verificadorLogin = false;
            var user = new Usuario
            {
                Correo = "jaime.bernal@gamil.com",
                Contrasena = "123"
            };
           
            httpClient.BaseAddress = new Uri("https://databasefirsttsp3.azurewebsites.net/");
            var postRequest = httpClient.PostAsync("api/Usuarios/Login", user, new JsonMediaTypeFormatter()).Result;
            
            if (true)
            {
                var resultString = postRequest.Content.ReadAsStringAsync().Result;
                var resultado = JsonConvert.DeserializeObject<bool>(resultString);
                verificadorLogin = resultado;
                await App.Current.MainPage.Navigation.PushAsync(new MainPage());
            }
    **/

        }




        #region ListViewImplemetation2

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged == null)
            {
                return;
            }

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
