using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelascoCrhystelProgreso3.Models
{
    public class CVAeropuertoBD
    {

        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string NombreAeropuerto { get; set; }
        public string Pais { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string Email { get; set; }
        public string MiNombre { get; set; }
        public CVAeropuertoBD()
        {
            MiNombre = "CrhystelVelasco";
        }
    }

}
