using Capstone.DAO.Interfaces;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capstone.DAO
{
    public class CheeseSqlDao : ICheeseDao
    {
        private readonly string connectionString;

        public CheeseSqlDao(string connString)
        {
            connectionString = connString;
        }
        public Cheese AddCheeseToDatabase(NewCheese cheeseToAdd)
        {
            int outputID = 0;
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO cheese (cheese_name, fdc_id, is_available, price)" +
                        "OUTPUT INSERTED.cheese_id VALUES (@cheese_name, @fdc_id, @is_available, @price)", conn);
                    cmd.Parameters.AddWithValue("@cheese_name", cheeseToAdd.CheeseName);
                    cmd.Parameters.AddWithValue("@fdc_id", cheeseToAdd.FDCID);
                    cmd.Parameters.AddWithValue("@is_available", cheeseToAdd.IsAvailable);
                    cmd.Parameters.AddWithValue("@price", cheeseToAdd.Price);
                    outputID = Convert.ToInt32(cmd.ExecuteScalar());

                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
            //same thing as address
            return GetCheeseByID(outputID);
        }

        public int DeleteCheeseByID(int id)
        {
            int numberOfRows = 0;

            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("DELETE FROM cheese WHERE cheese_id = @cheese_id", conn);
                    cmd.Parameters.AddWithValue("@cheese_id", id);
                    numberOfRows = cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return numberOfRows;
        }

        public List<Cheese> GetAllCheeses()
        {
            List<Cheese> returnCheeses = new List<Cheese>();
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT cheese_id, cheese_name, fdc_id, is_available, price FROM cheese", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Cheese cheese = MapRowToCheese(reader);
                        returnCheeses.Add(cheese);
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return returnCheeses;
        }

        public Cheese GetCheeseByID(int id)
        {
            Cheese cheese = null;

            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT cheese_id, cheese_name, fdc_id, is_available, price FROM cheese WHERE cheese_id = @cheese_id", conn);
                    cmd.Parameters.AddWithValue("@cheese_id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        cheese = MapRowToCheese(reader);
                    }
                    else
                    {
                        throw new KeyNotFoundException("Cheese Could Not Be Found");
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return cheese;
        }

        public List<Cheese> GetCheeseByPizzaID(int id)
        {
            List<Cheese> returnCheeses = new List<Cheese>();

            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT c.cheese_id, cheese_name, fdc_id, c.price, c.is_available, p.pizza_id FROM cheese as c" +
                        "join pizza_cheese as pc on c.cheese_id = pc.cheese_id" +
                        "join pizza as p on p.pizza_id = pc.pizza_id" +
                        "WHERE p.pizza_id = @pizza_id", conn);
                    cmd.Parameters.AddWithValue("@pizza_id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Cheese cheese = MapRowToCheese(reader);
                        returnCheeses.Add(cheese);
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return returnCheeses;
        }

        private Cheese MapRowToCheese(SqlDataReader reader)
        {
            Cheese cheese = new Cheese();
            cheese.CheeseID = Convert.ToInt32(reader["cheese_id"]);
            cheese.CheeseName = Convert.ToString(reader["cheese_name"]);
            cheese.FDCID = Convert.ToInt32(reader["fdc_id"]);
            cheese.IsAvailable = Convert.ToBoolean(reader["is_available"]);
            cheese.Price = Convert.ToDecimal(reader["price"]);
            return cheese;
        }
    }
}
