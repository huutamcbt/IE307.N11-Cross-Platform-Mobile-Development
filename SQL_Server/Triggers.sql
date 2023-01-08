---------------------------------------------------------------------------------------------------------
-- Users Triggers

CREATE TRIGGER dbo.utrg_Users_BeforeInsert
ON dbo.Users
INSTEAD OF INSERT
AS
BEGIN
    IF(EXISTS(SELECT *
    FROM Users INNER JOIN Inserted ON Users.Username = Inserted.Username))
        -- Select the EXISTED_USER checkcode value
        SELECT 5
    ELSE 
    BEGIN
        INSERT Users
            (Username, Password, FirstName, LastName, Telephone, CreatedDate, ModifiedDate, Logo)
        SELECT i.Username, i.Password, i.FirstName, i.LastName, i.Telephone, i.CreatedDate, i.ModifiedDate, i.Logo
        FROM Inserted i;
        -- Select the opposite value of EXISTED_USER checkcode 
        SELECT 200
    END
END  

GO

---------------------------------------------------------------------------------------------------------

CREATE TRIGGER dbo.utrg_Users_BeforeUpdate
ON dbo.Users
INSTEAD OF UPDATE
AS
BEGIN
    -- In case, the trigger update a information of user except password
    IF(EXISTS(SELECT *
    FROM Users u, Inserted i
    WHERE u.UserId = i.UserId AND u.Password = i.Password))
    BEGIN
       
        UPDATE Users 
        SET  FirstName = i.FirstName, LastName = i.LastName, Telephone = i.Telephone, 
        CreatedDate =i.CreatedDate, ModifiedDate = i.ModifiedDate, Logo = i.Logo
        FROM Inserted AS i
        WHERE Users.Username = i.Username
        -- Select the opposite value of EXISTED_USER checkcode 
        SELECT 200
    END
    -- In this case, the trigger update only password
    ELSE
    BEGIN
        UPDATE Users
        SET Password = i.Password
        FROM Inserted AS i
        WHERE Users.UserId = i.UserId
        SELECT 200
    END
END

GO

---------------------------------------------------------------------------------------------------------

