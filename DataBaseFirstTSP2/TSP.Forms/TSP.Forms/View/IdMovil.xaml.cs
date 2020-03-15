using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Xamarin.Forms;
using Com.OneSignal;
using Xamarin.Forms.Xaml;

namespace TSP.Forms.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IdMovil : ContentPage
    {
        public IdMovil()
        {
            InitializeComponent();
        }

        private void ShowPlayerIdHandler(object sender, EventArgs e)
        {
            OneSignal.Current.IdsAvailable(new Com.OneSignal.Abstractions.IdsAvailableCallback((playerID, pushToken) =>
            {
                playerIdLabel.Text = $"Player ID de este device:\n{playerID}";
            }));
        }
    }
}