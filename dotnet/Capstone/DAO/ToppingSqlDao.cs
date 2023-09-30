using Capstone.DAO.Interfaces;
using Capstone.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System;
using System.Data;

namespace Capstone.DAO
{
    public class ToppingSqlDao : IToppingDao
    {
        private readonly string connectionString;

        public ToppingSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Topping AddToppingToDatabase(NewTopping toppingToAdd)
        {
            int outputID = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO topping (topping_name, fdc_id, price, is_available) " +
                                                    "OUTPUT INSERTED.topping_id " +
                                                    "VALUES (@toppingName, @fdcId, @price, @isAvailable)", conn);
                    cmd.Parameters.AddWithValue("@toppingName", toppingToAdd.ToppingName);
                    cmd.Parameters.AddWithValue("@fdcId", toppingToAdd.FDCID);
                    cmd.Parameters.AddWithValue("@price", toppingToAdd.Price);
                    cmd.Parameters.AddWithValue("@isAvailable", toppingToAdd.IsAvailable);

                    outputID = Convert.ToInt32(cmd.ExecuteScalar());

                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return GetToppingByID(outputID);
        }

        public Topping GetToppingByID(int id)
        {
            Topping newTopping = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT topping_id, topping_name, fdc_id, price, is_available " +
                                                    "FROM topping WHERE topping_id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        newTopping = GetToppingFromReader(reader);
                    }
 
                }
            }
            catch(KeyNotFoundException ex)
            {
                throw ex;
            }
            return newTopping;
        }

        public List<Topping> GetAllToppings()
        {
            List<Topping> returnToppings = new List<Topping>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT topping_id, topping_name, fdc_id, price, is_available " +
                                                    "FROM topping", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Topping topping = GetToppingFromReader(reader);
                        returnToppings.Add(topping);
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return returnToppings;
        }

        public int DeleteToppingByID(int id)
        {
            int numberOfRows = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("DELETE FROM topping WHERE topping_id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    numberOfRows = cmd.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return numberOfRows;
        }

        private Topping GetToppingFromReader(SqlDataReader reader)
        {
            Topping topping = new Topping()
            {
                ToppingID = Convert.ToInt32(reader["topping_id"]),
                ToppingName = Convert.ToString(reader["topping_name"]),
                FDCID = Convert.ToInt32(reader["fdc_id"]),
                Price = Convert.ToDecimal(reader["price"]),
                IsAvailable = Convert.ToBoolean(reader["is_available"]),
            };

            return topping;
        }
    }
}