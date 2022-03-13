using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examen_ALLAN_F.Model
{
    public class Contacto
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(70)]
        public string Nombre { get; set; }
        [MaxLength(70)]
        public string Apellido { get; set; } 
        public int Edad { get; set; }
        public double Telefono { get; set; }
        public string Pais { get; set; }
        public string Nota { get; set; }
        public double Longitud { get; set; }
        public double Latitud { get; set; }

    }
}
