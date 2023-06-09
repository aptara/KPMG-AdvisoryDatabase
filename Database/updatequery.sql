USE [AdvisoryDatabase]
GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 27-06-2023 12:33:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[UpdateUser]



-- default parameter
@UserMasterID int,
@FirstName nvarchar(20),
@LastName varchar(20),
@Email varchar(40),
@NetworkID nvarchar(MAX),
@LocationID int,
@IsActive bit,


@Id INT = NULL
,@Operation INT = NULL
,@CreatedBy INT =NULL
,@CreatedOn Datetime=NULL
,@LastUpdatedBy int=NULL
,@LastUpdatedOn Datetime=NULL
,@TaskMasterID VARCHAR(MAX)=NULL--'22,25,88,99'
AS  


 IF @Operation = 2 -- update
BEGIN  

 SET NOCOUNT ON;
 BEGIN
    UPDATE UserMaster
    SET FirstName = @FirstName, LastName = @LastName, LocationID = @LocationID, NetworkID=@NetworkID, Email = @Email,IsActive=@IsActive
    WHERE UserMasterID = @UserMasterID

    SELECT @LocationID= LocationID
    FROM LocationMaster
    WHERE LocationID = @LocationID;


  --   	SET @UserMasterID = (SELECT SCOPE_IDENTITY());

		--SELECT @UserMasterID  

    BEGIN

    	DECLARE @TempUserTaskMapping TABLE(ID INT IDENTITY(1,1), TempTaskMasterID varchar(MAX) )

       INSERT INTO @TempUserTaskMapping (TempTaskMasterID)
            SELECT ITEM FROM dbo.SplitString(@TaskMasterID, ',');

            DELETE FROM UserTaskMapping
            WHERE UserMasterID = @UserMasterID;

           INSERT INTO UserTaskMapping (UserMasterID, TaskMasterID, CreatedBy, CreatedOn, LastUpdatedBy, LastUpdatedOn)
            SELECT @UserMasterID, t.TempTaskMasterID, @CreatedBy, GETDATE(), @LastUpdatedBy, GETDATE()
            FROM @TempUserTaskMapping t;

END

 END  
 
END



