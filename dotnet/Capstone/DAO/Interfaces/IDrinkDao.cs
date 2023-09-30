using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO.Interfaces
{
    public interface IDrinkDao
    {
        //Create
        /// <summary>
        /// Adds a new drink to the database using the given data.
        /// </summary>
        /// <param name="drinkToAdd">The data of the drink to add.</param>
        /// <returns>A copy of the new drink from the database.</returns>
        public Drink AddDrinkToDatabase(NewDrink drinkToAdd);
        //Retrieve
        public List<Drink> GetDrinksByOrderId(int orderId);
        /// <summary>
        /// Gets the drink with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the drink to retrieve.</param>
        /// <returns>The Requested drink.</returns>
        public Drink GetDrinkByID(int id);
        /// <summary>
        /// Gets a list containing every drink in the database.
        /// </summary>
        /// <returns>A list of drinks.</returns>
        public List<Drink> GetAllDrinks();
        //Delete
        /// <summary>
        /// Deletes the drink with the specified ID from the datbase.
        /// </summary>
        /// <param name="id"></param>
        public int DeleteDrinkByID(int id);
        public Drink SetDrinkToAvailable(int id);
        public Drink SetDrinkToUnavailable(int id);
    }
}
