-- Добавление пользователей с ФИО
INSERT INTO Users (Login, Password, Role, FullName) VALUES
('admin', 'admin123', 'Admin', N'Иванов Иван Иванович'),
('manager', 'manager123', 'Manager', N'Петров Петр Петрович'),
('client', 'client123', 'Client', N'Сидорова Анна Сергеевна');

-- Добавление товаров с новыми полями
INSERT INTO Products (Name, Description, Price, Quantity, Category, Manufacturer, Supplier, Unit, Discount, ImagePath) VALUES
(N'Кроссовки Nike Air', N'Легкие и удобные', 7500.00, 10, N'Кроссовки', N'Nike', N'Спортмастер', N'пара', 10.0, NULL),
(N'Ботинки Timberland', N'Водонепроницаемые', 12000.00, 5, N'Ботинки', N'Timberland', N'Zenden', N'пара', 5.0, NULL),
(N'Туфли женские', N'Лакированные', 4500.00, 8, N'Туфли', N'Fabiani', N'Rendez-Vous', N'пара', 20.0, NULL),
(N'Ботинки демисезонные', N'Нет в наличии', 8500.00, 0, N'Ботинки', N'Columbia', N'Спорттовары', N'пара', 0.0, NULL);

-- Добавление заказов
INSERT INTO Orders (UserId, OrderDate, Status) VALUES
(3, '2025-02-01', 'New'),
(3, '2025-02-05', 'Completed');

-- Добавление позиций заказов
INSERT INTO OrderItems (OrderId, ProductId, Quantity, Price) VALUES
(1, 1, 2, 7500.00),
(1, 3, 1, 4500.00),
(2, 2, 1, 12000.00);