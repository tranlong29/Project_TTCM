using Microsoft.AspNetCore.Mvc;

namespace fontend.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
