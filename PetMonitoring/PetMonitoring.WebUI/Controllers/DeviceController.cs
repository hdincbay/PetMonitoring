using Microsoft.AspNetCore.Mvc;
using PetMonitoring.Web.Infrastructure.AppClients;
using PetMonitoring.Web.Application.DTOs;

namespace PetMonitoring.WebUI.Controllers
{
    public class DeviceController : Controller
    {
        private readonly DeviceApiClient _deviceApiClient;

        public DeviceController(DeviceApiClient deviceApiClient)
        {
            _deviceApiClient = deviceApiClient;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var devices = await _deviceApiClient.GetAllAsync();
            return View(devices);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([FromForm] DeviceDTO model)
        {
            return View();
        }
    }
}
