USE FOODBOOKING;

GO

---------------------------------------------------------------------------------------------------------
-- Product Stored Procedure

CREATE PROCEDURE usp_GetAllProduct
AS
BEGIN
    SELECT * FROM Products;
END

GO

---------------------------------------------------------------------------------------------------------

CREATE PROCEDURE usp_GetProductById(@ProductId INT)
AS
BEGIN
    SELECT * 
    FROM Products
    WHERE ProductId = @ProductId;
END

GO

---------------------------------------------------------------------------------------------------------

CREATE PROCEDURE usp_GetProductByCategory(@CategoryId INT)
AS
BEGIN
    SELECT *
    FROM Products
    WHERE CategoryId = @CategoryId;
END

GO


---------------------------------------------------------------------------------------------------------

CREATE PROCEDURE usp_UpdateProductById(@ProductId INT, @Name NVARCHAR(30), @Description NVARCHAR(200))
AS
BEGIN
    UPDATE Products
    SET Name = @Name, Description = @Description
    WHERE ProductId = @ProductId;
END

GO

---------------------------------------------------------------------------------------------------------
-- Category Stored Procedure

CREATE PROCEDURE usp_GetAllCategory
AS
BEGIN
    SELECT * FROM ProductCategorys;
END

GO

---------------------------------------------------------------------------------------------------------
-- User Address Stored Procedure

CREATE PROCEDURE usp_AddUserAddress(
    @UserId INT, 
    @Address NVARCHAR(50), 
    @District NVARCHAR(50), 
    @Province NVARCHAR(15), 
    @City NVARCHAR(30), 
    @Country NVARCHAR(15), 
    @Mobile VARCHAR(15))
AS
BEGIN
    INSERT INTO UserAddresss (UserId, Address, District, Province, City, Country, Mobile)
    OUTPUT inserted.AddressId
    VALUES (@UserId, @Address, @District, @Province, @City, @Country, @Mobile)
END

GO

---------------------------------------------------------------------------------------------------------

CREATE PROCEDURE usp_UpdateUserAddress
    @AddressId INT,
    @UserId INT, 
    @Address NVARCHAR(50), 
    @District NVARCHAR(50), 
    @Province NVARCHAR(15), 
    @City NVARCHAR(30), 
    @Country NVARCHAR(15), 
    @Mobile VARCHAR(15)
AS 
BEGIN
    UPDATE UserAddresss
    SET UserId = @UserId, Address = @Address, District = @District, Province = @Province, City = @City, Country = @Country, Mobile = @Mobile
    OUTPUT Inserted.AddressId
    WHERE AddressId = @AddressId;
END

GO

---------------------------------------------------------------------------------------------------------

CREATE PROCEDURE usp_RemoveAddress
    @AddressId INT
AS
BEGIN
    DELETE FROM UserAddresss 
    OUTPUT Deleted.AddressId
    WHERE AddressId = @AddressId;
END

GO

---------------------------------------------------------------------------------------------------------
-- User Stored Procedure

CREATE PROCEDURE usp_GetUSerById
    @UserId INT
AS
BEGIN
    SELECT * 
    FROM Users
    WHERE UserId = @UserId;
END

GO

---------------------------------------------------------------------------------------------------------

CREATE PROCEDURE usp_UpdateUser
    @UserId INT,
    @Username VARCHAR(20), 
    @Password TEXT, 
    @FirstName NVARCHAR(50), 
    @LastName NVARCHAR(20), 
    @Telephone VARCHAR(15), 
    @CreatedDate DATETIME, 
    @ModifiedDate DATETIME, 
    @Logo VARCHAR(100)
AS
BEGIN
    UPDATE Users
    SET Username = @Username, Password = @Password, 
                FirstName = @FirstName, LastName = @LastName, 
                Telephone = @Telephone, CreatedDate = @CreatedDate, 
                ModifiedDate = @ModifiedDate, Logo = @Logo
    OUTPUT Inserted.UserId
    WHERE UserId = @UserId;
END

GO

---------------------------------------------------------------------------------------------------------
-- Review Stored Procedure

CREATE PROCEDURE usp_GetReviewsByProductId
    @ProductId INT
AS 
BEGIN
    SELECT * 
    FROM Reviews
    WHERE ProductId = @ProductId;
END

GO

---------------------------------------------------------------------------------------------------------

CREATE PROCEDURE usp_AddReview
    @ProductId INT,
	@Rating INT,
	@UserId INT,
	@Content NVARCHAR(150),
	@CreatedDate DATETIME,
	@ModifiedDate DATETIME,
	@DeletedDate DATETIME
AS
BEGIN
    INSERT INTO Reviews(ProductId, Rating, UserId, Content, CreatedDate, ModifiedDate, DeletedDate)
    OUTPUT Inserted.ReviewId
    VALUES(@ProductId, @Rating, @UserId, @Content, @CreatedDate, @ModifiedDate, @DeletedDate)
END

GO

---------------------------------------------------------------------------------------------------------

CREATE PROCEDURE usp_UpdateReview
    @ReviewId INT,
    @ProductId INT,
	@Rating INT,
	@UserId INT,
	@Content NVARCHAR(150),
	@CreatedDate DATETIME,
	@ModifiedDate DATETIME,
	@DeletedDate DATETIME
AS 
BEGIN
    UPDATE Reviews
    SET ProductId = @ProductId, Rating = @Rating,
        UserId = @UserId, Content = @Content,
        CreatedDate = @CreatedDate, ModifiedDate = @ModifiedDate,
        DeletedDate = @DeletedDate
    OUTPUT Inserted.ReviewId
    WHERE ReviewId = @ReviewId
END

GO

---------------------------------------------------------------------------------------------------------

CREATE PROCEDURE usp_DeleteReview
    @ReviewId INT
AS
BEGIN
    DELETE FROM Reviews
    OUTPUT Deleted.ReviewId
    WHERE ReviewId = @ReviewId;
END


--EXEC usp_AddUserAddress 1, N'123',N'Hoàng Thế Thiện',N'Đăk Nông',N'Gia Nghĩa', N'V','0123456789';
-- DROP PROCEDURE usp_UpdateProductById;

-- SELECT TOP (1000) [ProductId]
--       ,[Name]
--       ,[Description]
--       ,[CategoryId]
--       ,[Price]
--       ,[DiscountId]
--       ,[CreatedDate]
--       ,[ModifiedDate]
--       ,[DeletedDate]
--       ,[Stock]
--       ,[Image]
--   FROM [FOODBOOKING].[dbo].[Products]


