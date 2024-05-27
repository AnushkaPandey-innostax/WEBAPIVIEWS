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
                List<Brands> brand = new List<Brands>();
                HttpResponseMessage response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var data = JsonConvert.DeserializeObject<List<Brands>>(result);
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
        public IActionResult Create(Brands brand)
        {
            String data = JsonConvert.SerializeObject(brand);
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
        Brands bd = new Brands();
        HttpResponseMessage response = client.GetAsync(url + id).Result;
            if(response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Brands>(result);
                if (data != null)
                {
                    bd = data;
                }
            }
           return View(bd);
    }
        [HttpPost]
        public IActionResult Edit(Brands brand)
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
            Brands bd = new Brands();
            HttpResponseMessage response = client.GetAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Brands>(result);
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
            Brands bd = new Brands();
            HttpResponseMessage response = client.GetAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Brands>(result);
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
