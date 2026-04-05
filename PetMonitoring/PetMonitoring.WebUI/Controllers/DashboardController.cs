using Microsoft.AspNetCore.Mvc;
using PetMonitoring.Web.Infrastructure.AppClients;
using PetMonitoring.WebUI.Models.ViewModels;

namespace PetMonitoring.WebUI.Controllers
{
    [Route("[controller]")]
    public class DashboardController : Controller
    {
        private readonly MovementApiClient _movementApiClient;
        private readonly TemperatureApiClient _temperatureApiClient;
        private readonly HealthApiClient _healthApiClient;

        public DashboardController(MovementApiClient movementApiClient, TemperatureApiClient temperatureApiClient, HealthApiClient healthApiClient)
        {
            _movementApiClient = movementApiClient;
            _temperatureApiClient = temperatureApiClient;
            _healthApiClient = healthApiClient;
        }
        [HttpGet("{deviceSerialNumber}")]
        public async Task<IActionResult> Index(string deviceSerialNumber)
        {
            var movementResponseList = await _movementApiClient.GetAllAsync(deviceSerialNumber);
            var temperatureResponseList = await _temperatureApiClient.GetAllAsync(deviceSerialNumber);
            var healthResponseList = await _healthApiClient.GetAllAsync(deviceSerialNumber);
            var vm = new DashboardVM
            {
                Movements = movementResponseList.MovementList!,
                Temperatures = temperatureResponseList.TemperatureList!,
                Healths = healthResponseList.HealthList!
            };

            return View(vm);
        }
    }
}
