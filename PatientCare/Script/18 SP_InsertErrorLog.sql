/****** Object:  StoredProcedure [dbo].[SP_InsertErrorLog]    Script Date: 10/1/2019 6:47:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_InsertErrorLog] 
@Exception NVARCHAR(max),
@ControllerName NVARCHAR(250),
@FunctionName NVARCHAR(500),
@StackTrace  NVARCHAR(max),
@UserID bigint
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO ExceptionMaster ([Exception], [ControllerName], [FunctionName], [StackTrace], [UserID])
	VALUES (@Exception,@ControllerName,@FunctionName,@StackTrace,@UserID)
END
GO
USE [master]
GO
ALTER DATABASE [HRTool] SET  READ_WRITE 
GO
