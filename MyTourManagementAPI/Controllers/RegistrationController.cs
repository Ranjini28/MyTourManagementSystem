using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MyTourManagementAPI.IRepository;
using MyTourManagementAPI.Models;
using System.Data.SqlClient;

namespace MyTourManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        //  public readonly IConfiguration _configuration;
        IUserRepository repository;
        public RegistrationController(IUserRepository _repository)
        {
            repository = _repository;

        }
        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await repository.GetAllUsers();
                if (users == null)
                {
                    return NotFound();
                }
                return Ok(users);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> AddUser([FromBody] UserRegisterDetails user)
        {

            if (ModelState.IsValid)
            {
                try
                {

                    var userId = await repository.AddUser(user);
                    if (userId > 0)
                    {
                        return Ok(userId);
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

        [HttpGet]
        [Route("GetUser/{userid}")]
        public async Task<IActionResult> GetUser(int? userid)
        {
            if (userid == null)
            {
                return BadRequest();
            }
            try
            {
                var users = await repository.GetUser(userid);
                if (users == null)
                {
                    return NotFound();
                }
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteUser/{userid}")]
        public async Task<IActionResult> DeleteUser(int? userid)
        {
            int result = 0;
            if (userid == null)
            {
                return BadRequest();
            }
            try
            {

                result = await repository.DeleteUser(userid);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UserRegisterDetails model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await repository.UpdateUser(model);
                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }

        /*[HttpGet]
        [Route("LoginUser/{useremail}/{password}")]
        public async Task<IActionResult> UserLogin(string useremail, string password)
        {
            int result = 0;
            if (useremail == null || password==null)
            {
                return BadRequest();
            }
            try
            {

                result = await repository.UserLogin(useremail,password);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }*/
    }
}