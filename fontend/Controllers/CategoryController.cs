using fontend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System;

namespace fontend.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly IConfiguration _Configure;
        private readonly string apiBaseUrl;

        public CategoryController(ILogger<CategoryController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _Configure = configuration;
            apiBaseUrl = _Configure.GetValue<string>("WebApiBaseUrl");
        }


        [HttpGet]
        public async Task<IActionResult> productsByIdCatgr(int id)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(apiBaseUrl);
            ViewBag.Domain = apiBaseUrl;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            string jsonStr = await client.GetStringAsync("api/Product");
            string json = await client.GetStringAsync("api/Category");
            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(jsonStr);
            List<Category> categories = JsonConvert.DeserializeObject<List<Category>>(json);
            ViewBag.CategoryName = categories;
            List<Product> prods = new List<Product>();
            foreach (var item in products)
            {
                if (item.IdCategory == id)
                {
                    prods.Add(item);
                }
            }
            return View(prods);
        }

    }
}
