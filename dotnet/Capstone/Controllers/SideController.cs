using Capstone.DAO.Interfaces;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Capstone.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SideController : ControllerBase
    {
        public ISideDao sideDao;
        public SideController(ISideDao _sideDao)
        {
            sideDao = _sideDao;
        }
        [HttpPost]
        public IActionResult AddSideToDatabase(NewSide side)
        {
            try
            {
                Side output = sideDao.AddNewSide(side);
                return Created("Sides/" + output.SideID, output);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete]
        public IActionResult DeleteSideByID(int id)
        {
            try
            {
                if(sideDao.DeleteSideByID(id) <= 0)
                {
                    return NotFound("Side could not be found, are you sure you used the correct id?");
                }
                return NoContent();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet()]
        public IActionResult GetAllSides()
        {
            try
            {
                return Ok(sideDao.GetAllSides(false));
            }
            catch (System.Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }
        [HttpGet("/Wing")]
        public IActionResult GetAllWings()
        {
            try
            {
                return Ok(sideDao.GetAllSides(true));
            }
            catch (System.Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetSideByID(int id)
        {
            try
            {
                Side output = new Side();
                output = sideDao.GetSideByID(id);
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
        public IActionResult GetSidesByOrderID(int id)
        {
            try
            {
                List<Side> output = new List<Side>();
                output = sideDao.GetSidesByOrderId(id);
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
        public IActionResult SetSideToAvailable(int id)
        {
            try
            {
                return Ok(sideDao.MakeSideAvailable(id));
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
        [HttpPut("avialable/{id}/false")]
        public IActionResult SetSideToUnavailable(int id)
        {
            try
            {
                return Ok(sideDao.MakeSideUnavailable(id));
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("Sides")]
        public IActionResult UpdateSide(Side side)
        {
            try
            {
                return Ok(sideDao.UpdateSide(side));
            }
            catch(KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
