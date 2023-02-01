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
    public class TourPackagesController : ControllerBase
    {
        
            //  public readonly IConfiguration _configuration;
            ITourRepository repository;
            public TourPackagesController(ITourRepository _repository)
            {
                repository = _repository;

            }
            [HttpGet]
            [Route("GetAllPackages")]
            public async Task<IActionResult> GetAllPackages()
            {
                try
                {
                    var pkgs = await repository.GetAllPackages();
                    if (pkgs == null)
                    {
                        return NotFound();
                    }
                    return Ok(pkgs);
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }


            [HttpPost]
            [Route("AddPackage")]
            public async Task<IActionResult> AddPackage([FromBody] TourPackageDetails pkg)
            {

                if (ModelState.IsValid)
                {
                    try
                    {

                        var tourId = await repository.AddPackage(pkg);
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

            [HttpGet]
            [Route("GetPackage/{tourid}")]
            public async Task<IActionResult> GetPackage(int? tourid)
            {
                if (tourid == null)
                {
                    return BadRequest();
                }
                try
                {
                    var pkgs = await repository.GetPackage(tourid);
                    if (pkgs == null)
                    {
                        return NotFound();
                    }
                    return Ok(pkgs);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            [HttpDelete]
            [Route("DeletePackage/{tourid}")]
            public async Task<IActionResult> DeletePackage(int? tourid)
            {
                int result = 0;
                if (tourid == null)
                {
                    return BadRequest();
                }
                try
                {

                    result = await repository.DeletePackage(tourid);
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
            [Route("UpdatePackage")]
            public async Task<IActionResult> UpdatePackage([FromBody] TourPackageDetails model)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        await repository.UpdatePackage(model);
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

