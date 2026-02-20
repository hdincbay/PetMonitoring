namespace PetMonitoring.Auth.API.Dtos
{
    public class LoginResponse
    {
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
    }
}
