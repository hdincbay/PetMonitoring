using PetMonitoring.Web.Application.DTOs.Health;
using PetMonitoring.Web.Application.DTOs.Movement;
using PetMonitoring.Web.Application.DTOs.Temperature;

namespace PetMonitoring.WebUI.Models.ViewModels
{
    public class DashboardVM
    {
        public List<MovementDTO> Movements { get; set; } = new List<MovementDTO>();
        public List<TemperatureDTO> Temperatures { get; set; } = new List<TemperatureDTO>();
        public List<HealthDTO> Healths { get; set; } = new List<HealthDTO>();
    }
}
