using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using VelascoCrhystelProgreso3.Interfaces;
using VelascoCrhystelProgreso3.Models;

namespace VelascoCrhystelProgreso3.Repositories
{
    public class CVAeropuertoRepository : IAeropuerto
    {
        private readonly HttpClient _httpClient;
        public CVAeropuertoRepository()
        {
            _httpClient = new HttpClient();
        }
        public Task<CVAeropuerto> GetAeropuerto(string name)
        {
            try
            {
                var url = $"https://localhost:44300/api/Aeropuerto/{name}";
                var response = _httpClient.GetAsync(url).Result;
                return JsonSerializer.DeserializeAsync<CVAeropuerto>(response, new JsonSerializerOptions({
                    PropertyNameCaseInsensitive = true
                });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
