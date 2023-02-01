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
    public class PaymentsController : ControllerBase
    {
        //  public readonly IConfiguration _configuration;
        IPaymentRepository repository;
        public PaymentsController(IPaymentRepository _repository)
        {
            repository = _repository;

        }
        [HttpGet]
        [Route("GetAllPayments")]
        public async Task<IActionResult> GetAllPayments()
        {
            try
            {
                var Payments = await repository.GetAllPayments();
                if (Payments == null)
                {
                    return NotFound();
                }
                return Ok(Payments);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpPost]
        [Route("AddPayment")]
        public async Task<IActionResult> AddPayment([FromBody] PaymentDetails Payment)
        {

            if (ModelState.IsValid)
            {
                try
                {

                    var PaymentId = await repository.AddPayment(Payment);
                    if (PaymentId > 0)
                    {
                        return Ok(PaymentId);
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
        [Route("GetPayment/{Paymentid}")]
        public async Task<IActionResult> GetPayment(int? Paymentid)
        {
            if (Paymentid == null)
            {
                return BadRequest();
            }
            try
            {
                var Payments = await repository.GetPayment(Paymentid);
                if (Payments == null)
                {
                    return NotFound();
                }
                return Ok(Payments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeletePayment/{Paymentid}")]
        public async Task<IActionResult> DeletePayment(int? Paymentid)
        {
            int result = 0;
            if (Paymentid == null)
            {
                return BadRequest();
            }
            try
            {

                result = await repository.DeletePayment(Paymentid);
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
        [Route("UpdatePayment")]
        public async Task<IActionResult> UpdatePayment([FromBody] PaymentDetails model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await repository.UpdatePayment(model);
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
