-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE recruit_selection_clone_in_another_vacancy 
	@id INT,
	@id_vacancy INT,
	@creator_sid VARCHAR(46)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO recruit_selections (id_candidate,  id_vacancy, creator_sid, id_state, state_change_date, state_changer_sid,state_descr)
    SELECT id_candidate,  @id_vacancy, @creator_sid, id_state, state_change_date, state_changer_sid,state_descr
	FROM dbo.recruit_selections
	WHERE id=@id
END
