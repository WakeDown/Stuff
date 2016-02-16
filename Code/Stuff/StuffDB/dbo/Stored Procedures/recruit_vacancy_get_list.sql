-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[recruit_vacancy_get_list] 
	@id INT = NULL,
	@top_rows INT = NULL,
	@page_num INT = NULL,
	@vacancy_name NVARCHAR(150) = NULL,
	@deadline_date NVARCHAR(12) = NULL,
	@personal_manager_name NVARCHAR(150) = NULL,
	@date_create NVARCHAR(150) = NULL,
	@state NVARCHAR(150) = NULL,
	@active_only BIT = NULL,
	@personal_manager_sid varchar(46) = null,
	@viewer_sid varchar(46) = null,
	@branch_office NVARCHAR(150) = NULL
AS
BEGIN
	SET NOCOUNT ON;
	if @top_rows is null or @top_rows = 0
	begin
	set @top_rows = 100000000
	END
  
  DECLARE @offset INT
  
  SET @offset =  @top_rows * (@page_num - 1)
	
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


	;WITH recruit_vacancies AS (
   select * FROM recruit_vacancies_view r
   WHERE (@id IS NULL OR @id <= 0 OR (@id IS NOT NULL AND @id > 0 AND r.id=@id))
   AND (@vacancy_name IS NULL OR LTRIM(RTRIM(@vacancy_name))  = '' OR (@vacancy_name IS NOT NULL AND LTRIM(RTRIM(@vacancy_name))  != '' AND (r.position_name LIKE '%' + LTRIM(RTRIM(@vacancy_name)) + '%' OR r.department_name LIKE '%' + LTRIM(RTRIM(@vacancy_name)) + '%')))
    AND (@deadline_date IS NULL OR LTRIM(RTRIM(@deadline_date)) = '' OR (@deadline_date IS NOT NULL AND LTRIM(RTRIM(@deadline_date)) != '' AND (CONVERT(NVARCHAR(12),r.deadline_date, 104) LIKE '%' + LTRIM(RTRIM(@deadline_date)) + '%' or CONVERT(NVARCHAR(12),r.order_end_date, 104) LIKE '%' + LTRIM(RTRIM(@deadline_date)) + '%' or CONVERT(NVARCHAR(12),r.claim_end_date, 104) LIKE '%' + LTRIM(RTRIM(@deadline_date)) + '%')))
	 AND (@date_create IS NULL OR LTRIM(RTRIM(@date_create)) = '' OR (@date_create IS NOT NULL AND LTRIM(RTRIM(@date_create)) != '' AND (CONVERT(NVARCHAR(12),r.dattim1, 104) LIKE '%' + LTRIM(RTRIM(@date_create)) + '%' + '%' OR r.creator_name LIKE '%' + LTRIM(RTRIM(@date_create)) + '%')))
	 AND (@personal_manager_name IS NULL OR LTRIM(RTRIM(@personal_manager_name)) = '' OR (@personal_manager_name IS NOT NULL AND LTRIM(RTRIM(@personal_manager_name)) != '' AND r.personal_manager_name LIKE '%' + LTRIM(RTRIM(@personal_manager_name) + '%')))
	 AND (@personal_manager_sid IS NULL OR @personal_manager_sid = '' OR (@personal_manager_sid IS NOT NULL AND @personal_manager_sid != '' AND r.personal_manager_sid = @personal_manager_sid))
	 AND (@state IS NULL OR LTRIM(RTRIM(@state)) = '' OR (@state IS NOT NULL AND LTRIM(RTRIM(@state)) != '' AND (r.state_name LIKE '%' + LTRIM(RTRIM(@state) + '%') OR r.state_changer_name LIKE '%' + LTRIM(RTRIM(@state) + '%') OR CONVERT(NVARCHAR(12),r.state_change_date, 104) LIKE '%' + LTRIM(RTRIM(@state) + '%'))))
	 AND (@active_only IS NULL OR (@active_only IS NOT NULL AND r.state_is_active = @active_only))
	 and (@viewer_sid is null or @viewer_sid = '' or (@viewer_sid is not null and @viewer_sid != '' and (r.author_sid in (select ad_sid from @sid_list) or r.author_sid = @viewer_sid)))
	and (@branch_office is null or @branch_office = '' or (@branch_office is not null and @branch_office != '' and r.branch_office_name like '%' + @branch_office +'%'))
	)
   select *
FROM recruit_vacancies r
    CROSS JOIN (SELECT Count(1) AS total_count FROM recruit_vacancies) AS tCount
ORDER BY id desc
OFFSET @offset ROWS 
FETCH NEXT @top_rows ROWS ONLY

END
