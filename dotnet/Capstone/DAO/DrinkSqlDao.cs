using Capstone.DAO.Interfaces;
using Capstone.Models;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Capstone.DAO
{
    public class DrinkSQLDao : IDrinkDao
    {
        private readonly string connectionString;

        public DrinkSQLDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Drink AddDrinkToDatabase(NewDrink drinkToAdd)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = "INSERT INTO drink (drink_name, fdc_id, price, is_available) " +
                                 "OUTPUT INSERTED.drink_id " +
                                 "VALUES (@name, @fdcId, @price, @isAvailable)";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@name", drinkToAdd.DrinkName);
                    cmd.Parameters.AddWithValue("@fdcId", drinkToAdd.FDCID);
                    cmd.Parameters.AddWithValue("@price", drinkToAdd.Price);
                    cmd.Parameters.AddWithValue("@isAvailable", drinkToAdd.IsAvailable);

                    int newDrinkId = Convert.ToInt32(cmd.ExecuteScalar());

                    Drink newDrink = new Drink
                    {
                        DrinkID = newDrinkId,
                        DrinkName = drinkToAdd.DrinkName,
                        FDCID = drinkToAdd.FDCID,
                        Price = drinkToAdd.Price,
                        IsAvailable = drinkToAdd.IsAvailable
                    };

                    return newDrink;
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public Drink GetDrinkByID(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT drink_id, drink_name, fdc_id, price, is_available FROM drink WHERE drink_id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        return GetDrinkFromReader(reader);
                    }
                    else
                    {
                        throw new KeyNotFoundException($"Drink with ID {id} not found.");
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }
        public List<Drink> GetDrinksByOrderId(int orderId)
        {
            string sql = "SELECT drink_id, drink_name, fdc_id, price, is_available FROM drink " +
                "WHERE drink_id IN (SELECT drink_id FROM order_drink WHERE order_id = @orderId)";
            List<Drink> output = new List<Drink>();
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@orderId", orderId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Drink newDrink = GetDrinkFromReader(reader);
                        output.Add(newDrink);
                    }
                    return output;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<Drink> GetAllDrinks()
        {
            List<Drink> drinks = new List<Drink>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT drink_id, drink_name, fdc_id, price, is_available FROM drink", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Drink drink = GetDrinkFromReader(reader);
                        drinks.Add(drink);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return drinks;
        }
        public int DeleteDrinkByID(int id)
        {
            int numberOfRows = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("DELETE FROM drink WHERE drink_id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    numberOfRows = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return numberOfRows;
        }
        

        
        private Drink SetDrinkAvailability(int id, bool isAvailable)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE drink SET is_available = @isAvailable WHERE drink_id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@isAvailable", isAvailable);
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    return GetDrinkByID(id);
                }
                else
                {
                    throw new KeyNotFoundException($"Drink with ID {id} not found.");
                }
            }
        }
        public Drink SetDrinkToAvailable(int id)
        {
            return SetDrinkAvailability(id, true);
        }

        public Drink SetDrinkToUnavailable(int id)
        {
            return SetDrinkAvailability(id, false);
        }

        private Drink GetDrinkFromReader(SqlDataReader reader)
        {
            Drink drink = new Drink()
            {
                DrinkID = Convert.ToInt32(reader["drink_id"]),
                DrinkName = Convert.ToString(reader["drink_name"]),
                FDCID = Convert.ToInt32(reader["fdc_id"]),
                Price = Convert.ToDecimal(reader["price"]),
                IsAvailable = Convert.ToBoolean(reader["is_available"]),
            };

            return drink;
        }
    }
}