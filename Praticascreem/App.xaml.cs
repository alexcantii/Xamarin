using System;
using System.IO;
using Praticascreem.Data;
using Praticascreem.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Praticascreem
{
    public partial class App : Application
    {

        static DatabaseQuery database;

       

        public static DatabaseQuery Database
        {
            get
            {
                if (database == null)
                {
                    database = new DatabaseQuery(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DBname.db"));
                }
                return database;
            }
        }

        




        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new  View.Starpage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
