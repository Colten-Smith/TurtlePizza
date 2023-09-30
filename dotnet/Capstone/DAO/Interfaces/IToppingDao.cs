using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO.Interfaces
{
    public interface IToppingDao
    {
        //Create
        /// <summary>
        /// Adds a new topping to the database using the given data.
        /// </summary>
        /// <param name="toppingToAdd">A NewTopping object containing the data to add.</param>
        /// <returns>A copy of the new topping in the database.</returns>
        public Topping AddToppingToDatabase(NewTopping toppingToAdd);
        //Retrieve
        /// <summary>
        /// Retrieves the topping from the database with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the topping to retrieve.</param>
        /// <returns>The specified Topping object.</returns>
        public Topping GetToppingByID(int id);
        /// <summary>
        /// Retrieves a list of every topping in the database. Throws a KeyNotFound exception if no topping is found.
        /// </summary>
        /// <returns>A list of all existing Topping objects.</returns>
        public List<Topping> GetAllToppings();
        //Delete
        /// <summary>
        /// Deletes the topping in the database with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the topping to delete.</param>
        public int DeleteToppingByID(int id);

    }
}
