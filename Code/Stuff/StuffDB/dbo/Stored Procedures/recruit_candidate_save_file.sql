-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE recruit_candidate_save_file
	@file VARBINARY(max),
	@file_name NVARCHAR(500),
	@id_candidate int,
	@creator_sid varchar(46)
AS
BEGIN
	SET NOCOUNT ON;

    IF @file IS NOT NULL
   BEGIN
   
   IF @file_name IS NULL OR LTRIM(RTRIM(@file_name)) = ''
   BEGIN
	SET @file_name = CONCAT('Резюме кандидата №', @id_candidate)
   end

   INSERT INTO dbo.recruit_candidate_resume_files
           ( id_candidate ,
             data ,
			 [file_name],
             dattim1 ,
             creator_sid
           )
   VALUES  ( @id_candidate , -- id_candidate - int             
             @file , -- data - varbinary(max)
			 @file_name,
             GETDATE() , -- dattim1 - datetime
             @creator_sid  -- creator_sid - varchar(46)
           )
		   end
END
