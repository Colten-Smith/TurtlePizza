using Capstone.DAO.Interfaces;
using Capstone.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capstone.DAO
{
    public class CrustSqlDao : ICrustDao
    {
        private readonly string connectionString;

        public CrustSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
        public Crust AddCrustToDatabase(NewCrust crustToAdd)
        {
            int outputID = 0;
            try
            {
                using ( SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO crust(crust_name, fdc_id, is_available, price)" +
                                                    "OUTPUT INSERTED.crust_id VALUES (@crust_name, @fdc_id, @is_available, @price)", conn);
                    cmd.Parameters.AddWithValue("@crust_name", crustToAdd.CrustName);
                    cmd.Parameters.AddWithValue("@fdc_id", crustToAdd.FDCID);
                    cmd.Parameters.AddWithValue("@is_available", crustToAdd.IsAvailable);
                    cmd.Parameters.AddWithValue("@price", crustToAdd.Price);
                    outputID = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch(SqlException ex)
            {
                throw new KeyNotFoundException("Could not add new crust", ex);
            }
            //same as address
            return GetCrustByID(outputID);
        }

        public int DeleteCrustByID(int id)
        {
            int numberOfRows = 0;

            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("DELETE FROM crust WHERE crust_id = @crust_id");
                    cmd.Parameters.AddWithValue("@crust_id", id);

                    cmd.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return numberOfRows;
        }

        public List<Crust> GetAllCrusts()
        {
            List<Crust> returnCrusts = new List<Crust>();

            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT crust_id, crust_name, fdc_id, is_available, price FROM crust", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Crust crust = MapRowToCrust(reader);
                        returnCrusts.Add(crust);
                    }
                }
            }
            catch(SqlException ex)
            {
                throw new Exception("Could not retrieve crusts", ex);
            }
            return returnCrusts;
        }

        public Crust GetCrustByID(int id)
        {
            Crust newCrust = null;
            
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT crust_id, crust_name, fdc_id, is_available, price FROM crust " +
                                                    "WHERE crust_id = @crust_id",conn);
                    cmd.Parameters.AddWithValue("@crust_id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        newCrust = MapRowToCrust(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new KeyNotFoundException("Could not find crust", ex);
            }
            return newCrust;
        }

        private Crust MapRowToCrust(SqlDataReader reader)
        {
            Crust crust = new Crust();
            crust.CrustID = Convert.ToInt32(reader["crust_id"]);
            crust.CrustName = Convert.ToString(reader["crust_name"]);
            crust.FDCID = Convert.ToInt32(reader["fdc_id"]);
            crust.IsAvailable = Convert.ToBoolean(reader["is_available"]);
            crust.Price = Convert.ToDecimal(reader["price"]);
            return crust;
        }
    }
}
