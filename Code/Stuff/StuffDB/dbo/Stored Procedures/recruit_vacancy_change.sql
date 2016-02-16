-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE recruit_vacancy_change
	@id INT,
	@creator_sid VARCHAR(46),
	@personal_manager_sid VARCHAR(46)

AS
BEGIN
	SET NOCOUNT ON;

    UPDATE recruit_vacancies
	SET personal_manager_sid = @personal_manager_sid
	WHERE id=@id
END
