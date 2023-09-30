using Capstone.DAO.Interfaces;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using System;
using System.Collections.Generic;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SizeController : Controller
    {
        public ISizeDao sizeDao;
        public SizeController(ISizeDao _sizeDao)
        {
            sizeDao = _sizeDao;
        }
        [HttpPost]
        public IActionResult AddSizeToDatabase(NewSize size)
        {
            try
            {
                Size output = sizeDao.AddNewSize(size);
                return Created("Size" + output.SizeID, output);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        public IActionResult GetAllSizes()
        {
            try
            {
                List<Size> output = new List<Size>();
                output = sizeDao.GetAllSizes();
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
        public IActionResult GetSizeByID(int id)
        {
            try
            {
                Size output = new Size();
                output = sizeDao.GetSizeByID(id);
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
        public IActionResult SetSizeToAvailable(int id)
        {
            try
            {
                return Ok(sizeDao.MakeAvailable(id));
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
        public IActionResult SetSizeToUnavailable(int id)
        {
            try
            {
                return Ok(sizeDao.MakeUnavailable(id));
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
        [HttpPut("Size/")]
        public IActionResult UpdateSize(Size size)
        {
            try
            {
                return Ok(sizeDao.UpdateSize(size));
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
