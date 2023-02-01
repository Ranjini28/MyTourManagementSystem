using Microsoft.AspNetCore.Mvc;
using MyTourManagementAPI.DataAccessLayer;
using MyTourManagementAPI.Models;

namespace MyTourManagementAPI.Controllers
{
    [Route("api/[controller]")]
    public class PaymentController : Controller
    {
        private TourDbContext _context;
        public PaymentController(TourDbContext context)
        {
            _context = context;

        }
        [HttpGet]
        public List<PaymentDetails> GetAllPayDetails()
        {
            return _context.PaymentDetails.ToList();
        }
        [HttpGet("{Id}")]
        public PaymentDetails GetPaymentReciept(int Id)
        {
            var payment = _context.PaymentDetails.Where(a => a.UserId == Id).SingleOrDefault();
            return payment;

        }

        [HttpPost]
        public IActionResult AddPayment([FromBody] PaymentDetails payment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }
            _context.PaymentDetails.Add(payment);
            _context.SaveChanges();

            return Ok();

        }

       /* [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteUser(int Id)
        {
            var user = await _context.PaymentDetails.FindAsync(Id);
            if (user == null)
            {
                return NotFound();
            }
            _context.PaymentDetails.Remove(user);
            await _context.SaveChangesAsync();
            return NoContent();
        }*/
    }
}
