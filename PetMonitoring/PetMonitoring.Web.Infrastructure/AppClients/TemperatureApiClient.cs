using PetMonitoring.Web.Application.DTOs.Temperature;
using System.Net.Http.Json;
using System.Text;

namespace PetMonitoring.Web.Infrastructure.AppClients
{
    public class TemperatureApiClient
    {
        private readonly HttpClient _httpClient;
        public TemperatureApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<TemperatureResponseDTO> GetAllAsync(string deviceSerialNumber)
        {
            var result = await _httpClient.GetFromJsonAsync<TemperatureResponseDTO>($"Temperature/GetByDevice?DeviceSerialNumber={deviceSerialNumber}");
            return result!;
        }
    }
}
