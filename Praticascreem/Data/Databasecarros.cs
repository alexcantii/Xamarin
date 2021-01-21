using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Praticascreem.Models;
using SQLite;

namespace Praticascreem.Data
{
    public class Databasecarros
    {

        // propiedad 
        readonly SQLiteAsyncConnection _database;
        private readonly DataBase _dataBase;


        public Databasecarros()
        {
            _dataBase = new DataBase();
            _database = new SQLiteAsyncConnection(_dataBase.path());
            _database.CreateTableAsync<Carros>().Wait();



        }


        #region CRUD 

        // Selec o busqueda de informacion 
        public async Task<List<Carros>> GetCarros()
        {

            return await _database.QueryAsync<Carros>("Select * From Carros");

        }
        #endregion



        #region Insertar y actualizar

        #endregion

        // Insertar y actualizar

        public async Task<int> SaveCarrosAsync(Carros carros)
        {

            if (carros.Id != 0)
            {

                return await _database.UpdateAsync(carros);

            }
            else {

                return await _database.InsertAsync(carros);


            }

        }

        public async Task<Carros> GetAllCarrosAsync(Carros carros)
        {
            return await _database.GetAsync<Carros>(carros.Id);
        }





        #region Eliminar 


        public Task<int> DeleteCarrosrAsync(Carros carros)
        {

            return _database.DeleteAsync(carros);
        }

        #endregion



    }
}
