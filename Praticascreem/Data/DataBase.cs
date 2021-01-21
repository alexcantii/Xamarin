using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Praticascreem.Data
{
    public class DataBase
    {
        public static string database;
        public string path()
        {
            if (database == null)
            {

     database = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TesName.db3");
            }
            return database;
        }
    }
}
