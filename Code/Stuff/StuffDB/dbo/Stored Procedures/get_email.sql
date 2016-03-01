CREATE PROCEDURE [dbo].[get_email]
	@full_name nvarchar(150) = null,
	@sid varchar(46) = null
	as begin set nocount on;
	select top 1 email 
	from employees_view e 
	where (@full_name is null or @full_name ='' or (@full_name is not null and @full_name <> '' and e.full_name = @full_name))
	and (@sid is null or @sid ='' or (@sid is not null and @sid <> '' and e.ad_sid = @sid))
	UNION ALL
  SELECT ca.email COLLATE Cyrillic_General_CI_AS FROM Service.dbo.contractor_access ca
  WHERE ca.enabled=1  
  AND (@full_name is null or @full_name ='' or (@full_name is not null and @full_name <> '' and ca.name = @full_name))
	and (@sid is null or @sid ='' or (@sid is not null and @sid <> '' and ca.ad_sid = @sid))

	end;