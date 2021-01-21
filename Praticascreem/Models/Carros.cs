using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Praticascreem.Models
{
    public class Carros
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
       
        public string Nombre { get; set; }


        public string Apellido { get; set; }

        public string Email { get; set; }

        public string Edad { get; set; }

        public DateTime Creation_Date { get; set; }



    }
}
