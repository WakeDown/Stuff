-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE recruit_question_create_link
	@id_selection int,
	@creator_sid varchar(46)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @sid varchar(46), @id int

	update [recruit_question_links]
	set enabled=0, dattim2=getdate(), deleter_sid=@creator_sid
	where id_selection=@id_selection

    insert into [dbo].[recruit_question_links] (id_selection, creator_sid)
	values (@id_selection, @creator_sid)

	set @id=SCOPE_IDENTITY()
	select @id as id, [sid] from [recruit_question_links] where id=@id

END
