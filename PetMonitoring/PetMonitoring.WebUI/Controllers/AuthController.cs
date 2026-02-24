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
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromForm] LoginDTO model)
        {
            var modelSrl = Newtonsoft.Json.JsonConvert.SerializeObject(model);

            return RedirectToAction("Index", "Home");
        }
        [HttpGet("Register")]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromForm] RegisterDTO model)
        {
            var modelSrl = Newtonsoft.Json.JsonConvert.SerializeObject(model);

            return RedirectToAction("Index", "Home");
        }
    }
}