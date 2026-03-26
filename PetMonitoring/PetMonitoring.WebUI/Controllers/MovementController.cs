using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetMonitoring.Web.Infrastructure.AppClients;

namespace PetMonitoring.WebUI.Controllers
{
    public class MovementController : Controller
    {
        private readonly MovementApiClient _client;

        public MovementController(MovementApiClient client)
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

            var chartData = result.MovementList.Select(x => new
            {
                time = x.CreatedDate,
                value = x.ActivityLevel.ToString()
            });

            return Json(chartData);
        }
    }
}
