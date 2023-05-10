using Microsoft.AspNetCore.Mvc;

namespace fontend.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult bantin()
        {
            return View();
        }
    }
}
