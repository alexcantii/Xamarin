using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Praticascreem.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Praticascreem.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarrosPage : ContentPage
    {
        public CarrosPage()
        {
            InitializeComponent();
            BindingContext = new CarrosViewModel();
        }

        private async void btnTomarFoto_Clicked(object sender, EventArgs e)
        {
            var camaraOptions =
                new StoreCameraMediaOptions();
            camaraOptions.PhotoSize = PhotoSize.Small;

            var photo =
                await Plugin.Media.CrossMedia.Current
                .TakePhotoAsync(new StoreCameraMediaOptions());
            if (photo != null) {
                Photo.Source = ImageSource.FromStream(() =>
                {
                    return photo.GetStream();
                });
            }


        }



        private async void btnSeleccionarFoto_Clicked(object sender, EventArgs e)
        {

            if (!CrossMedia.Current.IsPickPhotoSupported) {

                await DisplayAlert("Photo not Supported", ":Permission not granted to phoro.", "ok");
                return;
            }

            var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions {

                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,

            });

            if (file == null)
                return;
            photoseleccionar.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });
        }

        private void limpiarEntry_Clicked(object sender, EventArgs e)
        {
            NombreTxt.Text = string.Empty;
            ApellidoTxt.Text = string.Empty;
            EdadTxt.Text = string.Empty;
            EmailTxt.Text = string.Empty;
            
        }

    }
}