using Microsoft.AspNetCore.Mvc;

using MyTourManagementMVC.Helper;
using MyTourManagementMVC.Models;
using MyTourManagementSystemMVC.Models;
using Newtonsoft.Json;

namespace MyTourManagementMVC.Controllers
{
    public class BookingController : Controller
    {
        MyTourAPI aPI = new MyTourAPI();
        public async Task<IActionResult> Index()
        {
            List<BookingDetails> bookings = new List<BookingDetails>();
            HttpClient client = aPI.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Bookings/GetAllBookings");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                bookings = JsonConvert.DeserializeObject<List<BookingDetails>>(results);

            }
            return View(bookings);
        }
        public async Task<IActionResult> Details(int Id)
        {
            var booking = new BookingDetails();
            HttpClient client = aPI.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/Bookings/GetBooking/{Id}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                booking = JsonConvert.DeserializeObject<BookingDetails>(results);
            }
            return View(booking);
        }
        public ActionResult create()
        {
            return View();

        }
        [HttpPost]
        public IActionResult create(BookingDetails booking)
        {
            HttpClient client = aPI.Initial();
            var addUser = client.PostAsJsonAsync<BookingDetails>("api/Bookings/AddBooking", booking);
            addUser.Wait();
            var result = addUser.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Create", "Payment");
            }
            return View();
        }

        public async Task<IActionResult> Delete(int Id)
        {
            var booking = new BookingDetails();
            HttpClient client = aPI.Initial();
            HttpResponseMessage res = await client.DeleteAsync($"api/Bookings/DeleteBooking{Id}");
            return RedirectToAction("Index");
        }

       /* public async Task<IActionResult> GetBookingInformation(int Id)
        {

            var booking = new BookingInfo();
            HttpClient client = aPI.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/Bookings/GetBookingInformation2/{Id}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                booking = JsonConvert.DeserializeObject<BookingInfo>(results);
            }
            return View(booking);
        }
       */
        /*public async Task<IActionResult> GetBookingInfo()
        {
            using (TourDbContext tourDal = new TourDbContext())
            {
                List<UserRegisterDetails> users = tourDal.UserRegisterDetails.ToList();
                List<BookingDetails> bookings = tourDal.BookingDetails.ToList();
                List<TourPackageDetails> packages = tourDal.TourPackageDetails.ToList();
                var bookdetails = from u in tourDal.UserRegisterDetails
                                  join b in
                                  tourDal.BookingDetails.ToList() on u.UserId equals b.UserId into table1
                                  from b in table1.ToList()
                                  join t in tourDal.TourPackageDetails on
                                  b.TourId equals t.TourId into table2
                                  from t in table2.ToList()
                                  select new BookingInfo
                                  {
                                      users = u,
                                      bookings = b,
                                      tours = t
                                  };
                return View(bookdetails);
            }*/

    }
}