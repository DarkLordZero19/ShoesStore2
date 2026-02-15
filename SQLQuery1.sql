CREATE TABLE [dbo].[Users] (
    [Id]          UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Username]    NVARCHAR (100)   NOT NULL,
    [Password]    NVARCHAR (255)   NOT NULL,
    [Role]        NVARCHAR (20)    NOT NULL,
    [CreatedDate] DATETIME         DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([Username] ASC),
    CHECK ([Role]='Admin' OR [Role]='Manager' OR [Role]='Client')
);

CREATE TABLE [dbo].[Products] (
    [Id]            UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Name]          NVARCHAR (200)   NOT NULL,
    [Description]   NVARCHAR (MAX)   NULL,
    [Category]      NVARCHAR (100)   NOT NULL,
    [Price]         DECIMAL (10, 2)  NOT NULL,
    [StockQuantity] INT              DEFAULT ((0)) NOT NULL,
    [Size]          INT              NULL,
    [Color]         NVARCHAR (50)    NULL,
    [Brand]         NVARCHAR (100)   NULL,
    [CreatedDate]   DATETIME         DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CHECK ([Price]>=(0)),
    CHECK ([StockQuantity]>=(0))
);

CREATE TABLE [dbo].[Orders] (
    [Id]              UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [UserId]          UNIQUEIDENTIFIER NOT NULL,
    [ProductId]       UNIQUEIDENTIFIER NOT NULL,
    [Quantity]        INT              DEFAULT ((1)) NOT NULL,
    [OrderDate]       DATETIME         DEFAULT (getdate()) NOT NULL,
    [Status]          NVARCHAR (20)    DEFAULT ('Pending') NOT NULL,
    [TotalPrice]      DECIMAL (10, 2)  NOT NULL,
    [Notes]           NVARCHAR (500)   NULL,
    [ShippingAddress] NVARCHAR (500)   NULL,
    [Phone]           NVARCHAR (20)    NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]),
    FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id]),
    CHECK ([Quantity]>(0)),
    CHECK ([Status]='Cancelled' OR [Status]='Delivered' OR [Status]='Shipped' OR [Status]='Processing' OR [Status]='Pending'),
    CHECK ([TotalPrice]>=(0))
);