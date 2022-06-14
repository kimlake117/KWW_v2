-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
alter PROCEDURE [dbo].[CreateOrder]
	@UserID nvarchar(128),
	@BillingFirstName varchar(128),
	@BillingLastName varchar(128),
	@BillingStreet varchar(128),
	@BillingCity varchar(128),
	@BillingState int,
	@BillingPostalCode varchar(32),
	@CCardNumber varchar(32),
	@CCMonth int,
	@CCYear int,
	@CVC int,
	@ShippingFirstName varchar(128),
	@ShippingLastName varchar(128),
	@ShippingStreet varchar(128),
	@ShippingCity varchar(128),
	@ShippingState int,
	@ShippingPostalCode varchar(32)
	
AS
BEGIN

	--the cart's total value to be calculated later
	Declare @CartTotal money,
	--used in calculating cart value and inserting into order details
	@ProductID int,
	@Quantity int,
	@Price money,

	--the new parent order id
	@ParentOrder int,

	--the new Billing Detail id
	@BillingDetail int,

	--used in insert into billing
	@BillingFullName varchar(128),

	--used in insert into shipping
	@ShippingFullName varchar(128),

	--the new shipping detail ID
	@ShippingDetail int

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	--USED TO INSERT INTO ORDER DETAILS
	DECLARE C_UserCartProducts CURSOR LOCAL FOR
	SELECT UC.ProductID,UC.Quantity,P.ProductPrice FROM [dbo].[UserCart] UC
	INNER JOIN [dbo].[Product] P ON P.ProductID = UC.ProductID
	WHERE UC.UserID = @UserID
	
	--Begin getting the User Cart's Toatl Value
	set @CartTotal = 0;

	DECLARE C_UserCartCost CURSOR LOCAL FOR 
	SELECT Quantity,ProductPrice FROM [dbo].[UserCart] UC
	inner join [dbo].[Product] P on p.ProductID = UC.ProductID
	WHERE UserID = @UserID;

	open C_UserCartCost

	FETCH NEXT FROM C_UserCartCost into @Quantity, @Price

	WHILE (@@FETCH_STATUS = 0)

	BEGIN

		set @CartTotal = @CartTotal + (@Quantity * @Price)

		FETCH NEXT FROM C_UserCartCost into @Quantity, @Price
	END

	close C_UserCartCost
	--end getting user cart's total value


	BEGIN TRANSACTION;
		--insert into parent order table
		insert into [dbo].[ParentOrder]([UserID],[OrderStatusID],[ToalOrderCost],[OrderDate],[StatusDate]) 
		values(@UserID,1,@CartTotal,GETDATE(),GETDATE());

		--get the parent order id
		set @ParentOrder = (select IDENT_CURRENT('[dbo].[ParentOrder]'));

		--INSERT INTO OrderDetails table
		OPEN C_UserCartProducts

		FETCH NEXT FROM C_UserCartProducts into @ProductID,@Quantity,@Price

		WHILE (@@FETCH_STATUS = 0)

		BEGIN
			INSERT INTO [dbo].[OrderDetail]([ParentOrderID],[ProductID],[Quantity],[PriceAtPurchace])
			VALUES(@ParentOrder,@ProductID,@Quantity,@Price);

			FETCH NEXT FROM C_UserCartProducts into @ProductID,@Quantity,@Price
		END

		CLOSE C_UserCartProducts

		--concat the billing name name
		set @BillingFullName = CONCAT(@BillingFirstName+' ',@BillingLastName);

		--insert into billing detail
		insert into BillingDetail([ParentOrderID],[BillingName],[BillingStreetAddress],[BillingCity],[BillingState],[BillingPostalCode],[CreditCardNumber],[CreditCardExpMonth],[CreditCardExpYear],[CVC])
		values(@ParentOrder,@BillingFullName,@BillingStreet,@BillingCity,@BillingState,@BillingPostalCode,@CCardNumber,@CCMonth,@CCYear,@CVC);

		--get the id of the row we just inserted
		SET @BillingDetail = (select IDENT_CURRENT('[dbo].[BillingDetail]'));

		--CONCAT SHIPPING NAME
		set @ShippingFullName = CONCAT(@ShippingFirstName+' ',@ShippingLastName);

		--INSERT INTO SHIPPING DETATIL
		INSERT INTO [dbo].[ShippingDetail]([ParentOrderID],[ShippingName],[ShippingStreetAddress],[ShippingCity],[ShippingState],[ShippingPostalCode])
		values(@ParentOrder,@ShippingFullName,@ShippingStreet,@ShippingCity,@ShippingState,@ShippingPostalCode)

		--get the id of the row we just inserted
		set @ShippingDetail = (select IDENT_CURRENT('[dbo].[ShippingDetail]'));

		--update the parent order with shipping and billing ID's
		update [dbo].[ParentOrder]
		set [ShippingDetailID] = @ShippingDetail,[BillingDetailID] = @BillingDetail
		where [ParentOrderID] = @ParentOrder

		--delete from the user cart
		delete from [dbo].[UserCart]
		where [UserID] = @UserID
	
	END
	COMMIT;
GO
