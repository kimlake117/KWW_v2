
--the Microsof Identity framework will create the user, roles, and user roles table that i will use



CREATE TABLE [dbo].[Product] (
	ProductID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	ProductName varchar(128) NOT NULL,
	Photo image,
	ProductPrice money,
	ProductDescription varchar(MAX),
	Active bit NOT NULL
);

CREATE TABLE [dbo].[UserCart] (
	UserID NVARCHAR(128) NOT NULL FOREIGN KEY REFERENCES [dbo].[User](UserID),
	ProductID int FOREIGN KEY REFERENCES [dbo].[Product](ProductID) NOT NULL,
	Quantity INTEGER NOT NULL
);

CREATE TABLE [dbo].[OrderStatus] (
	OrderStatusID INT Not NULL IDENTITY(1,1) PRIMARY KEY,
	OrderStatusDescription varchar(128) NOT NULL
);

CREATE TABLE [dbo].[State] (
	StateID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	StateName varchar(128) NOT NULL
);

CREATE TABLE [dbo].[OrderDetail] (
	OrderDetailID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	ParentOrderID INT, 
	ProductID INT NOT NULL FOREIGN KEY REFERENCES Product(ProductID), 
	Quantity int NOT NULL,
	PriceAtPurchace money
);

CREATE TABLE ShippingDetail (
	ShippingDetailID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	ParentOrderID INT,
	ShippingName varchar(128),
	ShippingStreetAddress varchar(128),
	ShippingCity varchar(128),
	ShippingState INT FOREIGN KEY REFERENCES State(StateID),
	ShippingPostalCode varchar(32)
);

CREATE TABLE BillingDetail (
	BillingDetailID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	ParentOrderID INT,
	BillingName varchar(128),
	BillingStreetAddress varchar(128),
	BillingCity varchar(128),
	BillingState INT FOREIGN KEY REFERENCES State(StateID),
	BillingPostalCode varchar(32), 
	CreditCardNumber varchar(32), 
	CreditCardExpMonth INT,
	CreditCardExpYear INT,
	CVC INT,
);

CREATE TABLE ParentOrder (
	ParentOrderID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	UserID NVARCHAR(128) NOT NULL FOREIGN KEY REFERENCES [dbo].[User](UserID),
	OrderStatusID INT NOT NULL FOREIGN KEY REFERENCES OrderStatus(OrderStatusID),
	ShippingDetailID INT FOREIGN KEY REFERENCES [dbo].[ShippingDetail](ShippingDetailID),
	BillingDetailID INT FOREIGN KEY REFERENCES [dbo].[BillingDetail](BillingDetailID),
	ToalOrderCost money NOT NULL,
	OrderDate DATETIME NOT NULL,
	StatusDate DATETIME NOT NULL,
	);
							

