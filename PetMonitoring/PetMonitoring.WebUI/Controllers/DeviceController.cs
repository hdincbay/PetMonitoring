using Microsoft.AspNetCore.Mvc;
using PetMonitoring.Web.Infrastructure.AppClients;
using PetMonitoring.Web.Application.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace PetMonitoring.WebUI.Controllers
{
    public class DeviceController : Controller
    {
        private readonly DeviceApiClient _client;

        public DeviceController(DeviceApiClient client)
        {
            _client = client;
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var devices = await _client.GetAllAsync();
            return View(devices);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] DeviceDTO model)
        {
            var result = await _client.CreateAsync(model);
            var responseContent = await result.Content.ReadAsStringAsync();
            if (result.IsSuccessStatusCode)
            {
                ViewBag.SuccessMessage = responseContent;
                return View();
            }
            else
            {
                ViewBag.ErrorMessage = responseContent;
                return View(model);
            }
        }
    }
}
