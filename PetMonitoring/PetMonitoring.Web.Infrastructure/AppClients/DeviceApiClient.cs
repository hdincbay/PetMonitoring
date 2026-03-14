using PetMonitoring.Web.Application.DTOs.Device;
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
        public async Task<DeviceResponseDTO> GetByDeviceIdAsync(Guid deviceId)
        {
            var result = await _httpClient.GetFromJsonAsync<DeviceResponseDTO>("Devicemanagement/GetByDeviceId?deviceId=" + deviceId);
            return result!;
        }
        public async Task<DeviceResponseDTO> CreateAsync(DeviceDTO model)
        {
            var result = await _httpClient.PostAsJsonAsync("Devicemanagement/Create", model);
            var responseDto = Newtonsoft.Json.JsonConvert.DeserializeObject<DeviceResponseDTO>(await result.Content.ReadAsStringAsync());
            return responseDto!;
        }
        public async Task<DeviceResponseDTO> UpdateAsync(DeviceDTO model)
        {
            var result = await _httpClient.PatchAsJsonAsync("Devicemanagement/Update", model);
            var responseDto = Newtonsoft.Json.JsonConvert.DeserializeObject<DeviceResponseDTO>(await result.Content.ReadAsStringAsync());
            return responseDto!;
        }
    }
}
