using PetMonitoring.Web.Application.DTOs.Auth;
using System.Net.Http.Json;

namespace PetMonitoring.Web.Infrastructure.AppClients
{
    public class AuthApiClient
    {
        private readonly HttpClient _httpClient;

        public AuthApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<HttpResponseMessage> LoginAsync(LoginDTO model)
        {
            var response = await _httpClient.PostAsJsonAsync("Auth/Login", model);
            return response!;
        }
        public async Task<HttpResponseMessage> RegisterAsync(RegisterDTO model)
        {
            var response = await _httpClient.PostAsJsonAsync("Auth/Register", model);
            return response!;
        }
    }
}
