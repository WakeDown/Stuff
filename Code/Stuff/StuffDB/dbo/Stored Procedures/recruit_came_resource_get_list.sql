-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[recruit_came_resource_get_list] 
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT *
	--, ISNULL((SELECT COUNT(1) FROM recruit_candidates rc WHERE rc.enabled=1 AND id_came_resource = cr.id), 0) AS cnt
	FROM recruit_came_resources cr
	WHERE enabled=1
	ORDER BY 
	--cnt desc
	order_num, name
END
