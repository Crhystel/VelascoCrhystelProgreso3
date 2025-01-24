using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelascoCrhystelProgreso3.Models;

namespace VelascoCrhystelProgreso3.Repositories
{
    public class CVConexionDBRepository
    {
        private readonly string _dbPath=Path.Combine(FileSystem.AppDataDirectory, "CVAeropuertosP3.db3");
        private SQLiteConnection _conexion;

        private readonly HttpClient _httpClient;
        private readonly List<CVAeropuerto> _aeropuertos = new();
        public CVConexionDBRepository(HttpClient httpClient)
        {
            Init();
            _httpClient = httpClient;
        }
        public void Init()
        {
            _conexion = new SQLiteConnection(_dbPath);
            _conexion.CreateTable<CVAeropuertoBD>();
        }
        public void Add(CVAeropuerto aeropuerto)
        {
            var aeropuertoBD = new CVAeropuertoBD
            {
                Pais = aeropuerto.country,
                Latitud = aeropuerto.location.latitude.ToString(),
                Longitud = aeropuerto.location.longitude.ToString(),
                Email = aeropuerto.contact_info.email,
                MiNombre = "CrhystelVelasco"
            };
            _conexion.Insert(aeropuertoBD);
        }
        public List<CVAeropuertoBD> GetAeropuertoBD()
        {
            return _conexion.Table<CVAeropuertoBD>().ToList();
        }
        public async Task SaveChangesAsync()
        {
            await Task.CompletedTask;
        }
    }
}
