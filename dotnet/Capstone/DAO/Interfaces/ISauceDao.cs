using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO.Interfaces
{
    public interface ISauceDao
    {
        //Create
        /// <summary>
        /// Adds a new Sauce to the database using the given data.
        /// </summary>
        /// <param name="sauceToAdd">A NewSauce Object containing the new Data.</param>
        /// <returns> A copy of the new sauce object in the database.</returns>
        public Sauce AddNewSauce(NewSauce sauceToAdd);
        //Retrieve
        /// <summary>
        /// Retrieves the requested Sauce using the given ID.
        /// </summary>
        /// <param name="id">The ID of the Sauce to retrieve.</param>
        /// <returns>The requested Sauce.</returns>
        public Sauce GetSauceByID(int id);
        /// <summary>
        /// Gets all of the sauces in the database.
        /// </summary>
        /// <returns>A List of every sauce.</returns>
        public List<Sauce> GetAllSauces();
        //Update
        /// <summary>
        /// Updates a sauce record in the database to have the given data.
        /// </summary>
        /// <param name="sauceToUpdate">A Sauce object containing the new data and the sauce's ID.</param>
        /// <returns>The Updated Sauce</returns>
        public Sauce UpdateSauce(Sauce sauceToUpdate);
        /// <summary>
        /// Sets the specified sauce to Unavailable.
        /// </summary>
        /// <param name="id">The ID of the sauce to mark.</param>
        /// <returns>The updated sauce.</returns>
        public Sauce SetSauceToUnavailable(int id);
        /// <summary>
        /// Sets the specified sauce to Available.
        /// </summary>
        /// <param name="id">The ID of the sauce to mark.</param>
        /// <returns>The updated sauce.</returns>
        public Sauce SetSauceToAvailable(int id);
        //Delete
        /// <summary>
        /// Deletes the specified sauce from the database.
        /// </summary>
        /// <param name="id">The id of the sauce to delete.</param>
        public int DeleteSauce(int id);
    }
}
