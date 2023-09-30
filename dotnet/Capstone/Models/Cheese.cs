using System.Security.Policy;
using System.Threading;

namespace Capstone.Models
{
    public class Cheese
    {
        /// <summary>
        /// The ID of the Cheese
        /// </summary>
        public int CheeseID { get; set; }
        /// <summary>
        /// The name or type of cheese
        /// </summary>
        public string CheeseName { get; set; }
        /// <summary>
        /// the id for the cheese in the usda api to get nutrition information
        /// </summary>
        public int FDCID { get; set; }
        /// <summary>
        /// to show if the cheese is in stock 
        /// </summary>
        public bool IsAvailable { get; set; }
        public decimal Price { get; set; }
    }
    public class NewCheese
    {

        public string CheeseName { get; set; }
        public int FDCID { get; set; }
        public bool IsAvailable { get; set; }
        public decimal Price { get; set; }
    }
}
