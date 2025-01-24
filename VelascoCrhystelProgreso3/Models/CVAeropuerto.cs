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
        public double latitude { get; set; }
        public double longitude { get; set; }
    }

    public class ContactInfo
    {
        public string phone { get; set; }
        public string email { get; set; }
        public string website { get; set; }
    }

    public class Terminal
    {
        public string name { get; set; }
        public List<Gate> gates { get; set; }
    }

    public class Gate
    {
        public string gate_number { get; set; }
        public List<string> airlines { get; set; }
    }

    public class CVAeropuerto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public Location location { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string timezone { get; set; }
        public List<Terminal> terminals { get; set; }
        public List<string> airlines { get; set; }
        public List<string> services { get; set; }
        public ContactInfo contact_info { get; set; }
    }


}
