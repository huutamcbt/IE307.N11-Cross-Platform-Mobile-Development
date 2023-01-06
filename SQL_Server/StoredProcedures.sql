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
CREATE PROCEDURE usp_AddUser
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
    INSERT INTO Users(Username, Password, FirstName, LastName, Telephone, CreatedDate, ModifiedDate, Logo)
    VALUES(@Username, @Password, @FirstName, @LastName, @Telephone, @CreatedDate, @ModifiedDate, @Logo)

END

GO
--drop PROCEDURE usp_AddUser;
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

GO

---------------------------------------------------------------------------------------------------------
-- CartItem Stored Procedure

CREATE PROCEDURE usp_AddCartItem
	@SessionId int,
	@ProductId int,
	@Quantity int,
	@CreatedDate DateTime,
	@ModifiedDate DateTime
AS
BEGIN
    INSERT INTO CartItems(SessionId, ProductId, Quantity, CreatedDate, ModifiedDate)
    OUTPUT Inserted.CartItemId
    VALUES(@SessionId, @ProductId, @Quantity, @CreatedDate, @ModifiedDate)
END

GO

---------------------------------------------------------------------------------------------------------

CREATE PROCEDURE usp_GetCartItemBySessionId
    @SessionId INT
AS
BEGIN
    SELECT *
    FROM CartItems 
    WHERE SessionId = @SessionId; 
END

GO

---------------------------------------------------------------------------------------------------------

CREATE PROCEDURE usp_UpdateCartItem
    @CartItemId INT,
	@SessionId INT,
	@ProductId INT,
	@Quantity INT,
	@CreatedDate DATETIME,
	@ModifiedDate DATETIME
AS
BEGIN
    UPDATE CartItems
    SET SessionId = @SessionId, ProductId = @ProductId, Quantity = @Quantity, CreatedDate = @CreatedDate, ModifiedDate = @ModifiedDate
    OUTPUT Inserted.CartItemId
    WHERE CartItemId = @CartItemId;
END

GO

---------------------------------------------------------------------------------------------------------

CREATE PROCEDURE usp_DeleteCartItem
    @SessionId INT,
	@ProductId INT
AS
BEGIN
    DELETE FROM  CartItems
    OUTPUT Deleted.CartItemId
    WHERE SessionId = @SessionId AND ProductId = @ProductId;
END





