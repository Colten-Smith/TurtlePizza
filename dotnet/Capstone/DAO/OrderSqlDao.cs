using Capstone.DAO.Interfaces;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace Capstone.DAO
{
    public class OrderSqlDao : IOrderDao
    {
        private readonly string connectionString;
        public IPizzaDao PizzaDao;
        public ISideDao SideDao;
        public IDrinkDao DrinkDao;

        public OrderSqlDao(string dbConnectionString, IPizzaDao pizzaDao, ISideDao sideDao, IDrinkDao drinkDao)
        {
            connectionString = dbConnectionString;
            PizzaDao = pizzaDao;
            SideDao = sideDao;
            DrinkDao = drinkDao;
        }
        public Order AddNewOrderToDatabase(NewOrder orderToAdd)
        {
            //NEED TO FIX CUSTOMER FROM NULL TO USER ID UNLESS USER ID = 0
            string sql = "INSERT INTO [order] (user_id, total_price, is_delivery, order_status, cancelled, cook_id, driver_id, " +
                "notes, name, payment_id, address_id) " +
                "OUTPUT INSERTED.order_id " +
                "values(null, @total, @deliver, 1, 0, 1, 1, @notes, @name, @paymentId, @addressId); ";
            Order output = new Order();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@customer", orderToAdd.UserID);
                    cmd.Parameters.AddWithValue("@total", 0);
                    cmd.Parameters.AddWithValue("@deliver", orderToAdd.IsDelivery);
                    cmd.Parameters.AddWithValue("@notes", orderToAdd.Notes);
                    cmd.Parameters.AddWithValue("@name", orderToAdd.Name);
                    cmd.Parameters.AddWithValue("@paymentId", orderToAdd.PaymentID);
                    cmd.Parameters.AddWithValue("@addressId", orderToAdd.AddressID);
                    int orderId = Convert.ToInt32(cmd.ExecuteScalar());
                    if (orderId > 0)
                    {
                        AddPizzasToOrder(orderToAdd, orderId);
                        AddSidesToOrder(orderToAdd, orderId);
                        AddDrinksToOrder(orderToAdd, orderId);
                    }
                    else
                    {
                        throw new Exception("There was an error.");
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return output;
        }
        public void AddPizzasToOrder(NewOrder order, int orderId)
        {
            foreach(NewPizzaAndSize item in order.PizzaIds)
            {
                try
                {
                    string sql = "INSERT INTO order_pizza(order_id, pizza_id, size_id) " +
                        "VALUES(@orderId, @pizzaId, @sizeId)";
                    using(SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@orderId", orderId);
                        cmd.Parameters.AddWithValue("@pizzaId", item.Pizza);
                        cmd.Parameters.AddWithValue("@sizeId", item.Size);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
        public void AddSidesToOrder(NewOrder order, int orderId)
        {
            foreach (int item in order.Drinks)
            {
                try
                {
                    string sql = "INSERT INTO order_drink(order_id, drink_id) " +
                        "VALUES(@orderId, @drinkId)";
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@orderId", orderId);
                        cmd.Parameters.AddWithValue("@drinkId", item);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
        public void AddDrinksToOrder(NewOrder order, int orderId)
        {
            foreach (int item in order.Sides)
            {
                try
                {
                    string sql = "INSERT INTO order_side(order_id, side_id) " +
                        "VALUES(@orderId, @sideId)";
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@orderId", orderId);
                        cmd.Parameters.AddWithValue("@sideId", item);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
        public Order GetOrderById(int id)
        {
            string sql = "SELECT TOP 1 order_id, user_id, total_price, is_delivery, order_status, start_time, delivery_time, " +
                "complete_time, cancelled, cook_id, driver_id, notes, name, payment_id, address_id FROM [order] " +
                "WHERE order_id = @id";
            Order output = new Order();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        output = MapRowToOrder(reader);
                    }
                    else
                    {
                        throw new KeyNotFoundException("Invalid ID, No Order Found.");
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return output;
        }
        public List<Order> GetOrdersByUserID(int userId)
        {
            string sql = "SELECT order_id, user_id, total_price, is_delivery, order_status, start_time, delivery_time, " +
                "complete_time, cancelled, cook_id, driver_id, notes, name, payment_id, address_id FROM [order] " +
                "WHERE user_id = @id";
            List<Order> output = new List<Order>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", userId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        output.Add(MapRowToOrder(reader));
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return output;
        }
        public List<Order> GetCompletedOrders()
        {
            string sql = "SELECT order_id, user_id, total_price, is_delivery, order_status, start_time, delivery_time, " +
                "complete_time, cancelled, cook_id, driver_id, notes, name, payment_id, address_id FROM [order] " +
                "WHERE order_status = 5";
            List<Order> output = new List<Order>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        output.Add(MapRowToOrder(reader));
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return output;
        }
        public List<Order> GetActiveOrders()
        {
            string sql = "SELECT order_id, user_id, total_price, is_delivery, order_status, start_time, delivery_time, " +
                "complete_time, cancelled, cook_id, driver_id, notes, name, payment_id, address_id FROM [order] " +
                "WHERE order_status != 5 AND cancelled = 0";
            List<Order> output = new List<Order>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        output.Add(MapRowToOrder(reader));
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return output;
        }
        public List<Order> GetAllOrders()
        {
            string sql = "SELECT order_id, user_id, total_price, is_delivery, order_status, start_time, delivery_time, " +
                "complete_time, cancelled, cook_id, driver_id, notes, name, payment_id, address_id FROM [order] ";
            List<Order> output = new List<Order>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        output.Add(MapRowToOrder(reader));
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return output;
        }
        public List<Order> GetOrdersCompletedDuringPeriod(DateTime start, DateTime end)
        {
            //TODO Complete GetOrdersCompletedDuringPeriod
            throw new NotImplementedException();
        }
        public Order UpdateOrder(Order orderToUpdate)
        {
            string sql = "UPDATE [order] SET user_id = @user, total_price = @total, is_delivery = @isDelivery, " +
                "order_status = @status, start_time = @ready, delivery_time = @deliveryTime, complete_time = @completeTime, " +
                "cook_id = @cook, driver_id = @driver, notes = @notes, name = @name, " +
                "payment_id = @payment, address_id = @address WHERE order_id = @id";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@user", orderToUpdate.UserID);
                    cmd.Parameters.AddWithValue("@total", orderToUpdate.TotalPrice);
                    cmd.Parameters.AddWithValue("@isDelivery", orderToUpdate.IsDelivery);
                    cmd.Parameters.AddWithValue("@status", orderToUpdate.OrderStatus);
                    cmd.Parameters.AddWithValue("@ready", orderToUpdate.StartTime);
                    cmd.Parameters.AddWithValue("@deliveryTime", orderToUpdate.DeliveryTime);
                    cmd.Parameters.AddWithValue("@completeTime", orderToUpdate.CompleteTime);
                    cmd.Parameters.AddWithValue("@cook", orderToUpdate.CookID);
                    cmd.Parameters.AddWithValue("@driver", orderToUpdate.DriverID);
                    cmd.Parameters.AddWithValue("@notes", orderToUpdate.Notes);
                    cmd.Parameters.AddWithValue("@name", orderToUpdate.Name);
                    cmd.Parameters.AddWithValue("@payment", orderToUpdate.PaymentID);
                    cmd.Parameters.AddWithValue("@address", orderToUpdate.AddressID);
                    cmd.Parameters.AddWithValue("@id", orderToUpdate.OrderID);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        return GetOrderById(orderToUpdate.OrderID);
                    }
                    else
                    {
                        throw new Exception("Something went wrong while updating the order.");
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Order MarkOrderAsComplete(int orderId)
        {
            string sql = "UPDATE [order] SET order_status = 5 WHERE order_id = @id";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", orderId);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        return GetOrderById(orderId);
                    }
                    else
                    {
                        throw new Exception("Something went wrong while updating the order.");
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Order MarkOrderAsOutForDelivery(int orderId)
        {
            string sql = "UPDATE [order] SET order_status = 4 WHERE order_id = @id";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", orderId);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        return GetOrderById(orderId);
                    }
                    else
                    {
                        throw new Exception("Something went wrong while updating the order.");
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Order MarkOrderAsBegun(int orderId)
        {
            string sql = "UPDATE [order] SET order_status = 2 WHERE order_id = @id";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", orderId);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        return GetOrderById(orderId);
                    }
                    else
                    {
                        throw new Exception("Something went wrong while updating the order.");
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Order MarkOrderAsPrepared(int orderId)
        {
            string sql = "UPDATE [order] SET order_status = 3 WHERE order_id = @id";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", orderId);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        return GetOrderById(orderId);
                    }
                    else
                    {
                        throw new Exception("Something went wrong while updating the order.");
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Order CancelOrder(int orderId)
        {
            string sql = "UPDATE [order] SET is_cancelled = 1 WHERE order_id = @id";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", orderId);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        return GetOrderById(orderId);
                    }
                    else
                    {
                        throw new Exception("Something went wrong while updating the order.");
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //Delete
        public int DeleteOrderById(int id)
        {
            string sql = "DELETE FROM [order] WHERE order_id = @id";
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery(); 
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //Helpers
        public Order MapRowToOrder(SqlDataReader reader)
        {
            Order output = new Order();
            output.AddressID = Convert.ToInt32(reader["address_id"]);
            output.CompleteTime = Convert.ToDateTime(reader["complete_time"]);
            output.CookID = Convert.ToInt32(reader["cook_id"]);
            output.DriverID = Convert.ToInt32(reader["driver_id"]);
            output.IsDelivery = Convert.ToBoolean(reader["is_delivery"]);
            output.Name = Convert.ToString(reader["name"]);
            output.Notes = Convert.ToString(reader["notes"]);
            output.OrderID = Convert.ToInt32(reader["order_id"]);
            output.OrderStatus = Convert.ToByte(reader["order_status"]);
            output.PaymentID = Convert.ToInt32(reader["payment_id"]);
            output.Pizzas = PizzaDao.GetPizzasAndSizesByOrderId(output.OrderID);
            output.Sides = SideDao.GetSidesByOrderId(output.OrderID);
            output.Drinks = DrinkDao.GetDrinksByOrderId(output.OrderID);
            output.StartTime = Convert.ToDateTime(reader["start_time"]);
            output.TotalPrice = Convert.ToDecimal(reader["total_price"]);
            output.UserID = Convert.ToInt32(reader["user_id"]);
            return output;
        }
        public decimal CalculateTotalPrice(int id)
        {
            decimal total = new decimal();
            //Get the sum of all Specialty Pizzas
            total += CalculateTotalSpecialtyPrice(id);
            //Get the sum of all Custom Pizza Toppings
            total += CalculateTotalCustomToppingPrice(id);
            //Get the sum of all Extra Toppings
            total += CalculateTotalExtraToppingPrice(id) * (decimal)1.5;
            //Get the sum of all crusts
            total += CalculateTotalCrustPrice(id);
            //Get the sum of all sauces 
            total += CalculateTotalSaucePrice(id);
            //Get the sum of all sides
            total += CalculateTotalSidePrice(id);
            //Get the sum of all drinks
            total += CalculateTotalDrinkPrice(id);
            return total;
            
        }
        public decimal CalculateTotalSpecialtyPrice(int id)
        {
            string sql = "(SELECT sum(price) FROM pizza WHERE is_specialty = 1 AND pizza_id IN " +
                "(SELECT pizza_id FROM order_pizza WHERE order_id = @orderId))";
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@orderId", id);
                    return Convert.ToDecimal(cmd.ExecuteScalar());
                }
            }
            catch(NullReferenceException)
            {
                return 0;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public decimal CalculateTotalCustomToppingPrice(int id)
        {
            string sql = "SELECT sum(price) FROM topping WHERE topping_id IN (SELECT topping_id FROM pizza_topping " +
                "WHERE is_extra = 0 AND pizza_id IN (SELECT pizza_id FROM pizza WHERE is_specialty = 0 AND pizza_id IN " +
                "(SELECT pizza_id FROM order_pizza WHERE order_id = @orderId )))";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@orderId", id);
                    return Convert.ToDecimal(cmd.ExecuteScalar());
                }
            }
            catch (NullReferenceException)
            {
                return 0;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public decimal CalculateTotalExtraToppingPrice(int id)
        {
            string sql = "SELECT sum(price) FROM topping WHERE topping_id IN (SELECT topping_id FROM pizza_topping " +
                "WHERE is_extra = 1 AND pizza_id IN (SELECT pizza_id FROM pizza WHERE is_specialty = 0 AND pizza_id IN " +
                "(SELECT pizza_id FROM order_pizza WHERE order_id = @orderId )))";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@orderId", id);
                    return Convert.ToDecimal(cmd.ExecuteScalar());
                }
            }
            catch (NullReferenceException)
            {
                return 0;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public decimal CalculateTotalCrustPrice(int id)
        {
            string sql = "SELECT sum(price) FROM crust WHERE crust_id IN (SELECT crust_id FROM pizza " +
                "WHERE is_specialty = 0 AND pizza_id IN (SELECT pizza_id from pizza WHERE is_specialty = 0 " +
                "AND pizza_id IN (SELECT pizza_id FROM order_pizza WHERE order_id = @orderId)))";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@orderId", id);
                    return Convert.ToDecimal(cmd.ExecuteScalar());
                }
            }
            catch (NullReferenceException)
            {
                return 0;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public decimal CalculateTotalSaucePrice(int id)
        {
            string sql = "SELECT sum(price) FROM sauce WHERE sauce_id IN (SELECT sauce_id FROM pizza " +
                "WHERE is_specialty = 0 AND pizza_id IN (SELECT pizza_id from pizza WHERE is_specialty = 0 " +
                "AND pizza_id IN (SELECT pizza_id FROM order_pizza WHERE order_id = @orderId)))";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@orderId", id);
                    return Convert.ToDecimal(cmd.ExecuteScalar());
                }
            }
            catch (NullReferenceException)
            {
                return 0;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public decimal CalculateTotalSidePrice(int id)
        {
            string sql = "SELECT sum(price) FROM side WHERE side_id IN (SELECT side_id FROM order_side " +
                "WHERE order_id = @orderId)";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@orderId", id);
                    return Convert.ToDecimal(cmd.ExecuteScalar());
                }
            }
            catch (NullReferenceException)
            {
                return 0;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public decimal CalculateTotalDrinkPrice(int id)
        {
            string sql = "SELECT sum(price) FROM drink WHERE drink_id IN(SELECT drink_id " +
                "FROM order_drink WHERE order_id = @orderId)";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@orderId", id);
                    return Convert.ToDecimal(cmd.ExecuteScalar());
                }
            }
            catch (NullReferenceException)
            {
                return 0;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public decimal UpdateOrderTotal(int id)
        {
            string sql = "UPDATE [order] SET total_price = @total WHERE order_id = @id";
            decimal output = CalculateTotalPrice(id);
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@total", output);
                    cmd.Parameters.AddWithValue("@id", id);
                    if(cmd.ExecuteNonQuery() <= 0)
                    {
                        throw new Exception("Total could not be updated.");
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return output;
        }

    }
}