using Microsoft.AspNetCore.Mvc;
using PetMonitoring.Web.Domain.DTOs;

namespace PetMonitoring.WebUI.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ProcessLogin([FromForm] LoginDTO model)
        {
            var modelSrl = Newtonsoft.Json.JsonConvert.SerializeObject(model);

            return RedirectToAction("Index", "Home");
        }
    }
}