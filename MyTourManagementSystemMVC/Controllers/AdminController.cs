using Microsoft.AspNetCore.Mvc;

using MyTourManagementMVC.Helper;
using MyTourManagementMVC.Models;
using MyTourManagementSystemMVC.Models;
using Newtonsoft.Json;


namespace MyTourManagementSystemMVC.Controllers
{
    public class AdminController : Controller
    {
        MyTourAPI aPI = new MyTourAPI();
        public IActionResult Index()

        {
            return View();
        }
        public ActionResult create()
        {
            return View();

        }
        [HttpPost]
        public IActionResult create(admin ad)
        {
            HttpClient client = aPI.Initial();
            var addUser = client.PostAsJsonAsync<admin>("api/Bookings/AddAdmin", ad);
            addUser.Wait();
            var result = addUser.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }

        public IActionResult AddTourPackage()
        {
            return RedirectToAction("Create", "TourPackage");
        }
        public IActionResult AddTravelAgency()
        {
            return RedirectToAction("Create", "TravelAgency");
        }
        public IActionResult AdminLogin()
        {
            return View();
        }
        public IActionResult AdminRegSuccess(admin ad)
        {

            return View();
        }
    }
}
    
