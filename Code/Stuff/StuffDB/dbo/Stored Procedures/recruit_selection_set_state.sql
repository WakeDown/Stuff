
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[recruit_selection_set_state]
	@id INT,
	@state_sys_name NVARCHAR(50) = null,
	@id_state INT = null,
	@creator_sid VARCHAR(46),
	@descr NVARCHAR(MAX) = NULL
AS
BEGIN
	SET NOCOUNT ON;

	BEGIN TRY
	BEGIN TRAN

	IF @id_state IS NULL OR @id_state <= 0
	begin
	SELECT TOP 1 @id_state = id FROM recruit_selection_states WHERE enabled=1 AND sys_name = @state_sys_name
	END
    
     UPDATE recruit_selections
	 SET id_state = @id_state, state_change_date = GETDATE(), state_changer_sid = @creator_sid, state_descr=@descr
	 WHERE id=@id

	 INSERT INTO recruit_selection_state_history (id_selection, id_state, creator_sid, descr)
	 VALUES (@id, @id_state, @creator_sid, @descr)

	 IF EXISTS(SELECT 1 FROM recruit_selection_states WHERE id=@id_state AND is_accept = 1)
	 BEGIN
		DECLARE @id_vacancy INT, @id_selection int
		SELECT @id_vacancy = id_vacancy FROM recruit_selections WHERE id=@id

		--Отклоняем все открытые резюме по данной вакансии кроме утвержденной
		DECLARE sel_curs CURSOR FOR
		SELECT id from recruit_selections WHERE enabled=1 and id_vacancy = @id_vacancy AND id != @id

		OPEN sel_curs   
			FETCH NEXT FROM sel_curs INTO @id_selection   

			WHILE @@FETCH_STATUS = 0   
			BEGIN   
				   EXEC dbo.recruit_selection_set_state @id = @id_selection,
					   @state_sys_name = N'CANCEL',
					   @creator_sid = @creator_sid, -- varchar(46)
					   @descr = N'Утвержден другой кандидат' -- nvarchar(max)       

				   FETCH NEXT FROM sel_curs INTO @id_selection   
			END   

CLOSE sel_curs   
DEALLOCATE sel_curs

		--Закрываем заявку/вакансию
		EXEC recruit_vacancy_set_state @id=@id_vacancy, @state_sys_name='END', @creator_sid=@creator_sid
	 end

	 COMMIT TRAN
END TRY
BEGIN CATCH     
	 IF(@@TRANCOUNT > 0)
        ROLLBACK TRAN
		THROW
END CATCH
    
END

