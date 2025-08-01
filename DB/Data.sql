﻿USE FUMiniLongChauSystem;
GO

-- CATEGORIES
INSERT INTO Categories (Name, Description) VALUES
(N'Thuốc cảm, sốt', N'Dùng để hạ sốt và giảm đau do cảm lạnh.'),
(N'Thuốc tiêu hóa', N'Giúp tiêu hóa tốt, chống đầy hơi.'),
(N'Thuốc ho & viêm họng', N'Chống ho, dịu cổ họng.'),
(N'Thuốc dị ứng', N'Chống dị ứng, viêm mũi.'),
(N'Vitamin & Khoáng chất', N'Tăng cường sức đề kháng.');

-- PRODUCTS
INSERT INTO Products (Name, Description, Price, Stock, ImageUrl, IsPrescriptionRequired, CategoryId)
VALUES 
(N'Paracetamol 500mg', N'Hạ sốt, giảm đau nhẹ.', 20000, 150, 'Assets/Paracetamol.jpg', 0, 1),
(N'Efferalgan 500mg', N'Hạ sốt, viên sủi dễ uống.', 25000, 100, 'Assets/Efferalgan.jpg', 0, 1),
(N'Gastropulgite', N'Thuốc dạ dày, chống axit.', 30000, 50, 'Assets/Gastropulgite.jpg', 0, 2),
(N'Vitamin C 500mg', N'Tăng cường miễn dịch.', 15000, 200, 'Assets/VitaminC.jpg', 0, 5),
(N'Loratadin 10mg', N'Thuốc dị ứng, viêm mũi.', 18000, 80, 'Assets/Loratadin.jpg', 0, 4),

-- 👈 THÊM MỚI
(N'Tiffy 500mg', N'Trị cảm cúm, sốt, sổ mũi.', 18000, 120, 'Assets/Tiffy.jpg', 0, 1),
(N'Panadol Extra', N'Hạ sốt, giảm đau nhanh.', 22000, 140, 'Assets/Panadol.jpg', 0, 1),
(N'Omeprazol 20mg', N'Giảm tiết axit dạ dày.', 25000, 90, 'Assets/Omeprazol.jpg', 0, 2),
(N'Smecta', N'Diệt khuẩn và chống tiêu chảy.', 27000, 75, 'Assets/Smecta.jpg', 0, 2),
(N'Dextromethorphan', N'Thuốc ho, long đờm.', 21000, 100, 'Assets/Dextro.jpg', 0, 3),
(N'Terpin Codein', N'Thuốc ho khan.', 24000, 60, 'Assets/Terpin.jpg', 0, 3),
(N'Cetirizin', N'Thuốc dị ứng, mẩn ngứa.', 19000, 70, 'Assets/Cetirizin.jpg', 0, 4),
(N'Vitamin D3 Baby', N'Hỗ trợ phát triển xương trẻ nhỏ.', 28000, 50, 'Assets/VitaminD3.jpg', 0, 5),
(N'Calcium Corbiere', N'Bổ sung canxi.', 32000, 85, 'Assets/Calcium.jpg', 0, 5);

-- USERS
INSERT INTO Users (FullName, Email, PasswordHash, Phone, Role)
VALUES
(N'Admin', 'admin@FUMiniTikiSystem.com', '123', '0900000001', 'Admin'),
(N'Nguyễn Hữu Mỹ', 'mexnguyen894@gmail.com', '123', '0979298904', 'Customer');

-- ORDERS
INSERT INTO Orders (UserId, OrderDate, TotalAmount, Status, ShippingAddress)
VALUES
(2, GETDATE(), 63000, 'Pending', N'123 Đường ABC, Q1, TP.HCM');

-- ORDER DETAILS
INSERT INTO OrderDetails (OrderId, ProductId, Quantity, Price)
VALUES
(1, 1, 2, 20000), -- Paracetamol
(1, 4, 1, 15000); -- Vitamin C

-- CART ITEMS
INSERT INTO CartItems (UserId, ProductId, Quantity)
VALUES
(2, 2, 1), -- Efferalgan
(2, 3, 2); -- Gastropulgite

-- REVIEWS
INSERT INTO Reviews (UserId, ProductId, Rating, Comment)
VALUES
(2, 1, 5, N'Thuốc tốt, hạ sốt nhanh.'),
(2, 4, 4, N'Vitamin uống ngon, dễ uống.');

-- PAYMENTS
INSERT INTO Payments (OrderId, PaymentDate, PaymentType, PaymentStatus)
VALUES
(1, GETDATE(), 'COD', 'Paid');
