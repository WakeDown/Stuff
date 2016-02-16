-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE get_rest_holiday_transfer_days_years_list	

	@top_rows int = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	if @top_rows is null
begin
set @top_rows = 10000
end

	SELECT TOP (@top_rows) [year] from
   ( select YEAR(date) AS [year]
	from rest_holiday_transfer_days
	where enabled=1
	union ALL
	select year(getdate()) as [year]
	union  all
	select year(DATEADD(year, 1, getdate())) as [year]) AS t
	where t.[year] > 2015
	group by [year]
	order by [year]
END
