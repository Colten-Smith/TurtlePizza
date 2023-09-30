using Capstone.DAO.Interfaces;
using Capstone.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System;
using System.Reflection.Metadata.Ecma335;

namespace Capstone.DAO
{
    public class PaymentSqlDao : IPaymentDao
    {
        private readonly string connectionString;

        public PaymentSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Payment AddNewPaymentToDatabase(NewPayment paymentToAdd)
        {
            int outputID = 0;
            try
            {
                string sql;
                if(paymentToAdd.UserID == 0)
                {
                     sql = "INSERT INTO payment (card_num, exp_date, cvc) " +
                                                    "OUTPUT INSERTED.payment_id " +
                                                    "VALUES (@cardNum, @expDate, @cvc)";
                }
                else
                {
                    sql = "INSERT INTO payment (card_num, exp_date, cvc, user_id) " +
                                                    "OUTPUT INSERTED.payment_id " +
                                                    "VALUES (@cardNum, @expDate, @cvc, @userId)";
                }
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@cardNum", paymentToAdd.CardNum);
                    cmd.Parameters.AddWithValue("@expDate", paymentToAdd.ExpDate);
                    cmd.Parameters.AddWithValue("@cvc", paymentToAdd.CVC);
                    if(paymentToAdd.UserID != 0)
                    {
                        cmd.Parameters.AddWithValue("@userId", paymentToAdd.UserID);
                    }

                    outputID = Convert.ToInt32(cmd.ExecuteScalar());

       
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
                return GetPaymentByPaymentID(outputID);
                    
        }

        public Payment GetPaymentByPaymentID(int id)
        {
            Payment newPayment = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT payment_id, card_num, exp_date, cvc, user_id " +
                                                    "FROM payment WHERE payment_id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        newPayment = GetPaymentFromReader(reader);
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return newPayment;
        }

        public List<Payment> GetPaymentsByUserID(int userId)
        {
            List<Payment> returnPayments = new List<Payment>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT payment_id, card_num, exp_date, cvc, user_id " +
                                                    "FROM payments WHERE user_id = @userId", conn);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Payment payment = GetPaymentFromReader(reader);
                        returnPayments.Add(payment);
                    }

                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return returnPayments;
        }

        public int DeletePaymentByPaymentID(int id)
        {
            int numberOfRows = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("DELETE FROM payments WHERE payment_id = @id", conn);
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

        public int DeleteUserPayments(int userId)
        {
            int numberOfRows = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("DELETE FROM payments WHERE user_id = @userId", conn);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    numberOfRows = cmd.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return numberOfRows;
        }

        public int DeleteAnonymousPayments()
        {
            int numberOfRows = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("DELETE FROM payments WHERE user_id IS NULL", conn);
                    numberOfRows = cmd.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return numberOfRows;
        }

        
        public int DeleteExpiredPayments()
        {
            int numberOfRows = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("DELETE FROM payments WHERE exp_date < @currentDate", conn);
                    cmd.Parameters.AddWithValue("@currentDate", DateTime.Now);
                    numberOfRows = cmd.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return numberOfRows;
        }

        private Payment GetPaymentFromReader(SqlDataReader reader)
        {
            Payment payment = new Payment()
            {
                PaymentID = Convert.ToInt32(reader["payment_id"]),
                CardNum = Convert.ToString(reader["card_num"]),
                ExpDate = Convert.ToDateTime(reader["exp_date"]),
                CVC = Convert.ToInt32(reader["cvc"]),
                UserID = reader["user_id"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["user_id"])
            };

            return payment;
        }
    }
}