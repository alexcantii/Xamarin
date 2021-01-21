using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.IO;
using SQLite;


namespace Praticascreem.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        
        [MaxLength(38)]
        public string Email { get; set; }

        [MaxLength(16)]
        public string Password { get; set; }

        [MaxLength(11)]
        public string Nombre { get; set; }

        [MaxLength(2)]
        public string Edad { get; set; }

        public DateTime Creation_Date { get; set; }
    }
}
