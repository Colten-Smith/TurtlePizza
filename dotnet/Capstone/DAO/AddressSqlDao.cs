using Capstone.DAO.Interfaces;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.AccessControl;

namespace Capstone.DAO
{
    public class AddressSqlDao : IAddressDao
    {
        private readonly string connectionString;

        public AddressSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Address AddNewAddressToDatabase(NewAddress addressToAdd)
        {
            int outputID = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "";
                    if(addressToAdd.UserID != 0)
                    {
                        sql = "INSERT INTO address (state, city, zip, apt_num, street_address, user_id) " +
                                     "OUTPUT INSERTED.address_id VALUES (@state, @city, @zip, @apt_num, @street_address, @user)";
                    }
                    else
                    {
                        sql = "INSERT INTO address (state, city, zip, apt_num, street_address) " +
                                     "OUTPUT INSERTED.address_id VALUES (@state, @city, @zip, @apt_num, @street_address)";
                    }
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@state", addressToAdd.State.Substring(0, 2));
                    cmd.Parameters.AddWithValue("@city", addressToAdd.City);
                    cmd.Parameters.AddWithValue("@zip", addressToAdd.ZIP);
                    cmd.Parameters.AddWithValue("@apt_num", addressToAdd.AptNum);
                    cmd.Parameters.AddWithValue("@street_address", addressToAdd.StreetAddress);
                    if(addressToAdd.UserID > 0)
                    {
                        cmd.Parameters.AddWithValue("@user", addressToAdd.UserID);
                    }
                    outputID = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            //think we need to add address id to newAddress in the address model for this return 
            //just put user id to fill the spot for now
            return GetAddressByAddressID(outputID);
        }

        public Address GetAddressByAddressID(int id)
        {
            Address newAddress = null;
            string sql = "SELECT address_id, user_id, state, city, zip, apt_num, street_address " +
                         "FROM address WHERE address_id = @address_id";
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@address_id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        newAddress = MapRowToAddress(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return newAddress;
        }

        public List<Address> GetAddressesForUser(int userID)
        {
            List<Address> returnAddresses = new List<Address>();
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT address_id, user_id, state, city, zip, apt_num, street_address " +
                                     "FROM address WHERE user_id = @user_id",conn);
                    cmd.Parameters.AddWithValue("@user_id", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Address address = MapRowToAddress(reader);
                        returnAddresses.Add(address);
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return returnAddresses;
        }

        public int DeleteAddressFromDatabaseByAddressID(int id)
        {
            int numberOfRows = 0;
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("DELETE FROM address WHERE address_id = @address_id ", conn);
                    cmd.Parameters.AddWithValue("@address_id", id);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return numberOfRows;
        }

        public int DeleteAllAddressesForUser(int userID)
        {
            int numberOfRows = 0;
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("DELETE FROM address WHERE user_id = @user_id ",conn);
                    cmd.Parameters.AddWithValue("@user_id", userID);

                    numberOfRows = cmd.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return numberOfRows;
        }
        
        private Address MapRowToAddress(SqlDataReader reader)
        {
            Address address = new Address();
            address.AddressID = Convert.ToInt32(reader["address_id"]);
            if (reader["user_id"].GetType() == typeof(DBNull))
            {
                address.UserID = 0;
            }
            else {
                address.UserID = Convert.ToInt32(reader["user_id"]);
            }
            address.State = Convert.ToString(reader["state"]);
            address.City = Convert.ToString(reader["city"]);
            address.ZIP = Convert.ToInt32(reader["zip"]);
            address.AptNum = Convert.ToInt32(reader["apt_num"]);
            address.StreetAddress = Convert.ToString(reader["street_address"]);
            return address;
        }
    }
    
}
    