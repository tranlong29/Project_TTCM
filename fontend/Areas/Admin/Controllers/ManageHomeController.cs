using fontend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using fontend.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Linq;
using fontend.Areas.Admin.Models;
using Product = fontend.Areas.Admin.Models.Product;

namespace fontend.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ManageHomeController : Controller
    {
        private readonly ILogger<ManageHomeController> _logger;
        private readonly IConfiguration _Configure;
        private readonly string apiBaseUrl;

        public ManageHomeController(ILogger<ManageHomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _Configure = configuration;
            apiBaseUrl = _Configure.GetValue<string>("WebApiBaseUrl");
        }
        [Route("/Admin/ManageHome/Index")]
        public async Task<IActionResult> Index()
        {
            var products = await GetProducts();
            var customer = await GetCustomers();
            return View();
        }
        [HttpGet]
        public async Task<List<Product>> GetProducts()
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(apiBaseUrl);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            string jsonStr = await client.GetStringAsync("api/Product");
            List<Product> res = JsonConvert.DeserializeObject<List<Product>>(jsonStr);
            ViewBag.SlProduct = res.Count();
            return res;
        }
        [HttpGet]
        public async Task<List<Customer>> GetCustomers()
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(apiBaseUrl);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            string jsonStr = await client.GetStringAsync("api/Customer");
            List<Customer> res = JsonConvert.DeserializeObject<List<Customer>>(jsonStr);
            ViewBag.SlCustomer = res.Count()-1;
            List<Customer> customers = new List<Customer>();
            foreach (var customer in res)
            {
                if (customer.Admin == 0)
                {
                    customers.Add(customer);
                }
            }

            ViewBag.customers = customers;
            return res;
        }
    }
}
