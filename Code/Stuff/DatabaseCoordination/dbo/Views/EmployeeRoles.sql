CREATE VIEW [EmployeeRoles]
AS
SELECT
	[Id],
	[Name],
	[EmployeeId],
	[Enabled]
	FROM [$(StuffDB)].[dbo].[EmployeeRoles]