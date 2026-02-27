using Microsoft.AspNetCore.Mvc;
using PetMonitoring.Web.Application.DTOs;
using PetMonitoring.Web.Infrastructure.AppClients;

namespace PetMonitoring.WebUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly AuthApiClient _client;
        public AuthController(AuthApiClient client)
        {
            _client = client;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromForm] LoginDTO model)
        {
            var result = await _client.LoginAsync(model);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = await result.Content.ReadAsStringAsync();
                return View(model);
            }
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromForm] RegisterDTO model)
        {
            var result = await _client.RegisterAsync(model);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.ErrorMessage = await result.Content.ReadAsStringAsync();
                return View(model);
            }
        }
    }
}