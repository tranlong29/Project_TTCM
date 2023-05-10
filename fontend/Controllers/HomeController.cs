using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using fontend.Models;
using System.Text;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using static System.Net.WebRequestMethods;

namespace fontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _Configure;
        private readonly string apiBaseUrl;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _Configure = configuration;
            apiBaseUrl = _Configure.GetValue<string>("WebApiBaseUrl");
        }

        public async Task<IActionResult> Index()
        {
            var products = await GetProducts();
            return View(products);
        }
        [HttpGet]
        public async Task<List<Product>> GetProducts()
        {
            var accessToken = HttpContext.Session.GetString("JWToken");
            
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(apiBaseUrl);
            ViewBag.Domain = apiBaseUrl;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            string jsonStr = await client.GetStringAsync("api/Product");
            List<Product> res = JsonConvert.DeserializeObject<List<Product>>(jsonStr);

            return res;
        }
    }
}
