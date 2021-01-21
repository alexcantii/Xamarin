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
    public class RegisterViewModel : BaseViewModel
    {

        #region Attributes
        public string email;
        public string password;
        public string nombre;
        public string edad;
        public bool isRunning;
        public bool isVisible;
        public bool isEnabled;
        public bool isPassword;
       
        #endregion
        public RegisterViewModel()
        {

            IsEnabledTxt = true;
        }

        #region Properties
        public string Emailtxt
        {
            get { return this.email; }

            set { SetValue(ref this.email, value); } }



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



        public bool IsEnabledTxt {

            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }

        }


        public bool IsVisibleTxt {

            get { return this.isVisible; }
            set { SetValue(ref this.isVisible, value); }
        }

        public bool IsRunningTxt
        {

            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }

        public bool IsPassword {
            get { return this.isPassword; }
            set { SetValue(ref this.isPassword, value); }

            } 
        #endregion



        #region Command

        public ICommand RegisterCommand {


            get {
                return new RelayCommand(RegisterMethod);
            }

        
        }

        #endregion


        #region Methods
        public async void RegisterMethod() {

            if (string.IsNullOrWhiteSpace(this.Emailtxt))
            {

                await Application.Current.MainPage.DisplayAlert("Error", "You mus enter Email.", "Accept");
                return;


            }


            //Valida que el formato del correo sea valido
            bool isEmail = Regex.IsMatch(Emailtxt, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            if (!isEmail)
            {


                await Application.Current.MainPage.DisplayAlert("Advertencia", "El formato del correo electrónico es incorrecto, revíselo e intente de nuevo.", "OK");
                return;
            }


            if (string.IsNullOrEmpty(this.Passwordtxt))
            {

                await Application.Current.MainPage.DisplayAlert("Error", "You mus enter Password.", "Accept");
                return;


            }

            if (string.IsNullOrEmpty(this.Nombretxt))
            {

                await Application.Current.MainPage.DisplayAlert("Error", "You mus enter nombre.", "Accept");
                return;


            }





            if (string.IsNullOrEmpty(this.Edadtxt))
            {

                await Application.Current.MainPage.DisplayAlert("Error", "You mus enter edad.", "Accept");
                return;


            }

            else {

                if (Edadtxt.Length != 2) {

                    await Application.Current.MainPage.DisplayAlert("Advertencia", "Solo permite 2 digitos .", "OK");
                    return;
                }

            }









            this.isVisible = true;
            this.isRunning = true;
            this.isEnabled = true;
            this.isPassword = true;


            await Task.Delay(1000);
            // User Modelo

            var user = new User
            {
                Email = Emailtxt.ToLower(),
                Password = Passwordtxt.ToLower(),
                Nombre = Nombretxt.ToLower(),
                Edad = Edadtxt.ToLower(),
                Creation_Date = DateTime.UtcNow.Date

            };

            await App.Database.SaveUserAsync(user);

           

            await Application.Current.MainPage.DisplayAlert("Datos guardados", "Bienvenido" + nombre.ToString(), "Acectar");
          
            this.IsRunningTxt = false;
            this.IsVisibleTxt = false;
            this.IsEnabledTxt = true;


            await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());

            
         
           

        } 


        #endregion


      

    }

}
