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
		SELECT ROW_NUMBER() OVER(ORDER BY ID) AS NUMBER,
		ID,
		[Name],[Address],[Mobile],[Pincode],[State],[City],[Parliamentry] 'Parliamentary',[Legilative] 'Legislative',
		@TotalCount as TotalCount	
		FROM [dbo].[User] A
	    ) AS TBL
		WHERE NUMBER BETWEEN ((@CurrentPage - 1) * @NumberOfRecords + 1) AND (@CurrentPage * @NumberOfRecords)
END

GO