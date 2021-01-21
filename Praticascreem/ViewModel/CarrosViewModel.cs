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
namespace Praticascreem.ViewModel
{
    public class CarrosViewModel : BaseViewModel
    {


        #region Attributes
        public string nombre;
        public string apellido;
        public string email;
        public string edad;
        public bool isRunning;
        public bool isVisible;
        public bool isEnabled;
        private readonly Databasecarros _databaseQuery;
        #endregion
        public CarrosViewModel()
        {
            _databaseQuery = new Databasecarros();



        }




        #region Properties
        public string NombreTxt
        {
            get { return this.nombre; }

            set { SetValue(ref this.nombre, value); }
        }

        public string ApellidoTxt
        {
            get { return this.apellido; }

            set { SetValue(ref this.apellido, value); }
        }


        public string EmailTxt
        {
            get { return this.email; }

            set { SetValue(ref this.email, value); }
        }

        public string EdadTxt
        {
            get { return this.edad; }

            set { SetValue(ref this.edad, value); }
        }

        public bool IsEnabledTxt
        {

            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }

        }


        public bool IsVisibleTxt
        {

            get { return this.isVisible; }
            set { SetValue(ref this.isVisible, value); }
        }

        public bool IsRunningTxt
        {

            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }


        #endregion

        #region Command

        public ICommand RegistroCommand
        {


            get
            {
                return new RelayCommand(RegisterMethod);
            }


        }

        #endregion


        #region Methods
        public async void RegisterMethod()
        {

            if (string.IsNullOrEmpty(this.NombreTxt))
            {

                await Application.Current.MainPage.DisplayAlert("Error", "You mus enter Nombre.", "Accept");
                return;


            }

            if (string.IsNullOrEmpty(this.ApellidoTxt))
            {

                await Application.Current.MainPage.DisplayAlert("Error", "You mus enter Apellido.", "Accept");
                return;


            }
            if (string.IsNullOrEmpty(this.EmailTxt))
            {

                await Application.Current.MainPage.DisplayAlert("Error", "You mus enter Email.", "Accept");
                return;


            }

            if (string.IsNullOrEmpty(this.EdadTxt))
            {

                await Application.Current.MainPage.DisplayAlert("Error", "You mus enter Edad.", "Accept");
                return;


            }
            //this.IsVisibleTxt = true;
            //this.isRunning = true;
            //this.isEnabled = true;

            var carros = new Carros
            {
                Nombre = NombreTxt.ToLower(),
                Apellido = ApellidoTxt.ToLower(),
                Email = EmailTxt.ToLower(),
                Edad = EdadTxt.ToLower()


            };

            


            var obtenerId = await _databaseQuery.SaveCarrosAsync(carros);

            var obtengoRegistro = await _databaseQuery.GetCarros();


            await Application.Current.MainPage.DisplayAlert("Datos guardados", "Perfectamente", "Acectar");


           


            //this.IsRunningTxt = false;
            //this.IsVisibleTxt = false;
            //this.IsEnabledTxt = true;

            
         


           // await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());


        }
        #endregion


    }

}








