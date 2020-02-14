using TSP.Forms.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TSP.Forms.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlanGrupalPage : ContentPage
    {
        public PlanGrupalPage()
        {
            InitializeComponent();
            BindingContext = new PlanGrupalListViewModel();
        }
    }
}