using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelascoCrhystelProgreso3.Models
{
    public class CVAeropuerto
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string name { get; set; }
        public string country { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string email { get; set; }
        public string userName { get; set; }
    }
}
