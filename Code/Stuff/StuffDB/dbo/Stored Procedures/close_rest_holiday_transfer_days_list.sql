-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[close_rest_holiday_transfer_days_list]
	@id int,
	@deleter_sid varchar(46)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE rest_holiday_transfer_days
	SET ENABLED = 0, dattim2 = GETDATE(), deleter_sid = @deleter_sid
	WHERE id=@id
END
