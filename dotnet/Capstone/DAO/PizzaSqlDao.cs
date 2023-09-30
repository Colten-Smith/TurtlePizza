using Capstone.DAO.Interfaces;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace Capstone.DAO
{
    public class PizzaSqlDao : IPizzaDao
    {

        private readonly string connectionString;
        ICrustDao crustDao;
        ISauceDao sauceDao;
        ISizeDao sizeDao;
        public PizzaSqlDao(string dbConnectionString, ICrustDao _crustDao, ISauceDao _sauceDao, ISizeDao _sizeDao)
        {
            sauceDao = _sauceDao;
            connectionString = dbConnectionString;
            crustDao = _crustDao;
            sizeDao = _sizeDao;
        }
        public Pizza AddNewCustomPizzaToDatabase(NewPizza pizzaToAdd)
        {
            string sql = "INSERT INTO pizza(crust_id, pizza_name, user_id, is_favorited, is_available, is_vegetarian, " +
                "is_glutenfree, sauce_id, is_specialty, price) OUTPUT INSERTED.pizza_id " +
                "VALUES(@crust, @name, @user, @favorite, 1, @veg, @gluten, @sauce, 0, 0)";
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@crust", pizzaToAdd.CrustID);
                    cmd.Parameters.AddWithValue("@name", pizzaToAdd.PizzaName);
                    cmd.Parameters.AddWithValue("@user", pizzaToAdd.UserID);
                    if (!(pizzaToAdd.UserID > 0))
                    {
                        cmd.Parameters.AddWithValue("@favorite", false);
                    }
                    else {
                        cmd.Parameters.AddWithValue("@favorite", pizzaToAdd.IsFavorited);
                    }
                    cmd.Parameters.AddWithValue("@veg", pizzaToAdd.IsVegetarian);
                    cmd.Parameters.AddWithValue("@gluten", pizzaToAdd.IsGlutenFree);
                    cmd.Parameters.AddWithValue("@sauce", pizzaToAdd.SauceID);
                    int newId = Convert.ToInt32(cmd.ExecuteScalar());
                    if(newId > 0)
                    {
                        return GetPizzaByPizzaID(newId);
                    }
                    else
                    {
                        throw new Exception("Something went wrong while adding to the database.");
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Pizza AddNewSpecialtyPizzatoDatabase(NewPizza pizzaToAdd, decimal newPrice)
        {
            string sql = "INSERT INTO pizza(crust_id, pizza_name, user_id, is_favorited, is_available, is_vegetarian, " +
                "is_glutenfree, sauce_id, is_specialty, price) OUTPUT INSERTED.pizza_id " +
                "VALUES(@crust, @name, @user, @favorite, 1, @veg, @gluten, @sauce, 1, 0)";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@crust", pizzaToAdd.CrustID);
                    cmd.Parameters.AddWithValue("@name", pizzaToAdd.PizzaName);
                    cmd.Parameters.AddWithValue("@user", pizzaToAdd.UserID);
                    if (!(pizzaToAdd.UserID > 0))
                    {
                        cmd.Parameters.AddWithValue("@favorite", false);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@favorite", pizzaToAdd.IsFavorited);
                    }
                    cmd.Parameters.AddWithValue("@veg", pizzaToAdd.IsVegetarian);
                    cmd.Parameters.AddWithValue("@gluten", pizzaToAdd.IsGlutenFree);
                    cmd.Parameters.AddWithValue("@sauce", pizzaToAdd.SauceID);
                    int newId = Convert.ToInt32(cmd.ExecuteScalar());
                    if (newId > 0)
                    {
                        UpdatePizzaPrice(newId, newPrice);
                        return GetPizzaByPizzaID(newId);
                    }
                    else
                    {
                        throw new Exception("Something went wrong while adding to the database.");
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DeleteAllPizzasNotAssociatedWithUsers()
        {
            string sql = "DELETE FROM pizza_topping WHERE pizza_id IN (SELECT pizza_id from pizza where user_id = null " +
                "AND is_specialty = 0); " +
                "DELETE FROM pizza_cheese WHERE pizza_id IN (SELECT pizza_id from pizza where user_id = null " +
                "AND is_specialty = 0);" +
                "DELETE FROM order_pizza WHERE pizza_id IN (SELECT pizza_id from pizza where user_id = null " +
                "AND is_specialty = 0);" +
                "DELETE FROM pizza WHERE user_id = null AND is_specialty = 0;";
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DeletePizzaByPizzaID(int id)
        {
            string sql = "DELETE FROM pizza_topping WHERE pizza_id = @id; " +
                "DELETE FROM pizza_cheese WHERE pizza_id = @id;" +
                "DELETE FROM order_pizza WHERE pizza_id = @id;" +
                "DELETE FROM pizza WHERE pizza_id = 0";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DeleteUsersPizzas(int userId)
        {
            string subQuery = "(SELECT pizza_id FROM order_pizza WHERE order_id IN (SELECT order_id FROM [order] WHERE user_id = @id))";
            string sql = $"DELETE FROM pizza_topping WHERE pizza_id IN {subQuery}; " +
                $"DELETE FROM pizza_cheese WHERE pizza_id IN {subQuery};" +
                $"DELETE FROM order_pizza WHERE pizza_id IN {subQuery};" +
                $"DELETE FROM pizza WHERE pizza_id IN {subQuery}";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", userId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            };
        }

        public void DeleteUserUnfavoritedPizzas(int userId)
        {
            string subQuery = "(SELECT pizza_id FROM pizza WHERE is_favorited = 0)";
            string sql = $"DELETE FROM pizza_topping WHERE pizza_id IN {subQuery}; " +
                $"DELETE FROM pizza_cheese WHERE pizza_id IN {subQuery};" +
                $"DELETE FROM order_pizza WHERE pizza_id IN {subQuery};" +
                $"DELETE FROM pizza WHERE pizza_id IN {subQuery}";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            };
        }

        public List<Pizza> GetAllSpecialtyPizzas()
        {
            string sql = "SELECT * FROM pizza WHERE is_specialty = 1;";
            List<Pizza> output = new List<Pizza>();
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Pizza newPizza = MapRowToPizza(reader);
                        output.Add(newPizza);
                    }
                    return output;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Pizza GetPizzaByPizzaID(int id)
        {
            string sql = "SELECT * FROM pizza WHERE pizza_id = @id;";
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
                        return MapRowToPizza(reader);
                    }
                    else
                    {
                        throw new KeyNotFoundException("Pizza could not be found.");
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<PizzaAndSize> GetPizzasAndSizesByOrderId(int orderId)
        {
            string sql = "SELECT p.pizza_id, p.crust_id, p.pizza_name, p.is_available, p.is_vegetarian, p.is_glutenfree, " +
                "p.sauce_id, p.is_specialty, p.user_id, p.is_favorited, p.price, s.size_id, " +
                "s.price, s.is_available FROM pizza as p " +
                "JOIN order_pizza AS op ON p.pizza_id = op.pizza_id " +
                "JOIN size AS s ON s.size_id = op.size_id " +
                "WHERE order_id = @orderId";
            List<PizzaAndSize> output = new List<PizzaAndSize>();
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@orderId", orderId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        PizzaAndSize newPizza = new PizzaAndSize();
                        newPizza.Pizza = MapRowToOrderPizza(reader);
                        newPizza.Size = sizeDao.GetSizeByID(Convert.ToInt32(reader["s.size_id"]));
                    }
                    return output;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Pizza> GetUserFavoritePizzas(int userId)
        {
            string sql = "SELECT * FROM pizza WHERE user_id = @userId AND is_favorited = 1";
            List<Pizza> output = new List<Pizza>();
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Pizza newPizza = MapRowToPizza(reader);
                        output.Add(newPizza);
                    }
                    return output;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public Pizza UpdatePizza(Pizza pizzaToUpdate)
        {
            string sql = "UPDATE pizza SET crust_id = @crust, pizza_name = @name, is_available = @available, is_vegetarian = " +
                "@vegetarian, is_glutenfree = @gluten sauce_id = @sauce, is_specialty = @specialty, " +
                "price = @price WHERE pizza_id = @id";
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@crust", pizzaToUpdate.Crust.CrustID);
                    cmd.Parameters.AddWithValue("@name", pizzaToUpdate.PizzaName);
                    cmd.Parameters.AddWithValue("@available", pizzaToUpdate.IsAvailable);
                    cmd.Parameters.AddWithValue("@vegetarian", pizzaToUpdate.IsVegetarian);
                    cmd.Parameters.AddWithValue("@gluten", pizzaToUpdate.IsGlutenFree);
                    cmd.Parameters.AddWithValue("@sauce", pizzaToUpdate.Sauce.SauceID);
                    cmd.Parameters.AddWithValue("@specialty", pizzaToUpdate.IsSpecialty);
                    cmd.Parameters.AddWithValue("@price", pizzaToUpdate.Price);
                    if(cmd.ExecuteNonQuery() > 0)
                    {
                        return GetPizzaByPizzaID(pizzaToUpdate.PizzaID);
                    }
                    else
                    {
                        throw new KeyNotFoundException();
                    }
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public Pizza UpdatePizzaPrice(int PizzaId, decimal NewPrice)
        {
            string sql = "UPDATE pizza SET price = @price WHERE pizza_id = @id";
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@price", NewPrice);
                    cmd.Parameters.AddWithValue("@id", PizzaId);
                    if(cmd.ExecuteNonQuery() > 0)
                    {
                        return GetPizzaByPizzaID(PizzaId);
                    }
                    else
                    {
                        throw new KeyNotFoundException("Pizza could not be found.");
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //Helpers
        //TODO Complete pizza helpers
        public Pizza MapRowToPizza(SqlDataReader reader)
        {
            Pizza output = new Pizza();
            //crust_id, pizza_name, user_id, is_favorited, is_available,
            //is_vegetarian is_glutenfree, sauce_id, is_specialty, price
            output.PizzaID = Convert.ToInt32(reader["pizza_id"]);
            output.Crust = crustDao.GetCrustByID(Convert.ToInt32(reader["crust_id"]));
            output.PizzaName = Convert.ToString(reader["pizza_name"]);
            output.IsAvailable = Convert.ToBoolean(reader["is_available"]);
            output.IsVegetarian = Convert.ToBoolean(reader["is_vegetarian"]);
            output.IsGlutenFree = Convert.ToBoolean(reader["is_glutenfree"]);
            output.Sauce = sauceDao.GetSauceByID(Convert.ToInt32(reader["sauce_id"]));
            output.IsSpecialty = Convert.ToBoolean(reader["is_specialty"]);
            output.Price = Convert.ToDecimal(reader["price"]);
            return output;
        }
        public Pizza MapRowToOrderPizza(SqlDataReader reader)
        {
            Pizza output = new Pizza();

            output.PizzaID = Convert.ToInt32(reader["p.pizza_id"]);
            output.Crust = crustDao.GetCrustByID(Convert.ToInt32(reader["p.crust_id"]));
            output.PizzaName = Convert.ToString(reader["p.pizza_name"]);
            output.IsAvailable = Convert.ToBoolean(reader["p.is_available"]);
            output.IsVegetarian = Convert.ToBoolean(reader["p.is_vegetarian"]);
            output.IsGlutenFree = Convert.ToBoolean(reader["p.is_glutenfree"]);
            output.Sauce = sauceDao.GetSauceByID(Convert.ToInt32(reader["p.sauce_id"]));
            output.IsSpecialty = Convert.ToBoolean(reader["p.is_specialty"]);
            output.Price = Convert.ToDecimal(reader["p.price"]);
            return output;
        }
    }
}