-- Create database FOODBOOKING;

-- use master;
-- drop database FOODBOOKING;

-- use FOODBOOKING;

-- DROP TABLE OrderItems;
-- DROP TABLE OrderDetails;
-- DROP TABLE CartItems;
-- DROP TABLE PaymentDetails;
-- DROP TABLE UserPayments;
-- DROP TABLE UserAddresss;
-- DROP TABLE Blogs;
-- DROP TABLE Reviews;
-- DROP TABLE Products;
-- DROP TABLE Discounts;
-- DROP TABLE ProductCategorys;
-- DROP TABLE ShoppingSessions;
-- DROP TABLE Users;




----- Create Table -----


create table FOODBOOKING.dbo.Discounts
(
	DiscountId int not null identity(1,1),
	Name varchar(30),
	Description NVARCHAR(100),
	DiscountPercent decimal,
	Active bit,
	CreatedDate DateTime,
	ModifiedDate DateTime,
	DeletedDate DateTime
);

create table FOODBOOKING.dbo.ProductCategorys
(
	CategoryId int not null identity(1,1),
	Name nvarchar(30),
	Description NVARCHAR(100),
	Image varchar(100),
	CreatedDate DateTime,
	ModifiedDate DateTime,
	DeletedDate DateTime
);

CREATE TABLE FOODBOOKING.dbo.Products
(
	ProductId INT NOT NULL IDENTITY(1,1),
	Name nvarchar(30) NOT NULL,
	Description NVARCHAR(200) NOT NULL,
	CategoryId int,
	Price float,
	DiscountId int,
	CreatedDate DateTime,
	ModifiedDate DateTime,
	DeletedDate DateTime,
	Stock int,
	Image varchar(200)
);

create table FOODBOOKING.dbo.OrderItems
(
	OrderItemId INT NOT NULL IDENTITY(1,1),
	OrderId INT NOT NULL,
	ProductId INT,
	Quantity INT,
	CreatedDate DATETIME,
	ModifiedDate DATETIME
);

create table FOODBOOKING.dbo.OrderDetails
(
	OrderId INT NOT NULL IDENTITY(1,1),
	--PaymentId INT,
	AddressId INT,
	UserId INT,
	Total FLOAT,
	CreatedDate DATETIME,
	ModifiedDate DATETIME
);

create table FOODBOOKING.dbo.CartItems
(
	CartItemId INT NOT NULL IDENTITY(1,1),
	SessionId INT,
	ProductId INT,
	Quantity INT,
	CreatedDate DATETIME,
	ModifiedDate DATETIME,
);

create table FOODBOOKING.dbo.Reviews
(
	ReviewId INT NOT NULL IDENTITY(1,1),
	ProductId INT,
	Rating INT,
	UserId INT,
	Content NVARCHAR(150),
	CreatedDate DATETIME,
	ModifiedDate DATETIME,
	DeletedDate DATETIME,
);


create table FOODBOOKING.dbo.ShoppingSessions
(
	SessionId INT NOT NULL IDENTITY(1,1),
	UserId INT,
	Total FLOAT,
	CreatedDate DATETIME,
	ModifiedDate DATETIME
);

create table FOODBOOKING.dbo.PaymentDetails
(
	PaymentId int not null identity(1,1),
	OrderId int,
	Amount float,
	Provider varchar(100),
	Status varchar(10),
	CreatedDate DateTime,
	ModifiedDate DateTime
);

create table FOODBOOKING.dbo.Users
(
	UserId INT not null identity(1,1),
	Username VARCHAR(20),
	Password VARCHAR(50),
	FirstName NVARCHAR(50),
	LastName NVARCHAR(20),
	Telephone VARCHAR(15),
	CreatedDate DATETIME,
	ModifiedDate DATETIME,
	Logo VARCHAR(100)
);

create table FOODBOOKING.dbo.UserPayments
(
	UserPaymentId int not null identity(1,1),
	UserId int,
	PaymentType varchar(10),
	Provider varchar(20),
	AccountNo varchar(20),
	Expiry DateTime
);

