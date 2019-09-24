CREATE PROCEDURE SP_GetCityData 

AS
BEGIN
	
	SET NOCOUNT ON;

    SELECT [Id],[Name] FROM [dbo].[cities]
END
GO