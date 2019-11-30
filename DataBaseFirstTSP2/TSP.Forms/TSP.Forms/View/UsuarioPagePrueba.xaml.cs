using TSP.Forms.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TSP.Forms.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsuarioPagePrueba : ContentPage
    {
        public UsuarioPagePrueba()
        {
            InitializeComponent();
            BindingContext = new UsuarioPruebaListViewModel();
        }
    }
}