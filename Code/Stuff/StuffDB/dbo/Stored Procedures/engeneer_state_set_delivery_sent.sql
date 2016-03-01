-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE engeneer_state_set_delivery_sent
	@id int,
	@new bit = 0,
	@expired bit = 0,
	@updated bit = 0
AS
begin
if @expired=1 
begin
update engeneer_states
set expired_delivery_sent=1
where id=@id
end
else
if @new = 1
begin
update engeneer_states
set new_delivery_sent=1
where id=@id
end
else
if @updated = 1
begin
update engeneer_states
set update_delivery_sent=1
where id=@id
end
END
