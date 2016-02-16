-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[recruit_vacancy_set_state]
@id INT,
	@state_sys_name NVARCHAR(50),
	@creator_sid VARCHAR(46),
	@descr nvarchar(MAX) = null
AS
BEGIN
	SET NOCOUNT ON;

	BEGIN TRY
	BEGIN TRAN

	DECLARE @id_state INT
	SELECT TOP 1 @id_state = id FROM recruit_vacancy_states WHERE enabled=1 AND sys_name = @state_sys_name

     UPDATE recruit_vacancies
	 SET id_state = @id_state, state_change_date = GETDATE(), state_changer_sid = @creator_sid
	 WHERE id=@id

	 INSERT INTO recruit_vacancy_state_history (id_vacancy, id_state, creator_sid, descr)
	 VALUES (@id, @id_state, @creator_sid, @descr)

	 IF exists(SELECT 1 FROM dbo.recruit_vacancy_states WHERE id=@id_state AND is_end=1)
	 BEGIN
		UPDATE recruit_vacancies
		SET end_date=GETDATE()
		WHERE id=@id
	 end

	 COMMIT tran
END TRY
BEGIN CATCH     
	 IF(@@TRANCOUNT > 0)
        ROLLBACK TRAN
		throw
END CATCH
    
END
