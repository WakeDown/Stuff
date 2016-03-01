-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[clone_rest_holiday_transfer_days]
	@year_from int,
	@year_to int,
	@creator_sid varchar(46)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
    INSERT INTO rest_holiday_transfer_days (date, descr, creator_sid)
	SELECT CONVERT(date, CONCAT(DAY(date), '-', MONTH(date), '-', @year_to)), descr, @creator_sid FROM rest_holiday_transfer_days WHERE ENABLED=1 AND YEAR(date) = @year_from
END
