/****** Object:  StoredProcedure [dbo].[SP_ForgotUsernamePassword]    Script Date: 10/1/2019 6:47:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_ForgotUsernamePassword]
@Username nvarchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   SELECT 
	UserID, 
	Username,
	password,
	EmailID
	from UserMaster WHERE EmailID = @Username 

END

GO