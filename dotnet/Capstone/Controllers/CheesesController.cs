using Capstone.DAO;
using Capstone.DAO.Interfaces;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Authorization;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CheesesController : ControllerBase
    {
        private readonly ICheeseDao cheeseDao;
        public CheesesController(ICheeseDao _cheeseDao)
        {
            cheeseDao = _cheeseDao;
        }
        [HttpGet]
        public IActionResult GetAllCheeses()
        {
            try
            {
                List<Cheese> output = new List<Cheese>();
                output = cheeseDao.GetAllCheeses();
                return Ok(output);
            }
            catch(KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetCheeseById(int id)
        {
            try
            {
                Cheese output = new Cheese();
                output = cheeseDao.GetCheeseByID(id);
                return Ok(output);
            }
            catch(KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]

        //TODO Authorize
        public IActionResult AddCheeseToDatabase(NewCheese cheese)
        {
            try
            {
                Cheese output = cheeseDao.AddCheeseToDatabase(cheese);
                return Created("Cheeses/" + output.CheeseID, output);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpDelete("{id}")]

        //TODO Authorize
        public IActionResult DeleteCheeseById(int id)
        {
            try
            {
                if(cheeseDao.DeleteCheeseByID(id) <= 0)
                {
                    return NotFound("Cheese could not be found, are you sure you used the correct id?");
                }
                return NoContent();
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }
    }
}
