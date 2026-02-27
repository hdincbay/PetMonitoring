namespace PetMonitoring.Web.Application.DTOs
{
    public record RegisterDTO
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
