
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[recruit_selection_create] 
	@id_vacancy INT,
	@id_candidate INT,
	@creator_sid VARCHAR(46),
	@id_came_type int = null
AS
BEGIN
	SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM recruit_selections WITH(NOLOCK) WHERE enabled=1 AND id_vacancy=@id_vacancy AND id_candidate=@id_candidate)
	BEGIN
	--RAISERROR ('Указанное резюме уже существует в списке вакансии. Добавление отклонено.',16,1)
	--return
	;THROW 60000, 'Указанное резюме уже существует в списке вакансии. Добавление отклонено.', 1;
	END
	BEGIN TRY
	BEGIN TRAN selection
    DECLARE @id INT

	if  @id_came_type is null begin
	select top 1 @id_came_type = id from recruit_candidate_came_types where sys_name = 'LIST'
	end

	INSERT INTO recruit_selections (id_vacancy, id_candidate, creator_sid, id_came_type)
	VALUES (@id_vacancy, @id_candidate, @creator_sid, @id_came_type)
	SET @id = SCOPE_IDENTITY()

	EXEC recruit_selection_set_state @id=@id,@state_sys_name='NEW', @creator_sid=@creator_sid

	COMMIT TRAN selection
END TRY
BEGIN CATCH     
	 IF(@@TRANCOUNT > 0)
        ROLLBACK TRAN selection;
		THROW
END CATCH
		   SELECT @id AS id

END

