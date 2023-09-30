using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Capstone.Models
{
    public class Drink
    {
        /// <summary>
        /// the unique id for the drink
        /// </summary>
        public int DrinkID { get; set; }
        /// <summary>
        /// the name of the drink
        /// </summary>
        public string DrinkName { get; set; }
        /// <summary>
        /// the id of the drink in the usda api 
        /// </summary>
        public int FDCID { get; set; }
        /// <summary>
        /// the price of the drink
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// if the cheese is in stock
        /// </summary>
        public bool IsAvailable { get; set; }
    }
    public class NewDrink
    {
        public string DrinkName { get; set; }
        public int FDCID { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
    }
}
