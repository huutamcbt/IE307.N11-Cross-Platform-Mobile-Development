USE FOODBOOKING;

GO

---------------------------------------------------------------------------------------------------------

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

CREATE PROCEDURE usp_GetAllCategory
AS
BEGIN
    SELECT * FROM ProductCategorys;
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


