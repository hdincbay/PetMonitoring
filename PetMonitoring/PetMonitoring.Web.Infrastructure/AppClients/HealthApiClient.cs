using PetMonitoring.Web.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;

namespace PetMonitoring.Web.Infrastructure.AppClients
{
    public class HealthApiClient
    {
        private readonly HttpClient _httpClient;
        public HealthApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<HealthResponseDTO> GetAllAsync(string deviceSerialNumber)
        {
            var result = await _httpClient.GetFromJsonAsync<HealthResponseDTO>($"Health/GetByDevice?DeviceSerialNumber={deviceSerialNumber}");
            return result!;
        }
    }
}
