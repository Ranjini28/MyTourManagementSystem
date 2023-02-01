using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTourManagementAPI.DataAccessLayer;
using MyTourManagementAPI.IRepository;
using MyTourManagementAPI.Models;

namespace MyTourManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        IAdminRepository repository;
        public AdminController(IAdminRepository _repository)
        {
            repository = _repository;

        }
        [HttpPost]
        [Route("AddAdmin")]
        public async Task<IActionResult> AddAdmin([FromBody] Admin admin)
        {

            if (ModelState.IsValid)
            {
                try
                {

                    var tourId = await repository.AddAdmin(admin);
                    if (tourId > 0)
                    {
                        return Ok(tourId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

    }
}
