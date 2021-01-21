using PracticSqliteCrud.Base;
using PracticSqliteCrud.Models;
using PracticSqliteCrud.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PracticSqliteCrud.ViewModels
{

    public class RazasViewModel : ViewModelBase
    {
        public RazasViewModel()
        {
            RepositoryRazas repo = new RepositoryRazas();
            List<Raza> lista = repo.GetRazas();
            this.Razas = new ObservableCollection<Raza>(lista);
        }

        private ObservableCollection<Raza> _Razas;
        public ObservableCollection<Raza> Razas
        {
            get { return this._Razas; }
            set
            {
                this._Razas = value;
                OnPropertyChanged("Razas");
            }
        }
    }
}