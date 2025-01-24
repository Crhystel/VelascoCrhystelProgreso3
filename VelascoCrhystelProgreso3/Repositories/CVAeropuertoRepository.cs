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
        public CVAeropuertoRepository(HttpClient httpClient)
        {
            _httpClient = new HttpClient();
        }
        public async Task<List<CVAeropuerto>> GetAeropuerto(string name)
        {
            try
            {
                var url = $"https://freetestapi.com/api/v1/airports?search={name}";
                var response = await _httpClient.GetStringAsync(url);
                return JsonSerializer.Deserialize<List<CVAeropuerto>>(response, new JsonSerializerOptions
                {
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
