CREATE VIEW [EmployeeRoles]
AS
SELECT
	[Id],
	[Name],
	[EmployeeSid],
	[Enabled]
	FROM [$(StuffDB)].[dbo].[employeeRoles]