using Capstone.DAO.Interfaces;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace Capstone.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {
        public IPizzaDao pizzaDao;
        public PizzaController(IPizzaDao _pizzaDao)
        {
            pizzaDao = _pizzaDao;
        }
        [HttpGet()]
        public IActionResult GetSpecialtyPizzas()
        {
            try
            {
                return Ok(pizzaDao.GetAllSpecialtyPizzas());
            }
            catch (System.Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetPizzaById(int id)
        {
            try
            {
                return Ok(pizzaDao.GetPizzaByPizzaID(id));
            }
            catch(KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (System.Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet("userpizzas")]
        public IActionResult GetUserPizzas()
        {
            try
            {
                return Ok(pizzaDao.GetUserFavoritePizzas(/*TODO Figure out how to get the current user id*/ 0));
            }
            catch (System.Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }
        [HttpPost("custom")]
        public IActionResult AddCustomPizzaToDatabase(NewPizza pizza)
        {
            try
            {
                Pizza output = pizzaDao.AddNewCustomPizzaToDatabase(pizza);
                return Created("" + output.PizzaID, output);
            }
            catch (System.Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }
        [HttpPost("specialty/{price}")]
        //TODO Authorize
        public IActionResult AddSpecialtyPizzaToDatabase(NewPizza pizza, decimal price)
        {
            try
            {
                Pizza output = pizzaDao.AddNewSpecialtyPizzatoDatabase(pizza, price);
                return Created("" + output.PizzaID, output);
            }
            catch (System.Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }
        [HttpPut("{id}/{newprice}")]
        //TODO Authorize
        public IActionResult UpdatePizzaPrice(int id, decimal newprice)
        {
            try
            {
                return Ok(pizzaDao.UpdatePizzaPrice(id, newprice));
            }
            catch(KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (System.Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }
        [HttpDelete("{id}")]
        //TODO Authorize
        public IActionResult DeletePizzaById(int id)
        {
            try
            {
                pizzaDao.DeletePizzaByPizzaID(id);
                return NoContent();
            }
            catch(KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (System.Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }
        [HttpDelete("user/{userId}")]
        //TODO Authorize as User
        public IActionResult DeleteUserUnfavoritedPizzas(int userId)
        {
            try
            {
                pizzaDao.DeleteUserUnfavoritedPizzas(userId);
                return NoContent();
            }
            catch(KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (System.Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }
        [HttpDelete()]
        //TODO Authorize
        public IActionResult DeleteUnassociatedPizzas()
        {
            try
            {
                pizzaDao.DeleteAllPizzasNotAssociatedWithUsers();
                return NoContent();
            }
            catch (System.Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}