-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[engeneer_state_get_list]	
AS
BEGIN
	SET NOCOUNT ON;

    select es.id,  v.name as vendor_name, es.descr, date_end, o.name as organization_name, l.name as language, pic_data, es.name, engeneer_sid, e.display_name AS engeneer_name
	from engeneer_states es 
	INNER JOIN dbo.employees e ON e.ad_Sid=es.engeneer_sid
	inner join vendors v on v.id=es.id_vendor
	inner join organizations o on o.id=es.id_organization
	inner join languages l on l.id=es.id_language
	where es.enabled=1	
	order by v.name
END
