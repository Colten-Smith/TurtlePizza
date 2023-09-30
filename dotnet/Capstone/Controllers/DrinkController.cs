using Capstone.DAO.Interfaces;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DrinkController : ControllerBase
    {
        private readonly IDrinkDao drinkDao;
        public DrinkController(IDrinkDao _drinkDao)
        {
            drinkDao = _drinkDao;
        }
        [HttpPost()]
        public IActionResult AddDrinkToDatabase(NewDrink drink)
        {
            try
            {
                Drink output = drinkDao.AddDrinkToDatabase(drink);
                return Created("Drinks/" + output.DrinkID, output);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetDrinkByID(int id)
        {
            try
            {
                Drink output = new Drink();
                output = drinkDao.GetDrinkByID(id);
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
        [HttpGet("order/{id}")]
        public IActionResult GetDrinksByOrderID(int id)
        {
            try
            {
                List<Drink> output = new List<Drink>();
                output = drinkDao.GetDrinksByOrderId(id);
                return Ok(output);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
         
        }
        [HttpGet()]
        public IActionResult GetAllDrinks()
        {
            try
            {
                List<Drink> output = new List<Drink>();
                output = drinkDao.GetAllDrinks();
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
        [HttpDelete("{id}")]
        public IActionResult DeleteDrinkByID(int id)
        {
            try
            {
                if(drinkDao.DeleteDrinkByID(id) <= 0)
                {
                    return NotFound("Drink could not be found, are you sure you used the corred id?");
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut("available/{id}/true")]
        public IActionResult SetDrinkToAvailable(int id)
        {
            try
            {
                return Ok(drinkDao.SetDrinkToAvailable(id));
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
        [HttpPut("available/{id}/false")]
        public IActionResult SetDrinkToUnavailable(int id)
        {
            try
            {
                return Ok(drinkDao.SetDrinkToUnavailable(id));
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
    }
}
