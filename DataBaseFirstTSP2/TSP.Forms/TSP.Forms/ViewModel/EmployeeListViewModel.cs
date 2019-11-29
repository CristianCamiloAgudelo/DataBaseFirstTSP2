using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using TSP.Forms.Model;

namespace TSP.Forms.View
{
    class EmployeeListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Employee> Employees { get; set; }
        public EmployeeListViewModel()
        {
            Employees = new ObservableCollection<Employee>()
            {
                new Employee(){Id =1, Name = "Graja", Quantity=1,Total=25},
                new Employee(){Id =2, Name = "Agu", Quantity=1,Total=25},
                new Employee(){Id =3, Name = "Loren", Quantity=1,Total=25},
                new Employee(){Id =4, Name = "YerMAlo", Quantity=1,Total=25}
            };
        }

        #region ListViewImplemetation

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
