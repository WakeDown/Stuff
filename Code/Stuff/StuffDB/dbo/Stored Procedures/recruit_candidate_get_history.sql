-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[recruit_candidate_get_history] 
	@id INT,
	@full_list BIT = 0
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @top_rows INT
	SET @top_rows = 1000000
    if @full_list = 0
	begin
		SET @top_rows = 1
	END
	
	;WITH recruit_candidate_history AS (
   select h.*, e.display_name AS creator_name, st.name AS state_name, s.id_vacancy AS link_id
   FROM dbo.recruit_selection_state_history h LEFT JOIN dbo.employees e ON e.ad_sid=h.creator_sid
   INNER JOIN recruit_selection_states st ON st.id=h.id_state
   INNER JOIN dbo.recruit_selections s ON h.id_selection=s.id
   WHERE s.id_candidate=@id)

   select *
FROM recruit_candidate_history r
    CROSS JOIN (SELECT Count(1) AS total_count FROM recruit_candidate_history) AS tCount
ORDER BY dattim1 desc
OFFSET 0 ROWS 
FETCH NEXT @top_rows ROWS ONLY
END
