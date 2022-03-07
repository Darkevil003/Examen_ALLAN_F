using Examen_ALLAN_F.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examen_ALLAN_F.Controller
{
    public static class DataBase
    {
        public static Task<List<Contacto>> listregistrer()
        {
            return DB.dbconexion.Table<Contacto>().ToListAsync();

        }

        public static Task<int> addregistrer(Contacto contacto)
        {
            if (contacto.Id != 0)
            {
                return DB.dbconexion.UpdateAsync(contacto);
            }
            else
            {
                return DB.dbconexion.InsertAsync(contacto);
            }
        }
        public static Task<Contacto> Obteneregistrer(int cid)
        {
            return DB.dbconexion.Table<Contacto>()
                .Where(i => i.Id == cid)
                .FirstOrDefaultAsync();

        }

        public static Task<int> Delregister(Contacto contacto)
        {

            return DB.dbconexion.DeleteAsync(contacto);
        }
    }
}
