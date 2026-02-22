using Microsoft.AspNetCore.Mvc;
using PetMonitoring.Web.Domain.DTOs;

namespace PetMonitoring.WebUI.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ProcessLogin([FromForm] LoginDTO model)
        {
            var modelSrl = Newtonsoft.Json.JsonConvert.SerializeObject(model);

            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
    }
}