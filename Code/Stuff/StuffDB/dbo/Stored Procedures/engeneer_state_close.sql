-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE engeneer_state_close
@id int,
	@deleter_sid varchar(46)
	as begin
	set nocount on;
	update engeneer_states
	set enabled = 0, dattim2 = getdate(), deleter_sid = @deleter_sid
	where id=@id
	end