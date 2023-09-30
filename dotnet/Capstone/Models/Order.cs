using System;
using System.Collections.Generic;
using System.Threading;

namespace Capstone.Models
{
    public class Order
    {
        /// <summary>
        /// The ID of the order.
        /// </summary>
        public int OrderID { get; set; }
        /// <summary>
        /// The ID of the user who placed the order.
        /// </summary>
        public int? UserID { get; set; }
        /// <summary>
        /// The total price of the order.
        /// </summary>
        public decimal TotalPrice { get; set; }
        /// <summary>
        /// Indicates whether or not the order is a delivery.
        /// </summary>
        public bool IsDelivery { get; set; }
        /// <summary>
        /// Indicates the status of the order. (1: Placed, 2: Preparing, 3: Boxing, 4: Delivering, 5: Complete)
        /// Step 4 will be skipped on pickup orders.
        /// </summary>
        public byte OrderStatus { get; set; }
        /// <summary>
        /// The time when the order began being prepared.
        /// </summary>
        public DateTime? StartTime { get; set; }
        /// <summary>
        /// The time when the order was sent out for delivery.
        /// </summary>
        public DateTime? DeliveryTime { get; set; }
        /// <summary>
        /// The time when the order was completed.
        /// </summary>
        public DateTime? CompleteTime { get; set; }
        /// <summary>
        /// Notes left by the customer about the order. May contain both delivery instructions and instructions for preparation.
        /// </summary>
        public string Notes { get; set; }
        /// <summary>
        /// The ID of the payment used for the order.
        /// </summary>
        public int PaymentID { get; set; }
        /// <summary>
        /// The ID of the address to deliver to. Can be null for pickup orders.
        /// </summary>
        public int? AddressID { get; set; }
        public int? CookID { get; set; }
        public int? DriverID { get; set; }
        public string Name { get; set; }
        //TODO Fix Pizzas in Order Model.
        /// <summary>
        /// A Dictionary of the pizzas in the order and their sizes.
        /// </summary>
        public List<PizzaAndSize> Pizzas { get; set; }
        /// <summary>
        /// A dictionary of the sides.
        /// </summary>
        public List<Side> Sides { get; set; }
        /// <summary>
        /// A dictionary of the drinks in the order 
        /// </summary>
        public List<Drink> Drinks { get; set; }
    }
    public class NewOrder
    {
        /// <summary>
        /// The ID of the user who placed the order.
        /// </summary>
        public int? UserID { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// Indicates whether or not the order is a delivery.
        /// </summary>
        public bool IsDelivery { get; set; }
        /// <summary>
        /// Indicates the status of the order. (1: Placed, 2: Preparing, 3: Boxing, 4: Delivering, 5: Complete)
        /// Step 4 will be skipped on pickup orders.
        /// </summary>
        public byte OrderStatus { get; set; }
        /// <summary>
        /// Notes left by the customer about the order. May contain both delivery instructions and instructions for preparation.
        /// </summary>
        public string Notes { get; set; }
        /// <summary>
        /// The ID of the payment used for the order.
        /// </summary>
        public int PaymentID { get; set; }
        /// <summary>
        /// The ID of the address to deliver to. Can be null for pickup orders.
        /// </summary>
        public int? AddressID { get; set; }
        /// <summary>
        /// A Dictionary of the pizza ids in the order and their size ids.
        /// </summary>
        public List<NewPizzaAndSize> PizzaIds { get; set; }
        /// <summary>
        /// A dictionary of the side ids in the order and their size ids.
        /// </summary>
        public List<int> Sides { get; set; }
        /// <summary>
        /// A dictionary of the drink ids in the order and their size ids.
        /// </summary>
        public List<int> Drinks { get; set; }
    }
}
