-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE recruit_selection_close 
	@id INT,
	@deleter_sid VARCHAR(46)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE recruit_selections
	SET dattim2=GETDATE(), enabled = 0, deleter_sid=@deleter_sid
	WHERE id=@id
END
