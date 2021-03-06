USE [KWWDB]
GO
/****** Object:  StoredProcedure [dbo].[GetUserCart]    Script Date: 5/30/2022 3:37:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[GetUserCart]
	@UserID nvarchar(128)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	select UC.UserID,UC.ProductID,p.ProductName,UC.Quantity,p.ProductPrice from [dbo].[UserCart] UC
	inner join [dbo].[Product] p on UC.ProductID = p.ProductID
	where UC.UserID = @UserID
	order by UC.ProductID

END
