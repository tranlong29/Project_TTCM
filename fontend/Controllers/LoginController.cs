using fontend.Areas.Admin.Models;
using fontend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace fontend.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> LoginUser(Login login)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent stringContent = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");

                using (var reponse = await httpClient.PostAsync("https://localhost:44384/api/Token/login", stringContent))
                {
                    string token = await reponse.Content.ReadAsStringAsync();
                    if (token == "Invalid username/password")
                    {
                        
                        TempData["Message"] = "Invalid username/password";
                        return Redirect("~/Login/Index");
                    }
                    else
                    {
                        HttpContext.Session.SetString("JWToken", token);
                    }

                }
                return Redirect("~/Home/Index");
            }
        }

        public async Task<IActionResult> Register(Login login)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent stringContent = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");

                using (var reponse = await httpClient.PostAsync("https://localhost:44384/api/Token/Register", stringContent))
                {
                    string token = await reponse.Content.ReadAsStringAsync();
                    if (token == "UserName đã tồn tại!!!")
                    {
                        TempData["posted"] = "UserName đã tồn tại!!!";
                    }
                }
                return Redirect("~/Login/Index");
            }
        }
        
        public IActionResult Logoff()
        {
            HttpContext.Session.Clear();
            return Redirect("~/Admin/LoginAdmin/Index");
        }
    }
}

