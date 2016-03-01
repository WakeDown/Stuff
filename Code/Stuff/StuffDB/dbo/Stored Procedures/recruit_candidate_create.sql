-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[recruit_candidate_create]
	@surname NVARCHAR(50),
	@name NVARCHAR(50),
	@patronymic NVARCHAR(50) = null,
	@display_name NVARCHAR(55),
	@male BIT,
	@id_came_resource INT,
	@birth_date DATE = NULL,
	@creator_Sid VARCHAR(46),
	@phone NVARCHAR(500) = NULL,
	@email NVARCHAR(500) = NULL,
	@file VARBINARY(max) = NULL,
	@file_name NVARCHAR(500) = null,
	@id_came_type int = null
AS
BEGIN
	SET NOCOUNT ON;

	BEGIN TRY
	BEGIN TRAN

	DECLARE @id INT
   INSERT INTO recruit_candidates (surname, name, patronymic, display_name, male, id_came_resource, birth_date, creator_sid, phone, email, id_came_type)
   VALUES (@surname, @name, @patronymic, @display_name, @male, @id_came_resource, @birth_date, @creator_sid, @phone, @email, @id_came_type)
   SET @id = SCOPE_IDENTITY()

   IF @file IS NOT NULL
   BEGIN
   
   IF @file_name IS NULL OR LTRIM(RTRIM(@file_name)) = ''
   BEGIN
	SET @file_name = CONCAT('Резюме кандидата №', @id)
   end

   INSERT INTO dbo.recruit_candidate_resume_files
           ( id_candidate ,
             data ,
			 [file_name],
             dattim1 ,
             creator_sid
           )
   VALUES  ( @id , -- id_candidate - int             
             @file , -- data - varbinary(max)
			 @file_name,
             GETDATE() , -- dattim1 - datetime
             @creator_sid  -- creator_sid - varchar(46)
           )
		   end

   COMMIT TRAN
END TRY
BEGIN CATCH     
	 IF(@@TRANCOUNT > 0)
        ROLLBACK TRAN;
		THROW
END CATCH


   SELECT @id AS id
END
