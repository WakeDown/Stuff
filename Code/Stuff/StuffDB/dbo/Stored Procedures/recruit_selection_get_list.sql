-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[recruit_selection_get_list] 
	@id_vacancy INT = null,
	@id_candidate INT = null,
	@viewer_sid varchar(46) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
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

    ;WITH recruit_selections AS (
   select *, 
   --case when s.state_order_num <= 0 then 
   (select count(1) from recruit_selection_states where enabled=1 and order_num != 0 and order_num <= 
   (
   select top 1 order_num from recruit_selection_state_history sh
   inner join recruit_selection_states sst on sst.enabled=1 and sst.id=sh.id_state
   where sh.id_selection=s.id and sst.order_num > 0
   order by sh.id desc
   )
   )
   -- else
   --(select count(1) from recruit_selection_states where enabled=1 and order_num != 0 and order_num <= s.state_order_num) end 
   as full_state_count 
   FROM recruit_selections_view s
   WHERE (@id_vacancy IS NULL OR @id_vacancy <=0 OR(@id_vacancy IS NOT NULL AND @id_vacancy > 0 and id_vacancy=@id_vacancy))
   AND (@id_candidate IS NULL OR @id_candidate <=0 OR(@id_candidate IS NOT NULL AND @id_candidate > 0 and s.id_candidate=@id_candidate))
   and (@viewer_sid is null or @viewer_sid = '' or (@viewer_sid is not null and @viewer_sid != '' and (s.vacancy_author_sid in (select ad_sid from @sid_list) or s.vacancy_author_sid = @viewer_sid)))
    )

   select *
FROM recruit_selections s
    CROSS JOIN (SELECT Count(1) AS total_count FROM recruit_selections) AS tCount
ORDER BY s.state_is_active DESC, s.candidate_display_name
END
