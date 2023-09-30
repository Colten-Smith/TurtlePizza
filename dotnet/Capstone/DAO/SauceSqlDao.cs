using Capstone.DAO.Interfaces;
using Capstone.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;

namespace Capstone.DAO
{
    public class SauceSqlDao : ISauceDao
    {
        private readonly string connectionString;

        public SauceSqlDao(string dbconnectionString)
        {
            connectionString = dbconnectionString;
        }
        public Sauce AddNewSauce(NewSauce sauceToAdd)
        {
            int outputID = 0;
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO sauce (sauce_name, is_available, fdc_id) " +
                                                    "OUTPUT INSERTED.sauce_id VALUES (@sauce_name, @is_available, @fdc_id)", conn);
                    cmd.Parameters.AddWithValue("@sauce_name", sauceToAdd.SauceName);
                    cmd.Parameters.AddWithValue("@is_available", sauceToAdd.IsAvailable);
                    cmd.Parameters.AddWithValue("@fdc_id", sauceToAdd.FDCID);
                    outputID = Convert.ToInt32(cmd.ExecuteScalar());

                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return GetSauceByID(outputID);
        }

        public int DeleteSauce(int id)
        {
            int numberOfRows = 0;
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM sauce WHERE sauce_id = @sauce_id", conn);
                    cmd.Parameters.AddWithValue("@sauce_id", id);
                    numberOfRows = cmd.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return numberOfRows;
        }

        public List<Sauce> GetAllSauces()
        {
            List<Sauce> returnSauces = new List<Sauce>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT sauce_id, sauce_name, is_available, fdc_id " +
                                                    "FROM sauce", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Sauce sauce = MapRowToSauce(reader);
                        returnSauces.Add(sauce);
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return returnSauces;
        }

        public Sauce GetSauceByID(int id)
        {
            Sauce newSauce = null;

            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT sauce_id, sauce_name, is_available, fdc_id FROM sauce " +
                                                    "WHERE sauce_id = @sauce_id",conn);
                    cmd.Parameters.AddWithValue("@sauce_id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        newSauce = MapRowToSauce(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return newSauce;
        }
        private Sauce SetSauceAvailablity(int id, bool isAvailable)
        {
            Sauce updatedSauce = null;
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("UPDATE sauce SET is_available = @is_available WHERE sauce_id = @sauce_id ", conn);
                    cmd.Parameters.AddWithValue("@is_available", isAvailable);
                    cmd.Parameters.AddWithValue("@sauce_id", id);
                    int numberOfRows = cmd.ExecuteNonQuery();
                    if(numberOfRows > 0)
                    {
                        updatedSauce = GetSauceByID(id);
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return updatedSauce;
        }

        public Sauce SetSauceToAvailable(int id)
        {
            return SetSauceAvailablity(id, true);
        }

        public Sauce SetSauceToUnavailable(int id)
        {
            return SetSauceAvailablity(id, false);
        }

        public Sauce UpdateSauce(Sauce sauceToUpdate)
        {
            Sauce updatedSauce = null;
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE sauce SET sauce_name = @sauce_name, fdc_id = @fdc_id ", conn);
                    cmd.Parameters.AddWithValue("@sauce_name", sauceToUpdate.SauceName);
                    cmd.Parameters.AddWithValue("@fdc_id", sauceToUpdate.FDCID);
                    cmd.ExecuteNonQuery();
                }
                updatedSauce = GetSauceByID(sauceToUpdate.SauceID);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return updatedSauce;
        }
        
        private Sauce MapRowToSauce(SqlDataReader reader)
        {
            Sauce sauce = new Sauce();
            sauce.SauceID = Convert.ToInt32(reader["sauce_id"]);
            sauce.SauceName = Convert.ToString(reader["sauce_name"]);
            sauce.IsAvailable = Convert.ToBoolean(reader["is_available"]);
            sauce.FDCID = Convert.ToInt32(reader["fdc_id"]);
            return sauce;
        }
    }
}
