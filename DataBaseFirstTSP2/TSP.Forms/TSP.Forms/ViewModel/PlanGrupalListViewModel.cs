using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;
using System.Runtime.CompilerServices;
using TSP.Forms.Model;

namespace TSP.Forms.ViewModel
{
    internal class PlanGrupalListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<PlanGrupal> PlanGrupalColleccion2 { get; set; }
        public ObservableCollection<Tarea> TareasColleccion { get; set; }

        public string NombreEquipo { get; set; }


        public PlanGrupalListViewModel()
        {
            GetPlanGrupalApi();

        }

        //public async Task<PlanGrupal> GetPlanGrupalApiAsync()
        //{
        //    var HttpCliente = new HttpClient();

        //    HttpResponseMessage PlanGrupalJson = HttpCliente.GetAsync("https://databasefirsttsp2.azurewebsites.net/api/PlanIndividual/1").Result;
        //    var apiResponse = await PlanGrupalJson.Content.ReadAsStringAsync();
        //    var PlanGrupalConvertido = JsonConvert.DeserializeObject<PlanGrupal>(apiResponse);
        //    return PlanGrupalConvertido;
        //}

        public void GetPlanGrupalApi()
        {

            var json = new WebClient().DownloadString("https://databasefirsttsp2.azurewebsites.net/api/plangrupal/1");
            var plangrupals = JsonConvert.DeserializeObject<PlanGrupal>(json);

            NombreEquipo = plangrupals.Nombre;

            PlanGrupalColleccion2 = new ObservableCollection<PlanGrupal>()
            {
                new PlanGrupal(){Nombre = plangrupals.Nombre,
                    EquipoDesarrolloId = plangrupals.EquipoDesarrolloId,
                    Tarea = plangrupals.Tarea
                }


            };
            TareasColleccion = new ObservableCollection<Tarea>();
            foreach (Tarea tarea in plangrupals.Tarea)
            {

                TareasColleccion.Add(tarea);
            }
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
