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
            var result = await _client.GetAllAsync();
            return View(result.DeviceList);
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
            var responseContent = result?.Message;
            if (result?.Status == 0)
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
