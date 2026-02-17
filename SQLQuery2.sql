-- Добавление пользователей (пароли: admin123, manager123, client123)
INSERT INTO Users (Login, Password, Role) VALUES
('admin', 'admin123', 'Admin'),
('manager', 'manager123', 'Manager'),
('client', 'client123', 'Client');

-- Добавление товаров
INSERT INTO Products (Name, Description, Price, Quantity, Category) VALUES
(N'Кроссовки Nike Air', N'Легкие и удобные', 7500.00, 10, N'Кроссовки'),
(N'Ботинки Timberland', N'Водонепроницаемые', 12000.00, 5, N'Ботинки'),
(N'Туфли женские', N'Лакированные', 4500.00, 8, N'Туфли');

-- Добавление заказов
INSERT INTO Orders (UserId, OrderDate, Status) VALUES
(3, '2025-02-01', 'New'),
(3, '2025-02-05', 'Completed');

-- Добавление позиций заказов
INSERT INTO OrderItems (OrderId, ProductId, Quantity, Price) VALUES
(1, 1, 2, 7500.00),
(1, 3, 1, 4500.00),
(2, 2, 1, 12000.00);
