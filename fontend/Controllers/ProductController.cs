using fontend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System;

namespace fontend.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _Configure;
        private readonly string apiBaseUrl;

        public ProductController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _Configure = configuration;

            apiBaseUrl = _Configure.GetValue<string>("WebApiBaseUrl");
        }
        HttpClient client = new HttpClient();
        public async Task<IActionResult> product()
        {
            client.BaseAddress = new Uri(apiBaseUrl);
            string datajson = await client.GetStringAsync("Product");

            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(datajson);
            return View();
        }
    }
}
