-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[hilodays_count_in_period] 
	@date_start DATE,
	@date_end DATE
AS
BEGIN
	SET NOCOUNT ON;

    SELECT h.date AS ctn FROM dbo.wd_holidays h
	WHERE h.date BETWEEN @date_start AND @date_end
	
END
