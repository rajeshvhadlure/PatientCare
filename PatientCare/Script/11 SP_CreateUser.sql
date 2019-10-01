/****** Object:  StoredProcedure [dbo].[SP_CreateUser]    Script Date: 10/1/2019 6:47:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_CreateUser]
@FirstName nvarchar(50), 
@MiddleName nvarchar(50), 
@LastName nvarchar(50), 
@EmailID nvarchar(50), 
@Username nvarchar(50), 
@password nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    Insert into UserMaster (FirstName, MiddleName, LastName, EmailID, Username, password)
	VALUES (@FirstName, @MiddleName, @LastName, @EmailID, @Username, @password)
END

GO