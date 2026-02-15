using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using ShoesStore.Module;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static ShoesStore.Module.Users;

namespace ShoesStore.Data
{
    public class DataContext
    {
        public List<Products> Products { get; set; }
        public List<Users> Users { get; set; }
        public List<Orders> Orders { get; set; }
        static string connectionString = "Server=(localdb)\\mssqllocaldb;Database=master;Trusted_Connection=True;";
        public DataContext()
        {
            // Создаем таблицы при первом запуске
            Task.Run(async () => await InitializeDatabase()).Wait();
        }

        private async Task InitializeDatabase()
        {
            try
            {
                await CreateUsers();
                await CreateProducts();
                await CreateOrders();
                await SeedUsersIfEmpty();
                Console.WriteLine("База данных инициализирована");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка инициализации БД: {ex.Message}");
            }
        }
        static async Task CreateUsers()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string sql = @"
                CREATE TABLE Users (
                    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID() NOT NULL,
                    Username NVARCHAR(100) NOT NULL,
                    Password NVARCHAR(255) NOT NULL,
                    Role NVARCHAR(20) NOT NULL,
                    CreatedDate DATETIME DEFAULT GETDATE() NULL
                )";
                SqlCommand command = new SqlCommand(sql, connection);
                await command.ExecuteNonQueryAsync();
                Console.WriteLine("Таблица Users создана");
            }
        }
        public async Task<List<Users>> GetUsersAsync(List<Users> users)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var command = new SqlCommand("SELECT * FROM Users", connection);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        Guid id = reader.GetGuid(0);
                        string username = reader.GetString(1);
                        string password = reader.GetString(2);
                        Users.RoleType role = (Users.RoleType)Enum.Parse(typeof(Users.RoleType), reader.GetString(3));
                        DateTime createdDate;
                        if (reader.IsDBNull(4))
                            createdDate = DateTime.MinValue;
                        else
                            createdDate = reader.GetDateTime(4);

                        var user = new Users(id, username, password, role, createdDate);
                        users.Add(user);
                    }
                }
            }
            Users = users;
            return users;
        }
        public async Task SaveUserAsync(Users user)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string sql = @"
                    INSERT INTO Users (Id, Username, Password, Role, CreatedDate)
                    VALUES (@Id, @Username, @Password, @Role, @CreatedDate)";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", user.ID);
                    command.Parameters.AddWithValue("@Username", user.UserName);
                    command.Parameters.AddWithValue("@Password", user.Password);
                    command.Parameters.AddWithValue("@Role", user.Role.ToString());
                    command.Parameters.AddWithValue("@CreatedDate", user.CreatedDate);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
        private async Task SeedUsersIfEmpty()
        {
            int count = await GetUserCountAsync();
            if (count == 0)
            {
                var users = new List<Users>
                {
                    new Users("admin", "admin123", RoleType.Admin),
                    new Users("manager", "manager123", RoleType.Manager),
                    new Users("client", "client123", RoleType.Client)
                };

                foreach (var user in users)
                {
                    await SaveUserAsync(user);
                }

                Console.WriteLine("Тестовые пользователи добавлены.");
            }
        }

        private async Task<int> GetUserCountAsync()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string sql = "SELECT COUNT(*) FROM Users";
                using (var command = new SqlCommand(sql, connection))
                {
                    return (int)await command.ExecuteScalarAsync();
                }
            }
        }

        static async Task CreateProducts()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string sql = @"
                CREATE TABLE Products (
                    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID() NOT NULL,
                    Name NVARCHAR(200) NOT NULL,
                    Description NVARCHAR(MAX) NULL,
                    Category NVARCHAR(100) NOT NULL,
                    Price DECIMAL(10,2) NOT NULL,
                    StockQuantity INT DEFAULT 0 NOT NULL,
                    Size INT NULL,
                    Color NVARCHAR(50) NULL,
                    Brand NVARCHAR(100) NULL,
                    CreatedDate DATETIME DEFAULT GETDATE() NULL
                )";
                SqlCommand command = new SqlCommand(sql, connection);
                await command.ExecuteNonQueryAsync();
                Console.WriteLine("Таблица Products создана");
            }
        }

        public async Task<List<Products>> GetProductsAsync(List<Products> products)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var command = new SqlCommand("SELECT * FROM Products", connection);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        Guid id = reader.GetGuid(0);
                        string name = reader.GetString(1);
                        string description = reader.GetString(2);
                        string category = reader.GetString(3);
                        decimal price = reader.GetDecimal(4);
                        int stockQuantity = reader.GetInt32(5);

                        DateTime createdDate = reader.GetDateTime(9);

                        int? size = null;
                        if (!reader.IsDBNull(6))
                            size = reader.GetInt32(6);

                        string color = null;
                        if (!reader.IsDBNull(7))
                            color = reader.GetString(7);

                        string brand = null;
                        if (!reader.IsDBNull(8))
                            brand = reader.GetString(8);

                        var product = new Products(
                            id, name, description, category, price,
                            stockQuantity, createdDate, size, color, brand
                        );

                        products.Add(product);
                    }
                }
            }
            Products = products;
            return products;
        }
        public async Task AddProductAsync(Products product)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string sql = @"
                    INSERT INTO Products (Id, Name, Description, Category, Price, StockQuantity, Size, Color, Brand, CreatedDate)
                    VALUES (@Id, @Name, @Description, @Category, @Price, @StockQuantity, @Size, @Color, @Brand, @CreatedDate)";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", product.ID);
                    command.Parameters.AddWithValue("@Name", product.Name);

                    if (product.Description != null)
                        command.Parameters.AddWithValue("@Description", product.Description);
                    else
                        command.Parameters.AddWithValue("@Description", DBNull.Value);

                    command.Parameters.AddWithValue("@Category", product.Category);
                    command.Parameters.AddWithValue("@Price", product.Price);
                    command.Parameters.AddWithValue("@StockQuantity", product.StockQuantity);

                    if (product.Size.HasValue)
                        command.Parameters.AddWithValue("@Size", product.Size.Value);
                    else
                        command.Parameters.AddWithValue("@Size", DBNull.Value);

                    if (product.Color != null)
                        command.Parameters.AddWithValue("@Color", product.Color);
                    else
                        command.Parameters.AddWithValue("@Color", DBNull.Value);

                    if (product.Brand != null)
                        command.Parameters.AddWithValue("@Brand", product.Brand);
                    else
                        command.Parameters.AddWithValue("@Brand", DBNull.Value);

                    command.Parameters.AddWithValue("@CreatedDate", product.CreatedDate);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateProductAsync(Products product)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string sql = @"
                    UPDATE Products SET
                        Name = @Name,
                        Description = @Description,
                        Category = @Category,
                        Price = @Price,
                        StockQuantity = @StockQuantity,
                        Size = @Size,
                        Color = @Color,
                        Brand = @Brand
                    WHERE Id = @Id";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", product.ID);
                    command.Parameters.AddWithValue("@Name", product.Name);

                    if (product.Description != null)
                        command.Parameters.AddWithValue("@Description", product.Description);
                    else
                        command.Parameters.AddWithValue("@Description", DBNull.Value);

                    command.Parameters.AddWithValue("@Category", product.Category);
                    command.Parameters.AddWithValue("@Price", product.Price);
                    command.Parameters.AddWithValue("@StockQuantity", product.StockQuantity);

                    if (product.Size.HasValue)
                        command.Parameters.AddWithValue("@Size", product.Size.Value);
                    else
                        command.Parameters.AddWithValue("@Size", DBNull.Value);

                    if (product.Color != null)
                        command.Parameters.AddWithValue("@Color", product.Color);
                    else
                        command.Parameters.AddWithValue("@Color", DBNull.Value);

                    if (product.Brand != null)
                        command.Parameters.AddWithValue("@Brand", product.Brand);
                    else
                        command.Parameters.AddWithValue("@Brand", DBNull.Value);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
        public async Task DeleteProductAsync(Guid productId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string deleteOrders = "DELETE FROM Orders WHERE ProductId = @ProductId";
                using (var cmdOrders = new SqlCommand(deleteOrders, connection))
                {
                    cmdOrders.Parameters.AddWithValue("@ProductId", productId);
                    await cmdOrders.ExecuteNonQueryAsync();
                }

                string sql = "DELETE FROM Products WHERE Id = @Id";
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", productId);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
        static async Task CreateOrders()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string sql = @"
                CREATE TABLE Orders (
                    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID() NOT NULL,
                    UserId UNIQUEIDENTIFIER NOT NULL,
                    ProductId UNIQUEIDENTIFIER NOT NULL,
                    Quantity INT DEFAULT 1 NOT NULL,
                    OrderDate DATETIME DEFAULT GETDATE() NOT NULL,
                    Status NVARCHAR(20) DEFAULT 'Pending' NOT NULL,
                    TotalPrice DECIMAL(10,2) NOT NULL,
                    Notes NVARCHAR(500) NULL,
                    ShippingAddress NVARCHAR(500) NULL,
                    Phone NVARCHAR(20) NULL,
                    FOREIGN KEY (UserId) REFERENCES Users(Id),
                    FOREIGN KEY (ProductId) REFERENCES Products(Id)
                )";
                SqlCommand command = new SqlCommand(sql, connection);
                await command.ExecuteNonQueryAsync();
                Console.WriteLine("Таблица Orders создана");
            }
        }

        public async Task<List<Orders>> GetOrdersAsync(List<Orders> orders)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var command = new SqlCommand("SELECT * FROM Orders", connection);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        Guid id = reader.GetGuid(0);
                        Guid userId = reader.GetGuid(1);
                        Guid productId = reader.GetGuid(2);
                        int quantity = reader.GetInt32(3);
                        DateTime orderDate = reader.GetDateTime(4);
                        string status = reader.GetString(5);
                        decimal totalPrice = reader.GetDecimal(6);

                        string notes = null;
                        if (!reader.IsDBNull(7))
                            notes = reader.GetString(7);

                        string shippingAddress = null;
                        if (!reader.IsDBNull(8))
                            shippingAddress = reader.GetString(8);

                        string phone = null;
                        if (!reader.IsDBNull(9))
                            phone = reader.GetString(9);

                        var order = new Orders(id, userId, productId, quantity, orderDate, status, totalPrice, notes, shippingAddress, phone);
                        orders.Add(order);
                    }
                }
            }
            Orders = orders;
            return orders;
        }
        public async Task AddOrderAsync(Orders order)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string sql = @"
                    INSERT INTO Orders (Id, UserId, ProductId, Quantity, OrderDate, Status, TotalPrice, Notes, ShippingAddress, Phone)
                    VALUES (@Id, @UserId, @ProductId, @Quantity, @OrderDate, @Status, @TotalPrice, @Notes, @ShippingAddress, @Phone)";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", order.Id);
                    command.Parameters.AddWithValue("@UserId", order.UserId);
                    command.Parameters.AddWithValue("@ProductId", order.ProductId);
                    command.Parameters.AddWithValue("@Quantity", order.Quantity);
                    command.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                    command.Parameters.AddWithValue("@Status", order.Status);
                    command.Parameters.AddWithValue("@TotalPrice", order.TotalPrice);

                    if (order.Notes != null)
                        command.Parameters.AddWithValue("@Notes", order.Notes);
                    else
                        command.Parameters.AddWithValue("@Notes", DBNull.Value);

                    if (order.ShippingAddress != null)
                        command.Parameters.AddWithValue("@ShippingAddress", order.ShippingAddress);
                    else
                        command.Parameters.AddWithValue("@ShippingAddress", DBNull.Value);

                    if (order.Phone != null)
                        command.Parameters.AddWithValue("@Phone", order.Phone);
                    else
                        command.Parameters.AddWithValue("@Phone", DBNull.Value);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
        public async Task DeleteOrderAsync(Guid orderId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string sql = "DELETE FROM Orders WHERE Id = @Id";
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", orderId);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
        public async Task UpdateOrderStatusAsync(Guid orderId, string newStatus)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string sql = "UPDATE Orders SET Status = @Status WHERE Id = @Id";
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Status", newStatus);
                    command.Parameters.AddWithValue("@Id", orderId);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}