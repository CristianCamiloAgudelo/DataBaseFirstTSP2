using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Syncfusion.SfCalendar.XForms;

namespace TSP.Forms.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Calendar : ContentPage
    {
        public Calendar()
        {
            InitializeComponent();

            SfCalendar calendar = new SfCalendar();
            //calendar.SelectionMode = Syncfusion.SfCalendar.XForms.SelectionMode.MultiRangeSelection;

        }
    }
}