CREATE PROCEDURE [dbo].[SP_GetUserData_Forlist]
@CurrentPage int,
@NumberOfRecords int,
@OrderBy nvarchar(250),
@TotalCount int = 0 OUT 
AS
BEGIN
		SELECT @TotalCount = COUNT(ID)
		FROM [dbo].[User] 
		
		SELECT * 
		FROM (
		SELECT ROW_NUMBER() OVER(ORDER BY A.ID) AS NUMBER,
		A.ID,
		A.[Name],[Address],[Mobile],[Pincode],C.[Name] 'City',S.[Name] 'State',[Parliamentry] 'Parliamentary',[Legilative] 'Legislative',
		@TotalCount as TotalCount	
		FROM [dbo].[User] A
		INNER JOIN [dbo].[cities] C ON A.City = C.Id
		INNER JOIN [dbo].[states] S ON A.State = S.id
	    ) AS TBL
		WHERE NUMBER BETWEEN ((@CurrentPage - 1) * @NumberOfRecords + 1) AND (@CurrentPage * @NumberOfRecords)
END
GO