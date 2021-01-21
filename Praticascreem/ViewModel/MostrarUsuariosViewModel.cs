using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
using System;
using System.Text.RegularExpressions;
using Praticascreem.Models;
using Praticascreem.Data;
using Praticascreem.View;
using System.Threading.Tasks;
using Praticascreem.ViewModel;

namespace Praticascreem.ViewModel
{
    public class MostrarUsuariosViewModel : BaseViewModel
    {
        #region Attributes
        public string email;
        public string password;
        public string nombre;
        public string edad;
        public object listViewSource;
        public bool isRefreshing = false;
        


        #endregion

        public MostrarUsuariosViewModel()
        {
          
       
          LoadData();
        }

        #region Properties
        public string Emailtxt
        {
            get { return this.email; }

            set { SetValue(ref this.email, value); }
        }


        public string Passwordtxt
        {

            get { return this.password; }

            set { SetValue(ref this.password, value); }
        }


        public string Nombretxt
        {

            get { return this.nombre; }

            set { SetValue(ref this.nombre, value); }
        }


        public string Edadtxt
        {

            get { return this.edad; }

            set { SetValue(ref this.edad, value); }
        }


        public bool IsRefreshing
        {
            get { return isRefreshing; }

            set { SetValue(ref this.isRefreshing,value); }


        }

        public object ListViewSource
        {

            get { return this.listViewSource; }

            set { SetValue(ref this.listViewSource, value); }

        }


        #endregion


        public async Task LoadData()
        {
        this.ListViewSource = await App.Database.GetAllUserAsync();

        }


        #region Command
         
       

        #endregion




    }
}
