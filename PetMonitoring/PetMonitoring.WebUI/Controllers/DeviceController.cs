using Microsoft.AspNetCore.Mvc;

namespace PetMonitoring.WebUI.Controllers
{
    public class DeviceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