create table FOODBOOKING.dbo.UserAddresss
(
	AddressId int not null identity(1,1),
	UserId int,
	Address nvarchar(50),
	District nvarchar(50),
	Province nvarchar(15),
	City nvarchar(30),
	Country nvarchar(15),
	Mobile varchar(15)
);

create table FOODBOOKING.dbo.Blogs
(
	BlogId int not null identity(1,1),
	Title nvarchar(30),
	Content nvarchar(900),
	CreatedDate DateTime,
	ModifiedDate DateTime,
	DeletedDate DateTime
);

----- Add constraint -----

alter table Discounts add constraint PK_Discount primary key (DiscountId);
alter table ProductCategorys add constraint PK_ProductCategory primary key (CategoryId);
alter table Products add constraint PK_Product primary key (ProductId);
alter table OrderItems add constraint PK_OrderItem primary key (OrderItemId);
alter table OrderDetails add constraint PK_OrderDetail primary key (OrderId);
alter table CartItems add constraint PK_CartItem primary key (CartItemId);
alter table Reviews add constraint PK_Review primary key (ReviewId);
alter table ShoppingSessions add constraint PK_ShoppingSession primary key (SessionId);
alter table PaymentDetails add constraint PK_PaymentDetail primary key (PaymentId);
alter table Users add constraint  PK_User primary key (UserId);
alter table UserPayments add constraint PK_UserPayment primary key (UserPaymentId);
alter table UserAddresss add constraint PK_UserAddress primary key (AddressId);


alter table Products add constraint FK_ProductCategory_Product foreign key (CategoryId) references ProductCategorys(CategoryId);
alter table Products add constraint FK_Discount_Product foreign key (DiscountId) references Discounts(DiscountId);
alter table OrderItems add constraint FK_Product_OrderItem foreign key (ProductId) references Products(ProductId);
alter table OrderItems add constraint FK_OrderDetail_OrderItem foreign key (OrderId) references OrderDetails(OrderId);
--alter table OrderDetails add constraint FK_PaymentDetail_OrderDetail foreign key (PaymentId) references PaymentDetails(PaymentId);
alter table OrderDetails add constraint FK_User_OrderDetail foreign key (UserId) references Users(UserId);
alter table CartItems add constraint FK_Product_CartItem foreign key (ProductId) references Products(ProductId);
alter table CartItems add constraint FK_ShoppingSession_CartItem foreign key (SessionId) references ShoppingSessions(SessionId);
alter table Reviews add constraint FK_Product_Review foreign key (ProductId) references Products(ProductId);
alter table Reviews add constraint FK_User_Review foreign key (UserId) references Users(UserId);
alter table ShoppingSessions add constraint FK_User_ShoppingSession foreign key(UserId) references Users(UserId);
alter table UserPayments add constraint FK_User_UserPayment foreign key (UserId) references Users(UserId);
alter table UserAddresss add constraint FK_User_UserAddress foreign key(UserId) references Users(UserId);
alter table Blogs add constraint PK_Blog primary key (BlogId);

----- Insert Data -----



insert into ProductCategorys
	(Name, Description,Image, CreatedDate, ModifiedDate, DeletedDate)
values(N'Đồ nước', 'Description 1', 'icon_noodle.png', '', '', '');
insert into ProductCategorys
	(Name, Description,Image, CreatedDate, ModifiedDate, DeletedDate)
values(N'Cơm', 'Description 2', 'icon_rice.png', '', '', '');
insert into ProductCategorys
	(Name, Description,Image, CreatedDate, ModifiedDate, DeletedDate)
values(N'Đồ uống', 'Description 3', 'icon_drink.png', '', '', '');
insert into ProductCategorys
	(Name, Description,Image, CreatedDate, ModifiedDate, DeletedDate)
values(N'Đồ ăn vặt', 'Description 4', 'icon_snack.png', '', '', '');



