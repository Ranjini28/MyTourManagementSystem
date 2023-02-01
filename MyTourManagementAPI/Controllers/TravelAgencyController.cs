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
    public class TravelAgencyController : ControllerBase
    {
        IAgencyRepository repository;
        public TravelAgencyController(IAgencyRepository _repository)
        {
            repository = _repository;

        }
        [HttpGet]
        [Route("GetAllAgencys")]
        public async Task<IActionResult> GetAllAgencys()
        {
            try
            {
                var agencys = await repository.GetAllAgencys();
                if (agencys == null)
                {
                    return NotFound();
                }
                return Ok(agencys);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpPost]
        [Route("AddAgency")]
        public async Task<IActionResult> AddAgency([FromBody] TravelAgency agency)
        {

            if (ModelState.IsValid)
            {
                try
                {

                    var agencyId = await repository.AddAgency(agency);
                    if (agencyId > 0)
                    {
                        return Ok(agencyId);
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
        [Route("GetAgency/{agencyid}")]
        public async Task<IActionResult> GetAgency(int? agencyid)
        {
            if (agencyid == null)
            {
                return BadRequest();
            }
            try
            {
                var agencys = await repository.GetAgency(agencyid);
                if (agencys == null)
                {
                    return NotFound();
                }
                return Ok(agencys);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteAgency/{agencyid}")]
        public async Task<IActionResult> DeleteAgency(int? agencyid)
        {
            int result = 0;
            if (agencyid == null)
            {
                return BadRequest();
            }
            try
            {

                result = await repository.DeleteAgency(agencyid);
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
        [Route("UpdateAgency")]
        public async Task<IActionResult> UpdateAgency([FromBody] TravelAgency model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await repository.UpdateAgency(model);
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

    }
}
