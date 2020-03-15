
using Newtonsoft.Json;
using System;
using System.Collections;
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
        public ICommand LoginCommand { get; private set; }

        private string _correo, _contrasena;

        public LoginListViewModel()
        {
            //C:\MicrosoftVisualStudio\DataBaseFirstTSP2\DataBaseFirstTSP2\TSP.Forms\TSP.Forms\ViewModel\LoginListViewModel.cs
            LoginCommand = new Command(async () => await LoginUser().ConfigureAwait(false));
        }



        public string Correo
        {
            get
            {
                return _correo;
            }
            set
            {
                _correo = value;
                OnPropertyChanged("correo");
            }
        }

        private void RaisePropertyChanged(string propertyName)
        {
            var handle = PropertyChanged;
            if (handle != null)
            {
                handle(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string Contrasena
        {
            get
            {
                return _contrasena;
            }
            set
            {
                _contrasena = value;
                OnPropertyChanged("contraseña");
            }
        }

        private async Task LoginUser()
        {
            var httpClient = new HttpClient();
            bool verificadorLogin = false;
            var user = new Usuario
            {
                Correo = "jaime.bernal@gamil.com",
                Contrasena = "123"
            };
            httpClient.BaseAddress = new Uri("https://databasefirsttsp3.azurewebsites.net/");
            var postRequest = httpClient.PostAsync("api/Usuarios/Login", user, new JsonMediaTypeFormatter()).Result;
            
            if (postRequest.IsSuccessStatusCode)
            {
                var resultString = postRequest.Content.ReadAsStringAsync().Result;
                var resultado = JsonConvert.DeserializeObject<bool>(resultString);
                verificadorLogin = resultado;
                await App.Current.MainPage.Navigation.PushAsync(new MainPage());
            }
            
        }


        #region ListViewImplemetation2

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged ? .Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
