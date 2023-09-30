using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO.Interfaces
{
    public interface IAddressDao
    {
        //Create
        /// <summary>
        /// Adds a new Address to the database using the inputted NewAddress Object.
        /// </summary>
        /// <param name="addressToAdd">The NewAddress Object containing the data to add.</param>
        /// <returns>A copy of the new Address Object in the database.</returns>
        public Address AddNewAddressToDatabase(NewAddress addressToAdd);
        //Retrieve
        /// <summary>
        /// Gets the address with the matching ID from the database. Throws a KeyNotFound exception if no matching item is found.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>An Address Object.</returns>
        public Address GetAddressByAddressID(int id);
        /// <summary>
        /// Gets all addresses from the database that have the inputted User ID.
        /// </summary>
        /// <param name="userID">The User ID to search for.</param>
        /// <returns>A List of Address Objects.</returns>
        public List<Address> GetAddressesForUser(int userID);

        //Delete
        /// <summary>
        /// Deletes the specified Address from the database using the inputted address ID.
        /// </summary>
        /// <param name="id">The ID of the Address to delete.</param>
        public int DeleteAddressFromDatabaseByAddressID(int id);
        /// <summary>
        /// Deletes every Address in the database that shares the specified user ID.
        /// </summary>
        /// <param name="userID">The user ID associated with the addresses to delete.</param>
        public int DeleteAllAddressesForUser(int userID);
    }
}
