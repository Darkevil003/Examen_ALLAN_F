using Examen_ALLAN_F.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examen_ALLAN_F.Controller
{
    public static class DB
    {
        public static SQLiteAsyncConnection dbconexion;

        public static void conexion(string dbpath)
        {
            dbconexion = new SQLiteAsyncConnection(dbpath);

            dbconexion.CreateTableAsync<Contacto>();
         
        }
    }
}
