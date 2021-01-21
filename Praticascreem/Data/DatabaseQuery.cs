using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Praticascreem.Models;
using SQLite;
using Xamarin.Forms;
using System.Windows.Input;
using Praticascreem.ViewModel;
using Praticascreem.View;

namespace Praticascreem.Data
{
    public class DatabaseQuery
    {
        // propiedad 
        readonly SQLiteAsyncConnection _database;
       

        public DatabaseQuery(string dbPath)
        {
          
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<User>().Wait();
             


        }


        #region CRUD 

        // Selec o busqueda de informacion 
        public async Task<List<User>> GetUsers() {

            return await _database.QueryAsync<User>("Select * From User");

        }
        #endregion



        #region Insertar y actualizar

        #endregion

        // Insertar y actualizar

        public async Task<int> SaveUserAsync(User user)
        {
           
            


            if (user.Id != 0)
            {

             

                return await _database.UpdateAsync(user);

            }
            else {

                return await _database.InsertAsync(user);



            }

         

        }

        //public async Task<User> GetAllUserAsync(User user)
        //{
        //    return await _database.GetAsync<User>(user.Id);
        //}


        public Task<List<User>> GetAllUserAsync()
        {
            return _database.Table<User>().ToListAsync();


        }

      




        #region Eliminar 


        public Task<int> DeleteUserAsync(User user) {

            return _database.DeleteAsync(user);
        }

        #endregion


        public  Task<List<User>> GetUsersValidate(string email, string password) {

            return  _database.QueryAsync<User>("SELECT * FROM User WHERE Email = '" + email + "' AND Password ='" + password + "'");
        }


       

    }
}
