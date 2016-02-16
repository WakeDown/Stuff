-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE statement_printed_confirm
	@id INT,
	@confirmator_sid VARCHAR(46),
	@confirm BIT = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE dbo.statement_printed
	SET confirmed = @confirm, confirmator_sid = @confirmator_sid,date_confirm=GETDATE()
	WHERE id=@id
END
