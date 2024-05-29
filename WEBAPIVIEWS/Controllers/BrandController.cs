using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WEBAPIVIEWS.Models;

namespace WEBAPIVIEWS.Controllers
{
    public class BrandController : Controller
    {
        WebapiviewsContext context;
        IWebHostEnvironment env;
    
        public BrandController(WebapiviewsContext context, IWebHostEnvironment env)
        {
            this.context = context;
            this.env = env;
        }
        private string url = "http://localhost:5136/api/brands/";
            private HttpClient client = new HttpClient();
            [HttpGet]
            public IActionResult Index()
            {
                List<Brand> brand = new List<Brand>();
                HttpResponseMessage response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var data = JsonConvert.DeserializeObject<List<Brand>>(result);
                    if (data != null)
                    {
                        brand = data;
                }
                }
                return View(brand);
            }
        [HttpGet]
        public IActionResult Create()
        {
            return View();  
        }
        
        [HttpPost]
        public IActionResult Create(ProductViewModel prod)
        {
             string fileName = "";
            if (prod.photo != null)
            {
                string folder = Path.Combine(env.WebRootPath, "images");
                fileName = Guid.NewGuid().ToString() + "_" + prod.photo.FileName;
                string filePAth = Path.Combine(folder, fileName);
                prod.photo.CopyTo(new FileStream(filePAth, FileMode.Create));
                Brand brand = new Brand()
                {
                    Name = prod.Name,
                    Price = prod.Price,
                    Category = prod.Category,
                    ImagePath = fileName,

                };
                String data = JsonConvert.SerializeObject(brand);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(url, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["insert_message"] = "Brand Added...";
                    return RedirectToAction("Index");
                }
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
           return View(bd);
    }
        [HttpPost]
        public IActionResult Edit(Brand brand)
        {
            string data = JsonConvert.SerializeObject(brand);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync((url + brand.ID), content).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["update_message"] = "Brand Updated...";
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            Brand bd = new Brand();
            HttpResponseMessage response = client.GetAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Brand>(result);
                if (data != null)
                {
                    bd = data;
                }
            }
            return View(bd);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Brand bd = new Brand();
            HttpResponseMessage response = client.GetAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Brand>(result);
                if (data != null)
                {
                    bd = data;
                }
            }
            return View(bd);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
          
            HttpResponseMessage response = client.DeleteAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["delete_message"] = "Brand Deleted...";
                return RedirectToAction("Index");
            }
            return View();
        }
    }

}
       