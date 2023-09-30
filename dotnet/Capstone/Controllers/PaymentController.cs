using Capstone.DAO.Interfaces;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Capstone.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        public IPaymentDao paymentDao;
        public PaymentController(IPaymentDao _paymentDao)
        {
            paymentDao = _paymentDao;
        }
        [HttpPost]
        public IActionResult AddPaymentToDatabase(NewPayment payment)
        {
            try
            {
                Payment output = paymentDao.AddNewPaymentToDatabase(payment);
                return Created("Payments" + output.PaymentID, output);
            }
            catch(System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetPaymentByPaymentID(int id)
        {
            try
            {
                return Ok(paymentDao.GetPaymentByPaymentID(id));
            }
            catch(KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch(System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("User/{id}")]
        public IActionResult GetPaymentsByUserID(int id)
        {
            try
            {
                List<Payment> output = new List<Payment>();
                output = paymentDao.GetPaymentsByUserID(id);
                return Ok(output);
            }
            catch(KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeletePaymentByPaymentID(int id)
        {
            try
            {
                if(paymentDao.DeletePaymentByPaymentID(id) <= 0)
                {
                    return NotFound("Payment could not be found, are you sure you used the correct id?");
                }
                return NoContent();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("User/{id}")]
        public IActionResult DeletePaymentByUserID(int id)
        {
            try
            {
                if(paymentDao.DeleteUserPayments(id) <= 0)
                {
                    return NotFound("Payments could not be found, are you sure you used the correct id?");
                }
                return NoContent();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("Anonymous/")]
        public IActionResult DeleteAnonymousPayments()
        {
            try
            {
                if(paymentDao.DeleteAnonymousPayments() <= 0)
                {
                    return NotFound("Payment could not be found");
                }
                return NoContent();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("Expired")]
        public IActionResult DeleteExpiredPayments()
        {
            try
            {
                if(paymentDao.DeleteExpiredPayments() <= 0)
                {
                    return NotFound("Could not find any expired payments");
                }
                return NoContent();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
