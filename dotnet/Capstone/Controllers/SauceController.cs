using Capstone.DAO.Interfaces;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SauceController : ControllerBase
    {
        private readonly ISauceDao sauceDao;
        public SauceController(ISauceDao _sauceDao)
        {
            sauceDao = _sauceDao;
        }
        [HttpPost]
        public IActionResult AddSauceToDatabase(NewSauce sauce)
        {
            try
            {
                Sauce output = sauceDao.AddNewSauce(sauce);
                return Created("Sauce/" + output.SauceID, output);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSauceByID(int id)
        {
            try
            {
                if(sauceDao.DeleteSauce(id) <= 0)
                {
                    return NotFound("Sauce could not be found, are you sure you used the correct id?");
                }
                return NoContent();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }
        [HttpGet]
        public IActionResult GetAllSauces()
        {
            try
            {
                List<Sauce> output = new List<Sauce>();
                output = sauceDao.GetAllSauces();
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
        public IActionResult GetSauceById(int id)
        {
            try
            {
                Sauce output = new Sauce();
                output = sauceDao.GetSauceByID(id);
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
        [HttpPut("available/{id}/true")]
        public IActionResult SetSauceToAvailable(int id)
        {
            try
            {
                return Ok(sauceDao.SetSauceToAvailable(id));
            }
            catch(KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("available/{id}/false")]
        public IActionResult SetSauceToUnavailable(int id)
        {
            try
            {
                return Ok(sauceDao.SetSauceToUnavailable(id));
            }
            catch(KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("Sauce/")]
        public IActionResult UpdateSauce(Sauce sauce)
        {
            try
            {
                return Ok(sauceDao.UpdateSauce(sauce));
            }
            catch(KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
