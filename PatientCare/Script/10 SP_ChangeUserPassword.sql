/****** Object:  StoredProcedure [dbo].[SP_ChangeUserPassword]    Script Date: 10/1/2019 6:47:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[SP_ChangeUserPassword]
	 @UserID bigint,
	 @Password nvarchar(250),
	 @NewPassword nvarchar(250),
	 @Count int = 0 OUT
AS
BEGIN
	DECLARE @CurrentPassword nvarchar(250)

	SELECT @CurrentPassword = usr.[Password] from UserMaster usr where usr.UserID = @UserID

	IF(@CurrentPassword = @Password)
	BEGIN
		UPDATE UserMaster SET Password = @NewPassword
		WHERE UserID = @UserID
	END
	ELSE
	BEGIN
		SET @Count = -1
		SELECT @Count
	END
END

GO