insert into Discounts
	(Name, Description, DiscountPercent, Active, CreatedDate, ModifiedDate, DeletedDate)
values
	(N'Name 1', 'Description 1', 10, 1, '', '', '');
insert into Discounts
	(Name, Description, DiscountPercent, Active, CreatedDate, ModifiedDate, DeletedDate)
values
	(N'Name 2', 'Description 2', 10, 1, '', '', '');
insert into Discounts
	(Name, Description, DiscountPercent, Active, CreatedDate, ModifiedDate, DeletedDate)
values
	(N'Name 3', 'Description 3', 10, 1, '', '', '');
insert into Discounts
	(Name, Description, DiscountPercent, Active, CreatedDate, ModifiedDate, DeletedDate)
values
	(N'Name 4', 'Description 4', 10, 1, '', '', '');
insert into Discounts
	(Name, Description, DiscountPercent, Active, CreatedDate, ModifiedDate, DeletedDate)
values
	(N'Name 5', 'Description 5', 10, 1, '', '', '');


-- SET IDENTITY_INSERT Users ON;

Insert into Products
	(Name,Description,CategoryId,Price,DiscountId,CreatedDate,ModifiedDate,DeletedDate,Stock,Image)
values(N'Bún Bò Huế', N'Món ăn nước mang đậm hương vị truyền thống', 1, 30000, 1, '', '', '', 99, 'https://firebasestorage.googleapis.com/v0/b/elegant-skein-350903.appspot.com/o/Food%2FBun_bo_hue.jpg?alt=media&token=f8f49341-0907-48a5-913f-0e9248535cf2');
Insert into Products
	(Name,Description,CategoryId,Price,DiscountId,CreatedDate,ModifiedDate,DeletedDate,Stock,Image)
values(N'Bánh mì trứng', N'Bánh mì với nguyên liệu hoàn toàn từ nhà làm', 5, 15000, 1, '', '', '', 99, 'https://firebasestorage.googleapis.com/v0/b/elegant-skein-350903.appspot.com/o/Bread%2Fbanhmitrung.jpg?alt=media&token=69aaf1c1-ed26-4c4c-b395-3a951aa2d105');
Insert into Products
	(Name,Description,CategoryId,Price,DiscountId,CreatedDate,ModifiedDate,DeletedDate,Stock,Image)
values(N'Bánh mì thịt', N'Bánh mì với nguyên liệu hoàn toàn từ nhà làm', 5, 15000, 1, '', '', '', 99, 'https://firebasestorage.googleapis.com/v0/b/elegant-skein-350903.appspot.com/o/Bread%2Fbanhmithit.jpg?alt=media&token=6981704e-3284-4f20-a8f5-ac307e1a00e0');
Insert into Products
	(Name,Description,CategoryId,Price,DiscountId,CreatedDate,ModifiedDate,DeletedDate,Stock,Image)
values(N'Bún chả các Nha Trang', N'Bún chả cá Nha trang được chế biến, nêm nếm chuẩn vị', 1, 35000, 1, '', '', '', 99, 'https://firebasestorage.googleapis.com/v0/b/elegant-skein-350903.appspot.com/o/Food%2FBun_cha_ca_Nha_Trang.jpeg?alt=media&token=683d78a5-de7b-4c77-aead-e0ba7be8e89d');
Insert into Products
	(Name,Description,CategoryId,Price,DiscountId,CreatedDate,ModifiedDate,DeletedDate,Stock,Image)
values(N'Hủ tiếu nam vang', N'Món hủ tiếu nam vang ngon lành, nóng hổi', 1, 29000, 1, '', '', '', 99, 'https://firebasestorage.googleapis.com/v0/b/elegant-skein-350903.appspot.com/o/Food%2FHu_tieu_Nam_Vang.jpg?alt=media&token=e751bf7c-e177-460e-93c4-2dc70cd1f9c2');
Insert into Products
	(Name,Description,CategoryId,Price,DiscountId,CreatedDate,ModifiedDate,DeletedDate,Stock,Image)
