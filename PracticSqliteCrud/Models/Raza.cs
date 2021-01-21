using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticSqliteCrud.Models
{

    [Table("PERROS")]
    public class Raza
    {
        [PrimaryKey]
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Caracteristicas { get; set; }


    }
}