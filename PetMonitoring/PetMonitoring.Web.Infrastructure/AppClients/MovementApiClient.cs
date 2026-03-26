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
        public MovementApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<MovementResponseDTO> GetAllAsync(string deviceSerialNumber)
        {
            var result = await _httpClient.GetFromJsonAsync<MovementResponseDTO>($"Movement/GetByDevice?DeviceSerialNumber={deviceSerialNumber}");
            return result!;
        }
    }
}
