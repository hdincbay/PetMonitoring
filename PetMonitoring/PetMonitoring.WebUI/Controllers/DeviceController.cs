using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetMonitoring.Web.Application.DTOs.Device;
using PetMonitoring.Web.Infrastructure.AppClients;
using System.Reflection;

namespace PetMonitoring.WebUI.Controllers
{
    [Route("[controller]")]
    public class DeviceController : Controller
    {
        private readonly DeviceApiClient _client;

        public DeviceController(DeviceApiClient client)
        {
            _client = client;
        }
        [Authorize]
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var result = await _client.GetAllAsync();
            if (result?.Status != 0)
            {
                ViewBag.ErrorMessage = result?.Message;
                return View();
            }
            return View(result?.DeviceList);
        }
        [Authorize]
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var result = await _client.GetByDeviceIdAsync(id);
            if (result?.Status != 0)
            {
                ViewBag.ErrorMessage = result?.Message;
                return RedirectToAction("Index");
            }
            return View(result?.Device);
        }
        [Authorize]
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
            if (result?.Status != 0)
            {
                ViewBag.ErrorMessage = responseContent;
                return View(model);    
            }
            ViewBag.SuccessMessage = responseContent;
            return View();
        }
        [Authorize]
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromForm] DeviceDTO model)
        {
            var result = await _client.UpdateAsync(model);
            var responseContent = result?.Message;
            if (result?.Status != 0)
            {
                TempData["ErrorMessage"] = responseContent;   
            }
            TempData["SuccessMessage"] = responseContent;
            return RedirectToAction("Get", new { id = model.ID });
        }
        [Authorize]
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromForm] DeviceDTO model)
        {
            var result = await _client.DeleteAsync(model);
            return RedirectToAction("Index");
        }
    }
}
