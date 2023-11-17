using Microsoft.AspNetCore.Mvc;

namespace Restaurant.WebApi.Controllers.v1
{
    public class TableController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
