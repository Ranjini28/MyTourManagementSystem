using Microsoft.AspNetCore.Mvc;
using MyTourManagementAPI.DataAccessLayer;
using MyTourManagementAPI.Models;

namespace MyTourManagementAPI.Controllers
{
    [Route("api/[controller]")]
    public class TourController : Controller
    {
        private TourDbContext _context;
        public TourController(TourDbContext context)
        {
            _context = context;

        }
        [HttpGet]
        public List<TourPackageDetails> GetAllPackages()
        {
            return _context.TourPackageDetails.ToList();
        }
        [HttpGet("{Id}")]
        public TourPackageDetails GetPackage(int Id)
        {
            var pkg = _context.TourPackageDetails.Where(a => a.TourId == Id).SingleOrDefault();
            return pkg;
        }

        [HttpPost]
        public IActionResult AddPackage([FromBody] TourPackageDetails pkg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }
            _context.TourPackageDetails.Add(pkg);
            _context.SaveChanges();

            return Ok();

        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeletePackage(int Id)
        {
            var pkg = await _context.TourPackageDetails.FindAsync(Id);
            if (pkg == null)
            {
                return NotFound();
            }
            _context.TourPackageDetails.Remove(pkg);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        /*  [HttpPost]
          public async Task<IActionResult> UpdateUser([FromBody]UserRegisterDetails user)
          {
              if (!ModelState.IsValid)
              {
                  return BadRequest();
              }
              _context.UserDetails.Update(user);
              await _context.SaveChangesAsync();
              return NoContent();

          }*/

    }
}
