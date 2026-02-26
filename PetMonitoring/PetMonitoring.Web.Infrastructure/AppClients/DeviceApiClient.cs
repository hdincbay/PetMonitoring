using PetMonitoring.Web.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;

namespace PetMonitoring.Web.Infrastructure.AppClients
{
    public class DeviceApiClient
    {
        private readonly HttpClient _httpClient;

        public DeviceApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<DeviceDTO>> GetAllAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<List<DeviceDTO>>("Devicemanagement/GetAllDevices");
            return result!;
        }
    }
}
