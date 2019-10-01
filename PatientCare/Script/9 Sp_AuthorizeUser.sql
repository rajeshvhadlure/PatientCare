/****** Object:  StoredProcedure [dbo].[SP_AuthorizeUser]    Script Date: 10/1/2019 6:47:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_AuthorizeUser]
	 @Username nvarchar(50),
	 @Password nvarchar(50)
AS
BEGIN
	SELECT 
	UserID, 
	FirstName, 
	LastName, 
	EmailID, 
	Username
	from UserMaster WHERE Username = @Username AND password = @Password
END

GO