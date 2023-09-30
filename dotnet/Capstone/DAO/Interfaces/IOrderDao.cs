using Capstone.Models;
using System;
using System.Collections.Generic;

namespace Capstone.DAO.Interfaces
{
    public interface IOrderDao
    {
        //Create
        /// <summary>
        /// Adds a new order record to the database using the given data.
        /// </summary>
        /// <param name="orderToAdd">A NewOrder object containing the data to be added.</param>
        /// <returns>A copy of the new Order from the database.</returns>
        public Order AddNewOrderToDatabase(NewOrder orderToAdd);
        //Retrieve
        /// <summary>
        /// Gets the order with the specified ID from the database.
        /// </summary>
        /// <param name="id">The ID to search with.</param>
        /// <returns>The requested Order.</returns>
        public Order GetOrderById(int id);
        /// <summary>
        /// Gets all orders associated with a specified User ID.
        /// </summary>
        /// <param name="userId">The User ID to search with.</param>
        /// <returns>A List of requested Orders.</returns>
        public List<Order> GetOrdersByUserID(int userId);
        /// <summary>
        /// Gets all orders marked Completed in the database.
        /// </summary>
        /// <returns>A list of requested Orders.</returns>
        public List<Order> GetCompletedOrders();
        /// <summary>
        /// Gets all orders not marked Completed or Cancelled in the database.
        /// </summary>
        /// <returns>A list of requested Orders.</returns>
        public List<Order> GetActiveOrders();
        /// <summary>
        /// Gets all orders in the datbase.
        /// </summary>
        /// <returns>A list of Orders.</returns>
        public List<Order> GetAllOrders();
        //OPTIONAL
        /// <summary>
        /// Gets all orders that were marked completed within the specified timeframe.
        /// </summary>
        /// <param name="start">The start time.</param>
        /// <param name="end">The end time.</param>
        /// <returns>A list of requested Orders.</returns>
        public List<Order> GetOrdersCompletedDuringPeriod(DateTime start, DateTime end);
        //Update
        /// <summary>
        /// Updates an order in the database to have the specified data.
        /// </summary>
        /// <param name="orderToUpdate">An object containing the ID of the order to update and it's new data.</param>
        /// <returns>The Updated order object.</returns>
        public Order UpdateOrder(Order orderToUpdate);
        /// <summary>
        /// Finds the order in the database with the specified ID and sets it's status to completed, along with setting it's
        /// Completed Time to the current time.
        /// </summary>
        /// <param name="orderId">The ID of the order to mark.</param>
        /// <returns>The updated order object.</returns>
        public Order MarkOrderAsComplete(int orderId);
        /// <summary>
        /// Finds the order in the database with the specified ID and sets it's status to delivering, along with setting it's
        /// Delivery Time to the current time.
        /// </summary>
        /// <param name="orderId">The ID of the order to mark.</param>
        /// <returns>The updated order.</returns>
        public Order MarkOrderAsOutForDelivery(int orderId);
        /// <summary>
        /// Finds the order in the database with the specified ID and sets it's status to preparing, along with setting it's
        /// Start Time to the current time.
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns>The updated order.</returns>
        public Order MarkOrderAsBegun(int orderId);
        /// <summary>
        /// Finds the order in the database with the specified ID and sets it's status to boxing.
        /// </summary>
        /// <param name="orderId">The ID of the order to mark.</param>
        /// <returns>The updated order.</returns>
        public Order MarkOrderAsPrepared(int orderId);
        /// <summary>
        /// Sets the specified order to cancelled. Uses the User's ID to ensure that the user is cancelling their own order.
        /// </summary>
        /// <param name="orderId">The ID of the specified order.</param>
        /// <param name="userId">The ID of the user cancelling the order.</param>
        /// <returns>The Updated order.</returns>
        public Order CancelOrder(int orderId);
        //Delete
        /// <summary>
        /// Deletes the order with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the order to delete.</param>
        public int DeleteOrderById(int id);
    }
}
