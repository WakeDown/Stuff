-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE engeneer_state_get_prev_version
	@id int
AS
	begin set nocount on;

	select es_old.id, (select name from vendors v where v.id=es_old.id_vendor) as vendor_name , es_old.descr, es_old.date_end, 
	(select name from organizations o where o.id=es_old.id_organization) as organization_name, 
	(select name from languages l where l.id=es_old.id_language) as language, es_old.pic_data, es_old.creator_sid, es_old.name,
	es_old.engeneer_sid, e.name AS engeneer_name
from engeneer_states es 

INNER join engeneer_states es_old on es.id=es_old.old_id AND es_old.id = (SELECT MAX(id) FROM engeneer_states old WHERE old.old_id=@id)
INNER JOIN dbo.employees e ON e.ad_sid=es_old.engeneer_sid
where es.id=@id 

	end
