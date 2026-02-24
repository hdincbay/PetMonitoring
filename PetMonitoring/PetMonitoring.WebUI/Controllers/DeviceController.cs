using Microsoft.AspNetCore.Mvc;

namespace PetMonitoring.WebUI.Controllers
{
    [Route("[controller]")]
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
