-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[save_rest_holiday_transfer_days]
	@date Date,
	@descr nvarchar(500) = NULL,
	@creator_sid varchar(46)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @id int
    INSERT INTO rest_holiday_transfer_days (date, descr, creator_sid)
	VALUES (@date, @descr, @creator_sid)
	SET @id = SCOPE_IDENTITY()
	SELECT @id AS id
END
