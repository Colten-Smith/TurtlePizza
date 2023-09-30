using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO.Interfaces
{
    public interface IPaymentDao
    {
        //Create
        /// <summary>
        /// Adds a new record of payment information to the database.
        /// </summary>
        /// <param name="paymentToAdd">A NewPayment object containing the data to add to the database.</param>
        /// <returns>A Payment Object copy of the new payment record from the database.</returns>
        public Payment AddNewPaymentToDatabase(NewPayment paymentToAdd);
        //Retrieve
        /// <summary>
        /// Gets the payment record from the database with the matching Payment ID. Throws a KeyNotFound exception if none is found.
        /// </summary>
        /// <param name="id">The ID of the record to retrieve.</param>
        /// <returns>A Payment Object containing the requested payment information.</returns>
        public Payment GetPaymentByPaymentID(int id);
        /// <summary>
        /// Gets all payment info records from the database associated with a specified User ID.
        /// </summary>
        /// <param name="userId">The User ID to search for in the database.</param>
        /// <returns>A List of Payment Objects containing the requested data.</returns>
        public List<Payment> GetPaymentsByUserID(int userId);
        //Delete
        /// <summary>
        /// Deletes the payment in the database with the specified Payment ID.
        /// </summary>
        /// <param name="id">The ID of the Payment Record to delete.</param>
        public int DeletePaymentByPaymentID(int id);
        /// <summary>
        /// Deletes all records of Payment Info associated with a specified user from the database.
        /// </summary>
        /// <param name="userId">The ID of the specified User.</param>
        public int DeleteUserPayments(int userId);
        /// <summary>
        /// Deletes all payment info records in the database that aren't associated with any User IDs.
        /// </summary>
        public int DeleteAnonymousPayments();

        //OPTIONAL
        /// <summary>
        /// Deletes all Payment Info records in the database that have an expiration date that has already passed.
        /// </summary>
        public int DeleteExpiredPayments();
    }
}
