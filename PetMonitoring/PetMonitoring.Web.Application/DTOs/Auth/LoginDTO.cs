namespace PetMonitoring.Web.Application.DTOs.Auth
{
    public record LoginDTO
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
