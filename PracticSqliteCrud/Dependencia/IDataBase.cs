using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PracticSqliteCrud.Dependencia
{
  public  interface IDataBase
    {

        SQLite.SQLiteConnection GetConnection();
    }
}
