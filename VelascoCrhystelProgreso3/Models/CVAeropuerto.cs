using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelascoCrhystelProgreso3.Models
{
    public class Location
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
    public class Gate
    {
        public string Gate_Number { get; set; }
        public string Airlines { get; set; }
    }
    public class Terminal
    {
        public string Name { get; set; }
        public string Gates { get; set; }
    }
    public class ContactInfo
    {
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
    }
    public class CVAeropuerto
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Location { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Timezone { get; set; }
        public string Terminals { get; set; }
        public string Airlines { get; set; }
        public string Services { get; set; }
        public string Contact_Info { get; set; }
    }
}
