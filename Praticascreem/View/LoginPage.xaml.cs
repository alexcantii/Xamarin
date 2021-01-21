using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Praticascreem.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            BindingContext = new ViewModel.Loginviewmodel();
        }


        private void Registrar_Cliked(object sender, EventArgs e) {

            Navigation.PushAsync(new RegisterPage());
        
        }


      


    }
}