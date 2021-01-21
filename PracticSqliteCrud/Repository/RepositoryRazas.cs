using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PracticSqliteCrud.Dependencia;
using PracticSqliteCrud.Models;
using SQLite;
using Xamarin.Forms;

namespace PracticSqliteCrud.Repository
{
    public class RepositoryRazas
    {
     
            private SQLiteConnection cn;

            public RepositoryRazas()
            {
                this.cn = DependencyService.Get<IDataBase>().GetConnection();

            }

            //------------------MÉTODOS:
            public void CrearBBDD()
            {
                
                this.cn.CreateTable<Raza>();

            }

            public List<Raza> GetRazas()
            {
                var consulta = from datos in cn.Table<Raza>()
                               select datos;
                return consulta.ToList();
            }
            public Raza BuscarRaza(int num)
            {
                var consulta = from datos in cn.Table<Raza>()
                               where datos.Codigo == num
                               select datos;
                return consulta.FirstOrDefault();
            }
            public void InsertarRaza(int num, string nom, string car)
            {
                Raza raz = new Raza();
                raz.Caracteristicas = car;
                raz.Codigo = num;
                raz.Nombre = nom;
                this.cn.Insert(raz);
            }

            public void ModificarRaza(int num, string nom, string car)
            {
                Raza raz = this.BuscarRaza(num);
                raz.Nombre = nom;
                raz.Caracteristicas = car;
                this.cn.Update(raz);
            }
            public void EliminarRaza(int num)
            {
                Raza raz = this.BuscarRaza(num);
                this.cn.Delete<Raza>(num);
            }
        }
    }
