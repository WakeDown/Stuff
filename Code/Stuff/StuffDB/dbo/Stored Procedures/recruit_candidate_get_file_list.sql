-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE recruit_candidate_get_file_list
	@id_candidate int
AS
BEGIN
	SET NOCOUNT ON;

    select file_name, sid from recruit_candidate_resume_files where enabled=1 and id_candidate=@id_candidate
END
