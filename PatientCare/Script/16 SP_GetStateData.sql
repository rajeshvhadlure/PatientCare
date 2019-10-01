/****** Object:  StoredProcedure [dbo].[SP_GetStateData]    Script Date: 10/1/2019 6:47:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetStateData]

AS
BEGIN
	
	SET NOCOUNT ON;

    SELECT [Id],[Name] FROM [dbo].[states]
END
GO