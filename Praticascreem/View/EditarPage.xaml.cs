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
    public partial class EditarPage : ContentPage
    {
        public EditarPage()
        {

            InitializeComponent();
            BindingContext = new ActualizarUsuario();
        }
    }
}