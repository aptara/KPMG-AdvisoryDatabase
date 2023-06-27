USE [AdvisoryDatabase]
GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 27-06-2023 12:18:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[AddUser]



-- default parameter

@FirstName nvarchar(20),
@LastName varchar(20),
@Email varchar(40),
@LocationID int,
@NetworkID nvarchar(MAX),

@IsActive bit =1
,@Id INT = NULL
,@Operation INT = NULL
,@CreatedBy INT =NULL
,@CreatedOn Datetime=NULL
,@LastUpdatedBy int=NULL
,@LastUpdatedOn Datetime=NULL
,@TaskMasterID VARCHAR(MAX)=NULL--'22,25,88,99'
--,@TaskMasterID int
,@UserMasterID int=NULL

AS  


 IF @Operation = 1  -- Add
BEGIN  

 INSERT INTO UserMaster(FirstName, LastName, Email,LocationID,NetworkID,CreatedBy,CreatedOn,LastUpdatedBy,LastUpdatedOn,IsActive)
    VALUES (@FirstName, @LastName, @Email,@LocationID,@NetworkID,@CreatedBy,GETDATE(),@LastUpdatedBy,GETDATE(),@IsActive);
    SELECT LocationID
    FROM LocationMaster
    WHERE LocationID = @LocationID;

    	SET @UserMasterID = ( SELECT SCOPE_IDENTITY() )  

		SELECT @UserMasterID  

		BEGIN

				DECLARE @TempUserTaskMapping TABLE(ID INT IDENTITY(1,1), TeampTaskMasterID varchar(MAX) )

				INSERT INTO @TempUserTaskMapping(TeampTaskMasterID)
				SELECT ITEM FROM dbo.SplitString(@TaskMasterID, ',')

				Select * from @TempUserTaskMapping

				INSERT INTO UserTaskMapping (UserMasterID, TaskMasterID,CreatedBy,CreatedOn,LastUpdatedBy,LastUpdatedOn) 
				SELECT @UserMasterID,TeampTaskMasterID,@CreatedBy,getdate(),@LastUpdatedBy,getdate() from  @TempUserTaskMapping

		END
 
END



