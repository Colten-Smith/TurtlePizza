using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO.Interfaces
{
    public interface IPizzaDao
    {
        //Create
        /// <summary>
        /// Adds a new non-specialty pizza to the database using the input data.
        /// </summary>
        /// <param name="pizzaToAdd">A NewPizza Object containing the data to add.</param>
        /// <returns>A copy of the new Pizza from the database.</returns>
        public Pizza AddNewCustomPizzaToDatabase(NewPizza pizzaToAdd);
        /// <summary>
        /// Adds a new Specialty pizza to the database using the input data.
        /// </summary>
        /// <param name="pizzaToAdd">A NewPizza Object containing the data to add.</param>
        /// <returns>A copy of the new Pizza from the database.</returns>
        public Pizza AddNewSpecialtyPizzatoDatabase(NewPizza pizzaToAdd, decimal newPrice);
        //Retrieve
        public List<PizzaAndSize> GetPizzasAndSizesByOrderId(int orderId);
        /// <summary>
        /// Gets the pizza from the database with a matching Pizza ID. Throws a KeyNotFoundException if no pizza is found.
        /// </summary>
        /// <param name="id">The ID to search for.</param>
        /// <returns>A Pizza object with the retrieved data.</returns>
        public Pizza GetPizzaByPizzaID(int id);
        /// <summary>
        /// Gets every pizza marked as "Specialty" in the database.
        /// </summary>
        /// <returns>A List of Specialty Pizzas.</returns>
        public List<Pizza> GetAllSpecialtyPizzas();
        /// <summary>
        /// Gets every pizza associated with a specific user from the database that is marked as "Favorite".
        /// </summary>
        /// <param name="userId">The ID of the user to search for.</param>
        /// <returns>A List of Favorite Pizzas.</returns>
        public List<Pizza> GetUserFavoritePizzas(int userId);
        //Update
        /// <summary>
        /// Updates a pizza record in the database using the input data. Use the input data's ID to find which pizza to update.
        /// </summary>
        /// <param name="pizzaToUpdate">The Pizza to update and it's updated data.</param>
        /// <returns>The Updated Pizza object from the database. Uses GetPizzaByPizzaID.</returns>
        public Pizza UpdatePizza(Pizza pizzaToUpdate);
        public Pizza UpdatePizzaPrice(int PizzaId, decimal NewPrice);
        //Delete
        /// <summary>
        /// Deletes the pizza record from the database with the matching Pizza ID.
        /// </summary>
        /// <param name="id">The ID of the pizza to delete.</param>
        public void DeletePizzaByPizzaID(int id);
        /// <summary>
        /// Deletes all pizzas associated with the specified user.
        /// </summary>
        /// <param name="userId">The ID of the user associated with the deleted pizzas.</param>
        public void DeleteUsersPizzas(int userId);
        /// <summary>
        /// Deletes all pizzas for a user that have a favorited status of 0.
        /// </summary>
        /// <param name="userId">The ID of the user who's pizzas are being deleted.</param>
        public void DeleteUserUnfavoritedPizzas(int userId);
        /// <summary>
        /// Deletes all pizzas in the database with a null user id.
        /// </summary>
        public void DeleteAllPizzasNotAssociatedWithUsers();
    }
}
