using Microsoft.AspNetCore.Mvc;

namespace Restaurant.WebApi.Controllers.v1
{
    public class OderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
