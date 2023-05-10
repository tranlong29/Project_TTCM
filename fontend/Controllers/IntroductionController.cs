using Microsoft.AspNetCore.Mvc;

namespace fontend.Controllers
{
    public class IntroductionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
