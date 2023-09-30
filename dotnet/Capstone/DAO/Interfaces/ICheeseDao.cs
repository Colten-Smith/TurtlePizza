using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO.Interfaces
{
    public interface ICheeseDao
    {
        //Create
        /// <summary>
        /// Adds a new Cheese to the database.
        /// </summary>
        /// <param name="cheeseToAdd">The data to add.</param>
        /// <returns>A copy of the new Cheese from the database.</returns>
        public Cheese AddCheeseToDatabase(NewCheese cheeseToAdd);
        //Retrieve
        /// <summary>
        /// Gets the cheese with the specified id from the database.
        /// </summary>
        /// <param name="id">The ID of the cheese to retrieve.</param>
        /// <returns>The requested cheese.</returns>
        public Cheese GetCheeseByID(int id);
        /// <summary>
        /// Gets a list of every cheese in the database.
        /// </summary>
        /// <returns>A list containing the requested cheeses.</returns>
        public List<Cheese> GetAllCheeses();
        //Delete
        public int DeleteCheeseByID(int id);

        /// <summary>
        /// gets all the cheeses for a specific pizza id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Cheese> GetCheeseByPizzaID(int id);
    }
}
