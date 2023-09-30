using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO.Interfaces
{
    public interface ICrustDao
    {
        //Create
        /// <summary>
        /// Adds a new crust type to the database.
        /// </summary>
        /// <param name="crustToAdd">The data to add.</param>
        /// <returns>A copy of the new Crust from the database.</returns>
        public Crust AddCrustToDatabase(NewCrust crustToAdd);
        //Retrieve
        /// <summary>
        /// Gets the crust with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the crust to retrieve.</param>
        /// <returns>The requested Crust.</returns>
        public Crust GetCrustByID(int id);
        /// <summary>
        /// Gets a list of all fo the crust types from the database.
        /// </summary>
        /// <returns>A list of Crusts.</returns>
        public List<Crust> GetAllCrusts();
        //Delete
        /// <summary>
        /// Deletes the Crust with the specified ID from the database.
        /// </summary>
        /// <param name="id">The ID of the crust to delete.</param>
        public int DeleteCrustByID(int id);
    }
}
