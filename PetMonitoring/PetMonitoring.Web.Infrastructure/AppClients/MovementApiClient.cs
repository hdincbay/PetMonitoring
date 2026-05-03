using Microsoft.Extensions.Configuration;
using PetMonitoring.Web.Application.DTOs.Movement;
using PetMonitoring.Web.Application.DTOs.Temperature;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;

namespace PetMonitoring.Web.Infrastructure.AppClients
{
    public class MovementApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public MovementApiClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        public async Task<MovementResponseDTO> GetAllAsync(string deviceSerialNumber)
        {
            var chartDataCount = _configuration.GetValue<int>("ChartDataCount");
            var result = await _httpClient.GetFromJsonAsync<MovementResponseDTO>($"Movement/GetByDevice?DeviceSerialNumber={deviceSerialNumber}&Take={chartDataCount}");
            return result!;
        }
    }
}