values(N'Phở bò', N'Phở bò với nước dùng ngon tuyệt', 1, 29000, 1, '', '', '', 99, 'https://firebasestorage.googleapis.com/v0/b/elegant-skein-350903.appspot.com/o/Food%2FPho_bo.jpg?alt=media&token=3dfb1a60-71fd-4bed-8f96-e2b19123152d');
Insert into Products
	(Name,Description,CategoryId,Price,DiscountId,CreatedDate,ModifiedDate,DeletedDate,Stock,Image)
values(N'Cafe', N'Cafe được xay trực tiếp từ nguyên liệu thô', 3, 25000, 1, '', '', '', 99, 'https://firebasestorage.googleapis.com/v0/b/elegant-skein-350903.appspot.com/o/Drink%2Fcafe.JPG?alt=media&token=8ea896d4-a047-41e0-9b0c-fc3181930dc7');
Insert into Products
	(Name,Description,CategoryId,Price,DiscountId,CreatedDate,ModifiedDate,DeletedDate,Stock,Image)
values(N'Cơm tấm sườn trứng', N'Cơm tấm kèm canh chua, dưa leo và nước mắm', 2, 30000, 1, '', '', '', 99, 'https://firebasestorage.googleapis.com/v0/b/elegant-skein-350903.appspot.com/o/Dry_Food%2FCom_tam.jpg?alt=media&token=9c66b339-5cc6-4dd5-93e8-d433dea38ddb');
Insert into Products
	(Name,Description,CategoryId,Price,DiscountId,CreatedDate,ModifiedDate,DeletedDate,Stock,Image)
values(N'Khoai tây chiên', N'Khoai tây chiên phủ bột phô mai Có kèm tương ớt', 4, 10000, 1, '', '', '', 99, 'https://firebasestorage.googleapis.com/v0/b/elegant-skein-350903.appspot.com/o/Snack%2Fkhoaitaychien.jpg?alt=media&token=b1278ed3-9188-4d1a-a8a8-78b919e47185');
Insert into Products
	(Name,Description,CategoryId,Price,DiscountId,CreatedDate,ModifiedDate,DeletedDate,Stock,Image)
values(N'Trà tắc', N'...', 3, 12000, 1, '', '', '', 99, 'https://firebasestorage.googleapis.com/v0/b/elegant-skein-350903.appspot.com/o/Drink%2Ftratac.jpg?alt=media&token=73064593-dfdb-4ff0-b36f-2a171f668302');


-- SET IDENTITY_INSERT UserAddresss ON;

INSERT INTO Users
	(Username, Password, FirstName, LastName, Telephone, CreatedDate, ModifiedDate, Logo)
VALUES(N'toinomon', 'Password', N'Nguyễn Văn', N'B', '0654986587', '', '', N'profile.webp');

INSERT INTO UserAddresss
	(UserId, Address, District, Province, City, Country, Mobile)
VALUES(1, N'123', N'Hoàng Thế Thiện', N'Đăk Nông', N'Gia Nghĩa', N'V', '0123456789');


INSERT INTO OrderDetails
	(UserId, Total, CreatedDate, ModifiedDate)
VALUES(1, 20000000, '', '');

INSERT INTO  ShoppingSessions
	(UserId, Total, CreatedDate, ModifiedDate)
VALUES(1, 10, '', '');

INSERT into OrderDetails
	(UserId, Total, CreatedDate, ModifiedDate)
VALUES(1, 100.5, '', '')

INSERT into OrderItems
	(OrderId,ProductId, Quantity, CreatedDate, ModifiedDate)
VALUES(1, 1, 10, '', '')

INSERT INTO Blogs
	(Title, Content, CreatedDate, ModifiedDate, DeletedDate)
VALUES(N'Tiêu đề bài blog 1', N'Nội dung bài blog 1', '', '', '')

