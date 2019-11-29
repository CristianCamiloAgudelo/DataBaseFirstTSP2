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
    public partial class InboxPage : ContentPage
    {
        public InboxPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }
    }
}