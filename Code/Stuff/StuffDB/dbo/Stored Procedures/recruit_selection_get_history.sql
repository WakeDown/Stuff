-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[recruit_selection_get_history] 
	@id int	,
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

   select h.*, e.display_name AS creator_name, st.name AS state_name
   FROM dbo.recruit_selection_state_history h 
   LEFT JOIN dbo.employees e ON e.ad_sid=h.creator_sid
   INNER JOIN recruit_selection_states st ON st.id=h.id_state
   inner join recruit_selections_view s on h.id_selection=s.id
   WHERE h.id_selection=@id 
   and (@viewer_sid is null or @viewer_sid = '' or (@viewer_sid is not null and @viewer_sid != '' and (s.vacancy_author_sid in (select ad_sid from @sid_list) or s.vacancy_author_sid = @viewer_sid)))
   ORDER BY dattim1 desc
END
