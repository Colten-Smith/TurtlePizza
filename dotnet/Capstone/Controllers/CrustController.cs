using Capstone.DAO.Interfaces;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Capstone.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class CrustController : ControllerBase
    {
        private readonly ICrustDao crustDao;
        public CrustController(ICrustDao _crustDao)
        {
            crustDao = _crustDao;
        }
        [HttpPost()]
        public IActionResult AddCrustToDatabase(NewCrust crust)
        {
            try
            {
                Crust output = crustDao.AddCrustToDatabase(crust);
                return Created("Crusts/" + output.CrustID, output);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCrustByID(int id)
        {
            try
            {
                if(crustDao.DeleteCrustByID(id) <= 0)
                {
                    return NotFound("Crust could not be found, are you sure you used the correct id?");
                }
                return NoContent();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet()]
        public IActionResult GetAllCrusts()
        {
            try
            {
                List<Crust> output = new List<Crust>();
                output = crustDao.GetAllCrusts();
                return Ok(output);
            }
            catch(KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetCrustByID(int id)
        {
            try
            {
                Crust output = new Crust();
                output = crustDao.GetCrustByID(id);
                return Ok(output);
            }
            catch(KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
