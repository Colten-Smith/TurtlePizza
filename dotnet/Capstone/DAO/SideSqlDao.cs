using Capstone.DAO.Interfaces;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capstone.DAO
{
    public class SideSqlDao : ISideDao
    {
        private readonly string connectionString;

        public SideSqlDao(string dbconnectionString)
        {
            connectionString = dbconnectionString;
        }
        public Side AddNewSide(NewSide sideToAdd)
        {
            int outputID = 0;
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO side (side_name, is_available, fdc_id, is_wing) " +
                                                    "OUTPUT INSERTED.side_id VALUES (@side_name, @is_available, @fdc_id, @is_wing", conn);
                    cmd.Parameters.AddWithValue("@side_name", sideToAdd.SideName);
                    cmd.Parameters.AddWithValue("@is_available", sideToAdd.IsAvailable);
                    cmd.Parameters.AddWithValue("@fdc_id", sideToAdd.FDCID);
                    cmd.Parameters.AddWithValue("@is_wing", sideToAdd.Price);
                    outputID = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return GetSideByID(outputID);
        }

        public int DeleteSideByID(int id)
        {
            int numberOfRows = 0;
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM side WHERE side_id = @side_id", conn);
                    cmd.Parameters.AddWithValue("@side_id", id);
                    numberOfRows = cmd.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return numberOfRows;
        }

        public List<Side> GetAllSides(bool isWing)
        {
            List<Side> returnSides = new List<Side>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT side_id, side_name, is_available, fdc_id, is_wing, price " +
                                                    "FROM side WHERE is_wing = @is_wing", conn);
                    cmd.Parameters.AddWithValue("@is_wing", isWing);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Side side = MapRowToSide(reader);
                        returnSides.Add(side);
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return returnSides;
        }

        public Side GetSideByID(int id)
        {
            Side newSide = null;
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT side_id, side_name, is_available, fdc_id, price " +
                                                    "FROM side WHERE side_id = @side_id");
                    cmd.Parameters.AddWithValue("@side_id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        newSide = MapRowToSide(reader);
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return newSide;
        }

        public List<Side> GetSidesByOrderId(int orderId)
        {
            List<Side> returnSides = new List<Side>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT s.side_id, s.side_name, s.is_available, s.fdc_id, s.is_wing, o.order_id from side as s" +
                                                     "join order_side as os on os.side_id = s.side_id" +
                                                     "join [order] as o on os.order_id = o.order_id" +
                                                     "WHERE o.order_id = @order_id", conn);
                    cmd.Parameters.AddWithValue("@order_id", orderId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Side side = MapRowToSide(reader);
                        returnSides.Add(side);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returnSides;
        }
        private Side SetSideAvailability(int id, bool isAvailable)
        {
            Side updatedSide = null;
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("UPDATE side SET is_available = @is_available WHERE side_id = @side_id", conn);
                    cmd.Parameters.AddWithValue("@is_available", isAvailable);
                    cmd.Parameters.AddWithValue("@side_id", id);
                    int numberOfRows = cmd.ExecuteNonQuery();
                    if(numberOfRows > 0)
                    {
                        updatedSide = GetSideByID(id);
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return updatedSide;
        }

        public Side MakeSideAvailable(int id)
        {
            return SetSideAvailability(id, true);
        }

        public Side MakeSideUnavailable(int id)
        {
            return SetSideAvailability(id, false);
        }

        public Side UpdateSide(Side sideToUpdate)
        {
            Side updatedSide = null;
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE side SET side_name = @side_name, fdc_id = @fdc_id, is_wing = @is_wing", conn);
                    cmd.Parameters.AddWithValue("@side_name", sideToUpdate.SideName);
                    cmd.Parameters.AddWithValue("@fdc_id", sideToUpdate.FDCID);
                    cmd.Parameters.AddWithValue("@is_wing", sideToUpdate.IsWing);
                    cmd.ExecuteNonQuery();
                }
                updatedSide = GetSideByID(sideToUpdate.SideID);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return updatedSide;
        }
        private Side MapRowToSide(SqlDataReader reader)
        {
            Side side = new Side();
            side.SideID = Convert.ToInt32(reader["side_id"]);
            side.SideName = Convert.ToString(reader["side_name"]);
            side.IsAvailable = Convert.ToBoolean(reader["is_available"]);
            side.FDCID = Convert.ToInt32(reader["fdc_id"]);
            side.IsWing= Convert.ToBoolean(reader["is_wing"]);
            side.Price = Convert.ToDecimal(reader["price"]);
            return side;
        }
    }
}
