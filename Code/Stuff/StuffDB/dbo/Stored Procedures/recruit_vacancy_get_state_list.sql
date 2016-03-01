-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE recruit_vacancy_get_state_list 
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT * , (SELECT COUNT(1) FROM dbo.recruit_vacancies WHERE enabled = 1 AND id_state=s.id) AS [count]
	FROM dbo.recruit_vacancy_states s WHERE enabled=1
END
