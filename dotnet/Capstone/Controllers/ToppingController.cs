using Capstone.DAO.Interfaces;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Capstone.Controllers
{
    [Route ("[controller]")]
    [ApiController]
    public class ToppingController : Controller
    {
        private readonly IToppingDao toppingDao;
        public ToppingController(IToppingDao _toppingDao)
        {
            toppingDao = _toppingDao;
        }
        [HttpPost]
        public IActionResult AddToppingToDatabase(NewTopping topping)
        {
            try
            {
                Topping output = toppingDao.AddToppingToDatabase(topping);
                return Created("Toppings/" + output.ToppingID, output);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetToppingByID(int id)
        {
             try
             {
                 Topping output = new Topping();
                 output = toppingDao.GetToppingByID(id);
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
        [HttpGet]
        public IActionResult GetAllToppings()
        {
            try
            {
                List<Topping> output = new List<Topping>();
                output = toppingDao.GetAllToppings();
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
        [HttpDelete]
        public IActionResult DeleteToppingByID(int id)
        {
            try
            {
                if(toppingDao.DeleteToppingByID(id) <= 0)
                {
                    return NotFound("Topping could not be found, are you sure you used the correct id?");
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
