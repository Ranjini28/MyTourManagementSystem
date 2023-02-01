using Microsoft.AspNetCore.Mvc;
using MyTourManagementSystemMVC.Models;
using System.Diagnostics;

namespace MyTourManagementSystemMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        
    }
}