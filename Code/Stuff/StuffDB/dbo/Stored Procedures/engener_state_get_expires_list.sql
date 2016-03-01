-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE engener_state_get_expires_list
@expires bit = 0,
@newbie bit = 0,
@updated bit = 0
	AS begin
set nocount on;
if @expires = 1
begin
	select vs.id,  v.name as vendor_name, vs.descr, date_end, o.name as organization_name, l.name as language, pic_data, vs.name
	, engeneer_sid, e.name AS engeneer_name
	from engeneer_states vs 
	INNER JOIN dbo.employees e ON e.ad_Sid=vs.engeneer_sid
	inner join vendors v on v.id=vs.id_vendor
	inner join organizations o on o.id=vs.id_organization
	inner join languages l on l.id=vs.id_language
	where vs.enabled=1 and convert(date,date_end) <= convert(date,dateadd(month, 2, getdate())) and expired_delivery_sent = 0 
	end
	else if @newbie = 1
	begin
	select vs.id,  v.name as vendor_name, vs.descr, date_end, o.name as organization_name, l.name as language, pic_data, vs.name
	, engeneer_sid, e.name AS engeneer_name
	from engeneer_states vs 
	INNER JOIN dbo.employees e ON e.ad_Sid=vs.engeneer_sid
	inner join vendors v on v.id=vs.id_vendor
	inner join organizations o on o.id=vs.id_organization
	inner join languages l on l.id=vs.id_language
	where vs.enabled=1 and new_delivery_sent = 0 
	end
	else if @updated = 1
	begin
	select vs.id,  v.name as vendor_name, vs.descr, date_end, o.name as organization_name, l.name as language, pic_data, vs.name
	, engeneer_sid, e.name AS engeneer_name
	from engeneer_states vs 
	INNER JOIN dbo.employees e ON e.ad_Sid=vs.engeneer_sid
	inner join vendors v on v.id=vs.id_vendor
	inner join organizations o on o.id=vs.id_organization
	inner join languages l on l.id=vs.id_language
	where vs.enabled=1 and update_delivery_sent = 0 
	END
    end
