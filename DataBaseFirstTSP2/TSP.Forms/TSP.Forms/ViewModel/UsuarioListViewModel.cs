using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;
using System.Runtime.CompilerServices;
using TSP.Forms.Model;

namespace TSP.Forms.ViewModel
{
    internal class UsuarioListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Usuario> UsuarioColleccion { get; set; }

        public UsuarioListViewModel()
        {
            GetUsuarioApi();
        }

        public void GetUsuarioApi()
        {

            var json = new WebClient().DownloadString("https://databasefirsttsp2.azurewebsites.net/api/Usuarios/4");
            var usuarioJson = JsonConvert.DeserializeObject<Usuario>(json);


            UsuarioColleccion = new ObservableCollection<Usuario>()
            {
                new Usuario(){
                    Codigo = usuarioJson.Codigo,
                    Nombre = usuarioJson.Nombre,
                    Apellido = usuarioJson.Apellido,
                    Rol = usuarioJson.Rol,
                    Universidad = usuarioJson.Universidad
                }


            };

        }

        #region ListViewImplemetation3

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
