-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE recruit_question_check_link
	@sid varchar(46)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    if exists(select 1 from recruit_question_links where enabled=1 and sid=@sid)
	begin
		select 1 as [exists]
	end
	else
	begin
		select 0 as [exists]
	end
END
