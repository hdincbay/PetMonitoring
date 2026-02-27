namespace PetMonitoring.Web.Application.DTOs
{
    public record LoginDTO
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
