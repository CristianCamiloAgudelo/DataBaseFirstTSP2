
using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace TSP.Forms.ViewModel
{
    internal class LoginListViewModel : INotifyPropertyChanged
    {
        public ICommand LoginCommand { get; private set; }

        private string correoElectronico, contraseña;

        public LoginListViewModel()
        {
            LoginCommand = new Command(async () => await LoginUser());
        }



        public string CorreoElectronico
        {
            get
            {
                return correoElectronico;
            }
            set
            {
                if (correoElectronico != value)
                {
                    correoElectronico = value;
                    OnPropertyChanged("CorreoElectronico");
                }
            }
        }

        public string Contraseña
        {
            get
            {
                return contraseña;
            }
            set
            {
                if (contraseña != value)
                {
                    contraseña = value;
                    OnPropertyChanged("Contraseña");
                }
            }
        }

        private async Task LoginUser()
        {
            await App.Current.MainPage.Navigation.PushAsync(new MainPage());
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
