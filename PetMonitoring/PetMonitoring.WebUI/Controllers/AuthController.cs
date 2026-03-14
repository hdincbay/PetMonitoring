using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using PetMonitoring.Web.Application.DTOs.Auth;
using PetMonitoring.Web.Infrastructure.AppClients;
using System.Security.Claims;

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
            if (!result.IsSuccessStatusCode)
            {
                ViewBag.ErrorMessage = await result.Content.ReadAsStringAsync();
                return View(model);
            }
            var response = await result.Content.ReadFromJsonAsync<LoginResponseDTO>();
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, response!.UserId.ToString()),
                new Claim(ClaimTypes.Name, response.UserName!)
            };

            foreach (var role in response.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role!));
            }

            var identity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme
            );

            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal
            );
            return RedirectToAction("Index", "Home");
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
            if (result.IsSuccessStatusCode!)
            {
                ViewBag.ErrorMessage = await result.Content.ReadAsStringAsync();
                return View(model);
            }
            return RedirectToAction("Login");
        }
    }
}