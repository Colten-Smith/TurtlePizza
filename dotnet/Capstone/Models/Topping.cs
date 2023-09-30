using System;

namespace Capstone.Models
{
    public class Topping
    {
        /// <summary>
        /// The ID of the topping.
        /// </summary>
        public int ToppingID { get; set; }
        /// <summary>
        /// The name of the Topping.
        /// </summary>
        public string ToppingName { get;  set; }
        /// <summary>
        /// The FoodData Central ID of the topping.
        /// </summary>
        public int FDCID { get;  set; }
        /// <summary>
        /// The price of the topping.
        /// </summary>
        public decimal Price { get;  set; }
        /// <summary>
        /// Signifies whether or not the topping is available.
        /// </summary>
        public bool IsAvailable { get;  set; }
    }
    public class NewTopping
    {
        /// <summary>
        /// The name of the Topping.
        /// </summary>
        public string ToppingName { get; set; }
        /// <summary>
        /// The FoodData Central ID of the topping.
        /// </summary>
        public int FDCID { get; set; }
        /// <summary>
        /// The price of the topping.
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Signifies whether or not the topping is available.
        /// </summary>
        public bool IsAvailable { get; set; }
    }
}
