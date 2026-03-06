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
        public List<Product> Products { get; set; }
        public List<User> Users { get; set; }
        public List<Order> Orders { get; set; }
        public List<OrderItem> OrderItems { get; set; }

        private static readonly string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\777\\Source\\Repos\\ShoesStore3\\ShoesStore\\Database\\ShoesStoreDB.mdf;Integrated Security=True";
        //private static readonly string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Взрослая академия\\source\\repos\\ShoesStore2\\ShoesStore3\\ShoesStore\\Database\\ShoesStoreDB.mdf;Integrated Security=True";
        public User GetUser(string login, string password)
        {
            User user = null;
            string query = "SELECT Id, Login, Password, Role, FullName FROM Users WHERE Login = @Login AND Password = @Password";
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
                            Role = reader.GetString(3),
                        };
                        if (reader.IsDBNull(4))
                            user.FullName = null;
                        else
                            user.FullName = reader.GetString(4);
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
            string query = "SELECT Id, Name, Description, Price, Quantity, Category, Manufacturer, Supplier, Unit, Discount, ImagePath FROM Products";
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

                        if (reader.IsDBNull(2))
                            product.Description = null;
                        else
                            product.Description = reader.GetString(2);

                        product.Price = reader.GetDecimal(3);
                        product.Quantity = reader.GetInt32(4);

                        if (reader.IsDBNull(5))
                            product.Category = null;
                        else
                            product.Category = reader.GetString(5);

                        if (reader.IsDBNull(6))
                            product.Manufacturer = null;
                        else
                            product.Manufacturer = reader.GetString(6);

                        if (reader.IsDBNull(7))
                            product.Supplier = null;
                        else
                            product.Supplier = reader.GetString(7);

                        if (reader.IsDBNull(8))
                            product.Unit = null;
                        else
                            product.Unit = reader.GetString(8);

                        if (reader.IsDBNull(9))
                            product.Discount = 0;
                        else
                            product.Discount = reader.GetDecimal(9);

                        if (reader.IsDBNull(10))
                            product.ImagePath = null;
                        else
                            product.ImagePath = reader.GetString(10);

                        products.Add(product);
                    }
                }
            }
            return products;
        }

        //Получить товары с фильтрацией, поиском и сортировкой
        public List<Product> GetProducts(string categoryFilter, string supplierFilter, string searchText, string sortBy)
        {
            List<Product> products = new List<Product>();
            string query = "SELECT Id, Name, Description, Price, Quantity, Category, Manufacturer, Supplier, Unit, Discount, ImagePath FROM Products WHERE 1=1";

            if (!string.IsNullOrEmpty(categoryFilter))
                query += " AND Category = @Category";
            if (!string.IsNullOrEmpty(supplierFilter))
                query += " AND Supplier = @Supplier";
            if (!string.IsNullOrEmpty(searchText))
                query += " AND (Name LIKE @Search OR Description LIKE @Search OR Manufacturer LIKE @Search OR Supplier LIKE @Search)";

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
                else if (sortBy == "QuantityASC")
                    query += " ORDER BY Quantity ASC";
                else if (sortBy == "QuantityDESC")
                    query += " ORDER BY Quantity DESC";
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
                if (!string.IsNullOrEmpty(supplierFilter))
                    command.Parameters.AddWithValue("@Supplier", supplierFilter);
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

                        if (reader.IsDBNull(2))
                            product.Description = null;
                        else
                            product.Description = reader.GetString(2);

                        product.Price = reader.GetDecimal(3);
                        product.Quantity = reader.GetInt32(4);

                        if (reader.IsDBNull(5))
                            product.Category = null;
                        else
                            product.Category = reader.GetString(5);

                        if (reader.IsDBNull(6))
                            product.Manufacturer = null;
                        else
                            product.Manufacturer = reader.GetString(6);

                        if (reader.IsDBNull(7))
                            product.Supplier = null;
                        else
                            product.Supplier = reader.GetString(7);

                        if (reader.IsDBNull(8))
                            product.Unit = null;
                        else
                            product.Unit = reader.GetString(8);

                        if (reader.IsDBNull(9))
                            product.Discount = 0;
                        else
                            product.Discount = reader.GetDecimal(9);

                        if (reader.IsDBNull(10))
                            product.ImagePath = null;
                        else
                            product.ImagePath = reader.GetString(10);

                        products.Add(product);
                    }
                }
            }
            return products;
        }

        //Добавить новый товар
        public void AddProduct(Product product)
        {
            string query = "INSERT INTO Products (Name, Description, Price, Quantity, Category, Manufacturer, Supplier, Unit, Discount, ImagePath) " +
                "VALUES (@Name, @Description, @Price, @Quantity, @Category, @Manufacturer, @Supplier, @Unit, @Discount, @ImagePath)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", product.Name);
                if (product.Description != null)
                    command.Parameters.AddWithValue("@Description", product.Description);
                else
                    command.Parameters.AddWithValue("@Description", DBNull.Value);

                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@Quantity", product.Quantity);

                if (product.Category != null)
                    command.Parameters.AddWithValue("@Category", product.Category);
                else
                    command.Parameters.AddWithValue("@Category", DBNull.Value);

                if (product.Manufacturer != null)
                    command.Parameters.AddWithValue("@Manufacturer", product.Manufacturer);
                else
                    command.Parameters.AddWithValue("@Manufacturer", DBNull.Value);

                if (product.Supplier != null)
                    command.Parameters.AddWithValue("@Supplier", product.Supplier);
                else
                    command.Parameters.AddWithValue("@Supplier", DBNull.Value);

                if (product.Unit != null)
                    command.Parameters.AddWithValue("@Unit", product.Unit);
                else
                    command.Parameters.AddWithValue("@Unit", DBNull.Value);

                command.Parameters.AddWithValue("@Discount", product.Discount);

                if (product.ImagePath != null)
                    command.Parameters.AddWithValue("@ImagePath", product.ImagePath);
                else
                    command.Parameters.AddWithValue("@ImagePath", DBNull.Value);

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

                if (product.Description != null)
                    command.Parameters.AddWithValue("@Description", product.Description);
                else
                    command.Parameters.AddWithValue("@Description", DBNull.Value);

                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@Quantity", product.Quantity);

                if (product.Category != null)
                    command.Parameters.AddWithValue("@Category", product.Category);
                else
                    command.Parameters.AddWithValue("@Category", DBNull.Value);

                if (product.Manufacturer != null)
                    command.Parameters.AddWithValue("@Manufacturer", product.Manufacturer);
                else
                    command.Parameters.AddWithValue("@Manufacturer", DBNull.Value);

                if (product.Supplier != null)
                    command.Parameters.AddWithValue("@Supplier", product.Supplier);
                else
                    command.Parameters.AddWithValue("@Supplier", DBNull.Value);

                if (product.Unit != null)
                    command.Parameters.AddWithValue("@Unit", product.Unit);
                else
                    command.Parameters.AddWithValue("@Unit", DBNull.Value);

                command.Parameters.AddWithValue("@Discount", product.Discount);

                if (product.ImagePath != null)
                    command.Parameters.AddWithValue("@ImagePath", product.ImagePath);
                else
                    command.Parameters.AddWithValue("@ImagePath", DBNull.Value);

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
            string query = "SELECT Id, UserId, OrderDate, Status, DeliveryAddress, IssueDate FROM Orders WHERE 1=1";
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
                        if (!reader.IsDBNull(4))
                            order.DeliveryAddress = reader.GetString(4);
                        else
                            order.DeliveryAddress = null;

                        if (!reader.IsDBNull(5))
                            order.IssueDate = reader.GetDateTime(5);
                        else
                            order.IssueDate = null;
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
                    //Вставка заказа
                    string orderQuery = "INSERT INTO Orders (UserId, OrderDate, Status, DeliveryAddress, IssueDate) VALUES (@UserId, @OrderDate, @Status, @DeliveryAddress, @IssueDate); SELECT SCOPE_IDENTITY();";
                    SqlCommand orderCmd = new SqlCommand(orderQuery, connection, transaction);
                    orderCmd.Parameters.AddWithValue("@UserId", order.UserId);
                    orderCmd.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                    orderCmd.Parameters.AddWithValue("@Status", order.Status);
                    if (order.DeliveryAddress != null)
                        orderCmd.Parameters.AddWithValue("@DeliveryAddress", order.DeliveryAddress);
                    else
                        orderCmd.Parameters.AddWithValue("@DeliveryAddress", DBNull.Value);

                    if (order.IssueDate != null)
                        orderCmd.Parameters.AddWithValue("@IssueDate", order.IssueDate.Value);
                    else
                        orderCmd.Parameters.AddWithValue("@IssueDate", DBNull.Value);
                    int orderId = Convert.ToInt32(orderCmd.ExecuteScalar());

                    // Вставка позиций и обновление остатков
                    foreach (var item in items)
                    {
                        //Вставка позиций
                        string itemQuery = "INSERT INTO OrderItems (OrderId, ProductId, Quantity, Price) VALUES (@OrderId, @ProductId, @Quantity, @Price)";
                        SqlCommand itemCmd = new SqlCommand(itemQuery, connection, transaction);
                        itemCmd.Parameters.AddWithValue("@OrderId", orderId);
                        itemCmd.Parameters.AddWithValue("@ProductId", item.ProductId);
                        itemCmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                        itemCmd.Parameters.AddWithValue("@Price", item.Price);
                        itemCmd.ExecuteNonQuery();

                        // Уменьшение остатка товара
                        string updateProductQuery = "UPDATE Products SET Quantity = Quantity - @Quantity WHERE Id = @ProductId";
                        SqlCommand updateCmd = new SqlCommand(updateProductQuery, connection, transaction);
                        updateCmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                        updateCmd.Parameters.AddWithValue("@ProductId", item.ProductId);
                        updateCmd.ExecuteNonQuery();
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

        //Обновить заказ
        public void UpdateOrder(Order order)
        {
            string query = @"UPDATE Orders SET UserId = @UserId, OrderDate = @OrderDate, Status = @Status, DeliveryAddress = @DeliveryAddress, IssueDate = @IssueDate WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", order.Id);
                command.Parameters.AddWithValue("@UserId", order.UserId);
                command.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                command.Parameters.AddWithValue("@Status", order.Status);
                if (order.DeliveryAddress != null)
                    command.Parameters.AddWithValue("@DeliveryAddress", order.DeliveryAddress);
                else
                    command.Parameters.AddWithValue("@DeliveryAddress", DBNull.Value);

                if (order.IssueDate != null)
                    command.Parameters.AddWithValue("@IssueDate", order.IssueDate.Value);
                else
                    command.Parameters.AddWithValue("@IssueDate", DBNull.Value);
                connection.Open();
                command.ExecuteNonQuery();
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

        //Получения списка клиентов
        public List<User> GetAllClients()
        {
            List<User> users = new List<User>();
            string query = "SELECT Id, Login, FullName FROM Users WHERE Role = 'Client'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        User user = new User
                        {
                            Id = reader.GetInt32(0),
                            Login = reader.GetString(1),
                        };
                        if (reader.IsDBNull(2))
                            user.FullName = null;
                        else
                            user.FullName = reader.GetString(2);
                        users.Add(user);
                    }
                }
            }
            return users;
        }


        //Удалить заказ
        public void DeleteOrder(int orderId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    // Сначала получим все позиции заказа, чтобы восстановить остатки
                    string selectItemsQuery = "SELECT ProductId, Quantity FROM OrderItems WHERE OrderId = @OrderId";
                    SqlCommand selectCmd = new SqlCommand(selectItemsQuery, connection, transaction);
                    selectCmd.Parameters.AddWithValue("@OrderId", orderId);
                    List<(int productId, int quantity)> items = new List<(int, int)>();
                    using (SqlDataReader reader = selectCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            items.Add((reader.GetInt32(0), reader.GetInt32(1)));
                        }
                    }

                    // Восстанавливаем остатки товаров
                    foreach (var item in items)
                    {
                        string updateProductQuery = "UPDATE Products SET Quantity = Quantity + @Quantity WHERE Id = @ProductId";
                        SqlCommand updateCmd = new SqlCommand(updateProductQuery, connection, transaction);
                        updateCmd.Parameters.AddWithValue("@Quantity", item.quantity);
                        updateCmd.Parameters.AddWithValue("@ProductId", item.productId);
                        updateCmd.ExecuteNonQuery();
                    }

                    // Удаляем заказ (позиции удалятся каскадно)
                    string deleteOrderQuery = "DELETE FROM Orders WHERE Id = @Id";
                    SqlCommand deleteCmd = new SqlCommand(deleteOrderQuery, connection, transaction);
                    deleteCmd.Parameters.AddWithValue("@Id", orderId);
                    deleteCmd.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        //Проверка удаления заказа
        public bool IsProductUsedInOrders(int productId)
        {
            string query = "SELECT COUNT(*) FROM OrderItems WHERE ProductId = @ProductId";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductId", productId);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }
    }
}