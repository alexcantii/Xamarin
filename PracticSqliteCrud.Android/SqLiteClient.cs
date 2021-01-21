using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using PracticSqliteCrud.Dependencia;
using PracticSqliteCrud.Droid;
using SQLite;
using Xamarin.Forms;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;



[assembly: Dependency(typeof(SqLiteClient))]

namespace PracticSqliteCrud.Droid
{
  public  class SqLiteClient: IDataBase
    {
     
            public SQLiteConnection GetConnection()
            {
            String bbddfile = "HOSPITAL.db3";
            String rutadocumentos = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            String path = Path.Combine(rutadocumentos, bbddfile);
            SQLite.SQLiteConnection cn = new SQLite.SQLiteConnection(path);
            return cn;

        }

       
    }
}