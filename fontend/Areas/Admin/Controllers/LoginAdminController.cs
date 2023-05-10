using fontend.Areas.Admin.Models;
using fontend.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace fontend.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginAdminController : Controller
    {
        private readonly ILogger<LoginAdminController> _logger;

        public LoginAdminController(ILogger<LoginAdminController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("/Admin/LoginAdmin/Login")]
        public async Task<IActionResult> Login(LoginAdmin loginAdmin)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent stringContent = new StringContent(JsonConvert.SerializeObject(loginAdmin), Encoding.UTF8, "application/json");

                using (var reponse = await httpClient.PostAsync("https://localhost:44384/api/Token/loginAmin", stringContent))
                {
                    string token = await reponse.Content.ReadAsStringAsync();
                    if (token == "Invalid username/password")
                    {

                        TempData["Message"] = "Invalid username/password";
                        return Redirect("~/Admin/LoginAdmin/Index");
                    }
                    else
                    {
                        HttpContext.Session.SetString("JWToken", token);
                    }

                }
                return Redirect("~/Admin/ManageHome/Index");
            }
        }
        
    }
}
