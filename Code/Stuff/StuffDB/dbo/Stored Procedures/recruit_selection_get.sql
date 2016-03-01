-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[recruit_selection_get]
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT *, 
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
	 WHERE id=@id
END
