/****** Object:  StoredProcedure [dbo].[SP_GetUserData_Forlist]    Script Date: 10/1/2019 6:47:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetUserData_Forlist]
@CurrentPage int,
@NumberOfRecords int,
@OrderBy nvarchar(250),
@Mobile nvarchar(15),
@Pincode nvarchar(10),
@State nvarchar(250),
@City nvarchar(250),
@Parliamentary nvarchar(max),
@Legislative nvarchar(max), 
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