-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE recruit_candidate_close_file
	@sid varchar(46),
	@deleter_sid varchar(46)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    update recruit_candidate_resume_files
	set enabled=0, dattim2=getdate(), deleter_sid=@deleter_sid 
	where sid=@sid
END
