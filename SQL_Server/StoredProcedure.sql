USE FOODBOOKING;

GO

CREATE PROCEDURE usp_GetAllProduct
AS
BEGIN
    SELECT * FROM Products;
END

GO

CREATE PROCEDURE usp_GetProductById(@ProductId INT)
AS
BEGIN
    SELECT * 
    FROM Products
    WHERE ProductId = @ProductId;
END

GO

CREATE PROCEDURE usp_GetProductByCategory(@CategoryId INT)
AS
BEGIN
    SELECT *
    FROM Products
    WHERE CategoryId = @CategoryId;
END

GO

