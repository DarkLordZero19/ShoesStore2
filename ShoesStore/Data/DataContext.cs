using Microsoft.Data.SqlClient;
using ShoesStore.Module;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesStore.Data
{
    public class DataContext
    {
        private static readonly string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\777\\Source\\Repos\\ShoesStore2\\ShoesStore\\Database\\ShoesStoreDB.mdf;Integrated Security=True";

        public User GetUser(string login, string password)
        {
            User user = null;
            string query = "SELECT Id, Login, Password, Role FROM Users WHERE Login = @Login AND Password = @Password";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Login", login);
                command.Parameters.AddWithValue("@Password", password);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new User
                        {
                            Id = reader.GetInt32(0),
                            Login = reader.GetString(1),
                            Password = reader.GetString(2),
                            Role = reader.GetString(3)
                        };
                    }
                }
            }
            return user;
        }

        public void RegisterUser(string login, string password)
        {
            string query = "INSERT INTO Users (Login, Password, Role) VALUES (@Login, @Password, 'Client')";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Login", login);
                command.Parameters.AddWithValue("@Password", password);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        //Получить все товары (без фильтров)
        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            string query = "SELECT Id, Name, Description, Price, Quantity, Category FROM Products";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Product product = new Product();
                        product.Id = reader.GetInt32(0);
                        product.Name = reader.GetString(1);
                        product.Description = reader.IsDBNull(2) ? null : reader.GetString(2);
                        product.Price = reader.GetDecimal(3);
                        product.Quantity = reader.GetInt32(4);
                        product.Category = reader.IsDBNull(5) ? null : reader.GetString(5);
                        products.Add(product);
                    }
                }
            }
            return products;
        }

        //Получить товары с фильтрацией, поиском и сортировкой
        public List<Product> GetProducts(string categoryFilter, string searchText, string sortBy)
        {
            List<Product> products = new List<Product>();
            string query = "SELECT Id, Name, Description, Price, Quantity, Category FROM Products WHERE 1=1";

            if (!string.IsNullOrEmpty(categoryFilter))
                query += " AND Category = @Category";
            if (!string.IsNullOrEmpty(searchText))
                query += " AND (Name LIKE @Search OR Description LIKE @Search)";

            //Безопасная сортировка (только разрешённые варианты)
            if (!string.IsNullOrEmpty(sortBy))
            {
                if (sortBy == "PriceASC")
                    query += " ORDER BY Price ASC";
                else if (sortBy == "PriceDESC")
                    query += " ORDER BY Price DESC";
                else if (sortBy == "NameASC")
                    query += " ORDER BY Name ASC";
                else if (sortBy == "NameDESC")
                    query += " ORDER BY Name DESC";
                else
                    query += " ORDER BY Id";
            }
            else
            {
                query += " ORDER BY Id";
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                if (!string.IsNullOrEmpty(categoryFilter))
                    command.Parameters.AddWithValue("@Category", categoryFilter);
                if (!string.IsNullOrEmpty(searchText))
                    command.Parameters.AddWithValue("@Search", "%" + searchText + "%");

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Product product = new Product();
                        product.Id = reader.GetInt32(0);
                        product.Name = reader.GetString(1);
                        product.Description = reader.IsDBNull(2) ? null : reader.GetString(2);
                        product.Price = reader.GetDecimal(3);
                        product.Quantity = reader.GetInt32(4);
                        product.Category = reader.IsDBNull(5) ? null : reader.GetString(5);
                        products.Add(product);
                    }
                }
            }
            return products;
        }

        //Добавить новый товар
        public void AddProduct(Product product)
        {
            string query = "INSERT INTO Products (Name, Description, Price, Quantity, Category) VALUES (@Name, @Description, @Price, @Quantity, @Category)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@Description", (object)product.Description ?? DBNull.Value);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@Quantity", product.Quantity);
                command.Parameters.AddWithValue("@Category", (object)product.Category ?? DBNull.Value);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        //Обновить данные товара
        public void UpdateProduct(Product product)
        {
            string query = "UPDATE Products SET Name = @Name, Description = @Description, Price = @Price, Quantity = @Quantity, Category = @Category WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", product.Id);
                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@Description", (object)product.Description ?? DBNull.Value);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@Quantity", product.Quantity);
                command.Parameters.AddWithValue("@Category", (object)product.Category ?? DBNull.Value);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        //Удалить товар по ID
        public void DeleteProduct(int productId)
        {
            string query = "DELETE FROM Products WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", productId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        //Получить список заказов с возможностью фильтрации
        public List<Order> GetOrders(int? userId, DateTime? dateFrom, DateTime? dateTo, string status)
        {
            List<Order> orders = new List<Order>();
            string query = "SELECT Id, UserId, OrderDate, Status FROM Orders WHERE 1=1";
            if (userId.HasValue)
                query += " AND UserId = @UserId";
            if (dateFrom.HasValue)
                query += " AND OrderDate >= @DateFrom";
            if (dateTo.HasValue)
                query += " AND OrderDate <= @DateTo";
            if (!string.IsNullOrEmpty(status))
                query += " AND Status = @Status";
            query += " ORDER BY OrderDate DESC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                if (userId.HasValue)
                    command.Parameters.AddWithValue("@UserId", userId.Value);
                if (dateFrom.HasValue)
                    command.Parameters.AddWithValue("@DateFrom", dateFrom.Value);
                if (dateTo.HasValue)
                    command.Parameters.AddWithValue("@DateTo", dateTo.Value);
                if (!string.IsNullOrEmpty(status))
                    command.Parameters.AddWithValue("@Status", status);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Order order = new Order
                        {
                            Id = reader.GetInt32(0),
                            UserId = reader.GetInt32(1),
                            OrderDate = reader.GetDateTime(2),
                            Status = reader.GetString(3)
                        };
                        orders.Add(order);
                    }
                }
            }
            return orders;
        }

        //Получить все позиции конкретного заказа
        public List<OrderItem> GetOrderItems(int orderId)
        {
            List<OrderItem> items = new List<OrderItem>();
            string query = "SELECT Id, OrderId, ProductId, Quantity, Price FROM OrderItems WHERE OrderId = @OrderId";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@OrderId", orderId);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        OrderItem item = new OrderItem
                        {
                            Id = reader.GetInt32(0),
                            OrderId = reader.GetInt32(1),
                            ProductId = reader.GetInt32(2),
                            Quantity = reader.GetInt32(3),
                            Price = reader.GetDecimal(4)
                        };
                        items.Add(item);
                    }
                }
            }
            return items;
        }

        //Добавить новый заказ вместе с позициями
        public void AddOrder(Order order, List<OrderItem> items)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    // Вставка заказа
                    string orderQuery = "INSERT INTO Orders (UserId, OrderDate, Status) VALUES (@UserId, @OrderDate, @Status); SELECT SCOPE_IDENTITY();";
                    SqlCommand orderCmd = new SqlCommand(orderQuery, connection, transaction);
                    orderCmd.Parameters.AddWithValue("@UserId", order.UserId);
                    orderCmd.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                    orderCmd.Parameters.AddWithValue("@Status", order.Status);
                    int orderId = Convert.ToInt32(orderCmd.ExecuteScalar());

                    // Вставка позиций
                    foreach (var item in items)
                    {
                        string itemQuery = "INSERT INTO OrderItems (OrderId, ProductId, Quantity, Price) VALUES (@OrderId, @ProductId, @Quantity, @Price)";
                        SqlCommand itemCmd = new SqlCommand(itemQuery, connection, transaction);
                        itemCmd.Parameters.AddWithValue("@OrderId", orderId);
                        itemCmd.Parameters.AddWithValue("@ProductId", item.ProductId);
                        itemCmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                        itemCmd.Parameters.AddWithValue("@Price", item.Price);
                        itemCmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        //Обновить статус заказа
        public void UpdateOrderStatus(int orderId, string newStatus)
        {
            string query = "UPDATE Orders SET Status = @Status WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", orderId);
                command.Parameters.AddWithValue("@Status", newStatus);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        //Удалить заказ
        public void DeleteOrder(int orderId)
        {
            string query = "DELETE FROM Orders WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", orderId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}