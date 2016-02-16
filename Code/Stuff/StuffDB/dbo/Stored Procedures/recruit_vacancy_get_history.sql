-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE recruit_vacancy_get_history 
	@id INT,
	@full_list BIT = 0
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @top_rows INT
	SET @top_rows = 1000000
    if @full_list = 0
	begin
		SET @top_rows = 3
	END
	
	;WITH recruit_vacancy_history AS (
   select h.*, e.display_name AS creator_name, st.name AS state_name FROM recruit_vacancy_state_history h LEFT JOIN dbo.employees e ON e.ad_sid=h.creator_sid
   INNER JOIN recruit_vacancy_states st ON st.id=h.id_state
   WHERE id_vacancy=@id )

   select *
FROM recruit_vacancy_history r
    CROSS JOIN (SELECT Count(1) AS total_count FROM recruit_vacancy_history) AS tCount
ORDER BY dattim1 desc
OFFSET 0 ROWS 
FETCH NEXT @top_rows ROWS ONLY

END
