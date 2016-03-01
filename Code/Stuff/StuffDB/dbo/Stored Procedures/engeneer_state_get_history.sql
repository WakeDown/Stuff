-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[engeneer_state_get_history]
	@id int
AS begin
set nocount on;
	select  es.id,  v.name as vendor_name, es.descr, date_end, o.name as organization_name, l.name as language, pic_data, 
	(select display_name FROM dbo.employees e WHERE e.ad_sid= es.creator_sid) AS creator, es.dattim1 AS date_create, es.name, engeneer_sid, e.display_name AS engeneer_name
	from engeneer_states es 
	INNER JOIN dbo.employees e ON e.ad_Sid=es.engeneer_sid
	inner join vendors v on v.id=es.id_vendor
	inner join organizations o on o.id=es.id_organization
	inner join languages l on l.id=es.id_language
	where es.id=@id or old_id =@id
	order by es.dattim2 desc
END
