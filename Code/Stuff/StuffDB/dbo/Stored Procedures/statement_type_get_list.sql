-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[statement_type_get_list] 
	@group_sys_name NVARCHAR(50) = null
AS
BEGIN
	SET NOCOUNT ON;

    SELECT * FROM dbo.statement_types st
	WHERE enabled=1
	AND (@group_sys_name IS NULL OR @group_sys_name = '' OR (@group_sys_name IS NOT NULL AND @group_sys_name != '' AND group_sys_name=@group_sys_name))
	ORDER BY st.order_num, st.name
END
