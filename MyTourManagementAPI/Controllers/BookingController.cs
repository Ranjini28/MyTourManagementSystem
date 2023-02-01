using Microsoft.AspNetCore.Mvc;
using MyTourManagementAPI.DataAccessLayer;
using MyTourManagementAPI.Models;

namespace MyTourManagementAPI.Controllers
{
    [Route("api/[controller]")]
    public class BookingController : Controller
    {
        private TourDbContext _context;
        public BookingController(TourDbContext context)
        {
            _context = context;

        }
        [HttpGet]
        public List<BookingDetails> GetAllBookings()
        {
            return _context.BookingDetails.ToList();
        }
        [HttpGet("{Id}")]
        public BookingDetails GetBookingDetails(int Id)
        {
            var booking = _context.BookingDetails.Where(a => a.Id == Id).SingleOrDefault();
            return booking;

        }

        [HttpPost]
        public IActionResult AddUser([FromBody] BookingDetails booking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }
            _context.BookingDetails.Add(booking);
            _context.SaveChanges();

            return Ok();

        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteBooking(int Id)
        {
            var booking = await _context.BookingDetails.FindAsync(Id);
            if (booking == null)
            {
                return NotFound();
            }
            _context.BookingDetails.Remove(booking);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
