using Microsoft.Extensions.Configuration;
using PetMonitoring.Web.Application.DTOs.Health;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;

namespace PetMonitoring.Web.Infrastructure.AppClients
{
    public class HealthApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public HealthApiClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        public async Task<HealthResponseDTO> GetAllAsync(string deviceSerialNumber)
        {
            var chartDataCount = _configuration.GetValue<int>("ChartDataCount");
            var result = await _httpClient.GetFromJsonAsync<HealthResponseDTO>($"Health/GetByDevice?DeviceSerialNumber={deviceSerialNumber}&Take={chartDataCount}");
            return result!;
        }
    }
}
