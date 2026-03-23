using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetMonitoring.Web.Infrastructure.AppClients;

namespace PetMonitoring.WebUI.Controllers
{
    [Route("[controller]")]
    public class TemperatureController : Controller
    {
        private readonly TemperatureApiClient _client;

        public TemperatureController(TemperatureApiClient client)
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

            var chartData = result.TemperatureList.Select(x => new
            {
                time = x.CreatedDate,
                value = x.CelsiusValue
            });

            return Json(chartData);
        }
    }
}