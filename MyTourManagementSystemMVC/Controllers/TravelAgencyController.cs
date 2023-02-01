using Microsoft.AspNetCore.Mvc;
using MyTourManagementMVC.Helper;
using MyTourManagementMVC.Models;
using Newtonsoft.Json;

namespace MyTourManagementMVC.Controllers
{
    public class TravelAgencyController : Controller
    {
        MyTourAPI aPI = new MyTourAPI();
        public async Task<IActionResult> Index()
        {
            List<TravelAgencyDetails> agency = new List<TravelAgencyDetails>();
            HttpClient client = aPI.Initial();
            HttpResponseMessage res = await client.GetAsync("api/TravelAgency/GetAllAgencys");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                agency = JsonConvert.DeserializeObject<List<TravelAgencyDetails>>(results);

            }
            return View(agency);
        }
        public async Task<IActionResult> Details(int Id)
        {
            var agency = new TravelAgencyDetails();
            HttpClient client = aPI.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/TravelAgency/GetAgency/{Id}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                agency = JsonConvert.DeserializeObject<TravelAgencyDetails>(results);
            }
            return View(agency);
        }
        public ActionResult create()
        {
            return View();

        }
        [HttpPost]
        public IActionResult create(TravelAgencyDetails user)
        {
            HttpClient client = aPI.Initial();
            var addAgency = client.PostAsJsonAsync<TravelAgencyDetails>("api/TravelAgency/AddAgency", user);
            addAgency.Wait();
            var result = addAgency.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Delete(int Id)
        {
            var agency = new TravelAgencyDetails();
            HttpClient client = aPI.Initial();
            HttpResponseMessage res = await client.DeleteAsync($"api/TravelAgency/DeleteAgency/{Id}");
            return RedirectToAction("Index");
        }
    }
}
