using Microsoft.Extensions.Configuration;
using PetMonitoring.Web.Application.DTOs.Temperature;
using System.Net.Http.Json;
using System.Text;

namespace PetMonitoring.Web.Infrastructure.AppClients
{
    public class TemperatureApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public TemperatureApiClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        public async Task<TemperatureResponseDTO> GetAllAsync(string deviceSerialNumber)
        {
            var chartDataCount = _configuration.GetValue<int>("ChartDataCount");
            var result = await _httpClient.GetFromJsonAsync<TemperatureResponseDTO>($"Temperature/GetByDevice?DeviceSerialNumber={deviceSerialNumber}&Take={chartDataCount}");
            return result!;
        }
    }
}
