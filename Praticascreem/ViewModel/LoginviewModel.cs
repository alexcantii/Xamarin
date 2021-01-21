using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Collections.Generic;
using Praticascreem.View;
using Praticascreem.Models;
using Praticascreem.Data;

namespace Praticascreem.ViewModel
{
    public class Loginviewmodel : BaseViewModel
    {

        #region Atributes

       
        private string email;
        private string password;
        public bool isRunning;
        public bool isVisible;
        public bool isEnabled;
        #endregion

        #region Constructor
        public Loginviewmodel()
        {
        
            this.IsEnabledTxt = true;
        }
        #endregion

        #region Properties
        public string EmailTxt
        {
            get { return this.email; }

            set { SetValue(ref this.email, value); }
        }


        public string PasswordTxt
        {
            get { return this.password; }

            set { SetValue(ref this.password, value); }
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



        #region Commands

        public ICommand LoginCommand
        {

            get { return new RelayCommand(LoginMethod);

            }

            set { }
        }



        #endregion


        #region Methods
        public async void LoginMethod()
        {
          
            if (string.IsNullOrEmpty(this.email))
            {
            
                await Application.Current.MainPage.DisplayAlert("Error", "Your must enter an email", " Accept");
                return;
            }


            if (string.IsNullOrEmpty(this.password))
            {
               
                await Application.Current.MainPage.DisplayAlert("Error", "Your must enter an Pasword", " Accept");
                return;
            }
            #endregion


            this.IsRunningTxt = true;
            this.IsVisibleTxt = true;
            this.IsEnabledTxt = false;

            await Task.Delay(20);

            List<User> e = App.Database.GetUsersValidate(email, password).Result;

            
            
            
            
            
            if (e.Count == 0)
            {
               
                await Application.Current.MainPage.DisplayAlert("Error", "Email o password incorrecta", "Accept");



            }
            else if (e.Count > 0) { 
                await Application.Current.MainPage.Navigation.PushAsync(new CarrosPage());
             
                
                this.IsRunningTxt = false;
                this.IsVisibleTxt = false;
                this.IsEnabledTxt = true;
            
            }
           

        }

        
        
        

    }

}
