using PetMonitoring.Web.Application.DTOs;
using System.Net.Http.Json;

namespace PetMonitoring.Web.Infrastructure.AppClients
{
    public class DeviceApiClient
    {
        private readonly HttpClient _httpClient;

        public DeviceApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<DeviceResponseDTO> GetAllAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<DeviceResponseDTO>("Devicemanagement/GetAllDevices");
            return result!;
        }
        public async Task<DeviceResponseDTO> CreateAsync(DeviceDTO model)
        {
            var result = await _httpClient.PostAsJsonAsync("Devicemanagement/Create", model);
            var responseDto = Newtonsoft.Json.JsonConvert.DeserializeObject<DeviceResponseDTO>(await result.Content.ReadAsStringAsync());
            return responseDto!;
        }
    }
}
