-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[statement_printed_get_list]
	@employee_sid VARCHAR(46)=null
AS
BEGIN
	SET NOCOUNT ON;

    SELECT  sp.id
      ,sp.id_statement_type
	  ,styp.name AS statement_type_name
	  ,styp.sys_name AS statement_type_sys_name
      ,employee_sid
	  ,e_emp.display_name AS employee_display_name
      ,date_begin
      ,date_end
      ,duration_hours
      ,duration_days
      ,cause
      ,sp.id_department
      ,sp.id_organization
      ,sp.dattim1 AS date_create
      ,sp.creator_sid
      ,sp.deleter_sid
      ,confirmed
      ,date_confirm
      ,confirmator_sid 
	FROM dbo.statement_printed sp
	LEFT JOIN dbo.employees e_emp ON sp.employee_sid = e_emp.ad_sid
	LEFT JOIN dbo.statement_types styp ON sp.id_statement_type = styp.id
	WHERE sp.enabled=1 AND confirmed = 1
	AND (@employee_sid IS NULL OR @employee_sid = '' OR (@employee_sid IS NOT NULL AND @employee_sid != '' AND employee_sid=@employee_sid))
END
