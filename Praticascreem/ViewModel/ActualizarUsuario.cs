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
    public class ActualizarUsuario : BaseViewModel
    {

        #region Attributes
        public string email;
        public string password;
        public string nombre;
        public string edad;
       


        #endregion

        public ActualizarUsuario() {

           
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


        #endregion


        #region Command
        public ICommand ActualizarCommand
        {


            get
            {
                return new RelayCommand(ActualizarMethod);
            }


        }

        #endregion


        #region Methods
        public async void ActualizarMethod()
        {

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

            else
            {

                if (Edadtxt.Length != 2)
                {

                    await Application.Current.MainPage.DisplayAlert("Advertencia", "Solo permite 2 digitos .", "OK");
                    return;
                }

            }



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



            if (user.Id == 0)
            {

                await Application.Current.MainPage.DisplayAlert("Usuario no encontrado", "ok", "Aceptar");

                await Application.Current.MainPage.Navigation.PushAsync(new EditarPage());

                return ;
            }

         

            await Application.Current.MainPage.DisplayAlert("Datos Actualizados", "Bien echo" + nombre.ToString(), "Acectar");

        


            await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());





        }


        #endregion




    }

}

