using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetMonitoring.Web.Infrastructure.AppClients;

namespace PetMonitoring.WebUI.Controllers
{
    [Route("[controller]")]
    public class HealthController : Controller
    {
        private readonly HealthApiClient _client;

        public HealthController(HealthApiClient client)
        {
            _client = client;
        }
        [Authorize]
        [HttpGet("GetChartData")]
        public async Task<IActionResult> GetChartData([FromQuery] string deviceSerialNumber)
        {
            var result = await _client.GetAllAsync(deviceSerialNumber);

            if (result?.Status != 0)
                return Json(new List<object>());

            var chartData = result.HealthList.Select(x => new
            {
                time = x.CreatedDate,
                value = x.Bpm
            });

            return Json(chartData);
        }
    }
}