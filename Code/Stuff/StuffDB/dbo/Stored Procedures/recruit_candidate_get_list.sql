-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[recruit_candidate_get_list] 
	@id INT = NULL,
	@top_rows INT = NULL,
	@page_num INT = NULL,
	@fio NVARCHAR(150) = NULL,
	@age NVARCHAR(150) = NULL,
	@phone NVARCHAR(150) = NULL,
	@email NVARCHAR(150) = NULL,
	@added NVARCHAR(150) = NULL,
	@sex  bit = NULL,
	@changed NVARCHAR(150) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    if @top_rows is null or @top_rows = 0
	begin
	set @top_rows = 100000000
	END
  
  DECLARE @offset INT
  
  SET @offset =  @top_rows * (@page_num - 1)
	
	;WITH recruit_candidates AS (
   select r.*, selection.state_name AS selection_state_name, selection.state_change_date AS selection_state_change_date, selection.state_changer_name AS selection_state_changer_name
   FROM recruit_candidates_view r
   OUTER APPLY
        (
        SELECT  TOP 1 st.name AS state_name, s.state_change_date, e_ch.display_name AS state_changer_name
        FROM    dbo.recruit_selections s		INNER JOIN
                         dbo.recruit_selection_states AS st ON s.id_state = st.id 
						 INNER JOIN dbo.employees AS e_ch WITH (NOLOCK) ON e_ch.ad_sid = s.state_changer_sid
        WHERE s.enabled=1 AND s.id_candidate=r.id
        ) selection
   WHERE (@id IS NULL OR @id <= 0 OR (@id IS NOT NULL AND @id > 0 AND r.id=@id))
   AND (@fio IS NULL OR LTRIM(RTRIM(@fio)) = '' OR (@fio IS NOT NULL AND LTRIM(RTRIM(@fio)) != '' AND (LOWER(r.surname) LIKE '%' + LOWER(LTRIM(RTRIM(@fio)) + '%') OR LOWER(r.name) LIKE '%' + LOWER(LTRIM(RTRIM(@fio))) OR LOWER(r.patronymic) LIKE '%' + LOWER(LTRIM(RTRIM(@fio)) + '%')OR LOWER(r.display_name) LIKE '%' + LOWER(LTRIM(RTRIM(@fio)) + '%'))))
   AND (@age IS NULL OR LTRIM(RTRIM(@age)) = '' OR (@age IS NOT NULL AND LTRIM(RTRIM(@age)) != '' AND CONVERT(NVARCHAR(50), DATEDIFF(YEAR, r.birth_date, GETDATE()) - 1) LIKE '%' + LTRIM(RTRIM(@age) + '%')))
   AND (@phone IS NULL OR LTRIM(RTRIM(@phone)) = '' OR (@phone IS NOT NULL AND LTRIM(RTRIM(@phone)) != '' AND r.phone LIKE '%' + LTRIM(RTRIM(@phone) + '%')))
   AND (@email IS NULL OR LTRIM(RTRIM(@email)) = '' OR (@email IS NOT NULL AND LTRIM(RTRIM(@email)) != '' AND LOWER(r.email) LIKE '%' + LOWER(LTRIM(RTRIM(@email)) + '%')))
   AND (@changed IS NULL OR LTRIM(RTRIM(@changed)) = '' OR (@changed IS NOT NULL AND LTRIM(RTRIM(@changed)) != '' AND (CONVERT(NVARCHAR(12),selection.state_change_date, 104) LIKE '%' + LTRIM(RTRIM(@changed) + '%') OR LOWER(selection.state_changer_name) LIKE '%' + LOWER(LTRIM(RTRIM(@changed)) + '%') OR LOWER(selection.state_name) LIKE '%' + LOWER(LTRIM(RTRIM(@changed)) + '%'))))
   AND (@added IS NULL OR LTRIM(RTRIM(@added)) = '' OR (@added IS NOT NULL AND LTRIM(RTRIM(@added)) != '' AND (CONVERT(NVARCHAR(12),r.dattim1, 104) LIKE '%' + LTRIM(RTRIM(@added) + '%') OR LOWER(r.creator_name) LIKE '%' + LOWER(LTRIM(RTRIM(@added)) + '%'))))
   --AND (@sex IS NULL OR LTRIM(RTRIM(@sex)) = '' OR (@sex IS NOT NULL AND LTRIM(RTRIM(@sex)) != '' AND  LOWER(CASE WHEN r.male = 1 THEN N'М' ELSE N'Ж' END) LIKE '%' + LOWER(LTRIM(RTRIM(@sex)) + '%')))
   AND (@sex IS NULL OR (@sex IS NOT NULL AND r.male = @sex))
    )

   select *
FROM recruit_candidates r
    CROSS JOIN (SELECT Count(1) AS total_count FROM recruit_candidates) AS tCount
ORDER BY id desc
OFFSET @offset ROWS 
FETCH NEXT @top_rows ROWS ONLY
END
