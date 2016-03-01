CREATE VIEW [EmployeeAlternates]
AS
SELECT 
	[Id],
	[EmployeeSid],
	[AlternateEmployeeSid],
	[StartDate],
	[EndDate],
	[Notify],
	[Unlimited],
	[Enabled]
	FROM [$(StuffDB)].[dbo].[employeeAlternates]