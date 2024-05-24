using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Policy;
using System.Text;
using WEBAPIVIEWS.Models;

namespace WEBAPIVIEWS.Controllers
{
    public class BrandController : Controller
    {

            private string url = "http://localhost:5136/api/brands/";
            private HttpClient client = new HttpClient();
            [HttpGet]
            public IActionResult Index()
            {
                List<Brand> brands = new List<Brand>();
                HttpResponseMessage response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var data = JsonConvert.DeserializeObject<List<Brand>>(result);
                    if (data != null)
                    {
                        brands = data;
                }
                }
                return View(brands);
            }
        [HttpGet]
        public IActionResult Create()
        {
            return View();  
        }
        [HttpPost]
        public IActionResult Create(Brand brands)
        {
            String data = JsonConvert.SerializeObject(brands);
            StringContent content = new StringContent(data,Encoding.UTF8,"application/json");
            HttpResponseMessage response =client.PostAsync(url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["insert_message"] = "Brand Added...";
                return RedirectToAction("Index");
            }
            return View();
        }

    
    [HttpGet]
    public IActionResult Edit(int id)
    {
        Brand bd = new Brand();
        HttpResponseMessage response = client.GetAsync(url + id).Result;
            if(response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Brand>(result);
                if (data != null)
                {
                    bd = data;
                }
            }
        return View();
    }
        [HttpPut]
        public IActionResult Edit(Brand brands)
        {
            String data = JsonConvert.SerializeObject(brands);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(url + brands.id, content).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["update_message"] = "Brand Updated...";
                return RedirectToAction("Index");
            }
            return View();
        }

    }

}
