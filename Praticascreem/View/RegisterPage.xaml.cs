using Praticascreem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Praticascreem.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
         

            InitializeComponent();
            BindingContext = new RegisterViewModel();
            
             
        }

        private void Volver_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
           
           

        }

       
        private void MostrarDatos_Cliked (object sender, EventArgs e)
        {
            Navigation.PushAsync(new MostrarUsuarios());


        }

        private void Mostrarcontraseña_Clicked(object sender, EventArgs e)
        {
            ContraseñaEntry.IsPassword = true;
            

        }

       
        private void LimpiarDatos_Cliked(object sender, EventArgs e)
        {

            //EmailEntry.Text = string.Empty;
            //ContraseñaEntry.Text = string.Empty;
            //NombreEntry.Text = string.Empty;
            //EdadEntry.Text = string.Empty;
            Navigation.PushAsync(new EditarPage());

        }

     


    }
}