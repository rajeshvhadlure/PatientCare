/****** Object:  StoredProcedure [dbo].[SP_GetParliamentData]    Script Date: 10/1/2019 6:47:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetParliamentData] 

AS
BEGIN
	
	SET NOCOUNT ON;

    SELECT [Id],[Name] FROM [dbo].[Parliament]
END
GO