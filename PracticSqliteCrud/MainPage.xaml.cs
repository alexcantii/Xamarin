
  
using PracticSqliteCrud.Models;
using PracticSqliteCrud.Repository;
using PracticSqliteCrud.ViewModels;
using PracticSqliteCrud.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PracticSqliteCrud
{
    public partial class MainPage : ContentPage
    {
        RepositoryRazas repo;
        public MainPage()
        {
            InitializeComponent();
            this.repo = new RepositoryRazas();
            this.repo.CrearBBDD();
            this.btneliminar.Clicked += Btneliminar_Clicked;
            this.btnmodificar.Clicked += Btnmodificar_Clicked;
            this.btnmostrar.Clicked += Btnmostrar_Clicked;
            this.btnnuevo.Clicked += Btnnuevo_Clicked;
        }

        private async void Btnnuevo_Clicked(object sender, EventArgs e)
        {
            InsertarRaza view = new InsertarRaza();
            await Navigation.PushModalAsync(view);

        }

        private async void Btnmostrar_Clicked(object sender, EventArgs e)
        {
            RazasView view = new RazasView();
            await Navigation.PushModalAsync(view);

        }

        private async void Btnmodificar_Clicked(object sender, EventArgs e)
        {
            ModificarRaza view = new ModificarRaza();
            RazaModel viewmodel = new RazaModel();

            //buscar el número de departamento que hay en la caja
            int num = int.Parse(this.cajacodigo.Text);
            //asociarlo con viewmodel
            Raza raz = this.repo.BuscarRaza(num);
            viewmodel.Raza = raz;
            view.BindingContext = viewmodel;
            await Navigation.PushModalAsync(view);
        }

        private async void Btneliminar_Clicked(object sender, EventArgs e)
        {
            EliminarRaza view = new EliminarRaza();
            RazaModel viewmodel = new RazaModel();
            int num = int.Parse(this.cajacodigo.Text);
            Raza raz = this.repo.BuscarRaza(num);
            viewmodel.Raza = raz;
            view.BindingContext = viewmodel;
            await Navigation.PushModalAsync(view);
        }
    }
}