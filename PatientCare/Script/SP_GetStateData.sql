CREATE PROCEDURE SP_GetStateData

AS
BEGIN
	
	SET NOCOUNT ON;

    SELECT [Id],[Name] FROM [dbo].[states]
END
GO
