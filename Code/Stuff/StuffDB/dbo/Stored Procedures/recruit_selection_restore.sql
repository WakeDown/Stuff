

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[recruit_selection_restore]
	@id INT,
	@creator_sid VARCHAR(46),
	@descr NVARCHAR(MAX) = NULL
AS
BEGIN
	SET NOCOUNT ON;

	BEGIN TRY
	BEGIN TRAN

	declare @id_state int
	SELECT TOP 1 @id_state = id FROM recruit_selection_states WHERE enabled=1 AND sys_name = 'RESTORE'
    
     UPDATE recruit_selections
	 SET id_state = @id_state, state_change_date = GETDATE(), state_changer_sid = @creator_sid, state_descr=@descr
	 WHERE id=@id

	 INSERT INTO recruit_selection_state_history (id_selection, id_state, creator_sid, descr)
	 VALUES (@id, @id_state, @creator_sid, @descr)

	 set @id_state = null

	 SELECT TOP 1 @id_state = s.id 
	 FROM recruit_selection_state_history h inner join recruit_selection_states s on h.id_state=s.id 
	 WHERE id_selection=@id and s.order_num > 0 order by h.id desc
    
	 if @id_state > 0
	 begin
		 UPDATE recruit_selections
		 SET id_state = @id_state, state_change_date = GETDATE(), state_changer_sid = @creator_sid, state_descr=@descr
		 WHERE id=@id

		 --INSERT INTO recruit_selection_state_history (id_selection, id_state, creator_sid, descr)
		 --VALUES (@id, @id_state, @creator_sid, @descr)
	 end
	 COMMIT TRAN
END TRY
BEGIN CATCH     
	 IF(@@TRANCOUNT > 0)
        ROLLBACK TRAN
		THROW
END CATCH
    
END


