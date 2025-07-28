CREATE DATABASE FUMiniLongChauSystem;
GO

USE FUMiniLongChauSystem;
GO

-- 1. Category
CREATE TABLE Categories (
    CategoryId INT IDENTITY PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255)
);

-- 2. Product
CREATE TABLE Products (
    ProductId INT IDENTITY PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(500),
    Price DECIMAL(18,2) NOT NULL,
    Stock INT NOT NULL,
    ImageUrl NVARCHAR(255), 
    IsPrescriptionRequired BIT NOT NULL DEFAULT 0,
    CategoryId INT FOREIGN KEY REFERENCES Categories(CategoryId)
);

-- 3. Users
CREATE TABLE Users (
    UserId INT IDENTITY PRIMARY KEY,
    FullName NVARCHAR(100),
    Email NVARCHAR(100) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    Phone NVARCHAR(20),
    Role NVARCHAR(20) NOT NULL -- 'Customer' or 'Admin'
);

-- 4. Orders
CREATE TABLE Orders (
    OrderId INT IDENTITY PRIMARY KEY,
    UserId INT FOREIGN KEY REFERENCES Users(UserId),
    OrderDate DATETIME NOT NULL DEFAULT GETDATE(),
    TotalAmount DECIMAL(18,2) NOT NULL,
    Status NVARCHAR(20) NOT NULL, -- 'Pending', 'Shipping', 'Completed', 'Canceled'
    ShippingAddress NVARCHAR(255) NOT NULL
);

-- 5. OrderDetails
CREATE TABLE OrderDetails (
    OrderDetailId INT IDENTITY PRIMARY KEY,
    OrderId INT FOREIGN KEY REFERENCES Orders(OrderId),
    ProductId INT FOREIGN KEY REFERENCES Products(ProductId),
    Quantity INT NOT NULL,
    Price DECIMAL(18,2) NOT NULL
);

-- 6. CartItems
CREATE TABLE CartItems (
    CartItemId INT IDENTITY PRIMARY KEY,
    UserId INT FOREIGN KEY REFERENCES Users(UserId),
    ProductId INT FOREIGN KEY REFERENCES Products(ProductId),
    Quantity INT NOT NULL
);

-- 7. Reviews (tùy chọn)
CREATE TABLE Reviews (
    ReviewId INT IDENTITY PRIMARY KEY,
    UserId INT FOREIGN KEY REFERENCES Users(UserId),
    ProductId INT FOREIGN KEY REFERENCES Products(ProductId),
    Rating INT CHECK (Rating >= 1 AND Rating <= 5),
    Comment NVARCHAR(500)
);

CREATE TABLE Payments (
    PaymentId INT IDENTITY PRIMARY KEY,
    OrderId INT NOT NULL FOREIGN KEY REFERENCES Orders(OrderId),
    PaymentDate DATETIME NOT NULL DEFAULT GETDATE(),
    PaymentType NVARCHAR(50) NOT NULL,       -- Ví dụ: 'COD', 'Momo', 'VNPay', 'CreditCard'
    PaymentStatus NVARCHAR(20) NOT NULL      -- Ví dụ: 'Pending', 'Paid', 'Failed'
);

