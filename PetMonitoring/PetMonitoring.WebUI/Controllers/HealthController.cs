using Microsoft.AspNetCore.Mvc;
using PetMonitoring.Web.Infrastructure.AppClients;

namespace PetMonitoring.WebUI.Controllers
{
    public class HealthController : Controller
    {
        private readonly HealthApiClient _client;

        public HealthController(HealthApiClient client)
        {
            _client = client;
        }
        public async Task<IActionResult> Index([FromQuery] string deviceSerialNumber)
        {
            var result = await _client.GetAllAsync(deviceSerialNumber);
            if (result?.Status != 0)
            {
                ViewBag.ErrorMessage = result?.Message;
                return View();
            }
            return View(result?.HealthList);
        }
    }
}
