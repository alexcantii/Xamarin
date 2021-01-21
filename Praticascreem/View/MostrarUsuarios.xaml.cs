using Praticascreem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Praticascreem.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MostrarUsuarios : ContentPage
    {
        public MostrarUsuarios()
        {
            InitializeComponent();
            BindingContext = new MostrarUsuariosViewModel();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}