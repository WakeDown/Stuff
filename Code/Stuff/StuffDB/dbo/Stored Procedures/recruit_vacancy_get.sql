-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[recruit_vacancy_get] 
	@id int,
	@viewer_sid varchar(46) = null
AS
BEGIN
	SET NOCOUNT ON;

	if (@viewer_sid is not null and @viewer_sid != '')
	begin
	declare @id_department int
	select @id_department = id_department from employees_view e where e.ad_sid = @viewer_sid and e.is_chief = 1

	if @id_department is not null and @id_department > 0
	begin
		declare @sid_list table(
		 ad_sid varchar(46)
		)
		
		;with deps(id, id_parent) as (
		   select id, id_parent
		   from dbo.departments
		   where id = @id_department
		   union all
		   select c.id, c.id_parent
		   from departments c
			 join deps p on p.id = c.id_parent 
		)
		insert into @sid_list 
		SELECT ad_sid 
		FROM dbo.employees_view e
		WHERE e.ad_sid <> @viewer_sid and e.id_department IN (SELECT id FROM deps)
	end
	end

    SELECT * FROM recruit_vacancies_view r WHERE id=@id and (@viewer_sid is null or @viewer_sid = '' or (@viewer_sid is not null and @viewer_sid != '' and (r.author_sid in (select ad_sid from @sid_list) or r.author_sid = @viewer_sid)))
END
