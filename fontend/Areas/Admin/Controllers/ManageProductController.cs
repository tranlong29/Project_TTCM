using fontend.Areas.Admin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Xml.Linq;

namespace fontend.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ManageProductController : Controller
    {
        private readonly ILogger<ManageProductController> _logger;
        private readonly IConfiguration _Configure;
        private readonly string apiBaseUrl;

        public ManageProductController(ILogger<ManageProductController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _Configure = configuration;
            apiBaseUrl = _Configure.GetValue<string>("WebApiBaseUrl");
        }


        [Route("Admin/ManageProduct/Index")]
        public async Task<IActionResult> Index()
        {
            var product = await GetProducts();
            return View(product);
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
            string json = await client.GetStringAsync("api/Category");
            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(jsonStr);
            List<Category> categories = JsonConvert.DeserializeObject<List<Category>>(json);
            ViewBag.CategoryName = categories;
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name");
            List<Product> prods = new List<Product>();
            foreach (var item in products)
            {
                var category = categories.FirstOrDefault(c => c.Id == item.IdCategory);
                if (category != null)
                {
                    item.CategoryName = category.Name;
                }
            }
            return products;
        }

        [Route("Admin/ManageProduct/Create")]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(apiBaseUrl);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            string json = await client.GetStringAsync("api/Category");
            List<Category> categories = JsonConvert.DeserializeObject<List<Category>>(json);
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name");
            ViewBag.Category = categories;
            return View();
        }

        [Route("Admin/ManageProduct/AddProduct")]
        [HttpPost]
        public IActionResult AddProduct(Product product, IFormFile fileImages)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseUrl);
                ViewBag.Domain = apiBaseUrl;
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                var formdata = new MultipartFormDataContent();
                formdata.Add(new StringContent(product.Name), "Name");
                formdata.Add(new StringContent(product.Quatity.ToString()), "Quatity");
                formdata.Add(new StringContent(product.IdCategory.ToString()), "IdCategory");
                formdata.Add(new StringContent(product.Price.ToString()), "Price");
                formdata.Add(new StringContent(product.Notes), "Notes");
                formdata.Add(new StringContent(product.ISDELETE.ToString()), "ISDELETE");
                formdata.Add(new StringContent(product.ISACTIVE.ToString()), "ISACTIVE");
                formdata.Add(new StringContent(product.Description), "Description");
                formdata.Add(new StreamContent(fileImages.OpenReadStream()), "fileImages", fileImages.FileName);

                var response = client.PostAsync("api/Product", formdata).Result;
                var json = response.Content.ReadAsStringAsync().Result;
            }
            return RedirectToAction("Index");
        }

        [Route("Admin/ManageProduct/AddCategory")]
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = client.PostAsJsonAsync("api/Category", category).Result;
                
            }
            return RedirectToAction("Create");
        }
        [Route("Admin/ManageProduct/DeleteProduct")]
        public IActionResult DeleteProduct(int id)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = client.DeleteAsync("api/Product/"+id).Result;
                if (Res.IsSuccessStatusCode)
                {
                    TempData["msg"] = "Product deleted successfully";
                }
                else
                {
                    TempData["msg"] = "Product delete failed";
                }
            }
            return RedirectToAction("Index");
        }
        /*[Route("Admin/ManageProduct/EditProduct")]
        public IActionResult EditProduct(int id)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                *//*HttpResponseMessage Res = client.PutAsJsonAsync("api/Product/" + id).Result;*//*
                if (Res.IsSuccessStatusCode)
                {
                    TempData["msg"] = "Product deleted successfully";
                }
                else
                {
                    TempData["msg"] = "Product delete failed";
                }
            }
            return RedirectToAction("Index");
        }*/
    }
}
