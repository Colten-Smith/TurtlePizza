using System.Collections.Generic;

namespace Capstone.Models
{
    public class Pizza
    {
        /// <summary>
        /// The ID associated with the pizza.
        /// </summary>
        public int PizzaID { get; set; }
        public decimal Price { get; set; }
        /// <summary>
        /// The ID associated with the pizza's crust.
        /// </summary>
        public Crust Crust { get; set; }
        /// <summary>
        /// The Name of the pizza.
        /// </summary>
        public string PizzaName { get; set; }
        /// <summary>
        /// The availability of the pizza.
        /// </summary>
        public bool IsAvailable { get; set; }
        /// <summary>
        /// Indicates whether or not the pizza is considered vegetarian.
        /// </summary>
        public bool IsVegetarian { get; set; }
        /// <summary>
        /// Indicates whether or not the pizza is considered gluten free.
        /// </summary>
        public bool IsGlutenFree { get; set; }
        /// <summary>
        /// Represents whether the pizza is considered a specialty option or not.
        /// </summary>
        public bool IsSpecialty { get; set; }
        /// <summary>
        /// The ID associated with the Sauce on the pizza.
        /// </summary>
        public Sauce Sauce { get; set; }
        /// <summary>
        /// A list of the toppings on the pizza and their associated data.
        /// </summary>
        public List<PizzaTopping> Toppings { get; set; }
        /// <summary>
        /// A list of the cheeses on the pizza.
        /// </summary>
        public List<Cheese> Cheeses { get; set; }
    }
    public class NewPizza
    {
        /// <summary>
        /// The ID associated with the pizza's crust.
        /// </summary>
        public int CrustID { get; set; }
        /// <summary>
        /// The Name of the pizza.
        /// </summary>
        public string PizzaName { get; set; }
        /// <summary>
        /// The ID of the user who created the pizza, if there is any.
        /// </summary>
        public int? UserID { get; set; }
        /// <summary>
        /// Represents if the user who created the pizza has it marked as a favorite.
        /// </summary>
        public bool IsFavorited { get; set; }
        /// <summary>
        /// Indicates whether or not the pizza is considered vegetarian.
        /// </summary>
        public bool IsVegetarian { get; set; }
        /// <summary>
        /// Indicates whether or not the pizza is considered gluten free.
        /// </summary>
        public bool IsGlutenFree { get; set; }
        /// <summary>
        /// The ID associated with the 
        /// </summary>
        public int SauceID { get; set; }
        /// <summary>
        /// A list of the toppings on the pizza and their associated data.
        /// </summary>
        public List<NewPizzaTopping> Toppings { get; set; }
        /// <summary>
        /// A list of the cheeses on the pizza.
        /// </summary>
        public List<int> CheeseIDs { get; set; }
    }
}
