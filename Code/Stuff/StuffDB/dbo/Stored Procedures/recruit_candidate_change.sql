-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE recruit_candidate_change
@id INT,
	@surname NVARCHAR(50),
	@name NVARCHAR(50),
	@patronymic NVARCHAR(50) = null,
	@display_name NVARCHAR(55),
	@birth_date DATE = NULL,
	@creator_Sid VARCHAR(46),
	@phone NVARCHAR(500) = NULL,
	@email NVARCHAR(500) = NULL,
	@file VARBINARY(max) = NULL,
	@file_name NVARCHAR(500) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    BEGIN TRY
	BEGIN TRAN

   update recruit_candidates 
   SET surname=@surname, name=@name, patronymic=@patronymic, display_name=@display_name,  birth_date=@birth_date, creator_sid=@creator_sid, phone=@phone, email=@email
   WHERE id=@id

   IF @file IS NOT NULL
   BEGIN
   
   IF @file_name IS NULL OR LTRIM(RTRIM(@file_name)) = ''
   BEGIN
	SET @file_name = CONCAT('Резюме кандидата №', @id)
   end

   UPDATE recruit_candidate_resume_files
	SET enabled=0, dattim2=GETDATE(), deleter_sid=@creator_sid
   WHERE enabled=1 AND id_candidate=@id

   INSERT INTO dbo.recruit_candidate_resume_files
           ( id_candidate ,
             data ,
			 [file_name],
             creator_sid
           )
   VALUES  ( @id , -- id_candidate - int             
             @file , -- data - varbinary(max)
			 @file_name,
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

END
