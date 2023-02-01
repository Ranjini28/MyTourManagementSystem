using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyTourManagementAPI.DataAccessLayer;
using MyTourManagementAPI.Models;
using System.Linq;

namespace MyTourManagementAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private TourDbContext _context;
        public UserController(TourDbContext context)
        {
            _context = context;

        }
        [HttpGet]
        public List<UserRegisterDetails> GetAllUsers()
        {
            return _context.UserRegisterDetails.ToList();
        }
        [HttpGet("{Id}")]
        public UserRegisterDetails GetUser(int Id) {
            var user = _context.UserRegisterDetails.Where(a => a.UserId == Id).SingleOrDefault();
            return user;
             
                }

        [HttpPost]
        public IActionResult AddUser([FromBody]UserRegisterDetails user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }
             _context.UserRegisterDetails.Add(user);
             _context.SaveChanges();
            
            return Ok();

        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteUser(int Id)
        {
            var user = await _context.UserRegisterDetails.FindAsync(Id);
            if(user == null)
            {
                return NotFound();
            }
            _context.UserRegisterDetails.Remove(user);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("{phno}")]
        public UserRegisterDetails GetUserByPhoneNumber(long phno)

        {

            var user = _context.UserRegisterDetails.Where(a => a.PhoneNumber == phno).SingleOrDefault();
            return user;

        }



        /*[HttpPost]
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



    
    
     