using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MyTourManagementAPI.DataAccessLayer;
using MyTourManagementAPI.IRepository;
using MyTourManagementAPI.Models;

using System.Data.SqlClient;

namespace MyTourManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        //  public readonly IConfiguration _configuration;
        IBookingRepository repository;
        public BookingsController(IBookingRepository _repository)
        {
            repository = _repository;

        }
        [HttpGet]
        [Route("GetAllBookings")]
        public async Task<IActionResult> GetAllBookings()
        {
            try
            {
                var Bookings = await repository.GetAllBookings();
                if (Bookings == null)
                {
                    return NotFound();
                }
                return Ok(Bookings);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpPost]
        [Route("AddBooking")]
        public async Task<IActionResult> AddBooking([FromBody] BookingDetails Booking)
        {

            if (ModelState.IsValid)
            {
                try
                {

                    var tourId = await repository.AddBooking(Booking);
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
        [Route("GetBooking/{Bookingid}")]
        public async Task<IActionResult> GetBooking(int? Bookingid)
        {
            if (Bookingid == null)
            {
                return BadRequest();
            }
            try
            {
                var Bookings = await repository.GetBooking(Bookingid);
                if (Bookings == null)
                {
                    return NotFound();
                }
                return Ok(Bookings);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteBooking/{Bookingid}")]
        public async Task<IActionResult> DeleteBooking(int? Bookingid)
        {
            int result = 0;
            if (Bookingid == null)
            {
                return BadRequest();
            }
            try
            {

                result = await repository.DeleteBooking(Bookingid);
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
        [Route("UpdateBooking")]
        public async Task<IActionResult> UpdateBooking([FromBody] BookingDetails model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await repository.UpdateBooking(model);
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

        [HttpGet]
        [Route("GetBookingInfo/{userid}")]
        public async Task<IActionResult> GetBookingInformation(int? userid)
        {
            if (userid == null)
            {
                return BadRequest();
            }
            try
            {
                var Bookings = await repository.GetBooking(userid);
                if (Bookings == null)
                {
                    return NotFound();
                }
                return Ok(Bookings);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
