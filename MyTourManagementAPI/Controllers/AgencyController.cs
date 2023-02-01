using Microsoft.AspNetCore.Mvc;
using MyTourManagementAPI.DataAccessLayer;
using MyTourManagementAPI.Models;

namespace MyTourManagementAPI.Controllers
{
    [Route("api/[controller]")]
    public class AgencyController : Controller
    {
        private TourDbContext _context;
        public AgencyController(TourDbContext context)
        {
            _context = context;

        }
        [HttpGet]
        public List<TravelAgency> GetAllAgencys()
        {
            return _context.TravelAgencyDetails.ToList();
        }
        [HttpGet("{Id}")]
        public TravelAgency GetAgency(int Id)
        {
            var agency = _context.TravelAgencyDetails.Where(a => a.AgencyId == Id).SingleOrDefault();
            return agency;

        }

        [HttpPost]
        public IActionResult AddAgency([FromBody] TravelAgency agency)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }
            _context.TravelAgencyDetails.Add(agency);
            _context.SaveChanges();

            return Ok();

        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAgency(int Id)
        {
            var agency = await _context.TravelAgencyDetails.FindAsync(Id);
            if (agency == null)
            {
                return NotFound();
            }
            _context.TravelAgencyDetails.Remove(agency);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
