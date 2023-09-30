using Capstone.DAO.Interfaces;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Capstone.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        IOrderDao orderDao;
        public OrderController(IOrderDao _orderDao)
        {
            orderDao = _orderDao;
        }
        [HttpGet]
        //TODO Authorize
        public IActionResult GetAllOrders()
        {
            try
            {
                return Ok(orderDao.GetAllOrders());
            }
            catch (System.Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet("{id}")]
        //TODO Authorize
        public IActionResult GetOrderById(int id)
        {
            try
            {
                return Ok(orderDao.GetOrderById(id));
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (System.Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }
        [HttpGet("active")]
        //TODO Authorize
        public IActionResult GetActiveOrders()
        {
            try
            {
                return Ok(orderDao.GetActiveOrders());
            }
            catch (System.Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }
        [HttpGet("complete")]
        //TODO Authorize
        public IActionResult GetCompleteOrders()
        {
            try
            {
                return Ok(orderDao.GetCompletedOrders());
            }
            catch (System.Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }
        [HttpPost]
        public IActionResult AddNewOrder(NewOrder order)
        {
            //TODO Fix Created Return on add new order
            try
            {
                Order newOrder = orderDao.AddNewOrderToDatabase(order);
                return Created("" + newOrder.OrderID, newOrder);
            }
            catch (System.Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpPut()]
        public IActionResult UpdateOrder(Order order)
        {
            try
            {
                return Ok(orderDao.UpdateOrder(order));
            }
            catch (System.Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult CancelOrder(int id)
        {
            try
            {
                return Ok(orderDao.CancelOrder(id));
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
        [HttpPut("{id}/complete")]
        //TODO Authorize
        public IActionResult MarkOrderAsComplete(int id)
        {
            try
            {
                return Ok(orderDao.MarkOrderAsComplete(id));
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
    }
}
