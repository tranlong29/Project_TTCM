using fontend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace fontend.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IConfiguration _Configure;
        private readonly string apiBaseUrl;

        public ProductController(ILogger<ProductController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _Configure = configuration;
            apiBaseUrl = _Configure.GetValue<string>("WebApiBaseUrl");
        }

        [HttpGet]      
        public async Task<IActionResult> products()
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
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> product(int id)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(apiBaseUrl);
            ViewBag.Domain = apiBaseUrl;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            string jsonStr = await client.GetStringAsync("api/Product/"+ id);
            string json = await client.GetStringAsync("api/ProductImage");
            List<Product_Images> prdcimg = JsonConvert.DeserializeObject<List<Product_Images>>(json);
            Product product = JsonConvert.DeserializeObject<Product>(jsonStr);
            string[] arrListStr = null;
            foreach (var item in prdcimg)
            {
                if (item.IdProduct == id)
                {
                    arrListStr = item.URLIMG.Split(';', StringSplitOptions.RemoveEmptyEntries);
                    
                }
            }
            ViewBag.ArrListStr = arrListStr;

            string products = await client.GetStringAsync("api/Product");
            List<Product> res = JsonConvert.DeserializeObject<List<Product>>(products);
            ViewBag.prodct = res;

            return View(product);
        }

       


    }
}
