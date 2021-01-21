using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PracticSqliteCrud.Base
{

    // INotifyPropertyChanged Para actualizar todas las vistas
    public class ViewModelBase : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyname));
        }

        }
}
