USE [AdvisoryDatabase]
GO
/****** Object:  StoredProcedure [dbo].[USP_UnlockCourseRecord]    Script Date: 26-06-2023 15:55:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[USP_UnlockCourseRecord]


 @Id INT = NULL
	, @CourseMasterID nvarchar(MAX) = NULL
	, @IsActive BIT = NULL
	, @Operation INT = 5
	, @LastUpdatedBy INT = NULL
	, @LastUpdatedOn DATETIME = NULL
	, @CreatedBy INT = NULL
    , @CreatedOn DATETIME = NULL

AS 

BEGIN
	Update CourseMaster SET IsRecordLocked='No' Where CourseMasterID IN (SELECT CONVERT(INT,item) from dbo.SplitString(@CourseMasterID,','))
	
END

