﻿
CREATE VIEW [dbo].[Employees] 
AS
SELECT 	
	[id],
	[ad_sid],
	[id_manager],
	[surname],
	[name],
	[patronymic],
	[full_name],
	[display_name],
	[id_position],
	[id_organization],
	[email],
	[work_num],
	[mobil_num],
	[id_emp_state],
	[id_department],
	[id_city],
	[enabled],
	[dattim1],
	[dattim2],
	[date_came],
	[birth_date],
	[male],
	[id_position_org],
	[hAS_ad_account],
	[creator_sid],
	[ad_login],
	[date_fired],
	[full_name_dat],
	[full_name_rod],
	[newvbie_delivery],
	[id_budget]
	FROM [$(StuffDB)].[dbo].[employees]