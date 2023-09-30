using Capstone.DAO.Interfaces;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capstone.DAO
{
    public class SizeSqlDao : ISizeDao
    {
        private readonly string connectionString;

        public SizeSqlDao(string dbconnectionString)
        {
            connectionString = dbconnectionString;
        }
        public Size AddNewSize(NewSize sizeToAdd)
        {
            int outputID = 0;
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO size (size_name, is_available, price)" +
                                                    "OUTPUT INSERTED.size_id VALUES (@size_name, @is_available, @price", conn);
                    cmd.Parameters.AddWithValue("@size_name", sizeToAdd.SizeName);
                    cmd.Parameters.AddWithValue("@is_available", sizeToAdd.IsAvailable);
                    cmd.Parameters.AddWithValue("@price", sizeToAdd.Price);
                    outputID = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return GetSizeByID(outputID);
        }

        public List<Size> GetAllSizes()
        {
            List<Size> returnSizes = new List<Size>();
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT size_id, size_name, is_available, price FROM size", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Size size = MapRowToSize(reader);
                        returnSizes.Add(size);
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return returnSizes;
        }

        public Size GetSizeByID(int id)
        {
            Size newSize = null;

            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT size_id, size_name, is_available, price " +
                                                    "FROM size WHERE size_id = @size_id",conn);
                    cmd.Parameters.AddWithValue("@size_id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        newSize = MapRowToSize(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return newSize;
        }
        
        private Size SetSizeAvailablity(int id, bool isAvailable)
        {
            Size updatedSize = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("UPDATE size SET is_available = @is_available WHERE size_id = @size_id", conn);
                    cmd.Parameters.AddWithValue("@size_id", id);
                    cmd.Parameters.AddWithValue("@is_available", isAvailable);
                    int numberOfRows = cmd.ExecuteNonQuery();

                    if(numberOfRows > 0)
                    {
                        updatedSize = GetSizeByID(id);
                    }

                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return updatedSize;
        }
        public Size MakeAvailable(int id)
        {
            return SetSizeAvailablity(id, true);
        }

        public Size MakeUnavailable(int id)
        {
            return SetSizeAvailablity(id, false);
        }

        public Size UpdateSize(Size sizeToUpdate)
        {
            Size updatedSize = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE size SET size_name = @size_name, price = @price", conn);
                    cmd.Parameters.AddWithValue("@size_name", sizeToUpdate.SizeName);
                    cmd.Parameters.AddWithValue("@price", sizeToUpdate.Price);
                    cmd.ExecuteNonQuery();
                }
                updatedSize = GetSizeByID(sizeToUpdate.SizeID);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return updatedSize;
        }

        private Size MapRowToSize(SqlDataReader reader)
        {
            Size size = new Size();
            size.SizeID = Convert.ToInt32(reader["size_id"]);
            size.SizeName = Convert.ToString(reader["size_name"]);
            size.IsAvailable = Convert.ToBoolean(reader["is_available"]);
            size.Price = Convert.ToDecimal(reader["price"]);
            return size;
        }
    }
}
