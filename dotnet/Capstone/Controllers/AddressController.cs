using Capstone.DAO.Interfaces;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressDao addressDao;
        public AddressController(IAddressDao _addressDao)
        {
            addressDao = _addressDao;
        }
        [HttpGet("user/{id}")]
        public IActionResult GetAllAddressesForUser(int userID)
        {
            try
            {
                List<Address> output = new List<Address>();
                output = addressDao.GetAddressesForUser(userID);
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
        public IActionResult GetAddressByAddressID(int id)
        {
            try
            {
                Address output = new Address();
                output = addressDao.GetAddressByAddressID(id);
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
        [HttpPost()]
        public IActionResult AddAddressToDatabase(NewAddress address)
        {
            try
            {
                Address output = addressDao.AddNewAddressToDatabase(address);
                return Created("Addresses/" + output.AddressID, output);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAddressByAddressID(int id)
        {
            try
            {
                if(addressDao.DeleteAddressFromDatabaseByAddressID(id) <= 0)
                {
                    return NotFound("Address could not be found, are you sure you used the correct id?");
                }
                return NoContent();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("user/{id}")]
        public IActionResult DeleteAllAddressesForUser(int id)
        {
            try
            {
                if(addressDao.DeleteAllAddressesForUser(id) <= 0)
                {
                    return NotFound("Addresses could not be found, are you sure you used the correct id?");
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
