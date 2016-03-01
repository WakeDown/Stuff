-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE recruit_question_form_create
	@link_sid varchar(46)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    if not exists (select 1 from recruit_question_forms	where link_sid = @link_sid)
	begin
		insert into recruit_question_forms (link_sid, id_selection, id_candidate, id_vacancy, surname, name, patronymic, birth_date)
		select  @link_sid, s.id, s.id_candidate, s.id_vacancy, c.surname, c.name, c.patronymic, c.birth_date from recruit_question_links l
		inner join recruit_selections s on s.id=l.id_selection
		inner join recruit_candidates c on s.id_candidate=c.id
		where l.enabled=1 and [sid]=@link_sid
	end
END
