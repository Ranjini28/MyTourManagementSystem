using Microsoft.AspNetCore.Mvc;
using MyTourManagementMVC.Helper;
using MyTourManagementSystemMVC.Models;
using Newtonsoft.Json;

namespace MyTourManagementMVC.Controllers
{
    public class PaymentController : Controller
    {
        MyTourAPI aPI = new MyTourAPI();
        public async Task<IActionResult> Index()
        {
            List<Payment> payments = new List<Payment>();
            HttpClient client = aPI.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Payments/GetAllPayments");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                payments = JsonConvert.DeserializeObject<List<Payment>>(results);

            }
            return View(payments);
        }
        public async Task<IActionResult> Details(int Id)
        {
            var payment = new Payment();
            HttpClient client = aPI.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/Payments/GetPayment/{Id}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                payment = JsonConvert.DeserializeObject<Payment>(results);
            }
            return View(payment);
        }
        public ActionResult create()
        {
            return View();

        }
        [HttpPost]
        public IActionResult create(Payment payment)
        {
            HttpClient client = aPI.Initial();
            var addPayment = client.PostAsJsonAsync<Payment>("api/Payments/AddPayment", payment);
            addPayment.Wait();
            var result = addPayment.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("PaymentConfirmation","Payment");
            }
            return View();
        }

        public async Task<IActionResult> Delete(int Id)
        {
            var payment = new Payment();
            HttpClient client = aPI.Initial();
            HttpResponseMessage res = await client.DeleteAsync($"api/Payments/DeletePayment/{Id}");
            return RedirectToAction("Index");
        }
        public IActionResult PaymentConfirmation()
        {
            return View();
        }
    }
}
