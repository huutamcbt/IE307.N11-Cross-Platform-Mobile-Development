---------------------------------------------------------------------------------------------------------
-- Users Triggers

CREATE TRIGGER dbo.utrg_Users_BI
ON dbo.Users
INSTEAD OF INSERT
AS
BEGIN
    IF(EXISTS(SELECT * FROM Users INNER JOIN Inserted ON Users.Username = Inserted.Username))
        -- Select the EXISTED_USER checkcode value
        SELECT 5
    ELSE 
    BEGIN
        INSERT Users(Username, Password, FirstName, LastName, Telephone, CreatedDate, ModifiedDate, Logo)
        SELECT i.Username, i.Password, i.FirstName, i.LastName, i.Telephone, i.CreatedDate, i.ModifiedDate, i.Logo
        FROM Inserted i;
        -- Select the opposite value of EXISTED_USER checkcode 
        SELECT -5
    END
END  

GO

---------------------------------------------------------------------------------------------------------

CREATE TRIGGER dbo.utrg_Users_BU
ON dbo.Users
INSTEAD OF UPDATE
AS
BEGIN
    IF(EXISTS(SELECT * FROM Users INNER JOIN  Inserted ON Users.Username = Inserted.Username))
        -- Select the EXISTED_USER checkcode value
        SELECT 5
    ELSE
    BEGIN
        UPDATE Users
        SET Username = i.Username, Password = i.Password, FirstName = i.FirstName, LastName = i.LastName, Telephone = i.Telephone, 
        CreatedDate =i.CreatedDate, ModifiedDate = i.ModifiedDate, Logo = i.Logo
        FROM Inserted i;
        -- Select the opposite value of EXISTED_USER checkcode 
        SELECT -5
    END
END

GO

---------------------------------------------------------------------------------------------------------
