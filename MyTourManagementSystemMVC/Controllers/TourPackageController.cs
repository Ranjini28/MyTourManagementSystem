using Microsoft.AspNetCore.Mvc;
using MyTourManagementMVC.Helper;
using MyTourManagementMVC.Models;
using Newtonsoft.Json;
namespace MyTourManagementMVC.Controllers
{
    public class TourPackageController : Controller
    {
        MyTourAPI aPI = new MyTourAPI();
        public async Task<IActionResult> Index()
        {
            List<TourPackageDetails> pkg = new List<TourPackageDetails>();
            HttpClient client = aPI.Initial();
            HttpResponseMessage res = await client.GetAsync("api/TourPackages/GetAllPackages");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                pkg = JsonConvert.DeserializeObject<List<TourPackageDetails>>(results);

            }
            return View(pkg);
        }
        public async Task<IActionResult> Details(int Id)
        {
            var pkg = new TourPackageDetails();
            HttpClient client = aPI.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/TourPackages/GetPackage/{Id}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                pkg = JsonConvert.DeserializeObject<TourPackageDetails>(results);
            }
            return View(pkg);
        }
        public ActionResult create()
        {
            return View();

        }
        [HttpPost]
        public IActionResult create(TourPackageDetails pkg)
        {
            HttpClient client = aPI.Initial();
            var addTour= client.PostAsJsonAsync<TourPackageDetails>("api/TourPackages/AddPackage", pkg);
            addTour.Wait();
            var result = addTour.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Delete(int Id)
        {
            var pkg = new TourPackageDetails();
            HttpClient client = aPI.Initial();
            HttpResponseMessage res = await client.DeleteAsync($"api/TourPackage/DeletePackage/{Id}");
            return RedirectToAction("Index");
        }



    }
}
