CREATE VIEW [EmployeeRoles]
AS
SELECT
	[Id],
	[Name],
	[EmployeeId]
	FROM [Stuff].[dbo].[EmployeeRoles]
	WHERE [Enabled] = 1